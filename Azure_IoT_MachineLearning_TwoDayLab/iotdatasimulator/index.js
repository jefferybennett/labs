var term = require('terminal-kit').terminal;
var async = require('async');
var iotDeviceClient = require('./iotdevice.js');
var iotHubClient = require('./iothub.js');

const FLOW_ENTERDEVICE = 0;
const FLOW_LISTDEVICES = 1
const FLOW_SENDDATA = 2;
const FLOW_EXIT = 3;

var connectionInformation = {hostName:"",deviceId:"",primaryKey:"",connectionString:""};
var progressBar, progress = 0;
var startPayload = {deviceId:"",t1:42.34,t2:65.34,frequency:133.23,pressure:120.34};
var lastPayload = null;
var upCount = 0, downCount = 0, spikeCount = 0;

term.on('key', function( name , matches , data ) {
	if (name === 'CTRL_C') {
		term.clear();
		console.log("Simulator terminated manually via <CTRL - C>");
		process.exit(); 
	}
}) ;

async.forever(
    function(next) {
		try {
			mainFlow(next);
		}
		catch (err) {
			term.clear();
			term.red("The following error occurred: " + err);
		}
	},
    function(err) {
		term.clear();
        term.red("Error occurred: " + err);
		process.exit();
    }
);

function mainFlow(next) {
	menu(function(err, nextstep) {
		if (err) next(err);
		switch(nextstep) {
			case FLOW_ENTERDEVICE:
				enterDeviceData(function(err) {
					if (err) next(err);
					term.clear();
					term.green("Device Connection Information Completed!");
					setTimeout(function() {
						next(null);
					}, 1000);
				});
				break;
			case FLOW_LISTDEVICES:
				listDevices(function(err) {
					if (err) next(err);
					term.clear();
					term.green("Device Selected!");
					setTimeout(function() {
						next(null);
					}, 1000);
				})
				break;
			case FLOW_SENDDATA:
				sendData(function() {
					if (err) next(err);
					term.clear();
					term.green("Send Simulated Process has Completed!");
					setTimeout(function() {
						next(null);
					}, 1000);
				});
				break;
			case FLOW_EXIT:
				term.clear();
				process.exit();
				break;
		}
	});
}

function menu(callback) {

	term.clear();

	var items = [ 'Enter Device Info', 'List Devices', 'Send Simulated Data', 'Exit' ] ;

	var options = {
		y: 1 ,	// the menu will be on the top of the terminal
		style: term.inverse ,
		selectedStyle: term.dim.blue.bgGreen
	} ;

	term.singleLineMenu( items , options , function( error , response ) {
		callback(null, response.selectedIndex);
	});

}

function enterDeviceData(cb) {

	term.clear();
	term.insertLine(1);

	async.waterfall([
		function(callback) {
			getInput("Enter the Azure IoT Hub HostName: ", "hostName", function(err) {
				if (err) callback(err);
				callback(null);
			});
		},
		function(callback) {
			getInput("Enter the Device ID: ", "deviceId", function(err) {
				if (err) callback(err);
				callback(null);
			});
		},
		function(callback) {
			getInput("Enter the Device's Primary Key: ", "primaryKey", function(err) {
				if (err) callback(err);
				callback(null);
			});
		},
	], function (err, result) {
		if (err) cb(err);
		cb(null);
	});

}

function getInput(question, index, callback) {
	term.white(question);
	term.inputField(
		function(err, input) {
			if (err) callback(err);
			connectionInformation[index]= input;
			term.clear();
			term.insertLine(1);
			callback(null);
		}
	);
}

function listDevices(cb) {

	var registeredDevices = [], deviceIds = [];
	var selectedDeviceId = "";
	var iotHub;

	async.waterfall([
		function(callback) {
			term.clear();
			term.insertLine(1);
			term.white("Enter the IoT Hub iothubowner policy connection string: ");
			term.inputField(
				function(err, input) {
					if (err) callback(err);
					connectionInformation.connectionString = input;
					term.clear();
					term.insertLine(1);
					callback(null);
				}
			);
		},
		function(callback) {
			iotHub = new iotHubClient(connectionInformation.connectionString);
			iotHub.listDevices(function(err, devices) {
				if (err) callback(err);
				registeredDevices = devices;
				deviceIds = devices.map(function(obj) {
					return obj["deviceId"];
				})
				callback(null);
			});
		},
		function(callback) {

			term.clear();
			term.insertLine(1);
			term( 'Select a device: ' ) ;

			term.inputField(
				{ history: deviceIds , autoComplete: deviceIds, autoCompleteMenu: true } ,
				function( err , input ) {
					if (err) callback(err);
					selectedDeviceId = input;
					callback(null);
				}
			) ;

		},
		function(callback) {
			iotHub.getDevice(selectedDeviceId, function(err, device) {
				if (err) callback(err);
				connectionInformation.deviceId = selectedDeviceId;
				connectionInformation.hostName = connectionInformation.connectionString.split(';')[0].split('=')[1];
				connectionInformation.primaryKey = device.authentication.SymmetricKey.primaryKey
				callback(null);
			});
		}
	], function (err, result) {
		if (err) cb(err);
		cb(null);
	});

}

function sendData(cb) {

	//for testing
	if (connectionInformation.deviceId == "") {
		console.insertLine(1);
		console.red("No device information entered. Using TEST device for simulation.")
		connectionInformation.hostName = "";
		connectionInformation.deviceId = "";
		connectionInformation.primaryKey = "";
	}

	var iotDevice = new iotDeviceClient(connectionInformation.deviceId, connectionInformation.hostName, connectionInformation.primaryKey);
	const items = 600;
	var progress = 0;

	term.clear();

	progressBar = term.progressBar( {
		width: 80,
		title: 'Sending data for ' + connectionInformation.deviceId,
		eta: true,
		percent: true
	} ) ;

	async.whilst(
		function() {
			return progress < items;
		},
		function(callback) {
			setTimeout(function() {
				var data = randomPayload(connectionInformation.deviceId);
				iotDevice.sendTelemetry(JSON.stringify(data), function(err, res) {
					if (err) callback(err);
					progress++;
					if (progress <= items) callback(null);
					progressBar.update(progress / items);
				});
			}, 1000);
		},
		function(err){
			if(err) cb(err);
			cb(null);
		}	

	);

}

function randomPayload(deviceId) {
	var returnPayload;
	var t1, t2, frequency, pressure;

	if (lastPayload == null) { lastPayload = startPayload };

	if (spikeCount == 60) {
		t1 = getRandom(lastPayload.t1, lastPayload.t1 + 60.24);
		t2 = getRandom(lastPayload.t2, lastPayload.t2 + 50.23);
		frequency = getRandom(lastPayload.frequency, lastPayload.frequency + 100.53);
		pressure = getRandom(lastPayload.pressure, lastPayload.pressure + 150.96);
		spikeCount = 0;
		returnPayload = {deviceId:deviceId,t1:t1,t2:t2,frequency:frequency,pressure:pressure};
		lastPayload = null;
		return returnPayload;
	} else { spikeCount++; }

	if (upCount > 10) {
		t1 = getRandom(lastPayload.t1, lastPayload.t1 + 3.23);
		t2 = getRandom(lastPayload.t2, lastPayload.t2 + 4.69);
		frequency = getRandom(lastPayload.frequency, lastPayload.frequency + 5.99);
		pressure = getRandom(lastPayload.pressure, lastPayload.pressure + 6.34);
		if (upCount > 20) { upCount = 0; }
		lastPayload = {deviceId:deviceId,t1:t1,t2:t2,frequency:frequency,pressure:pressure};
		return lastPayload;
	} else { upCount++; }

	t1 = getRandom(lastPayload.t1 - 3.34, lastPayload.t1);
	t2 = getRandom(lastPayload.t2 - 4.64, lastPayload.t2);
	frequency = getRandom(lastPayload.frequency - 5.38, lastPayload.frequency);
	pressure = getRandom(lastPayload.pressure - 6.28, lastPayload.pressure);
	lastPayload = {deviceId:deviceId,t1:t1,t2:t2,frequency:frequency,pressure:pressure};
	return lastPayload;
}

function getRandom(min, max) {
  return parseFloat((Math.round(Math.random() * (max - min)) + min).toFixed(2));
}

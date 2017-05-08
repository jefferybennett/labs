'use strict';

var Protocol = require('azure-iot-device-mqtt').Mqtt;
// Uncomment one of these transports and then change it in fromConnectionString to test other transports
// var Protocol = require('azure-iot-device-amqp').AmqpWs;
//var Protocol = require('azure-iot-device-http').Http;
//var Protocol = require('azure-iot-device-amqp').Amqp;
//var Protocol = require('azure-iot-device-mqtt').MqttWs;
var Client = require('azure-iot-device').Client;
var Message = require('azure-iot-device').Message;

var iotHubClient = function(deviceId, hostName, primaryKey) {

    var connectionDeviceString = 'HostName='.concat(hostName, ';DeviceId=', deviceId, ';SharedAccessKey=', primaryKey);
    var client = Client.fromConnectionString(connectionDeviceString, Protocol);

    console.log(connectionDeviceString);

    var connectCallback = function (err) {
        if (err) {
            console.error('Could not connect: ' + err.message);
        } else {
            console.log('Client connected');
            /*
            client.on('message', function (msg) {
                console.log('Id: ' + msg.messageId + ' Body: ' + msg.data);
                // When using MQTT the following line is a no-op.
                client.complete(msg, function(err, res) {
                    if (err) console.log('Client complete error: ' + err.toString());
                    if (res) console.log('Client complete status: ' + res.constructor.name);
                });
            });

            client.on('error', function (err) {
                console.error("Client ON error: " + err.message);
            });

            client.on('disconnect', function () {
                client.removeAllListeners();
                client.open(connectCallback);
            });
            */
        }
    };

    client.open(connectCallback);

    return {
        sendTelemetry: function(data, callback) {

            var Message = require('azure-iot-device').Message;

            var message = new Message(data);
            console.log("Sending message: " + message.getData());
            client.sendEvent(message, callback);

        }
    }
}

module.exports = iotHubClient;









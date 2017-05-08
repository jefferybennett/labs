'use strict';

var iothub = require('azure-iothub');
var Protocol = require('azure-iot-device-mqtt').Mqtt;

var iotHubClient = function(connectionString) {

    var device = new iothub.Device(null);
    var hostName = connectionString.split(';')[0].split('=')[1];

    console.log(hostName);

    return {
        registerDevice: function(deviceToRegister, key, callback) {

            var registry = iothub.Registry.fromConnectionString(connectionString, Protocol);

            device.deviceId = deviceToRegister.deviceId;

            registry.create(device, function registryCreateHandler(err, deviceInfo, res) {
                if (err) {
                    registry.get(device.deviceId, function registryGetHandler(err, deviceInfo, res) {
                        if (deviceInfo) {
                            deviceToRegister.deviceKey = deviceInfo.authentication.SymmetricKey.primaryKey;
                            return callback(key, deviceInfo);
                        }
                        return callback();
                    });
                }
                else { 
                    return callback(key, deviceInfo);
                }
            });
        },
        registerAndSend: function(deviceName) {
            this.registerDevice(deviceName)
        },
        listDevices: function(callback) {

            var registry = iothub.Registry.fromConnectionString(connectionString, Protocol);

            registry.list(function listDevicesResponse(err, devices) {
                if (err) return callback(err);
                return callback(null, devices);
            })
        },
        getDevice: function(deviceId, callback) {
            var registry = iothub.Registry.fromConnectionString(connectionString, Protocol);

            registry.get(deviceId, function getDeviceResponse(err, device) {
                if (err) return callback(err);
                return callback(null, device);
            })
        }
    }
}

module.exports = iotHubClient;










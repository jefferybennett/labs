With RawTelemetryGroupedByMinute AS (
    SELECT
        DeviceId, 
        DateAdd(hour, -7, System.TimeStamp) as EventDateTime,
        Temperature1, 
        Temperature2,
        Pressure,
        Frequency,
        Latitude,
        Longitude
    FROM
        iothub TIMESTAMP BY EventProcessedUtcTime
),
Alarms AS (
    SELECT DeviceId, 'HighTemperatureAlarm' As AlarmType,
    CONCAT('High Temperature identified on Device ', DeviceId, ' over last 5 minutes.') as AlarmDetail,
    DateAdd(minute, -5, DateAdd(hour, -7, System.TimeStamp)) As WindowStart,
    DateAdd(hour, -7, System.TimeStamp) AS WindowEnd, COUNT(*) AS EventCount, 5 AS WindowDurationInMinutes
    FROM iothub TIMESTAMP BY EventProcessedUtcTime
    WHERE Temperature1 > 90
    GROUP BY DeviceId, TumblingWindow(Duration(minute, 5)) 
    HAVING EventCount > 1
)

select * into powerbi from RawTelemetryGroupedByMinute
select * into docdbTelemetry from RawTelemetryGroupedByMinute
select * into docdbAlarms from Alarms
# Azure IoT BR Lab: IoT Telemetry, Commands, Stream Analytics, Power BI and Business Events / Notifications

## Before Starting

### Azure Environment and Subscription

You'll need an active Azure tenant with an enabled Azure subscription.  It's good practice to create the Azure services for this tutorial
in a single resource group.

### Software Requirements

- The Power BI Desktop app is optional. This tutorial, however, will show how dashboards and reports can be created
within the Power BI web portal. You can download it [here](https://www.microsoft.com/en-us/download/details.aspx?id=45331).

## Create the Azure Resource Group
Azure Resource Group's provide a number of useful capabilities. One of the primary is to organize your Azure service instances into
logical groups. Creating a single Resource Group that you'll use for this effort will prove very valuable.

- In the [Azure Management Portal](https://portal.azure.com):
    - Click the +New icon in the upper left corner.
    - Enter the search term 'Resource' in the search field. The option 'Resource Group' should immediately appear.
    - Then select Resource Group in the search listing and the Create button in the next blade.
    - In the Create Resource Group blade, complete the following fields:
        - Resource group name: Provide a name for your resource group. Pick a name that appropriately describes the purpose of
        resource group which you'll easily remember. For the lab, adding your name is good practice.
        - Subscription: Ensure the correct Azure subscription is selected.
        - Resource group location: Ensure the correct Azure DataCenter location is selected.
        - Click the Create button.

As you add additional Azure services, it's often easiest to simply add them directly from the Resource Group using the
Add button at the top of your Resource Group blade.

## Use the Azure IoT Suite Remote Monitoring Solution to Register your Device
Registering a device is the first step for it to begin securely communicating with Microsoft Azure.  Each device is
uniquely authenticated with Azure via the IoT Hub.

- In another browser window, open [Azure IoT Suite.com](https://azureiotsuite.com).
- Under the running Remote Monitoring instance, click the Launch button.
- In the Remote Monitoring portal, click on the "Add a Device" icon in the lower left-hand corner.
- Under Custom Device, click the Add New button.
- Select the option "Let me define my own Device ID", enter a value for your device, and click the Check ID button.
- Click the Create button to register your device.
- Record the DeviceId, IoT Hostname, and Device Key somewhere you won't lose it!
- Click the Devices icon on the upper left-hand menu under the Dashboard icon.
- Find your device in the All Devices list and click it.
- In the Device Details right-side menu, click "Enable Device".

## Install and Run the BR Data Simulator
- Acquire and install the BR Data Simulator from your incredibly cool Microsoft IoT Hackathon instructor.
- Find the shortcut "BRDataSimulator" now on your Desktop.

## Use the Azure IoT Device Explorer to monitor data coming from your Device

- Download and install the [Azure IoT Device Explorer](https://github.com/Azure/azure-iot-sdks/releases/download/2016-11-17/SetupDeviceExplorer.msi)
- Open the Device Explorer.
- In your IoT Hub's blade in the Azure Management Portal, click the Shared Access Policies tab.
- Click the "iothubowner" policy.
- Copy the primary Connection string.
- Paste the connection string in the IoT Hub Connection String field on the Configuration tab of the Device Explorer
and click the Update button.
- Click the Data tab.
- Select your device in the Device ID dropdown, click the Enable checkbox next to Consumer Group and enter your first name.
(A consumer group using your first name will have been pre-created)

## Create the Azure Stream Analytics Job

### Create the Job
- Add a Stream Analytics job to your resource group, using the following selections:
    - Job name: Provide a name for the Stream Analytics job.
    - Region: Select the appropriate Microsoft Data Center location.
    - Regional Monitoring Storage Account: Depending upon your selected region, you'll be able to select a storage account
    for Stream Analytics to store service monitoring data. It's ok if this isn't available in your region.
- Click the Create button to create the job.

The job will take a few minutes to deploy, after which you can select it your list of Stream Analytics jobs by clicking
the arrow next to its name.

### Add an input
- After selecting the job in Stream Analytics list, select Inputs.
- Click the Add Input icon in the bottom menu.
- In the Add an Input dialog, complete the following:
    - Select Data Stream and click the right arrow.
    - Select IoT Hub and click the right arrow.
    - In IoT Hub settings, complete the following fields:
        - Input Alias: Provide an alias for your input which you'll use to refer to it in your query.
        - Subscription: Select the appropriate Azure subscription.
        - Choose an IoT Hub: You should be able to select from a dropdown of existing IoT Hub instances. This will
        then provide default values for the remaining fields.
    - Click the right arrow.
    - Review serialization settings and click the complete checkmark icon.

### Adding Outputs
To add Ouputs to your Stream Analytics job, you'll need to be in the Job and then click Outputs.

#### Add the Power BI Output
The following documentation can assist in leveraging Stream Analytics with Power BI,
located [here](https://docs.microsoft.com/en-us/azure/stream-analytics/stream-analytics-power-bi-dashboard).

- In the bottom menu, click the Add Output icon.
- Select Power BI, and click the right arrow icon.
- In Authorize Connection, click the Authorize Now link and enter the credentials for the Office 365 account you wish
to use for Power BI. Ensure you click the Sign-In button and that your credentials are successfully authorized and accepted.
- In Microsoft Power BI Settings, complete the following fields:
    - Output alias: Provide an alias for your output which you'll use to refer to it in your query.
    - Dataset name: Provide a name of your dataset to be created in Power BI.
    - Table name: Provide a name of your table to be created in the dataset.
    - Workspace: Select the workspace in Power BI where the dataset and table will be created.
    - Click the checkmark icon to complete.

#### Add the Service Bus Output
- In the bottom menu, click the Add Output icon.
- Select Service Bus Topic, and click the right arrow icon.
- In Topic Settings, complete the following fields:
    - Output alias: Provide an alias for your output which you'll use to refer to it in your query.
    - Subscription: Select the appropriate Azure subscription.
    - Choose a Namespace: After selecting the Azure subscription, you should receive a dropdown of existing namespaces
    to select from. Select the correct namespace you created earlier for this purpose.
    - Choose a Topic: Select the existing Topic associated to the selected namespace.
    - Topic Policy Name: This value should have a default value.
- Review Serialization Settings and click the checkmark icon to complete.

#### Add the first DocumentDb Output (Raw Telemetry)


#### Add the second DocumentDb Output (Alarms)

### Write the Query
To write/edit your query, you'll need to be in the Stream Analytics Job and then click Query. While you can certainly use
the Management Portal query window to write and edit your query, I find it a best practice to leverage a tool like
[Visual Code](https://code.visualstudio.com) to write your query first, especially because I can leverage a source control
platform like GitHub to place it under source control.

Here's a sample query that leverages all three outputs described in this lab:

```sql
With RawTelemetryGroupedByMinute AS (
    SELECT
        DeviceId, 
        DateAdd(hour, -7, System.TimeStamp) as EventDateTime,
        Avg(Temperature) As Temperature, 
        Avg(Humidity) As Pressure
    FROM
        iothub TIMESTAMP BY EventProcessedUtcTime  
    Group By DeviceId, TumblingWindow(minute, 1)
),
Alarms AS (
    SELECT DeviceId, 'HighTemperatureAlarm' As AlarmType,
    CONCAT('High Temperature identified on Device ', DeviceId, ' over last 10 minutes.') as AlarmDetail,
    DateAdd(minute, -10, DateAdd(hour, -7, System.TimeStamp)) As WindowStart,
    DateAdd(hour, -7, System.TimeStamp) AS WindowEnd, COUNT(*) AS EventCount, 10 AS WindowDurationInMinutes
    FROM iothub TIMESTAMP BY EventProcessedUtcTime
    WHERE Temperature > 90
    GROUP BY DeviceId, TumblingWindow(Duration(minute, 10)) 
    HAVING EventCount > 2
)

select * into powerbi from RawTelemetryGroupedByMinute
select * into dobdbTelemetry from RawTelemetryGroupedByMinute
select * into docdbAlarms from Alarms
```

### Run the Job

## Create the Notification Flow

### Using Azure Logic Apps


#### Add the Service Bus Topic

```text
Endpoint=ENDPOINT;SharedAccessKeyName=SHAREDACCESSKEYNAME;SharedAccessKey=SHAREDACCESSKEY
```

So, an example connection string would look like this ...

```text
Endpoint=sb://sbtesting.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=UwMUwwvFsDQ6DCHUEYXFAqtivqJ2e1Rqy21hqZCPPSY=
```
***
**NOTE**: Make sure that the connection string is in one line (i.e. has no carriage returns) when you paste it in.
***



    

## Create a Power BI Dashboard and Report

https://briotdemo.documents.azure.com:443/

zSgXIflXje6qPsqFyRHeaDIynM6AGkyA97yEzKqA4vtKmGQYhfhn6JZgUxPYz4S0GlToKbRWOyJX3EOzWDFQgA==

```sql
SELECT c.deviceid, c.eventdatetime, c.temperature1, c.temperature2, c.pressure, c.frequency, c.latitude, c.longitude FROM c
```
# Azure Iot Alarms, Notifications and Power BI Lab

The following lab will take you through the steps of connecting
[Azure IoT Hub](https://azure.microsoft.com/en-us/documentation/services/iot-hub/) D2C (Device to Cloud) telemetry to Notifications
sent out through either [Azure Logic Apps](https://azure.microsoft.com/en-us/documentation/articles/app-service-logic-what-are-logic-apps/) or 
[Microsoft Flow](https://flow.microsoft.com). We'll leverage [Azure Stream Analytics](https://azure.microsoft.com/en-us/services/stream-analytics/) 
and [Azure Service Bus](https://azure.microsoft.com/en-us/services/service-bus/) to
connect the IoT Hub telemetry to Logic Apps or Flow. You'll also persist data from Stream Analytics into
[Azure SQL](https://azure.microsoft.com/en-us/services/sql-database/). Finally, you'll leverage
[Power BI](https://powerbi.microsoft.com/en-us/) to display both real-time and historical data.

## Table of Contents

- [1.1 Tutorial Overview](#11-tutorial-overview)
- [1.2 Before Starting](#12-before-starting)
    - [1.2.1 Azure Environment and Subscription](#121-azure-environment-and-subscription)
    - [1.2.2 Microsoft Flow](#122-microsoft-flow)
    - [1.2.3 Software Requirements](#123-software-requirements)
- [1.3 Create the Azure Resource Group](#13-create-the-azure-resource-group)
- [1.4 Create the Azure IoT Hub instance](#14-create-the-azure-iot-hub-instance)
- [1.5 Create the Azure Service Bus Topic](#15-create-the-azure-service-bus-topic)
- [1.6 Create the Azure SQL Database](#16-create-the-azure-sql-database)
    - [1.6.1 Creating the Azure SQL Server and Database](#161-creating-the-azure-sql-server-and-database)
    - [1.6.2 Create the Azure SQL table to persist your IoT telemetry](#162-create-the-azure-sql-table-to-persist-your-iot-telemetry)
- [1.7 Create the Azure Stream Analytics Job](#17-create-the-azure-stream-analytics-job)
    - [1.7.1 Create the Job](#171-create-the-job)
    - [1.7.2 Add an Input](#172-add-an-input)
    - [1.7.3 Adding Outputs](#173-adding-outputs)
        - [1.7.3.1 Add the Power BI Output](#1731-add-the-power-bi-output)
        - [1.7.3.2 Add the Service Bus Output](#1732-add-service-bus-output)
        - [1.7.3.3 Add the Azure SQL Output](#1733-add-the-azure-sql-output)
    - [1.7.4 Write the Query](#174-write-the-query)
    - [1.7.5 Run the Job](#175-run-the-job)
- [1.8 Create Notification Flow](#18-create-the-notification-flow)
    - [1.8.1 Using Azure Logic Apps](#181-using-azure-logic-apps)
    - [1.8.2 Using Microsoft Flow](#182-using-microsoft-flow)
- [1.9 Create a Power BI Dashboard and Report](#19-create-a-power-bi-dashboard-and-report)

## 1.1 Tutorial Overview

In this tutorial, you'll be doing the following:
- Creating an Azure Service Bus namespace and topic.
- Creating an Azure Stream Analytics job, leveraging Azure IoT Hub as an input and the Service Bus topic as an output.
- Using Azure Logic Apps or Microsoft Flow to accept the message from Stream Analytics and notify an user of it.
- Peristing streaming data into Azure SQL
- Creating a Power BI dashboard leveraging both real-time and historical data

## 1.2 Before Starting

### 1.2.1 Azure Environment and Subscription

You'll need an active Azure tenant with an enabled Azure subscription.  It's good practice to create the Azure services for this tutorial
in a single resource group.

### 1.2.2 Microsoft Flow

Microsoft Flow is a new service from Microsoft designed to enable individuals and businesses to automate tasks by integrating 
various kinds of other apps with Microsoft Flow. Currently (as of August 2016), Microsoft Flow is in preview and free. This 
may change once Microsoft Flow is no longer in preview.

Microsoft Flow is a good option for external business partners who are not using Microsoft Azure, and are unable to use Azure
Logic Apps.

### 1.2.3 Software Requirements

- To create the Azure SQL table for historical data storage, you'll need [Visual Studio](https://www.visualstudio.com/en-us/visual-studio-homepage-vs.aspx)
and the SQL Data Explorer add-in for Visual Studio, or the [SQL Management Studio](https://msdn.microsoft.com/en-us/library/mt238290.aspx).
If you're a Visual Studio user and don't plan to leverage its many other development capabilities, SQL Management Studio
is a simpler tool to leverage. I recommend it even if you're using Visual Studio as well.
- The Power BI Desktop app is optional. This tutorial, however, will show how dashboards and reports can be created
within the Power BI web portal.

## 1.3 Create the Azure Resource Group
Azure Resource Group's provide a number of useful capabilities. One of the primary is to organize your Azure service instances into
logical groups. Creating a single Resource Group that you'll use for this effort will prove very valuable.

- In the [Azure Management Portal](https://portal.azure.com):
    - Click the +New icon in the upper left corner.
    - Enter the search term 'Resource' in the search field. The option 'Resource Group' should immediately appear.
    - Then select Resource Group in the search listing and the Create button in the next blade.
    - In the Create Resource Group blade, complete the following fields:
        - Resource group name: Provide a name for your resource group. Pick a name that appropriately describes the purpose of
        resource group which you'll easily remember.
        - Subscription: Ensure the correct Azure subscription is selected.
        - Resource group location: Ensure the correct Azure DataCenter location is selected.
        - Click the Create button.

As you add additional Azure services, it's often easiest to simply add them directly from the Resource Group using the
Add button at the top of your Resource Group blade.

## 1.4 Create the Azure IoT Hub instance
If you've not already provisioned an instance of the Azure IoT Hub that you can leverage for this purpose, go ahead and do so.

- - In the [Azure Management Portal](https://portal.azure.com):
    - Click the +New icon in the upper left corner.
    - Enter the search term 'IoT' in the search field. The option 'IoT Hub' should immediately appear.
    - Then select IoT Hub in the search listing and the Create button in the next blade.
    - In the Create IoT Hub blade, complete the following fields:
        - Name: Enter a unique name for your IoT Hub instance. The name must be between 3 and 50 characters long, contain
        only alphanumeric characters (or a hyphen "-"), and not have been registered by anyone else.
        - Pricing and scale tier: You can currently select one of four tiers: Free, S1, S2, and S3. You can only have one
        free instance of the IoT Hub per Azure tenant. The Free hub provides for only 8k messages /day, and is typically
        useful only for initial development testing. If you plan to do potentially more than 8k messages /day, the
        S1 tier is a good choice as it provides for 400k messages /day and is $50 /month. If the IoT Hub instance you're
        creating will be used for production purposes, carefully review your scale and pricing options, and contact your
        Microsoft account team for assistance (if needed).
        - IoT Hub units: Default is 1. For testing purposes, this is typically sufficient.
        - Device-to-cloud partitions: 4 partitions is the default, and typically sufficient for testing.
        - Subscription: Make sure the correct Azure subscription is selected.
        - Resource Group: If not selected, select the Resource Group you created in step 1.3.
        - Enable Device Management - PREVIEW: If you wish to leverage the new device management capabilities in Azure
        IoT hub, check the box. However, please note that currently this will limit which Microsoft DataCenter locations
        you can select for your IoT Hub instance.
        - Location: Select the appropriate Microsoft Data Center location.
        - Click the Create button.

## 1.5 Create the Azure Service Bus Topic
(Currently, this is easiest to accomplish in the old [Azure Management Portal](https://manage.windowsazure.com))

- From the left-side menu, click Service Bus (which is eleventh from the top of this menu).
- Add the bottom menu, click the Create icon.
- In the Create a Namespace dialog, complete the following fields:
    - Namespace Name: Enter a name for your namespace, following the rules given in the field.
    - Type: Ensure Messaging is selected.
    - Messaging Tier: Basic or Standard for testing purposes is typically sufficient.
    - Region: Select the Microsoft Data Center location most closest to you.
    - Click the checkmark arrow in the lower right hand corner of the dialog.
- After the service bus namespace has completed activating, select its row in the service bus listing, and click
the right arrow next to its name. Then click Topics.
- Create the Create a new Topic link.
- At Service Bus > Topic select Quick Create, and complete the following fields:
    - Topic Name: Enter a relevant topic name, such as, for example, "Alarms" (assuming that's appropriate for your purposes).
    - Region Name: Select teh appropriate Microsoft Data Center location.
    - Namespace: The correct service bus namespace (that you just created) should already be selected by default.
    - Click the checkbox icon to create the topic.
- After the topic is created, we'll next add a subscription to it. Next to the new topic, click the right arrow link.
- Now in the newly created Topic, click Subscriptions.
- Click the Create a New Subscription link.
- In the Add a new subscription dialog, enter a subscription name, and click the right arrow.
- Review default subscription settings, and click the checkmark icon to complete.

## 1.6 Create the Azure SQL Database

#### 1.6.1. Creating the Azure SQL Server and Database
If you've not already done so, you'll need to create the Azure SQL instance.

- In the Azure Portal, click the + New button > Data + Storage and select **SQL Database**.
- In the SQL Database blade, complete the required new database attributes:
    - Database name: Give the database a name you'll remember.
    - Subscription: Select the Azure subscription associated to the lab work you're completing.
    - Resource group: Select the existing resource group associated to the lab work you're completing.
    - Select source: Select 'Blank Database'.
    - Server: Click 'Configure Required Settings'.  In the New Server blade complete the following fields:
        - Server Name: Provide an unique server name.
        - Server admin login: Provide a admin login username (it can't be 'admin', or 'administrator', for example).
        - Password / Confirm Password: Enter an appropriate password and ensure you securely save it where you'll remember it.
        - Location: Select the Azure Data Center location that's appropriate for you.
        - Click the Select button.
    - Pricing tier: Select an appropriate pricing tier. For completing this lab, a S0 or S1 is more than sufficient.
    - Collation: Keep default value.
- Click the Create button

It'll take a few minutes for the Deployment process to complete.

- Once the Azure database has been created, open its blade.
- Click the link below the Server Name field which will take you to the Azure SQL Server blade for your database.
- Under Essentials, click the link below Firewall that says Show firewall settings.
- Click the Add client IP button. This will add your current IP address to server firewall approved list, enabling you to
connect to the database via Visual Studio or SQL Management Studio.

#### 1.6.2 Create the Azure SQL table to persist your IoT telemetry

(Use the [Azure Management Portal](https://portal.azure.com) for these steps.)

Use the following instructions if you plan to use Visual Studio. The instructions to leverage SQL Management Studio,
are below these.

**If using Visual Studio**
- Select the Azure SQL Database that you created.
- Near the top of the blade, click the Tools button.
- In the Tools blade, click Open in Visual Studio.
- Click the Open in Visual Studio button.
- Visual Studio should launch. In Visual Studio:
    - In the Connect dialog you should see the correct information entered for your Azure SQL instance, except for the password.
    - Password: enter your password for the Azure SQL server.
    - (You may be prompted to enter the credentials for your Azure environment and create a firewall rule for your computer)
    - In the SQL Server Object Explorer:
        - Click the node arrow next to your database to show the schema nodes under it (eg. Tables, Views, ...).
        - Right click the Tables node and select Add New Table ...
    - In the dbo.Table window which now opens, create the columns for your table.
        - **NOTE**: If you plan to create a query with a "SELECT *" clause, you'll need to know precisely the schema of your input telemetry
        in the Stream Analytics job. If your table schema does not match it (including the ordinal position of columns), the 
        Stream Analytics job will fail in persisting data to your SQL database.
    - In the T-SQL pane, you can update the table name from "Table1" to a more revelant name for you.
    - Click the Update button.
    - In the Preview Database Updates dialog window, review the summary and click the Update Database button if you're ready to create the table
    in the database.
    - The status of the update operation is displayed in the Data Tools Operations window.

**If using SQL Management Studio**
- In the Connect to Server dialog, enter values in the following fields:
    - Server type: Should be defaulted to Database Engine.
    - Server name: Enter the SQL Server server name. You'll be able to find this on the Azure SQL Database blade. It should
    follow this format: [server name].database.windows.net
    - Authentication:
        - Login: Enter the Azure SQL username you entered when first creating the Azure SQL database.
        - Password: Enter the associated password.
    - Click the connect button.
- In the Object Explorer window, expand the node under your database > Tables.
- Write-click the Tables node and select New > Table.
- In the dbo.Table window which now opens, create the columns for your table.
    - **NOTE**: If you plan to create a query with a "SELECT *" clause, you'll need to know precisely the schema of your input telemetry
        in the Stream Analytics job. If your table schema does not match it (including the ordinal position of columns), the 
        Stream Analytics job will fail in persisting data to your SQL database.
    - Click the Save button and enter the name that you'd like to call the table.

## 1.7 Create the Azure Stream Analytics Job
(Currently, these steps are easiest (and for Stream Analytics, best) to accomplish in the old 
[Azure Management Portal](https://manage.windowsazure.com))

### 1.7.1 Create the Job
- In the left hand menu, select Stream Analytics.
- In the lower left hand corner, click the +New icon.
- Select Stream Analytics > Quick Create and complete the following fields:
    - Job name: Provide a name for the Stream Analytics job.
    - Region: Select the appropriate Microsoft Data Center location.
    - Regional Monitoring Storage Account: Depending upon your selected region, you'll be able to select a storage account
    for Stream Analytics to store service monitoring data. It's ok if this isn't available in your region.
- Click the Create Stream Analytics job checkmark.

The job will take a few minutes to deploy, after which you can select it your list of Stream Analytics jobs by clicking
the arrow next to its name.

### 1.7.2 Add an input
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

### 1.7.3 Adding Outputs
To add Ouputs to your Stream Analytics job, you'll need to be in the Job and then click Outputs.

#### 1.7.3.1 Add the Power BI Output
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

#### 1.7.3.2 Add the Service Bus Output
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

#### 1.7.3.3 Add the Azure SQL Output
**TIP**: If you're unsure of the exact schema of input data from Azure IoT Hub, it's helpful to leverage Azure Stream Analytics to briefly
output telemetry to a BLOB container in Azure storage. This will enable you to see the schema and ensure your data output to Azure SQL
is mapped properly from your Azure Stream Analytics job. Additionally, this will provide you test data to test your Stream Analytics
query.
***

- Ensure the Stream Analytics job is not running. If it is, stop it.
- Under Outputs, click the Add an Output button.
- Select SQL Database and click the next arrow.
- In the Add a SQL Database page, complete the following fields:
    - Output alias: Enter a simple name for your output. You'll use this to reference the output in your query.
    - Subscription: Select the Azure subscription associated to the lab work you're completing.
    - Choose a Database: Select the Azure SQL Database you created for this purpose.
    - Server Name: [should be defaulted for you]
    - Username: Enter the username for the Azure SQL server.
    - Password: Enter the password for the Azure SQL server.

### 1.7.4 Write the Query
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
    Group By DeviceId, PumpNo, TumblingWindow(minute, 1)
),
Alarms AS (
    SELECT DeviceId, 'HighTemperatureAlarm' As AlarmType,
    CONCAT('High Temperature identified on Device ', DeviceId, ' [Pump #', PumpNo, '] over last 10 minutes.') as AlarmDetail,
    DateAdd(minute, -10, DateAdd(hour, -7, System.TimeStamp)) As WindowStart,
    DateAdd(hour, -7, System.TimeStamp) AS WindowEnd, COUNT(*) AS EventCount, 10 AS WindowDurationInMinutes
    FROM iothub TIMESTAMP BY EventProcessedUtcTime
    WHERE Temperature > 90
    GROUP BY DeviceId, TumblingWindow(Duration(minute, 10)) 
    HAVING EventCount > 2
)

select * into powerbi from RawTelemetryGroupedByMinute
select * into sql from RawTelemetryGroupedByMinute
select * into servicebusalarm from Alarms
```

### 1.7.5 Run the Job

## 1.8 Create the Notification Flow

### 1.8.1 Using Azure Logic Apps

### 1.8.2 Using Microsoft Flow

#### Create a new Flow

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



    

## 1.9 Create a Power BI Dashboard and Report
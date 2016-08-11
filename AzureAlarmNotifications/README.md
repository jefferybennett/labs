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
- [1.3 Create the Azure Service Bus Topic](#13-create-the-azure-service-bus-topic)
- [1.4 Create the Azure Stream Analytics Job](#14-create-the-azure-stream-analytics-job)
- [1.5 Create Notification Flow](#15-create-the-notification-flow)
    - [1.5.1 Using Azure Logic Apps](#151-using-azure-logic-apps)
    - [1.5.2 Using Microsoft Flow](#152-using-microsoft-flow)
- [1.6 Persist Streaming Data into Azure SQL](#16-persist-streaming-data-into-azure-sql)
- [1.7 Create a Power BI Dashboard and Report](#17-create-a-power-bi-dashboard-and-report)

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

- To create the Azure SQL table for historical data storage, you'll need Visual Studio.
- The Power BI Desktop app is optional. This tutorial, however, will show how dashboards and reports can be created
within the Power BI web portal.

## 1.3 Create the Azure Service Bus Topic

## 1.4 Create the Azure Stream Analytics Job

### Create the Job

### Add an input

### Add an output

### Write the Query

## 1.5 Create the Notification Flow

### 1.5.1 Using Azure Logic Apps

### 1.5.2 Using Microsoft Flow

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

## 1.6 Persist Streaming Data into Azure SQL

#### Create the Azure SQL instance
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

#### Create the Azure SQL table to persist your IoT telemetry

(Use the [Azure Management Portal](https://portal.azure.com) for these steps.)

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

#### Add Azure SQL as an output to an existing Stream Analytics Job
(Currently, this is easiest to accomplish in the old [Azure Management Portal](https://manage.windowsazure.com))

***
**TIP**: If you're unsure of the exact schema of input data from Azure IoT Hub, it's help to leverage Azure Stream Analytics to briefly
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

    

## 1.7 Create a Power BI Dashboard and Report
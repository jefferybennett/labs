# Azure Alarm Notification Lab

The following lab will take you through the steps of connecting
[Azure IoT Hub](https://azure.microsoft.com/en-us/documentation/services/iot-hub/) D2C (Device to Cloud) telemetry to Notifications
sent out through either [Azure Logic Apps](https://azure.microsoft.com/en-us/documentation/articles/app-service-logic-what-are-logic-apps/) or 
[Microsoft Flow](https://flow.microsoft.com). We'll leverage [Azure Stream Analytics](https://azure.microsoft.com/en-us/services/stream-analytics/) 
and [Azure Service Bus](https://azure.microsoft.com/en-us/services/service-bus/) to
connect the IoT Hub telemetry to Logic Apps or Flow.

## Table of Contents

- [1.1 Tutorial Overview](#11-tutorial-overview)
- [1.2 Before Starting](#12-before-starting)
    - [1.2.1 Azure Environment and Subscription](#121-azure-environment-and-subscription)
    - [1.2.2 Microsoft Flow](#122-microsoft-flow)
- [1.3 Create the Azure Service Bus Topic](#13-create-the-azure-service-bus-topic)
- [1.4 Create the Azure Stream Analytics Job](#14-create-the-azure-stream-analytics-job)
- [1.5 Create Notification Flow](#15-create-the-notification-flow)
    - [1.5.1 Using Azure Logic Apps](#151-using-azure-logic-apps)
    - [1.5.2 Using Microsoft Flow](#152-using-microsoft-flow)

## 1.1 Tutorial Overview

In this tutorial, you'll be doing the following:
- Creating an Azure Service Bus namespace and topic
- Creating an Azure Stream Analytics job, leveraging Azure IoT Hub as an input and the Service Bus topic as an output.
- Using Azure Logic Apps or Microsoft Flow to accept the message from Stream Analytics and notify an user of it.

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
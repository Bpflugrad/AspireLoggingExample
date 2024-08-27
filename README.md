# AspireLoggingExample

Example project displaying seeming failures of `Azure.Monitor.OpenTelemetry.AspNetCore` 1.2.0 to handle Structured Logging.

## Background

My team has been adopting Aspire and transitioning from Azure Functions.  During this process I have been tasked with setting up a uniform pattern for "Telemetry" within our new applications.
During this process I wanted to respect the best practice of Structured Logging.  This, however, does not seem possible with `UseAzureMonitor` at this time.

## Setup

In `appsettings.Development.json` in `AppHost`update the key `ApplicationInsights` to your Application Insights connection string.

## Controllers

### ExtensionLogController

This endpoint uses the extension method `LogInformation`.
The expectation is that in Application Insights we will receive the following properties:
```
{
	"Message": "LogInformation(9001)",
	"OriginalFormat": "LogInformation({value})",
	"value": "9001"
}
```
However, `OriginalFormat` is not present on the trace.

### AttributeLogController

This endpoint uses `LoggerMessageAttribute`, instead of the extention methods.
The expectation is that in Application Insights we will receive the following properties:
```
{
	"Message": "LogFromAttributeMessage(9001)",
	"OriginalFormat": "LogFromAttributeMessage({value})",
	"value": "9001"
}
```
However, `OriginalFormat` is not present on the trace.

### ExceptionLogContrller

This endpoint uses a `LoggerMessageAttribute`, but logs a thrown `Exception`.
The expectation is that in Application Insights we will receive an Exception type with the following properties:
```
{
	"Message": "Exception Message",
	"OriginalFormat": "LogExceptionMessage({value})",
	"value": "9001"
}
```
In this case it appears that `OriginalFormat` is included.
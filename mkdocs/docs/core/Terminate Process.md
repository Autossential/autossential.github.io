Tries to gracefully close all instances of the applications corresponding to the specified processes. If not possible, it kills the process.

![](../img/activities/TerminateProcess.png)

##### Properties

|Name       |Description                                                                                                                              |
|-----------|-----------------------------------------------------------------------------------------------------------------------------------------|
|ProcessName|The name of the process to close or kill. Can be either a single name or a list of names.                                                |
|Timeout    |Specifies the amount of time in milliseconds to wait for the activity to run before an error is thrown. The default value is 30000 (30s).|


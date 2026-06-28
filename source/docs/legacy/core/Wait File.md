Waits until the file be available.

![](../img/activities/WaitFile.png)

##### Properties

|Name           |Description                                                                                                                                                                |
|---------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
|ContinueOnError|If set, continue executing the remaining activities even if the current activity has failed.                                                                               |
|FilePath       |The storage path of the file.                                                                                                                                              |
|Interval       |Specifies the amount of time (in milliseconds) for the file re-check. Any value less than 50 will be clamped to 50. Make sure to keep this value lesser than Timeout value.|
|Result         |The FileInfo object of the respective file when found.                                                                                                                     |
|Timeout        |The maximum time to wait (in milliseconds) the operation to complete.                                                                                                      |
|WaitForExist   |Waits until the file exists.                                                                                                                                               |


##### Usage

There are two very common situations where we can use this activity.

- Waiting for some downloading file be completed.
- Waiting for some file in use for another person or process be released.

!!! note
    For files that you **can't** determine the name, [Wait Dynamic File](Wait Dynamic File.md) suits better.


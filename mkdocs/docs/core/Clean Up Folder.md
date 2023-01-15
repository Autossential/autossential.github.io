Deletes all files and folders from a specified folder.

![](../img/activities/CleanUpFolder.png)

##### Properties

|Name              |Description                                                                                                                                                                                                                                                                   |
|------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
|DeleteEmptyFolders|Determines if the left empty folders after files deletion must also be deleted.                                                                                                                                                                                               |
|FolderPath        |The folder path to be cleaned up.                                                                                                                                                                                                                                             |
|LastWriteTime     |Deletes only the files with last write time till this reference date. Default is DateTime.Now.                                                                                                                                                                                |
|Result            |An object containing the number of files deleted, folders deleted and total deleted.                                                                                                                                                                                          |
|SearchPattern     |The search string to match against the names of files in path. This parameter can contain a combination of valid literal path and wildcard (\* and ?) characters, but it doesn't support regular expressions. It also supports a collection of strings. Default value is "\*.\*".|


##### Usage

The activity deletes all files and folders that exists on the specified folder to clean up.

We can keep the folder structure by unchecking the property `DeleteEmptyFolders`, so the folders will not be deleted.

By specifying a `SearchPattern` we can delete only the files with specific names or extensions.

Finally, use `LastWriteTime` property to delete the files create/modified till the specified date.

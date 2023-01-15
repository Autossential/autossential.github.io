Returns an enumerable collection of full file names that match a search pattern (or collection of patterns) and enumeration options in a specified path (or collection of paths).

![](../img/activities/EnumerateFiles.png)

##### Properties

|Name         |Description                                                                                                                                                                                                                                                                   |
|-------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
|DirectoryPath|The relative or absolute path (or collection of paths) to the directory (or directories) to search.                                                                                                                                                                           |
|Exclusions   |Excludes from the enumeration the files with any of the specified attributes.                                                                                                                                                                                                 |
|Result       |An enumerable collection of the full names (including paths) for the files in the directory specified by path and that match the specified search pattern and option.                                                                                                         |
|SearchOption |Specifies whether the search operation should include only the current directory or should include all subdirectories.                                                                                                                                                        |
|SearchPattern|The search string to match against the names of files in path. This parameter can contain a combination of valid literal path and wildcard (\* and ?) characters, but it doesn't support regular expressions. It also supports a collection of strings. Default value is "\*.\*".|


##### Usage

Returns a `IEnumerable<string>` with all file paths from the specified directory or directories.

Use the `SearchPattern` to filter the files by its name or extension.

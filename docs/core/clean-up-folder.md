<h1>
<img src="../imgs/CleanUpFolder.svg" width="32" height="32" />
Clean Up Folder
</h1>

Deletes all files and folders from a specified folder.

## Properties

| Name | Description | Required |
|------|-------------|:--------:|
| Continue on error | Specifies to continue executing the remaining activities even if the current activity failed. Only boolean values are allowed. |  |
| Delete Empty Folders | Determines if the left empty folders after files deletion must also be deleted. |  |
| Files Deleted | The number of files that were deleted. |  |
| Folder Path | The folder path to be cleaned up. | :ballot_box_with_check: |
| Folders Deleted | The number of folders that were deleted. |  |
| Last Write Time | Deletes only the files with last write time till this reference date. Default is DateTime.Now. |  |
| Search Option | Specifies whether the search operation should include only the current directory or should include all subdirectories. |  |
| Search Pattern | The search string defines file name patterns in the path. It supports literal text and wildcards (*, ?, !, &vert;), but not regular expressions. Use ! for exclusions (e.g., !*.txt), and &vert; for multiple patterns (e.g., *.png&vert;*.gif&vert;*.jpeg). Default is *.* (all files). |  |


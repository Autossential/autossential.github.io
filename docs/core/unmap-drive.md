<h1>
<img src="../imgs/UnmapDrive.svg" width="32" height="32" />
Unmap Drive
</h1>

Unmaps one or all mapped network drives from the system.

## Properties

| Name | Description | Required |
|------|-------------|:--------:|
| All Drives | When set to true, unmaps all mapped network drives. When false, only the drive specified in DriveLetter is unmapped. |  |
| Drive Letter | Specifies the drive letter of the mapped drive to be unmapped. The required format is &lt;letter>&lt;colon>, for example: "X:", "y:", "Z:". This property is ignored when AllDrives is set to true. |  |
| Result | Returns true if the drive was successfully unmapped, false otherwise. For multi-drive operations, returns true only if all mapped drives were successfully unmapped. |  |


# Unmap Drive

Unmaps one or all mapped network drives from the system.

![](imgs/UnmapDrive.png)

### Properties

| Name | Description | Required |
|------|-------------|----------|
| Drive Letter | Specifies the drive letter of the mapped drive to be unmapped. The required format is <letter><colon>, for example: "X:", "y:", "Z:". This property is ignored when AllDrives is set to true. |  |
| All Drives | When set to true, unmaps all mapped network drives. When false, only the drive specified in DriveLetter is unmapped. |  |
| Response Code | Represents the return code of the drive unmapping operation. For single drive operations, this value indicates whether the operation succeeded or failed according to standard Windows error codes. For multi-drive operations, 0 indicates all drives were successfully unmapped, 1 indicates partial success, and 2 indicates all drives failed. |  |
| Response Message | Provides the textual description corresponding to the response code. For multi-drive operations, this message contains details for each drive that failed to unmap. |  |
| Result | Returns true if the drive was successfully unmapped, false otherwise. For multi-drive operations, returns true only if all mapped drives were successfully unmapped. |  |


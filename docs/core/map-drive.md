<h1>
<img src="../imgs/MapDrive.svg" width="32" height="32" />
Map Drive
</h1>

Maps a Network Drive into the system.

## Properties

| Name | Description | Required |
|------|-------------|:--------:|
| Credential | Specifies the NetworkCredential object containing the username, password, and optionally the domain to authenticate the user when mapping the network drive. Required for protected shared folders. |  |
| Drive Letter | Specifies the drive letter to be mapped. If not provided, a random available letter will be assigned. The expected format is &lt;letter>&lt;colon>, for example: "X:", "y:", "Z:". |  |
| Force | Tries to force the connection if the drive letter is already being in use. |  |
| Mapped Drive | The mapped drive letter if the mapping was successful, it is represented in the format "&lt;letter>:". |  |
| Result | Returns true if the drive was successfully mapped, false otherwise. |  |
| Shared Drive Path | The shared drive path to connect with. | :ballot_box_with_check: |


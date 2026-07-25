<h1>
<img src="../imgs/WriteRange.svg" width="32" height="32" />
Write Range
</h1>

Writes a DataTable into an Excel worksheet starting at a specified cell (default A1). If the target sheet does not exist, a new one is created. All existing values in the target range are overwritten.

## Properties

| Name | Description | Required |
|------|-------------|:--------:|
| Add Headers | Indicates if column names are written as headers. |  |
| Data Table | Source DataTable to write into the worksheet. | :ballot_box_with_check: |
| Sheet Name | Name of the worksheet to write data into. | :ballot_box_with_check: |
| Starting Cell | Top-left cell where writing begins. |  |


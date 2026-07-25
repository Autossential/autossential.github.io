<h1>
<img src="../imgs/GetRangeSize.svg" width="32" height="32" />
Get Range Size
</h1>

Returns the bounding dimensions (rows and columns) of the specified range, trimming only trailing empty rows and columns.

## Properties

| Name | Description | Required |
|------|-------------|:--------:|
| Column Count | The number of columns in use included in the specified range. |  |
| Range | Specifies the range of cells to be read. If this value is not specified, all used cells of the spreadsheet is read. If the value consists of only one cell, all used rows in the spreadsheet are read starting from that cell. (Default: A1) |  |
| Row Count | The number of rows in use included in the specified range. |  |
| Sheet Name | The name of the worksheet containing the target range. | :ballot_box_with_check: |


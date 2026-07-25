<h1>
<img src="../imgs/ReadRange.svg" width="32" height="32" />
Read Range
</h1>

Reads the value of a range from a spreadsheet as a DataTable. If the range is not specified, all used cells in the spreadsheet are read. If the range is specified as a cell, all used rows starting from that cell is read.

## Properties

| Name | Description | Required |
|------|-------------|:--------:|
| Has Headers | Specifies if the first row in the range should be considered column headers definitions. If set to false, the columns in the DataTable will use the following pattern "Col{number}", e.g.: Col1, Col2, Col3, etc. |  |
| Headers Rows | Determines the number of rows that composes the header. The values of these rows are concatenated. |  |
| Range | Specifies the range of cells to be read. If this value is not specified, all used cells of the spreadsheet is read. If the value consists of only one cell, all used rows in the spreadsheet are read starting from that cell. (Default: A1) |  |
| Data Table | The output DataTable in which the read data is stored. |  |
| Rows Per Record | Determines the number of rows that composes a single record. The row values are concatenated. |  |
| Sheet Name | The name of the sheet from the workbook. | :ballot_box_with_check: |


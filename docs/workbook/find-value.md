<h1>
<img src="../imgs/FindValue.svg" width="32" height="32" />
Find Value
</h1>

Searches for a specified value within an Excel worksheet range and returns the cell address, row number, and column number of the first occurrence. Use this activity when you need to locate specific data within a workbook and retrieve its coordinates for further processing.

## Properties

| Name | Description | Required |
|------|-------------|:--------:|
| Cell Address | Returns the address of the cell containing the value (e.g., "B4"). |  |
| Column Number | Returns the 1-based column number of the cell containing the value (e.g., 2 for cell B4). |  |
| Range | Cell range to search within (e.g., "A1:C10"). If not provided, defaults to "A1" which searches the entire worksheet. |  |
| Row Number | Returns the 1-based row number of the cell containing the value (e.g., 4 for cell B4). |  |
| Sheet Name | Name of the worksheet to search for the value. This property is required and the sheet must exist in the workbook. | :ballot_box_with_check: |
| Value | The specific text or numeric value to locate within the worksheet range. This property is required and performs an exact match search. | :ballot_box_with_check: |


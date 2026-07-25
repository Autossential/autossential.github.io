<h1>
<img src="../imgs/InsertSheet.svg" width="32" height="32" />
Insert Sheet
</h1>

Inserts a new worksheet into the workbook with the specified name and optional position. Use this activity when you need to add a new sheet to the workbook.

## Properties

| Name | Description | Required |
|------|-------------|:--------:|
| Position | Optional index position where the new sheet will be inserted (1-based). If not provided or less than 1, the sheet is added at the end of the workbook. |  |
| Sheet Name | Name of the new worksheet to be inserted. This property is required and must be unique within the workbook. | :ballot_box_with_check: |


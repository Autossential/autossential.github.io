<h1>
<img src="../imgs/RemoveEmptyRows.svg" width="32" height="32" />
Remove Empty Rows
</h1>

Removes the empty rows from a Data Table.

## Properties

| Name | Description | Required |
|------|-------------|:--------:|
| Column Indexes | Column indexes to evaluate. Can be combined with Column Names. If not specified, all columns are considered. |  |
| Column Names | Column names to evaluate. Can be combined with Column Indexes. If not specified, all columns are considered. |  |
| Data Table | The Data Table whose empty rows will be removed. | :ballot_box_with_check: |
| Matching Mode | Determines how a row is evaluated for removal: All — the row is removed if all specified columns are empty. Any — the row is removed if any specified column is empty. If no columns are specified, all columns of the Data Table are considered. |  |


Promotes the first row of values to new column headers.

![](../img/activities/PromoteHeaders.png)

##### Properties

|Name           |Description                                                                                                |
|---------------|-----------------------------------------------------------------------------------------------------------|
|AutoRename     |When true, it avoids the "column name already belongs to DataTable" error by adding a numeric suffix to it.|
|EmptyColumnName|Replaces an empty column name by the value of this property.                                               |
|DataTable      |The input DataTable.                                                                                       |
|Result         |The output DataTable.                                                                                      |


##### Usage

Sample of input data table:

|  Col1  |        Col2        |      Col3       |  Col4   |
| ------ | ------------------ | --------------- | ------- |
| Name   | Company            | Email           | Country |
| Rhona  | Purus Ltd          | rhona@none.com  | Turkey  |
| Camden | Quisque Foundation | camden@none.com | Sweden  |

Result of promoting headers:

| Name   | Company            | Email           | Country |
| ------ | ------------------ | --------------- | ------- |
| Rhona  | Purus Ltd          | rhona@none.com  | Turkey  |
| Camden | Quisque Foundation | camden@none.com | Sweden  |

Keep `AutoRename` property set to true to handle possible duplicate values in the first row.

It will auto-rename columns with same name by appending a numeric suffix:

Input table:

| Col1 | Col2  |             Col3              |              Col4              |
| ---- | ----- | ----------------------------- | ------------------------------ |
| Name | Value | <span class="red">Name</span> | <span class="red">Value</span> |
| A    | 1     | B                             | 2                              |

Output table:

| Name | Value | <span class="green">Name1</span> | <span class="green">Value1</span> |
| ---- | ----- | -------------------------------- | --------------------------------- |
| A    | 1     | B                                | 2                                 |

In case of possible empty values in the first row, check `EmptyColumnName` on the properties table.

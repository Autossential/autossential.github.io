<h1>
<img src="../imgs/LoadDataFile.svg" width="32" height="32" />
Load Data File
</h1>

Parses a JSON or YAML file into a DataNode for simplified access and manipulation.

## Properties

| Name | Description | Required |
|------|-------------|:--------:|
| Culture | Specifies the culture used when converting node values to numeric types (e.g., int, long, double, decimal). |  |
| Encoding | Specifies the text encoding used when reading the file. Defaults to UTF-8. |  |
| File Path | The path to the JSON or YAML file to be loaded. | :ballot_box_with_check: |
| Result | The DataNode generated from the parsed file content. |  |

<!--@include: ../extras/load-data-file.md-->

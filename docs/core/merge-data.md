<h1>
<img src="../imgs/MergeData.svg" width="32" height="32" />
Merge Data
</h1>

Merges the source DataNode into the destination one. Scalar and Sequence values from source overwrite existing ones in destination. Map values are merged recursively.

## Properties

| Name | Description | Required |
|------|-------------|:--------:|
| Destination | The DataNode to be updated with source instance. | :ballot_box_with_check: |
| Source | The DataNode to merge into the destination instance. | :ballot_box_with_check: |

<!--@include: ../extras/merge-data.md-->

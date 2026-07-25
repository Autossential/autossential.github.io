<h1>
<img src="../imgs/Zip.svg" width="32" height="32" />
Zip
</h1>

Compresses files and folders into a zip archive.

## Properties

| Name | Description | Required |
|------|-------------|:--------:|
| Compressed File | Index or identifier of the compressed file created (when applicable). |  |
| Compression Level | Compression level used when creating the archive. |  |
| Entry Structure | Defines how files are stored inside the ZIP archive: keep relative paths, flatten to root, rename duplicates, or preserve full directory structure. Auto mode flattens when possible and falls back to relative paths if duplicate names are detected. |  |
| Files Count | The number of files added to the archive. |  |
| Text Encoding | Encoding used for entry names inside the zip archive. |  |
| To Compress | Collection of file and directory paths to compress. | :ballot_box_with_check: |
| Zip File Path | Path where the zip archive will be created. | :ballot_box_with_check: |


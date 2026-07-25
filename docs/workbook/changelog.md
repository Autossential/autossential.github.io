# Autossential.Workbook.Activities

## 1.3.0 - 2026.07.19

**New Actvities**

- **Freeze Panes**: Freeze specified rows and columns in worksheets, maintaining visibility during scrolling.
- **Hide/Unhide Sheet**: Toggle worksheet visibility with Hide/Unhide options.

## 1.2.2 - 2026.07.02

**Bug Fix**

Fixes a bug in the **GetRangeSize** activity when handling inferred rows, and updates activity descriptions for clarity

## 1.2.1 - 2026.06.29

**Bug Fix**

Fixes header and row value handling in the workbook processor when dealing with multi-header rows and multiple rows per record. The changes prevent empty column names from being concatenated into headers, and ensure row values are only concatenated when both the current and new values are non-empty.

- Prevent null/empty column names from being appended to headers
- Only concatenate row values when the current value is non-empty

## 1.2.0 - 2026.06.28

**New Activites**

- **Delete Sheet**: Delete worksheets from a workbook
- **Insert Sheet**: Insert new sheets at a specified position
- **Rename Sheet**: Rename existing sheets

## 1.1.0 - 2026.06.21

**New Activites**

- **Write Cell** – Write single values to sheet cells
- **Write Range** – Write DataTables to a sheet
- **Find Value** – Search for values and return coordinates
- **Save Workbook** – Explicit save workbook activity

## 1.0.0 - 2026.05.31

Initial version
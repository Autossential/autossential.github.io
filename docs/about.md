# About

Autossential is a suite of custom activities for [UiPath](https://www.uipath.com) that gives to developers practical, reusable building blocks that reduce boilerplate and repetitive coding patterns, helping automations stay cleaner and faster to build. The suite is organized into two independent packages: **Autossential.Activities** and **Autossential.Workbook.Activities**.

## Autossential.Activities

This package complements UiPath's native activity set with general-purpose activities organized into clear categories:

- **Data** — utilities for working with DataTables and dictionaries, such as promoting headers, transposing data, removing empty rows, and updating dictionaries.
- **Files** — streamlined handling of files and folders, including cleanup, waiting for files, and zip/unzip operations.
- **Programming** — activities that reduce the need for custom code, such as culture scoping, token replacement, and data parsing/merging.
- **System** — helpers for drive mapping and process management.
- **Workflow** — control-flow activities that improve readability and simplify orchestration logic (conditionals, timed loops, checkpoints, and controlled exits).

The package is compatible with both Windows and Cross-Platform UiPath projects, letting developers build more efficient workflows without falling back on custom code for common tasks.

## Autossential.Workbook.Activities

This package focuses on Excel workbook manipulation without requiring Microsoft Excel to be installed, supporting both XLSX and XLS formats. It provides activities for:

- Reading and writing cells, ranges, and tables.
- Working with formulas, including automatic evaluation of cached values.
- Managing workbook structure — adding, editing, and formatting worksheets, controlling visibility, and configuring freeze panes.
- Performing high-performance operations suitable for unattended automation, avoiding unnecessary I/O through change detection.

Because it doesn't depend on Excel being installed, this package is well suited for server-side or unattended environments and large-scale data processing scenarios.
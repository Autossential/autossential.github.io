# Changelog
All notable changes to this project will be documented in this page.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

The packages can be found on [NuGet.org](https://nuget.org/) and [UiPath Marketplace](https://marketplace.uipath.com/) being available first at NuGet.org.

## 3.3.8 - 2025.07.27

Minor code refactoring for **Terminate Process**.

**MapDrive** minor code refactoring to handle MS Error 1219 when "Force" option is enabled. 

## 3.3.7 - 2024.11.27
**Terminate Process** activity was updated to close the processes only for the current user session.

## 3.3.6 - 2024.10.20
Removed from code the obsolete **Repeat Until Failure** (since 3.3.0) activity.

Added the activities **Add To/Update Dictionary** and **Remove From Dictionary**.

Other minor code refactoring.

## 3.3.5 - 2024.06.16

Created new activity **Fill Data Column**.

Added the output property **IsTimeout** to **Time Loop** activity.

Added the output property **ResponseMessage** to **MapDrive** and **UnmapDrive** activities.

## 3.3.4 - 2024.05.19

**Time Loop** gets new property to propagate exceptions.

**Is True**, fixed the output variable.

Two new activives included **MapDrive** and **UnmapDrive** which can be used to map/unmap a network shared drive.

## 3.3.3 - 2024.05.09

Immediately exits from **Time Loop** without consider the **Loop Interval** if **Exit** is invoked.

## 3.3.2 - 2023.06.25

**<u>Breaking Changes:</u>**

**Time Loop** and **Repeat Until Failure** *(obsolete)* activities had their namespaces changed.

To fix any issue, open the workflow in a text editor and update the namespace below

clr-namespace:Autossential.Activities<u>.Workflow</u>;assembly=Autossential.Activities

to:

clr-namespace:Autossential.Activities;assembly=Autossential.Activities

## 3.3.1 - 2023.06.19

Added *PatternSearchMode* property on **Enumerate Files** and **CleanUpFolder** activities. 
**Terminate Process** activity had the code refactored.

## 3.3.0 - 2023.01.14

New **Time Loop** activity.

**Repeat Until Failure** is now <u>obsolete</u>. You can replace it by **Time Loop** activity.

Now the **Terminate Process** does not break when some process is get locked by Windows.

New features added to **Extract Data Column Values** activity.

## 3.2.2 - 2022.12.18

Bug fix on **Promote Headers** activity caused by the version 3.2.1.

Behavior changed on **Extract Data Column Values** activity, no error will occur if the DataTable has no columns.

## 3.2.1 - 2022.10.13

New **Terminate Process** activity.

New **Repeat Until Failure** activity.

Workflow designer enhancements for all activities.

## 3.1.2 - 2022.09.12

Added the optional property *FromDateTime* to **Wait Dynamic File** activity.

## 3.1.1 - 2022.09.03

**Container** and **Iterate** activities behavior were fixed when are used inside of a loop or in recursive calls.

## 3.1.0 - 2022.07.02

**Replace Tokens** activity added.

**Remove Columns** activity issue fixed when trying to remove columns with wrong names or indexes.

## 3.0.2 - 2022.03.29

**Wait Dynamic File** activity was updated to check files based on the *Last Write Time* instead of *Last Creation Time*.

**Culture Scope** and **Iterate** activities does not hold a variables scope anymore.

The *Index* property of the **Iterate** scope was converted to a local variable.


## 3.0.1 - 2022.02.20

Small fix on **Enumerate Files** activity designer regarding a property binding issue with folder picker.

## 3.0.0 - 2022.02.06

This version is compatible with Windows Legacy (.NET 4.61 Framework) and Windows (.NET 5).

Some standards was adopted from now on resulting in significant **BREAKING CHANGES**.

<pre class="changelog">
ADDED
- Compability with Windows (.NET 5.0)
- When-Do Activity
- New Encryption Activities that were designed in a composition way.
  > Text Encryption
  > DataTable Encryption

CHANGES
- Activities that returns a single value is now deriving from CodeActivity&lt;T>.
- Some XAML property names or structure was changed resulting in a BREAKING CHANGES for the below activities:
  > Aggregate
  > DataRow To Dictionary
  > DataTable To Text
  > Dictionary To DataTable
  > Enumerate Files
  > Extract Data Column Values
  > Promote Headers
  > Remove Data Columns
  > Remove Duplicate Rows
  > Remove Empty Rows
  > Transpose Data
  > Stopwatch
  > Zip
  > Wait File
  > Wait Dynamic File

- Extract Data Column Values: DefaultValue display name fixed.
- Aggregate: Detached option was removed.
- DataTable category is now called Data

REMOVED
- Decrypt DataTable
- Decrypt Text
- Encrypt DataTable
- Encrypt Text
</pre>


## Obsolete Versions

<i>Just for history purpose. No more listed for download.</i>

- 2.1.1 - 2022.01.03
> Implementation of cancellation token on Wait Dynamic File activity.<br>
> ContinueOnError fix for asyncronous activities
- 2.1.0 - 2021.12.21
- 2.0.3 - 2021.05.23
- 2.0.2 - 2021.01.08
- 2.0.1 - 2021.01.07
- 2.0.0 - 2020.12.31
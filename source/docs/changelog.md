# Changelog
All notable changes to this project will be documented in this page.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

The packages can be found on [NuGet.org](https://nuget.org/) and [UiPath Marketplace](https://marketplace.uipath.com/) being available first at NuGet.org.

## 4.0.7 - 2026.06.28

Updated missing property descriptions for TimeLoop.Result and MapDrive.Credential.

## 4.0.6 - 2026.06.21

CleanUpFolder updated to consider readonly files during clean up.

## 4.0.5 - 2026.06.07

Design time fix when browsing folder/file that was creating long relative paths.

## 4.0.4 - 2026.05.26

Wait File activity timeout has been fixed.

## 4.0.3 - 2026.05.09

Map Drive and Unmap Drive activities can now show a dropdown to select the available drive letters.

Updated wrong descriptions in the Resources.resx.

## 4.0.2 - 2026.05.03

DataNode model now uses `IList<T>` instead of `List<T>` in the methods `AsSequence` and `AsSequenceOrDefault`

## 4.0.1 - 2026.04.16

Removed the restriction of positive-only numbers in the Increment/Decrement activity.

## 4.0.0 - 2026.04.11

The redesigned Autossential.Activities package is tailored for the latest UiPath versions.

This release introduces 26 activities, each built to leverage the UiPath ViewModel for enhanced design-time rendering.
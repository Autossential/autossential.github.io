# Changelog
All notable changes to this project will be documented in this page.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).


## 1.2.3 - 2024.12.10

Downgrade of the dependencies YamlDotNet (11.2.1) and System.Text.Json (4.7.2) which were upgraded on the 1.2.2 version. This downgrade is to avoid conflicts with other UiPath libraries.

## 1.2.2 - 2024.12.01

Included **AsSecureString** and **AsRegex** methods to **ConfigSection**.

Some code refactoring.

## 1.1.0 - 2022.11.15

Added new activity **Config Parse**.

ConfigSection object is now iterable and *.Items* property was dropped.

## 1.0.0 - 2022.02.27

Initial release.
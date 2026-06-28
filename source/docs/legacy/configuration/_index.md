The *Autossential.Configuration.Activities* provides activities to create a rich configuration object *(ConfigSection)* based on text files formatted as YAML or JSON standards or from objects like DataTable and Dictionary.

This package has the following dependencies:

- System.Text.Json (4.7.2)
- YamlDotNet (11.2.1)

!!! info
    Read more about [ConfigSection](_config-section.md) class.

!!! warning "An experimental project"
    Autossential.Configuration was an experimental set of activities created to parse YAML and JSON files, allowing them to be used as a "Config" object in UiPath instead of the dictionary approach provided by UiPath’s template frameworks.

    This functionality is no longer needed, as Autossential.Activities 4.x provides a more robust alternative with the Load Data File, Parse Data, and Merge Data activities, which eliminate the need for external dependencies.

    As a result, the Autossential.Configuration project will not receive further updates or maintenance.  
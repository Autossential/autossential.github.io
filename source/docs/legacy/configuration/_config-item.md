A class that stores the key-value pair from the configuration files.

Each entry in a *ConfigSection* is a *ConfigItem*.

E.g:

```yaml
retries: 5 # ConfigItem (Key: retries, Value: 5)
screenshots: true # ConfigItem (Key: screenshots, Value: true)

letters: # ConfigItem (Key: letters, Value: ConfigSection)
    A-E: ABCDE # ConfigItem (Key: A-E, Value: ABCDE)
```

##### Methods

|         Name         |                       Description                       |
| -------------------- | ------------------------------------------------------- |
| ValueAsArray         | Retrieves a value as an array of objects (`object[]`)   |
| ValueAsArray&lt;T>   | Retrieves a value as an array of the specified type T   |
| ValueAsBoolean       | Retrieves a value as System.Boolean                     |
| ValueAsConfigSection | Retrieves a value as a ConfigSection (aka Sub-Sections) |
| ValueAsDateTime      | Retrieves a value as System.DateTime                    |
| ValueAsDecimal       | Retrieves a value as System.Decimal                     |
| ValueAsDouble        | Retrieves a value as System.Double                      |
| ValueAsFloat         | Retrieves a value as System.Float                       |
| ValueAsInt           | Retrieves a value as System.Int32                       |
| ValueAsList          | Retrieves a value as a list of objects (`List<object>`) |
| ValueAsList&lt;T>    | Retrieves a value as a list of the specified type T     |
| ValueAsLong          | Retrieves a value as System.Int64                       |
| ValueAsRegex         | Retrieves a valiue as a Regex                           |
| ValueAsSecureString  | Retrieves a value as a SecureString                     |
| ValueAsString        | Retrieves a value as System.String                      |


All items of a specific *ConfigSection* can be retrieved using *ConfigSection.Items*. E.g:

![](../img/ConfigItem_ForEachSample.png)

Make sure to select the ConfigItem as TypeArgument on ForEach activity:

![](../img/ConfigItem_ForEachItemTypeSample.png)

Adds a new key-value pair to the Dictionary. If the Dictionary does not exist, a new instance is created. If the key already exists in it, an exception will be thrown except if the Update If Exists option is enabled.

![](../img/activities/AddToUpdateDictionary.png)

##### Properties

|Name          |Description                                                                |
|--------------|---------------------------------------------------------------------------|
|Key           |The key of the element to add.                                             |
|Dictionary    |The Dictionary instance to receive the new key-value pair.                 |
|UpdateIfExists|If the key already exists in the Dictionary, updates its value.            |
|Value         |The value of the element to add. The value can be null for reference types.|


##### Usage

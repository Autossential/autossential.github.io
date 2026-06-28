# DataNode

## Overview

`DataNode` objects are returned by the activities [Load Data File](../LoadDataFile.md) and [Parse Data](../ParseData.md), and serve as inputs for the [Merge Data](../MergeData.md) activity.

It is a normalized, immutable wrapper around any value coming from YAML/JSON parsers or user-supplied objects. It encapsulates three canonical internal types and exposes a uniform API for navigation, existence checks, and value conversion, regardless of the data source.

## Internal Canonical Types

After construction, the internal value is always normalized to one of the three types below:

| `NodeType` | Internal .NET type | Description |
|---|---|---|
| `Scalar` | `string`, `null`, primitive (`int`, `bool`, `double`, …) | Atomic values |
| `Sequence` | `List<object>` | Lists; elements are recursively normalized |
| `Map` | `Dictionary<string, object>` | Key→value maps; values are recursively normalized |

> The `Type` property always reflects the canonical type of the node after normalization.

## Key-Path Syntax

All navigation and conversion methods that accept a `keyPath` overload support the following syntax:

| Example | Description |
|---|---|
| `"person.address.city"` | Dot-separated map keys |
| `"servers[0].host"` | Numeric index into a sequence |
| `"servers[0].ports[1]"` | Chained numeric indexes |
| `"metrics['error.rate'].value"` | Single-quoted key (for keys that contain dots) |
| `"metrics[\"error.rate\"]"` | Double-quoted key |
| `"metrics[error.rate]"` | Unquoted bracket key — treated as a map key |

---

## Properties

### `Type`

```csharp
public NodeType Type { get; private set; }
```

Returns the canonical type of the node (`Scalar`, `Sequence`, or `Map`). Set automatically when `RawValue` is assigned.

### `RawValue`

```csharp
public object RawValue { get; private set; }
```

Returns the raw internal value without any conversion. The setter is private and triggers reclassification of `Type`.

### `Culture`

```csharp
public CultureInfo Culture { get; }
```

The culture associated with the node, used in formatting and parsing operations (numeric and date conversions, etc.). Defaults to `CultureInfo.InvariantCulture` when not explicitly provided.

### `Keys`

```csharp
public IEnumerable<string> Keys { get; }
```

Returns the keys of the node when its type is `Map`. Returns an empty collection for any other type. Key order is not guaranteed.

### Indexer `this[string keyPath]`

```csharp
public DataNode this[string keyPath] { get; set; }
```

- **Get:** equivalent to `GetNode(keyPath)`.
- **Set:** navigates to the parent segment of the path and assigns the `RawValue` of the provided `DataNode`. Intermediate maps are created automatically if the path does not exist. Throws `InvalidOperationException` if the root node is not a `Map`.

**Example:**

```csharp
var node = DataNode.Empty(CultureInfo.InvariantCulture);
node["database.host"] = new DataNode("localhost");
string host = node["database.host"].AsString(); // "localhost"
```

## Constructors and Factory Methods

### `DataNode(object value, CultureInfo culture)`

Primary constructor. Normalizes `value` to its canonical type and associates `culture`. If `culture` is `null`, `CultureInfo.InvariantCulture` is used.

### `DataNode(object value)`

Shortcut for the primary constructor using `CultureInfo.InvariantCulture`.

### `DataNode()`

Creates an empty `Map` node (an empty `Dictionary<string, object>`) with invariant culture.

### `DataNode.Empty(CultureInfo culture)` _(static)_

```csharp
public static DataNode Empty(CultureInfo culture)
```

Creates an empty `Map` node associated with the given culture. Semantically equivalent to the default constructor, but with an explicit culture.

## Existence Check Methods

### `HasValue()`

```csharp
public bool HasValue()
```

Returns `true` if the internal value is not `null`.

### `HasValue(string keyPath)`

```csharp
public bool HasValue(string keyPath)
```

Navigates to `keyPath` and returns `true` if the resulting node has a non-null value. Equivalent to `GetNode(keyPath).HasValue()`.

### `HasNode(string keyPath)`

```csharp
public bool HasNode(string keyPath)
```

Checks whether a node exists at the specified path **without throwing an exception** for invalid paths or missing nodes — returns `false` in those cases.

- Returns `false` if `keyPath` is null or empty.
- Returns `false` if any intermediate segment does not exist.
- Exceptions thrown during traversal are caught internally and silently converted to `false`.

**Difference between `HasNode` and `HasValue`:**

| Method | Behavior when a node exists with a `null` value |
|---|---|
| `HasNode("path")` | `true` — the node exists, even if its value is null |
| `HasValue("path")` | `false` — the node exists but has no value |

## Navigation Methods

### `GetNode(string keyPath)`

```csharp
public DataNode GetNode(string keyPath)
```

Navigates to the node at `keyPath` and returns a `DataNode`. If the path does not exist, returns a scalar `DataNode` with a `null` value — it never throws for a missing path. Type mismatch exceptions (e.g., trying to index a `Scalar` as a `Map`) are propagated to the caller.

## Merge

### `Merge(DataNode other)`

```csharp
public void Merge(DataNode other)
```

Merges another `DataNode` into the current instance. Requires the current node to be of type `Map`; otherwise throws `InvalidOperationException`.

**Merge semantics:**

| Type of value in `other` | Behavior |
|---|---|
| `Map` | Recursive merge: keys present on both sides are merged; new keys are added |
| `Scalar` or `Sequence` | The value from `other` **overwrites** the current value |

If `other` is `null`, has no value, or is not a `Map`, the method returns without modifying anything.

**Example:**

```csharp
var base_ = new DataNode(new Dictionary<string, object>
{
    ["db"] = new Dictionary<string, object> { ["host"] = "localhost", ["port"] = 5432 }
});

var override_ = new DataNode(new Dictionary<string, object>
{
    ["db"] = new Dictionary<string, object> { ["port"] = 5433, ["name"] = "prod" }
});

base_.Merge(override_);
// Result: db.host = "localhost", db.port = 5433, db.name = "prod"
```

## Utility Methods

### `AsMap()`

```csharp
public Dictionary<string, object> AsMap()
```

Returns the underlying dictionary of the node. Throws `InvalidOperationException` if the type is not `Map`. Useful when direct manipulation of the internal map is required.

### `ToString()`

```csharp
public override string ToString()
```

Returns a human-readable representation of the node:

| `NodeType` | Output format |
|---|---|
| `Scalar` | The string value, or `"(null)"` if the value is null |
| `Sequence` | `"[Sequence, N items]"` |
| `Map` | `"[Map, N keys]"` |

## Type Converters

All converters exist in **two forms**:

1. **Direct** — operates on the current node's value.
2. **Navigation overload** (`DataNode.NavigationMethods.cs`) — navigates to `keyPath` first, then applies the same converter.

The `OrDefault` variants return a fallback value instead of throwing when conversion fails or the value is `null`.

### String

| Method | Signature |
|---|---|
| `AsString()` | `public string AsString()` |
| `AsString(keyPath)` | `public string AsString(string keyPath)` |
| `AsStringOrDefault(defaultValue)` | `public string AsStringOrDefault(string defaultValue)` |
| `AsStringOrDefault(keyPath, defaultValue)` | `public string AsStringOrDefault(string keyPath, string defaultValue)` |

Returns `null` if the value is `null`. No exception is thrown for a null value.

### Integer (`int`)

| Method | Signature |
|---|---|
| `AsInt()` | `public int AsInt()` |
| `AsInt(keyPath)` | `public int AsInt(string keyPath)` |
| `AsIntOrDefault(defaultValue)` | `public int AsIntOrDefault(int defaultValue)` |
| `AsIntOrDefault(keyPath, defaultValue)` | `public int AsIntOrDefault(string keyPath, int defaultValue)` |

Uses `Convert.ToInt32(value, Culture)` internally.

### Long (`long`)

| Method | Signature |
|---|---|
| `AsLong()` | `public long AsLong()` |
| `AsLong(keyPath)` | `public long AsLong(string keyPath)` |
| `AsLongOrDefault(defaultValue)` | `public long AsLongOrDefault(long defaultValue)` |
| `AsLongOrDefault(keyPath, defaultValue)` | `public long AsLongOrDefault(string keyPath, int defaultValue)` |

> Note: the `keyPath` overload of `AsLongOrDefault` declares the default value as `int` (matches the source declaration).

Uses `Convert.ToInt64(value, Culture)` internally.

### Float (`float`)

| Method | Signature |
|---|---|
| `AsFloat()` | `public float AsFloat()` |
| `AsFloat(keyPath)` | `public float AsFloat(string keyPath)` |
| `AsFloatOrDefault(defaultValue)` | `public float AsFloatOrDefault(float defaultValue)` |
| `AsFloatOrDefault(keyPath, defaultValue)` | `public float AsFloatOrDefault(string keyPath, float defaultValue)` |

Uses `Convert.ToSingle(value, Culture)` internally.

### Double (`double`)

| Method | Signature |
|---|---|
| `AsDouble()` | `public double AsDouble()` |
| `AsDouble(keyPath)` | `public double AsDouble(string keyPath)` |
| `AsDoubleOrDefault(defaultValue)` | `public double AsDoubleOrDefault(double defaultValue)` |
| `AsDoubleOrDefault(keyPath, defaultValue)` | `public double AsDoubleOrDefault(string keyPath, double defaultValue)` |

Uses `Convert.ToDouble(value, Culture)` internally.

### Decimal (`decimal`)

| Method | Signature |
|---|---|
| `AsDecimal()` | `public decimal AsDecimal()` |
| `AsDecimal(keyPath)` | `public decimal AsDecimal(string keyPath)` |
| `AsDecimalOrDefault(defaultValue)` | `public decimal AsDecimalOrDefault(decimal defaultValue)` |
| `AsDecimalOrDefault(keyPath, defaultValue)` | `public decimal AsDecimalOrDefault(string keyPath, decimal defaultValue)` |

Uses `Convert.ToDecimal(value, Culture)` internally.

### Boolean (`bool`)

| Method | Signature |
|---|---|
| `AsBool()` | `public bool AsBool()` |
| `AsBool(keyPath)` | `public bool AsBool(string keyPath)` |
| `AsBoolOrDefault(defaultValue)` | `public bool AsBoolOrDefault(bool defaultValue)` |
| `AsBoolOrDefault(keyPath, defaultValue)` | `public bool AsBoolOrDefault(string keyPath, bool defaultValue)` |

Uses a custom `ParseBool` helper that handles the following string values case-insensitively before falling back to `Convert.ToBoolean`:

| String value | Result |
|---|---|
| `"true"` or `"1"` | `true` |
| `"false"` or `"0"` | `false` |
| anything else | `Convert.ToBoolean(value)` |

### DateTime

| Method | Signature |
|---|---|
| `AsDateTime()` | `public DateTime AsDateTime()` |
| `AsDateTime(keyPath)` | `public DateTime AsDateTime(string keyPath)` |
| `AsDateTimeOrDefault(defaultValue)` | `public DateTime AsDateTimeOrDefault(DateTime defaultValue)` |
| `AsDateTimeOrDefault(keyPath, defaultValue)` | `public DateTime AsDateTimeOrDefault(string keyPath, DateTime defaultValue)` |

Uses `Convert.ToDateTime(value, Culture)` internally.

### Regex

| Method | Signature |
|---|---|
| `AsRegex()` | `public Regex AsRegex()` |
| `AsRegex(options)` | `public Regex AsRegex(RegexOptions options)` |
| `AsRegex(keyPath)` | `public Regex AsRegex(string keyPath)` |
| `AsRegex(keyPath, options)` | `public Regex AsRegex(string keyPath, RegexOptions options)` |
| `AsRegexOrDefault(defaultValue)` | `public Regex AsRegexOrDefault(Regex defaultValue)` |
| `AsRegexOrDefault(defaultValue, options)` | `public Regex AsRegexOrDefault(Regex defaultValue, RegexOptions options)` |
| `AsRegexOrDefault(keyPath, defaultValue)` | `public Regex AsRegexOrDefault(string keyPath, Regex defaultValue)` |
| `AsRegexOrDefault(keyPath, defaultValue, options)` | `public Regex AsRegexOrDefault(string keyPath, Regex defaultValue, RegexOptions options)` |

Constructs a `Regex` from the string representation of the value. The parameterless overload uses `RegexOptions.None`.

### Sequence (`IList<T>`)

| Method | Signature |
|---|---|
| `AsSequence<T>()` | `public IList<T> AsSequence<T>()` |
| `AsSequence<T>(keyPath)` | `public IList<T> AsSequence<T>(string keyPath)` |
| `AsSequenceOrDefault<T>(defaultValue)` | `public IList<T> AsSequenceOrDefault<T>(List<T> defaultValue)` |
| `AsSequenceOrDefault<T>(keyPath, defaultValue)` | `public IList<T> AsSequenceOrDefault<T>(string keyPath, IList<T> defaultValue)` |

Requires the node to be of type `Sequence`; otherwise throws `InvalidOperationException`. Each element is converted using the following rules, in order:

1. If the element is already of type `T`, it is returned as-is.
2. If `T` is `DataNode`, the element is wrapped in a new `DataNode`.
3. If the element implements `IConvertible`, `Convert.ChangeType` is used.
4. Otherwise, `InvalidOperationException` is thrown.
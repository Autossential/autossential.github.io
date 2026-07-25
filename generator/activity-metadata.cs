public struct Root
{
    public List<ActivityMetadata> Activities { get; set; }
}
public struct ActivityMetadata
{
    public ActivityMetadata()
    {
        Properties = new();
    }
    public string CategoryKey { get; set; }
    public string DefaultFactory { get; set; }
    public string DescriptionKey { get; set; }
    public string DisplayNameKey { get; set; }
    public string FullName { get; set; }
    public string IconKey { get; set; }
    public List<ActivityPropertyMetadata> Properties { get; set; }
}

public struct ActivityPropertyMetadata
{
    public ActivityPropertyCategoryMetadata Category { get; set; }
    public string DisplayNameKey { get; set; }
    public bool IsRequired { get; set; }
    public bool IsVisible { get; set; }
    public string Name { get; set; }
    public string TooltipKey { get; set; }
}

public struct ActivityPropertyCategoryMetadata
{
    public string DisplayNameKey { get; set; }
    public string Name { get; set; }
}
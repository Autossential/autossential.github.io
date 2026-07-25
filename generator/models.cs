public class SidebarItem
{
    /// <summary>
    /// The text label of the item.
    /// </summary>
    public string? Text { get; set; }

    /// <summary>
    /// The link of the item.
    /// </summary>
    public string? Link { get; set; }

    /// <summary>
    /// The children of the item.
    /// </summary>
    public List<SidebarItem>? Items { get; set; }

    /// <summary>
    /// If not specified, group is not collapsible.
    ///
    /// If `true`, group is collapsible and collapsed by default
    ///
    /// If `false`, group is collapsible but expanded by default
    /// </summary>
    public bool? Collapsed { get; set; }

    /// <summary>
    /// Base path for the children items.
    /// </summary>
    public string? Base { get; set; }

    /// <summary>
    /// Customize text that appears on the footer of previous/next page.
    /// </summary>
    public string? DocFooterText { get; set; }

    public string? Rel { get; set; }
    
    public string? Target { get; set; }
}

public class Source
{
    public string MetadataFilePath { get; set; }
    public string IconsFolder { get; set; }
    public string OutputDocsFolder { get; set; }
    public SidebarItem RootItem { get; set; }
}
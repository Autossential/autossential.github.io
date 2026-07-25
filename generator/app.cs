#!/usr/bin/env dotnet

#pragma warning disable IL2026 // Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8601 // Possible null reference assignment.

#:package UiPath.Workflow@6.0.0-20240401-07
#:package UiPath.Activities.Api@24.10.1
#:package System.Activities.ViewModels@1.20260216.2
#:package System.Activities.Metadata@6.0.0-20240517.13
#:project D:\Development\Autossential.Activities\Autossential.Activities\Autossential.Activities.csproj
#:project D:\Development\Autossential.Workbook.Activities\Autossential.Workbook.Activities\Autossential.Workbook.Activities.csproj
#:include activity-metadata.cs
#:include models.cs
#:property PublishAot=false

using System.Text;
using System.Text.Json;
using System.Resources;
using static System.Console;

const string IMGS_OUTPUT_PATH = "docs\\imgs";

var core = new Source
{
    MetadataFilePath = @"D:\Development\Autossential.Activities\Autossential.Activities\Resources\ActivitiesMetadata.json",
    IconsFolder = @"D:\Development\Autossential.Activities\Autossential.Activities\Resources\Icons",
    OutputDocsFolder = "core",
    RootItem = new SidebarItem
    {
        Text = "Activities",
        Base = "/core/",
        Items = [new SidebarItem { Text = "Change Log", Link = "/changelog" }],
    }
};

var workbook = new Source
{
    MetadataFilePath = @"D:\Development\Autossential.Workbook.Activities\Autossential.Workbook.Activities\Resources\ActivitiesMetadata.json",
    IconsFolder = @"D:\Development\Autossential.Workbook.Activities\Autossential.Workbook.Activities\Resources\Icons",
    OutputDocsFolder = "workbook",
    RootItem = new SidebarItem
    {
        Text = "Workbook.Activities",
        Base = "/workbook/",
        Items = [new SidebarItem { Text = "Change Log", Link = "/changelog" }],
    }
};

WriteLine("Deleting existing docs...");
foreach (var docFile in Directory.EnumerateFiles($"docs\\{core.OutputDocsFolder}", "*.md").Concat(Directory.EnumerateFiles($"docs\\{workbook.OutputDocsFolder}", "*.md")))
{
    if (Path.GetFileName(docFile) == "changelog.md")
        continue;

    File.Delete(docFile);
}

GenerateDocs(
    Autossential.Activities.Properties.Resources.ResourceManager.GetResourceSet(System.Globalization.CultureInfo.InvariantCulture, true, true)!,
    core);

GenerateDocs(
    Autossential.Workbook.Activities.Properties.Resources.ResourceManager.GetResourceSet(System.Globalization.CultureInfo.InvariantCulture, true, true)!,
    workbook);

var sidebarItems = new List<SidebarItem>
{
    new()
    {
        Text = "Introduction",
        Base = "/",
        Items =
        [
            new SidebarItem { Text = "About", Link = "/about" }
        ],
        Collapsed = false
    },
    core.RootItem,
    workbook.RootItem,
};

var sidebarJson = JsonSerializer.Serialize(sidebarItems, new JsonSerializerOptions
{
    WriteIndented = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
});

WriteLine("Generating sidebar...");
File.WriteAllText("docs/.vitepress/sidebar.mts", $"export default {sidebarJson};", Encoding.UTF8);

WriteLine("Documentation generation completed successfully.");


static void GenerateDocs(
    ResourceSet resourceManager,
    Source source)
{
    var root = JsonSerializer.Deserialize<Root>(File.ReadAllText(source.MetadataFilePath), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
    foreach (var activity in root.Activities)
    {
        var category = resourceManager.GetString(activity.CategoryKey) ?? ".Uncategorized";
        category = category[(category.LastIndexOf('.') + 1)..];

        var categorySidebarItem = source.RootItem.Items!.FirstOrDefault(i => i.Text == category);
        if (categorySidebarItem is null)
        {
            categorySidebarItem = new SidebarItem
            {
                Text = category,
                Items = [],
                Collapsed = true
            };
            source.RootItem.Items!.Add(categorySidebarItem);
        }

        var name = resourceManager.GetString(activity.DisplayNameKey)!;
        WriteLine($"Generating documentation for activity: {name}...");

        var description = resourceManager.GetString(activity.DescriptionKey);
        var iconPath = Path.Combine(source.IconsFolder, activity.IconKey);
        var iconName = Path.GetFileName(iconPath);
        File.Copy(iconPath, Path.Combine(IMGS_OUTPUT_PATH, iconName), true);

        var sb = new StringBuilder();
        sb.AppendLine("<h1>");
        sb.AppendLine($@"<img src=""../imgs/{iconName}"" width=""32"" height=""32"" />");
        sb.AppendLine(name);
        sb.AppendLine("</h1>");
        sb.AppendLine();
        sb.AppendLine(description);

        if (activity.Properties is not null && activity.Properties.Count > 0)
        {
            sb.AppendLine();
            sb.AppendLine("## Properties");
            sb.AppendLine();
            sb.AppendLine("| Name | Description | Required |");
            sb.AppendLine("|------|-------------|:--------:|");

            foreach (var prop in activity.Properties)
            {
                var propName = resourceManager.GetString(prop.DisplayNameKey);
                var propDescription = resourceManager.GetString(prop.TooltipKey)?.Replace("<", "&lt;").Replace("|", "&vert;");
                var required = prop.IsRequired ? ":ballot_box_with_check:" : "";
                sb.AppendLine($"| {propName} | {propDescription} | {required} |");
            }
        }

        sb.AppendLine();
        AddExtraContent(name, sb);

        // # Add range
        var fileName = $"{name.ToLower().Replace(" ", "-").Replace("/", "-")}.md";
        var target = Path.Combine($"docs\\{source.OutputDocsFolder}", fileName);
        File.WriteAllText(target, sb.ToString(), Encoding.UTF8);

        categorySidebarItem.Items!.Add(new SidebarItem
        {
            Text = name,
            Link = Path.GetFileNameWithoutExtension(fileName)
        });
    }
}

static void AddExtraContent(string name, StringBuilder sb)
{
    var expectedFileName = $"{name.ToLower().Replace(" ", "-").Replace("/", "-")}.md";
    if (File.Exists($"./docs/extras/{expectedFileName}"))
        sb.AppendLine($"<!--@include: ../extras/{expectedFileName}-->");
}

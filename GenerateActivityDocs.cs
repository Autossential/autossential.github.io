#pragma warning disable IL2026 // Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8601 // Possible null reference assignment.

#:package UiPath.Workflow@6.0.0-20240401-07
#:package UiPath.Activities.Api@24.10.1
#:package System.Activities.ViewModels@1.20260216.2
#:package System.Activities.Metadata@6.0.0-20240517.13
#:project D:\Development\Autossential-4\Autossential.Activities\Autossential.Activities.csproj

using System.Activities;
using System.Reflection;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Autossential.Activities;

var types = Assembly.Load("Autossential.Activities").GetTypes()
    .Where(t =>
        t.IsClass
        && t.IsPublic
        && typeof(Activity).IsAssignableFrom(t)
        && !t.IsAbstract
    ).ToList();

var resourceManager = Autossential.Activities.Properties.Resources.ResourceManager.GetResourceSet(System.Globalization.CultureInfo.InvariantCulture, true, true)!;

foreach (var type in types)
{
    var name = type.Name.TrimEnd("`1").TrimEnd("`2").ToString();
    var displayNameKey = $"{name}_DisplayName";
    var descriptionKey = $"{name}_Description";

    string displayName = resourceManager.GetString(displayNameKey) ?? type.Name;
    string description = resourceManager.GetString(descriptionKey) ?? "";

    var sb = new StringBuilder();
    sb.AppendLine($"# {displayName}");
    sb.AppendLine();
    sb.AppendLine(description);
    sb.AppendLine();
    sb.AppendLine($"![](imgs/{name}.png)");
    sb.AppendLine();

    var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(prop =>
        prop.Name != "Body"
        && prop.Name != "Id"
        && prop.Name != "DisplayName"
        && prop.DeclaringType != typeof(ActivityWithResult)).ToArray();

    if (props.Length > 0)
    {
        sb.AppendLine("### Properties").AppendLine();
        sb.AppendLine("| Name | Description | Required |");
        sb.AppendLine("|------|-------------|----------|");

        foreach (var prop in props)
        {
            var resourceActivityName = name;
            if (new[] { "SearchPattern", "TimeoutSeconds", "ContinueOnError" }.Contains(prop.Name))
            {
                resourceActivityName = "Common";
            }

            var propDisplayNameKey = $"{resourceActivityName}_{prop.Name}_DisplayName";
            var propDescriptionKey = $"{resourceActivityName}_{prop.Name}_Description";
            var required = prop.GetCustomAttribute<RequiredArgumentAttribute>() != null ||
                           prop.GetCustomAttribute<RequiredAttribute>() != null;

            string propDisplayName = resourceManager.GetString(propDisplayNameKey) ?? prop.Name;
            string propDescription = resourceManager.GetString(propDescriptionKey) ?? "";
            sb.AppendFormat("| {0} | {1} | {2} |", propDisplayName.Replace("|", "\\|"), propDescription.Replace("|", "\\|"), required ? "✓" : "");
            sb.AppendLine();
        }
    }

    AddCustomContent(type, sb);
    File.WriteAllText($"source/docs/{name}.md", sb.ToString(), Encoding.UTF8);
    Console.WriteLine($"Generated docs for: {name}");
}

void AddCustomContent(Type type, StringBuilder sb)
{
    sb.AppendLine();
    switch (type.Name)
    {
        case nameof(ParseData):
        case nameof(MergeData):
        case nameof(LoadDataFile):
            sb.AppendLine("!!! info \"Result\"");
            sb.AppendLine("\tRead more about [DataNode](models/DataNode.md) resulting type.");
            break;
        case nameof(Container):
            sb.AppendLine("### Usage").AppendLine();
            sb.AppendLine("The **Container** activity has no effect if not combined with [Exit](Exit.md) activity.").AppendLine();
            sb.AppendLine("With these two activities, we can avoid nested conditional Ifs or exit early from a workflow wrapped in a **Container**.").AppendLine();
            sb.AppendLine("Consider the below code:").AppendLine();
            sb.AppendLine("![](imgs/Container_Sample.png)").AppendLine();
            sb.AppendLine("Only the messages *\"First\"* and *\"Third\"* will be printed out.").AppendLine();
            sb.AppendLine("Based on its condition, the **Exit** activity tells to **Container** interrupt its execution. Then, the process flow continues to the next activity.").AppendLine();
            sb.AppendLine("Below is an abstraction of what happens to the execution flow:").AppendLine();
            sb.AppendLine("![](imgs/Container_Flow.png)").AppendLine();
            sb.AppendLine("Everything that is below the **Exit** activity and inside the **Container** will be ignored/skipped and the execution flow will continue to the next activity after the **Container**.").AppendLine();
            sb.AppendLine("This is very useful to avoid nested Ifs and to exit early from a workflow when certain conditions are not met.").AppendLine();
            sb.AppendLine("=== \"Nested Ifs\"").AppendLine();
            sb.AppendLine("\t![](imgs/Container_NestedIfs.png)").AppendLine();
            sb.AppendLine("=== \"Flow Chart\"").AppendLine();
            sb.AppendLine("\t![](imgs/Container_FlowChart.png)").AppendLine();
            sb.AppendLine("=== \"Container & Exit\"").AppendLine();
            sb.AppendLine("\t![](imgs/Container_Sample2.png)").AppendLine();
            break;
    }
}
Replaces the tokens of a string by the values of a Dictionary. Tokens are strings written in a specific pattern, usually enclosed in special characters. Use the combination of 'Pattern' and 'Placeholder' properties to define your token format.

![](../img/activities/ReplaceTokens.png)

##### Properties

|Name       |Description                                                                            |
|-----------|---------------------------------------------------------------------------------------|
|Content    |The text which contains the tokens to be replaced.                                     |
|Dictionary |The dictionary where each key/value pair are used to replace the tokens.               |
|Pattern    |The token text pattern. It can have characters either before and after the placeholder.|
|Placeholder|The placeholder where each dictionary key will found.                                  |
|Result     |The content after the tokens replacement be performed.                                 |


##### Usage

Lets consider the email template as content:

> *Dear <span class="red">{{</span>Business<span class="red">}}</span>,*

> *The <span class="red">{{</span>ProcessName<span class="red">}}</span> ran successfully today (<span class="red">{{</span>DateTime<span class="red">}}</span>).*

> *The consolidated report can be found attached.*

> *Regards,*<br/>*<span class="red">{{</span>ProcessTeam<span class="red">}}</span>*

And the below dictionary for token replacement:

```C#
Dictionary<string, object>
{
    {"Business", "John Connor"},
    {"ProcessName", "Terminator Bot"},
    {"DateTime", "02-Jul-2022"},
    {"ProcessTeam", "Resistence"}
}
```

The output results:

> *Dear John Connor,*

> *The Terminator Bot ran successfully today (02-Jul-2022).*

> *The consolidated report can be found attached.*

> *Regards,*<br/>*Resistence*

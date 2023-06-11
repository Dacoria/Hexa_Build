using System.Collections.Generic;

public class TooltipTexts
{
    public string Header;
    public string Content;

    public TooltipTexts(string header, string content)
    {
        Header = header;
        Content = content;
    }

    public TooltipTexts(string header, List<string> content)
    {
        Header = header;
        Content = string.Join("\n", content);
    }
}
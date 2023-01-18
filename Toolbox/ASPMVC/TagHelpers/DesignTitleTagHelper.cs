using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Toolbox.ASPMVC.TagHelpers
{
    [HtmlTargetElement("design-title")]
    public class DesignTitleTagHelper : TagHelper
    {
        public string TitleContent { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName= "h1";
            output.TagMode= TagMode.StartTagAndEndTag;
            output.Content.Append(TitleContent);
            output.Attributes.Add("style", "text-decoration:underline;");
        }
    }
}

using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Toolbox.ASPMVC.TagHelpers
{
    [HtmlTargetElement("validation-div")]
    public class ModelBasedTagHelper : TagHelper
    {
        [HtmlAttributeName("validation-for")]
        public ModelExpression FormProperty { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName= "div";
            output.TagMode= TagMode.StartTagAndEndTag;
            string propertyName = FormProperty.Name;
            string propertyValue = FormProperty.Model?.ToString() ?? ""; 
            output.Content.AppendHtml($"<h3>{propertyName} :</h3>");
            output.Content.AppendHtml($"<p>{propertyValue}</p>");
        }
    }
}

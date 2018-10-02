using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap01.TagHelpers
{
    public class Email :TagHelper
    {
        public string MailTo { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            var address = $"{MailTo}@fiap.com";
            output.Attributes.SetAttribute("href", $"mailto:{address}");
            output.Content.SetContent(address);
            
        }
    }

    [HtmlTargetElement("label", Attributes = ForAttributeName)]
    public class LabelRequiredTagHelper : LabelTagHelper
    {
        private const string ForAttributeName = "asp-for";

        public LabelRequiredTagHelper(IHtmlGenerator generator) : base(generator)
        {
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await base.ProcessAsync(context, output);
            var data = new DateTime();
            //if (For.Metadata.IsRequired)
            if (DateTime.TryParse(For.Model.ToString(), out data))
            {

                output.Content.AppendHtml("<input type=\"date\" value=\"" + data.ToString("yyyy-MM-dd") + "\">");
            }
        }
    }
}

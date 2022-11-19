using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dextermd.ITDeveloper.Mvc.Extensions.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string Domain { get; set; } = "eaditdeveloper.md";
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName =  "a";
            var prefix = await output.GetChildContentAsync();
            var myemail = prefix.GetContent() + "@" + Domain;
            output.Attributes.SetAttribute("href", "mailto:" + myemail);
            output.Content.SetContent(myemail);
        }
    }
}

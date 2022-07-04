using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Micheal.Bookstore.Helpers
{
    public class CustomEmailTagHelper: TagHelper
    {
        public string MyEmail { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.Add("id", "my-email-id");
            output.Attributes.SetAttribute("href", $"mailto:{MyEmail}");
            output.Content.SetContent("my-email");

        }
    }
}

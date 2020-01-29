using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Cities.Infrastructure.TagHelpers
{
    //[HtmlTargetElement("button", Attributes = "bs-button-color", ParentTag = "form")]
    //[HtmlTargetElement(Attributes = "bs-button-color", ParentTag = "form")]
    [HtmlTargetElement("button", Attributes = "bs-button-color", ParentTag = "form")]
    [HtmlTargetElement("a", Attributes = "bs-button-color", ParentTag = "form")]
    [HtmlTargetElement("button", Attributes = "bs-button-*", ParentTag = "form")]
    public class ButtonTagHelper : TagHelper
    {
        public override int Order => int.MaxValue; // last tag helper on any tag to run

        public string BsButtonColor { get; set; } // => bs-button-color: danger, bs-button-theme: null

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {            
            // bs-button-color="BsButtonColor" := class="btn btn-{BsButtonColor}"
            output.Attributes.SetAttribute("class", $"btn btn-{BsButtonColor}");
        }

        //public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        //{
        //    // ...
        //}
    }
}
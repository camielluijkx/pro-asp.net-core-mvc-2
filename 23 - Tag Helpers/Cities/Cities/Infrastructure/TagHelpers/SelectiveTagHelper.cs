using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Cities.Infrastructure.TagHelpers
{
    [HtmlTargetElement(Attributes = "show-for-action")]
    public class SelectiveTagHelper : TagHelper
    {
        public string ShowForAction { get; set; }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // <div show-for-action="Index" class="m-1 p-1 bg-danger"> => shows on Home/Index, not on Home/Create
            if (!ViewContext.RouteData.Values["action"].ToString()
                .Equals(ShowForAction, StringComparison.OrdinalIgnoreCase))
            {
                output.SuppressOutput();
            }
        }
    }
}
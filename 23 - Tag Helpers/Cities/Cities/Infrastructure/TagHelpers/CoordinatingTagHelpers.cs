using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Cities.Infrastructure.TagHelpers
{
    /*
     
     <div theme="primary">
        <button type="submit">Add</button>
        <button type="reset">Reset</button>
        <a href="/Home/Index">Cancel</a>
    </div>
    
        :=
         
     <div>
        <button type="submit" class="btn btn-primary">Add</button>
        <button type="reset" class="btn btn-primary">Reset</button>
        <a href="/Home/Index" class="btn btn-primary">Cancel</a>
    </div>
    
    */
    [HtmlTargetElement("div", Attributes = "theme")]
    public class ButtonGroupThemeTagHelper : TagHelper
    {
        public string Theme { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            context.Items["theme"] = Theme;
        }
    }

    [HtmlTargetElement("button", ParentTag = "div")]
    [HtmlTargetElement("a", ParentTag = "div")]
    public class ButtonThemeTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context.Items.ContainsKey("theme"))
            {
                output.Attributes.SetAttribute("class",
                    $"btn btn-{context.Items["theme"]}");
            }
        }
    }
}
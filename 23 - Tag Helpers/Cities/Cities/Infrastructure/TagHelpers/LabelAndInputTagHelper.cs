using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Cities.Infrastructure.TagHelpers
{
    [HtmlTargetElement("label", Attributes = "helper-for")]
    [HtmlTargetElement("input", Attributes = "helper-for")]
    public class LabelAndInputTagHelper : TagHelper
    {
        public ModelExpression HelperFor { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (output.TagName == "label")
            {
                // <label helper-for="ABC" /> := <label for="ABC">ABC</label>
                output.TagMode = TagMode.StartTagAndEndTag;
                output.Content.Append(HelperFor.Name);
                output.Attributes.SetAttribute("for", HelperFor.Name);
            }
            else if (output.TagName == "input")
            {
                // <input helper-for="ABC" /> := <input name="ABC" class="form-control" />
                output.TagMode = TagMode.SelfClosing;
                output.Attributes.SetAttribute("name", HelperFor.Name);
                output.Attributes.SetAttribute("class", "form-control");

                if (HelperFor.Metadata.ModelType == typeof(int?))
                {
                    // <input name="Population" class="form-control" type="number" />
                    output.Attributes.SetAttribute("type", "number");
                }
            }
        }
    }
}
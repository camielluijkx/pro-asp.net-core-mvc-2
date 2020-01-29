using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Cities.Infrastructure.TagHelpers
{
    [HtmlTargetElement("td", Attributes = "wrap")]
    public class TableCellTagHelper : TagHelper
    {
        //public string Wrap { get; set; } = null;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // <td wrap>@city.Name</td> := <td wrap><b><i>{city.Name}</i></b></td>
            output.PreContent.SetHtmlContent("<b><i>");
            output.PostContent.SetHtmlContent("</i></b>");
        }
    }
}
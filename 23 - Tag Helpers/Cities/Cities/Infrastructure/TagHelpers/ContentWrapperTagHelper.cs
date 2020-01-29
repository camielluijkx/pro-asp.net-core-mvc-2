using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Cities.Infrastructure.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "title")]
    public class ContentWrapperTagHelper : TagHelper
    {
        public bool IncludeHeader { get; set; } = true;

        public bool IncludeFooter { get; set; } = true;

        public string Title { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", "m-1 p-1");

            if (IncludeHeader)
            {
                // adds <div class="bg-info m-1 p-1"><h1>Cities</h1></div> before @RenderBody()
                TagBuilder headerTitle = new TagBuilder("h1");
                headerTitle.InnerHtml.Append(Title);

                TagBuilder headerContainer = new TagBuilder("div");
                headerContainer.Attributes["class"] = "bg-info m-1 p-1";
                headerContainer.InnerHtml.AppendHtml(headerTitle);

                output.PreElement.SetHtmlContent(headerContainer);
            }

            if (IncludeFooter)
            {
                // adds <div class="bg-info m-1 p-1"><h4>Cities</h4></div> after @RenderBody()
                TagBuilder footerTitle = new TagBuilder("h4");
                footerTitle.InnerHtml.Append(Title);

                TagBuilder footerContainer = new TagBuilder("div");
                footerContainer.Attributes["class"] = "bg-info m-1 p-1";
                footerContainer.InnerHtml.AppendHtml(footerTitle);

                output.PostElement.SetHtmlContent(footerContainer);
            }
        }
    }
}
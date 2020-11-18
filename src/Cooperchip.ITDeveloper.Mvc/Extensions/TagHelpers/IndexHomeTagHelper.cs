using Microsoft.AspNetCore.Razor.TagHelpers;
namespace Cooperchip.ITDeveloper.Mvc.Extentions.TagHelpers
{
    public class IndexHomeTagHelper : TagHelper
    {
        [HtmlAttributeName("titulo")]
        public string Titulo { get; set; }
        [HtmlAttributeName("imagem")]
        public string Imagem { get; set; }
        [HtmlAttributeName("controlador")]
        public string Controlador { get; set; }
        [HtmlAttributeName("visualizacao")]
        public string Visualizacao { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "session";

            output.Content.AppendHtml("<div class='col-md-3 col-sm-3 col-sx-12' style='padding-bottom: 15px; '>");
            output.Content.AppendHtml("<div class='card card-inverse text-md-center text-sm-center text-xs-center'>");
            output.Content.AppendHtml("<img src='/images/" + Imagem + "' class='card-img-top' style='width: 100%; height: auto;' />");

            output.Content.AppendHtml("<div class='card-img-overlay'>");
            output.Content.AppendHtml("<div style='text-align: center;'>");
            output.Content.AppendHtml("<a href='/" + Controlador + "/" + Visualizacao + "' style='text-decoration: none; color: #ed5353; font-size: 16px;' >");
            output.Content.AppendHtml("<h4 class='card-title'>" + Titulo + "</h4>");
            output.Content.AppendHtml("</a></div></div></div></div>");

        }
    }
}

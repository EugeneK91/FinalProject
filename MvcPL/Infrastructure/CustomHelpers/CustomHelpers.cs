using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPL.Infrastructure.Mappers;
using WebGrease.Css.Extensions;

namespace MvcPL.Infrastructure.CustomHelpers
{
    public static class CustomHelpers
    {
        public static MvcHtmlString Image(this HtmlHelper html, byte[] image,string[] clas=null,object htmlAttributes =null)
        {
            TagBuilder tag = new TagBuilder("img");

            var src =image.Length == 0? "/Content/images/default_avatar.png" :  "data:image/jpeg;base64," + Convert.ToBase64String((image));
            tag.MergeAttribute("src", src);
            tag.AddCssClass("img-responsive");

            

            if (clas != null && clas.Any())
            {
                clas.ForEach(c=>tag.AddCssClass(c));
            }
            if (htmlAttributes != null)
            {
                var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                tag.MergeAttributes(attributes);
            }
            else
            {
                tag.MergeAttribute("style", "height: 40px; width: 40px;margin: 0 auto;");
            }


            return new MvcHtmlString(tag.ToString());
        }
    }
}
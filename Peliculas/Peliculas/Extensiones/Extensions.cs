using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Peliculas.Extensiones
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> html, Expression<Func<TModel, TEnum>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var enumType = Nullable.GetUnderlyingType(metadata.ModelType) ?? metadata.ModelType;
            var enumValues = Enum.GetValues(enumType).Cast<object>();
            var items = enumValues.Select(item =>
            {
                var type = item.GetType();
                var member = type.GetMember(item.ToString());
                var attribute = member[0].GetCustomAttribute<DisplayAttribute>();
                string text = attribute != null ? ((DisplayAttribute)attribute).Name : item.ToString();
                //string value = ((int)item).ToString();
                string value = item.ToString();
                bool selected = item.Equals(metadata.Model);
                return new SelectListItem
                {
                    Text = text,
                    Value = value,
                    Selected = selected
                };
            });
            return html.DropDownListFor(expression, items, string.Empty, null);

        }

        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }
    }


}
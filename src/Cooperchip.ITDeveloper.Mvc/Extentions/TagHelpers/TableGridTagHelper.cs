
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Cooperchip.ITDeveloper.Mvc.Extentions.TagHelpers
{
    public class TableGridTagHelper : TagHelper
    {
        [HtmlAttributeName("Items")]
        public IEnumerable<object> Items { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "table";
            output.Attributes.Add("class", "table table-bordered table-hover");
            var props = GetItemProperties();
            TableHeader(output, props);
            TableBody(output, props);
        }
        private void TableHeader(TagHelperOutput output, PropertyInfo[] props)
        {
            output.Content.AppendHtml("<thead>");
            output.Content.AppendHtml("<tr>");
            foreach (var prop in props)
            {
                if (!prop.PropertyType.ToString().Contains("System.Collection"))
                {
                    var name = GetPropertyName(prop);
                    output.Content.AppendHtml(!name.Equals("Id") ? $"<th>{name}</th>" : $"<th>Ação</th>");
                }
            }
            output.Content.AppendHtml("</tr>");
            output.Content.AppendHtml("</thead>");
        }
        private void TableBody(TagHelperOutput output, PropertyInfo[] props)
        {
            string model = String.Empty;
            output.Content.AppendHtml("<tbody>");
            foreach (var item in Items)
            {
                output.Content.AppendHtml("<tr>");
                foreach (var prop in props)
                {
                    var value = GetPropertyValue(prop, item);
                    if (prop.Name.Equals("Id"))
                    {
                        model = prop.ReflectedType.Name;
                        output.Content.AppendHtml($"<td><a href='/{model}/Details/{value}' ><span class='fa fa-search fa-2x' title='Detalhes'></a>");
                        output.Content.AppendHtml($"<a href='/{model}/Edit/{value}' ><span class='fa fa-pencil-square fa-2x'  title='Editar'></a>");
                        output.Content.AppendHtml($"<a href='/{model}/Delete/{value}' ><span class='fa fa-trash fa-2x'  title='Excluir'></a></td>");
                    } else {
                        if (!prop.PropertyType.ToString().Contains("Collection"))
                            output.Content.AppendHtml($"<td>{value}</td>");
                    }
                }
                output.Content.AppendHtml("</tr>");

                // <span class="fa fa-pencil-square fa-2x" title="Editar Paciente"></span>
            }
            output.Content.AppendHtml("</tbody>");
        }

        private PropertyInfo[] GetItemProperties()
        {
            var listType = Items.GetType();
            if (listType.IsGenericType)
            {
                Type itemType = listType.GetGenericArguments().First();
                return itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            }
            return new PropertyInfo[] { };
        }

        /// <summary>
        /// ------------------------------------------------------------------ //
        /// //Funciona com essa notação: [DisplayName(displayName:"Descrição")]
        /// var attribute = property.GetCustomAttribute<DisplayNameAttribute>();
        /// if (attribute != null)
        /// {
        ///     return attribute.DisplayName; // Muda aqui
        /// }
        /// return property.Name;
        /// ------------------------------------------------------------------ // 
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>

        private string GetPropertyName(PropertyInfo property)
        {


            // Funciona com essa notação: [Display(Name = "Estado do Paciente")]
            var attribute = property.GetCustomAttribute<DisplayAttribute>();
            if (attribute != null)
            {
                return attribute.Name; // Muda aqui
            }
            return property.Name;


        }
        private object GetPropertyValue(PropertyInfo property, object instance)
        {
            return property.GetValue(instance);
        }
    }
}
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Dextermd.ITDeveloper.Mvc.Extensions.TagHelpers
{
    public class TableGridTagHelper : TagHelper
    {
        [HtmlAttributeName("Items")]
        public IEnumerable<object> Items { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "table";
            output.Attributes.Add("class", "table table-bordered table-horver");
            var props = GetItemsProperties();
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
                    output.Content.AppendHtml(!name.Equals("Id") ? $"<th>{name}</th>" : $"<th>Action</th>");
                }
            }
            output.Content.AppendHtml("</th>");
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
                        output.Content.AppendHtml($"<td><a href='/{model}/Details/{value}' <span class='fa fa-search fa-2x' title='Details'></a>&nbsp;&nbsp;");
                        output.Content.AppendHtml($"<a href='/{model}/Edit/{value}' <span class='fa fa-pencil-square fa-2x' title='Edit'></a>&nbsp;&nbsp;");
                        output.Content.AppendHtml($"<a href='/{model}/Delete/{value}' <span class='fa fa-trash fa-2x' title='Delete'></a>&nbsp;&nbsp;</td>");
                    }
                    else
                    {
                        if (!prop.PropertyType.ToString().Contains("Collection"))
                        {
                            output.Content.AppendHtml($"<td>{value}</td>");
                        }
                    }
                }
                output.Content.AppendHtml("</tr>");

            }
            output.Content.AppendHtml("</tbody>");
        }


        private string GetPropertyName(PropertyInfo property)
        {
            var attribute = property.GetCustomAttribute<DisplayAttribute>();
            if (attribute != null)
            {
                return attribute.Name;
            }
            return property.Name;
        }

        private object GetPropertyValue(PropertyInfo property, object instance)
        {
            return property.GetValue(instance);
        }

        private PropertyInfo[] GetItemsProperties()
        {
            var listType = Items.GetType();
            if (listType.IsGenericType)
            {
                Type itemType = listType.GetGenericArguments().First();
                return itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            }
            return new PropertyInfo[] {};
        }
    }
}

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Text.Encodings.Web;

namespace _04_Products_Model_.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime CreatedDate { get; set; }

        public Product(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
            CreatedDate = DateTime.Now;
        }

        public HtmlString CreateList()
        {
            var ul = new TagBuilder("ul");

            ul.InnerHtml.AppendHtml(CreateTag("li", $"Id: {Id}"));
            ul.InnerHtml.AppendHtml(CreateTag("li", $"Name: {Name}"));
            ul.InnerHtml.AppendHtml(CreateTag("li", $"Cost: {Price}"));
            ul.InnerHtml.AppendHtml(CreateTag("li", $"Create date: {CreatedDate}"));

            using var resultWriter = new StringWriter();
            ul.WriteTo(resultWriter, HtmlEncoder.Default);
            return new HtmlString(resultWriter.ToString());
        }

        public HtmlString CreateTableRow()
        {
            var tr = new TagBuilder("tr");

            tr.InnerHtml.AppendHtml(CreateTag("td", Id.ToString()));
            tr.InnerHtml.AppendHtml(CreateTag("td", Name));
            tr.InnerHtml.AppendHtml(CreateTag("td", Price.ToString()));
            tr.InnerHtml.AppendHtml(CreateTag("td", CreatedDate.ToString()));

            using var resultWriter = new StringWriter();
            tr.WriteTo(resultWriter, HtmlEncoder.Default);
            return new HtmlString(resultWriter.ToString());
        }

        private TagBuilder CreateTag(string tag, string str)
        {
            var newTag = new TagBuilder(tag);
            newTag.InnerHtml.Append(str);

            return newTag;
        }
    }
}

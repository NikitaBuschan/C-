using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace _03_FlowersShop.Models
{
    public class Address
    {
        public string Streat { get; set; }
        public string Number { get; set; }
        public int? Entrance { get; set; }
        public int? Floor { get; set; }


        public Address(string streat, string number)
        {
            Streat = streat;
            Number = number;
            Entrance = null;
            Floor = null;
        }

        public Address(string streat, string number, int floor) : this(streat, number) => Floor = floor;

        public Address(string streat, string number, int entrance, int floor) : this(streat, number, floor) => Entrance = entrance;

        public List<HtmlString> CreateAddress()
        {
            var strings = new List<HtmlString>();
            strings.Add(new HtmlString(Streat));
            strings.Add(new HtmlString(Number));
            strings.Add(new HtmlString(Entrance.ToString()));
            strings.Add(new HtmlString(Floor.ToString()));

            return strings;
        }
    }
}

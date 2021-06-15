using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Fridges
{
    public class XmlLib
    {
        private static XAttribute SetAttribute(string attr, string value) =>
            new XAttribute(attr, value);

        private static XElement SetElement(string element, string value) =>
            new XElement(element, value);

        private static XElement CreateElement(XAttribute attr, List<XElement> elements, string name)
        {
            XElement element = new XElement(name);
            element.Add(attr);
            foreach (var item in elements)
                element.Add(item);

            return element;
        }

        public static XElement CreateSeller(string name, int age) =>
            CreateElement(SetAttribute("Name", name),
                new List<XElement>()
                {
                    SetElement("Name", name),
                    SetElement("Age", age.ToString()),
                },
                "Seller");

        public static XElement CreateFridge(string model, string company, string color, int cost) =>
            CreateElement(SetAttribute("Model", model),
                new List<XElement>()
                {
                    SetElement("Company", company),
                    SetElement("Color", color),
                    SetElement("Cost", cost.ToString())
                },
                "Fridge");

        public static XElement CreateReceipt(int number, XElement Seller, XElement Fridge) =>
            CreateElement(SetAttribute("number", number.ToString()),
                new List<XElement>()
                {
                    SetElement("Date", DateTime.Now.ToString()),
                    Seller,
                    Fridge
                },
                "Receipt");

        public static void SaveReceipt(string path, XElement Receipt)
        {
            XDocument xmlDocument = new XDocument();
            xmlDocument.Add(Receipt);
            xmlDocument.Save(path);
        }
    }
}

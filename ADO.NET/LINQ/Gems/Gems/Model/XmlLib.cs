using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Gems.Model
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

        public static XElement CreateGem(string name, string color, bool opacity, string type, string desctiption) =>
            CreateElement(SetAttribute("Name", name),
                new List<XElement>()
                {
                    SetElement("Name", name),
                    SetElement("Color", color),
                    SetElement("Opacity", opacity == true ? "true" : "false"),
                    SetElement("Type", type),
                    SetElement("Description", desctiption),
                },
                "Gem");

        public static XElement CreateGems()
        {
            using (var db = new GemContext())
            {
                List<XElement> list = new List<XElement>();

                var gems = from a in db.Gems
                           select new
                           {
                               ID = a.ID,
                               Name = a.Name,
                               Color = a.Color,
                               Opacity = a.Opacity,
                               Type = a.Type.Name,
                               Desctiption = a.Description
                           };

                foreach (var gem in gems)
                    list.Add(XmlLib.CreateGem(gem.Name, gem.Color, gem.Opacity, gem.Type, gem.Desctiption));

                return CreateElement(SetAttribute("Gems", "Gems"), list, "Gems");
            }
        }

        public static void SaveFile(string path, XElement gems)
        {
            XDocument xmlDocument = new XDocument();

            xmlDocument.Add(gems);
            xmlDocument.Save(path);
        }
    }
}

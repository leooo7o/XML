// File: "LinqXml73"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            Task("LinqXml73");
            string name = GetString();
            XDocument d = XDocument.Load(name);
            XNamespace ns = d.Root.Name.Namespace;
            string[] brand = { "b92", "b95", "b98" };
            d.Root.ReplaceNodes(d.Root.Elements().Elements()
                .Select(e =>
                {
                    return new
                    {
                        street = e.Attribute("name").Value + "_" + e.Ancestors().First().Name.LocalName,
                        brand = "b" + e.Element(ns + "brand").Value,
                        price = e.Element(ns + "price").Value
                    };
                }).OrderBy(e => e.street).ThenBy(e => e.brand).GroupBy(e => e.street,(k, ee) => new XElement(ns + k, new XAttribute("brand-count", ee.Select(c => c.brand).Count().ToString()),ee.GroupJoin(brand, e1 => e1.brand, e2 => e2,
                (e1, ee2) => new XElement(ns + e1.brand,new XAttribute("price", e1.price))))) .Where(e => int.Parse(e.Attribute("brand-count").Value) >= 2));
            d.Save(name);
        }
    }
}

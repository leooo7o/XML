// File: "LinqXml67"
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
            Task("LinqXml67");
            string name = GetString();
            XDocument d = XDocument.Load(name);
            XNamespace ns = d.Root.Name.Namespace;
            var a = d.Root.Elements()
    .Select(e => e.Attribute("id").Value).Show();
    //Select(e =>
    //{
    //    return new
    //    {
    //        year = "a"+e.Element("name").Value,            
    //        mon = "a" + e.Element("month").Value,
    //        id = "a" + e.Attribute("id").Value,
    //        time = "a" + e.Attribute("time").Value
    //    };
    //}).Show();
        }
    }
}

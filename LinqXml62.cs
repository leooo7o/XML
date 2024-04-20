// File: "LinqXml62"
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
            Task("LinqXml62");
            string name = GetString();
            XDocument d = XDocument.Load(name);
            //d.Root.Elements().OrderBy(a=>int.Parse(a.Attribute("id").Value)).Show();
            d.Root.ReplaceNodes(d.Root.Elements().OrderBy(a => int.Parse(a.Attribute("id").Value)).Select(e => new XElement(d.Root.Name.Namespace+"id" + e.Attribute("id").Value,new XAttribute("date", e.Attribute("year").Value+"-"+e.Attribute("month").Value),new XAttribute("stu",1))));
            d.Save(name);
        }
    }
}

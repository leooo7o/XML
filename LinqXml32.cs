// File: "LinqXml32"
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
            Task("LinqXml32");
            Task("LinqXml32");
            string name = GetString(), s1 = GetString(), s2 = GetString();
            XDocument d = XDocument.Load(name);
            foreach (var e in d.Root.Elements().Elements(s1))
                e.AddBeforeSelf(new XElement(s2,
                e.LastAttribute, e.Elements().FirstOrDefault()));
            d.Save(name);
        }
    }
}

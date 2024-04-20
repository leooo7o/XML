// File: "LinqXml39"
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
            Task("LinqXml39");
            string name = GetString();
            XDocument d = XDocument.Load(name);
            var a=d.Root.Descendants().Reverse();
            foreach(var e in a)
            {
                e.Name = e.Parent.Name + "-" + e.Name;
            }
            d.Save(name);
        }
    }
}

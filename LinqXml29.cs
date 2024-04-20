// File: "LinqXml29"
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
            Task("LinqXml29");
            string name = GetString();
            XDocument d = XDocument.Load(name);
            d.Root.Elements().Elements().Where(e => e.Nodes().Count() == 0).Remove();
            d.Root.Elements().Where(a=>a.Nodes().Count()==0).Remove();
            //d.Root.Elements().Nodes().OfType<XElement>().Show().Where(a=> { return !a.HasElements; }).Remove();
            //d.Root.Elements().Elements().Where(a => { return !a.HasElements; }).Nodes().Remove();
            d.Save(name);
        }
    }
}

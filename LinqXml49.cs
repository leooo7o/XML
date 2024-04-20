// File: "LinqXml49"
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
            Task("LinqXml49");
            string name = GetString();
            string s = GetString();
            XDocument d = XDocument.Load(name);
            var xa = new XAttribute("total-time",d.Root.Descendants().Attributes(s).Select(e => (TimeSpan?)e??new TimeSpan(24, 0, 0)) .Aggregate(TimeSpan.Zero, (a, e) => a + e));
            Show(xa);
            d.Root.Add(xa);
            d.Save(name);
        }
    }
}

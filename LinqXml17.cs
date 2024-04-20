// File: "LinqXml17"
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
            Task("LinqXml17");
            XDocument d = XDocument.Load(GetString());
            var result = d.Root.DescendantNodes().OfType<XText>().Where(e => e.Value != "").Select(e => new{name = e.Parent.Name.LocalName,s = e.Value}).OrderBy(e => e.name).GroupBy(e => e.name).Show();
            foreach (var a in result)
            {
                Put(a.Key);
                var x = a.Select(e => e.s);
                foreach (var v in x)
                    Put(v);
            }
            //Select(e => new { key = e.Name.LocalName, word =e.Descendants().OfType<XText>()}).Show().OrderBy(e=>e.key).GroupBy(e=>e.key).Show();
            //foreach (var e in area)
            //{
            //Put(e.Key);
            //foreach (var a in e)
            {
                   // Put(a.word);
                }
            //}
        }
    }
}

// File: "LinqXml85"
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
            Task("LinqXml85");
            string name = GetString();
            XDocument d = XDocument.Load(name);
            XNamespace ns = d.Root.Name.Namespace;
            var a = d.Root.Elements()
            .Select(e =>
            {
                return new
                {
                    id = int.Parse(e.Attribute("class").Value),
                    name =e.Attribute("name").Value,
                    sub = e.Attribute("subject").Value,
                    score= e.Attribute("mark").Value
                };
            });
            var b=a.OrderBy(e => e.id).ThenBy(e => e.name).ThenBy(e => e.sub).ThenByDescending(e=>e.score).GroupBy(e=>e.id);
            XNamespace xml=d.Root.Name.Namespace;
            XElement res= new XElement(ns+"pupils");
            foreach (var qq in b)
            {
                var qqq = qq.GroupBy(e => e.name);
                XElement q = new XElement(ns+"class");
                q.Add(new XAttribute("number", qq.Key));
                foreach(var xx in qqq)
                {
                    var xxx = xx.GroupBy(e => e.sub);
                    XElement x = new XElement(ns+"pupil");
                    x.Add(new XAttribute("name", xx.Key));
                    foreach (var yy in xxx)
                    {
                        XElement y= new XElement(ns+"subject");
                        y.Add(new XAttribute("name", yy.Key));
                        foreach (var zz in yy)
                        {
                            XElement z = new XElement(ns+"mark", zz.score);
                            y.Add(z);
                        }
                        x.Add(y);
                    }
                    q.Add(x);
                }
                res.Add(q);
            }
            Show(res);
            XDocument dn = new XDocument(
                d.Declaration,
                new XElement(ns+"pupils",res.Elements()));
            dn.Save(name);
        }
    }
}

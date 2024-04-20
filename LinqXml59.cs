// File: "LinqXml59"
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
            Task("LinqXml59");
            string name = GetString();
            XDocument d = XDocument.Load(name);
            var area=d.Root.Elements().Attributes().Where(a => a.IsNamespaceDeclaration).Show();
            foreach (var e in area)
            {
                var n = (XNamespace)e.Value;
                var es = e.Parent.DescendantsAndSelf().Attributes();
                foreach(var x in es.Where(a =>a.Name.NamespaceName==n))
                    {
                    x.Value = (int.Parse(x.Value) * 2).ToString();
                }
            }
            d.Save(name);
            //var a=d.Root.Elements().Show(e=>e.Name.NamespaceName);
            //foreach(var j in a)
            //{
            //    Show(j.Name.Namespace);
            //}
        }
    }
}

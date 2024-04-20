// File: "LinqXml37"
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
            Task("LinqXml37");
            string name = GetString();
            XDocument d = XDocument.Load(name);
            var a = from e in d.Root.Elements().Elements()
                    where !e.IsEmpty
                    select e;
            a.Show();
            foreach (var e in a)
                e.Value = e.Value;
            d.Save(name);
        }
    }
}

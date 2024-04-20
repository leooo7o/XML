// File: "LinqXml8"
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
        // When solving tasks of the LinqXml group, the following
        // additional methods defined in the taskbook are available:
        // (*) Show() and Show(cmt) (extension methods) - debug output
        //       of a sequence, cmt - string comment;
        // (*) Show(e => r) and Show(cmt, e => r) (extension methods) -
        //       debug output of r values, obtained from elements e
        //       of a sequence, cmt - string comment.

        public static void Solve()
        {
            Task("LinqXml8");
            var a = File.ReadAllLines(GetString(), Encoding.Default)
                 .Select(e =>
                 {
                     string[] s = e.Split(' ');
                     IEnumerable<String> query = s.OrderBy(x => x);
                     return query;
                 });
            XDocument res = new XDocument(
                new XDeclaration(null, "us-ascii", null),
                new XElement("root", a.Select(e=>new XElement("line",e.Select(b=>new XElement("word",b.Select(c=>new XElement("char",c))))))));
            res.Save(GetString());
        }
    }
}

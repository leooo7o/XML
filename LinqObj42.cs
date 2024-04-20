// File: "LinqObj42"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            Task("LinqObj42");
            var r = File.ReadLines(GetString(), Encoding.Default)
                .Select(e =>
                {
                    string[] s = e.Split(' ');
                    return new
                    {
                        id = int.Parse(s[0]),
                        com=s[1],
                        street = s[2],
                        val = int.Parse(s[3])
                    };
                }).OrderBy(e => e.street).ThenBy(e => e.id).ThenBy(e => e.val).Show().GroupBy(e => e.street);
            string sout = GetString();
            List<string> ans=new List<string>();
            foreach (var g in r)
            {
                int x1, x2, x3;
                if (g.Where(e => e.id == 92).FirstOrDefault() != null)
                    x1 = g.Where(e => e.id == 92).First().val;
                else
                    x1 = 0;
                if (g.Where(e => e.id == 95).FirstOrDefault() != null)
                    x2 = g.Where(e => e.id == 95).First().val;
                else
                    x2 = 0;
                if (g.Where(e => e.id == 98).FirstOrDefault() != null)
                    x3 = g.Where(e => e.id == 98).First().val;
                else
                    x3 = 0;
                string s = g.Key+" "+x1.ToString()+" "+x2.ToString()+" "+x3.ToString();
                ans.Add(s);
            }
            File.WriteAllLines(sout, ans.ToArray(), Encoding.Default);
        }
    }
}

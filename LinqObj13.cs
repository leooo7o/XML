// File: "LinqObj13"
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
            Task("LinqObj13");
            var r = File.ReadLines(GetString(), Encoding.Default)
                .Select(e =>
                {
                    string[] s = e.Split(' ');
                    return new
                    {
                        num = int.Parse(s[0]),
                        year = int.Parse(s[1]),
                        name = s[2]
                    };
                }).OrderBy(e => e.year).GroupBy(e => e.year).Select(g => g.OrderByDescending(e => e.num).First()).OrderBy(e => e.year).Select(e => e.year + " " + e.num).Show();
            File.WriteAllLines(GetString(), r.ToArray(), Encoding.Default);
        }
    }
}

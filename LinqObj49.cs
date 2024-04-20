// File: "LinqObj49"
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
            Task("LinqObj49");
            var r = File.ReadLines(GetString(), Encoding.Default)
                .Select(e =>
                {
                    string[] s = e.Split(' ');
                    return new
                    {
                        name = s[0],
                        sym = s[1],
                        id = int.Parse(s[2]),
                        score = new { score1 = int.Parse(s[3]), score2 = int.Parse(s[4]), score3 = int.Parse(s[5]) }
                    };
                }).OrderBy(e => e.score.score1 + e.score.score2 + e.score.score3).GroupBy(e => e.score.score1 + e.score.score2 + e.score.score3).First();
            List<string> ans = new List<string>();
            ans.Add((r.First().score.score1 + r.First().score.score2 + r.First().score.score3).ToString());
            foreach (var g in r)
            {
                ans.Add(g.name + " " + g.sym + " " + g.id.ToString());
            }
            File.WriteAllLines(GetString(), ans, Encoding.Default);
        }
    }
}

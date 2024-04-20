// File: "LinqObj70"
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
            Task("LinqObj70");
            var r = File.ReadLines(GetString(), Encoding.Default)
               .Select(e =>
               {
                   string[] s = e.Split(' ');
                   return new
                   {
                       score = int.Parse(s[0]),
                       cla = int.Parse(s[1]),
                       name = s[2],
                       nam = s[3],
                       lesson = s[4]
                   };
               }).OrderBy(e => e.name).ThenBy(e => e.nam).GroupBy(e => new { e.name, e.nam }).Where(e => (e.Where(a => a.score < 4).Count()) == 0).Select(e => e.Select(a => new { a.score, a.cla, a.name, a.nam, a.lesson })).Select(e => e.Where(a => a.score == 5)).Where(e => e.Count() != 0).OrderByDescending(e => e.First().cla).ThenByDescending(e => e.Count()).Select(e => new { times = e.Count(), cla = e.First().cla, name = e.First().name + " " + e.First().nam }).OrderBy(e => e.cla).ThenByDescending(e => e.times);
            var n=r.Where(e => e.times == r.First(a => a.cla == e.cla).times).Select(e=>e.cla+" "+e.name+" "+e.times).Show();
            if (r.FirstOrDefault() != null)
                File.WriteAllLines(GetString(), n.ToArray(), Encoding.Default);
            else
                File.WriteAllText(GetString(), "Required students not found", Encoding.Default);
        }
    }
}

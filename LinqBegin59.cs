// File: "LinqBegin59"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            Task("LinqBegin59");
            GetEnumerableString().GroupBy(s => s.Length).Select(g=>g.OrderBy(x=>x).First()).OrderBy(s=>s.Length).Reverse().Show().Put();
        }
    }
}

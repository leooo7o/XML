// File: "LinqBegin53"
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
            Task("LinqBegin53");
            GetEnumerableInt().Join(GetEnumerableInt(), a => 0, b => 0, (a, b) => a + b).Distinct().OrderBy(x=>x).Show().Put();
        }
    }
}

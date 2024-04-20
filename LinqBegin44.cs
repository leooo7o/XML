// File: "LinqBegin44"
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
            Task("LinqBegin44");
            int a = GetInt();
            int b = GetInt();
            GetEnumerableInt().Where(x=>x>a).Concat(GetEnumerableInt().Where(x=>x<b)).OrderBy(x=>x).Show().Put();
        }
    }
}

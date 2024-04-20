// File: "LinqBegin38"
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
            Task("LinqBegin38");
            GetEnumerableInt().Select((x, i) => ((i+1) % 3 == 1? 2*x:x)).Where((x,i)=> ((i+1) % 3) !=0).Put();
        }
    }
}

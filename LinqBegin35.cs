// File: "LinqBegin35"
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
            Task("LinqBegin35");
            GetEnumerableInt().Select((x,i)=>x*(i+1)).Where(x=>Math.Abs(x/10)>0&&Math.Abs(x/10)<10).Reverse().Put();
        }
    }
}

// File: "LinqBegin30"
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
            Task("LinqBegin30");
            int k = GetInt();
            var res = GetEnumerableInt();
            res.Where((x, i) => x % 2 == 0).Except(res.Where((x,i)=>(i+1)>k)).Distinct().Reverse().Show().Put();
        }
    }
}

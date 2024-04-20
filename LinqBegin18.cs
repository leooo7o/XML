// File: "LinqBegin18"
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
            Task("LinqBegin18");
            GetEnumerableInt().Where(x => x < 0 && (x % 2) == 0).Reverse().Put();
        }
    }
}

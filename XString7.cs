// File: "XString7"
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
            Task("XString7");
            string s = GetString();
            int x1 = s[0];
            int x2 = s[s.Length-1];
            Put(x1);
            Put(x2);
        }
    }
}

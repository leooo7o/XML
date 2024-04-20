// File: "XString25"
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
            Task("XString25");
            string s = GetString();
            int x = int.Parse(s);
            string ans = Convert.ToString(x, 2);
            Put(ans);
        }
    }
}

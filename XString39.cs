// File: "XString39"
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
            Task("XString39");
            string s = GetString();
            int x=s.IndexOf(' ');
            s = s.Substring(x+1);
            x= s.IndexOf(' ');
            if (x == -1)
                Put("");
            else
                Put(s.Substring(0, x));
        }
    }
}

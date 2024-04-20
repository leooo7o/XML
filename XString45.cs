// File: "XString45"
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
            Task("XString45");
            string s = GetString();
            int x = 0;
            int min=20;
            foreach(char c in s)
            {
                if (c == ' ')
                {
                    if (min > x&&x!=0)
                        min = x;
                    x = 0;
                }
                else
                    x++;
            }
            if (min> x && x != 0)
                min = x;
            Put(min);
        }
    }
}

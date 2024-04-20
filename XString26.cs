// File: "XString26"
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
            Task("XString26");
            int n = GetInt();
            string s = GetString();
            int len = s.Length;
            if(n>len)
            {
                string tmp = new string('.', n - len);
                s=s.Insert(0, tmp);
            }
            else
            {
                s = s.Substring(len - n);
            }
            Put(s);
        }
    }
}

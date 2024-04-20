// File: "XString61"
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
            Task("XString61");
            string s=GetString();
            int len = s.Length;
            int p1 = 0, p2 = 0;
            for (int i = len - 1; i >= 0; i--)
            {
                if (s[i] == '\\')
                {
                    p1 = i;
                    break;
                }
            }
            //s.Remove(p1 + 1, len);
            for (int i = 0; i < p1; i++)
            {
                if (s[i] == '\\')
                    p2 = i;
            }
            string ans;
            if (p2 == 0)
            {
                ans = "\\";
            }
            else
            {
                ans = s.Substring(p2+1 ,p1-p2-1);
                //len = s.Length;
                //s[len - 1] = 0;
            }
            Put(ans);
        }
    }
}

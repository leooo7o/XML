// File: "XString63"
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
            Task("XString63");
            string s=GetString();
            int k=GetInt();
            int len = s.Length;
            char[] ans = s.ToCharArray();
            for (int i = 0; i < len; i++)
            {
                if (ans[i] >= 'a' && ans[i] <= 'z')
                    ans[i] = Convert.ToChar((ans[i] - 'a' + k) % 26 + 'a');
                else if (ans[i] >= 'A' && ans[i] <= 'Z')
                    ans[i] = Convert.ToChar((ans[i] - 'A' + k) % 26 + 'A');
            }
            s = new string(ans);
            Put(s);
        }
    }
}

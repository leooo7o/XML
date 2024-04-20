// File: "XString18"
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
            Task("XString18");
            string s = GetString();
            char[] ans = s.ToCharArray();
            for(int i=0;i<s.Length;i++)
            {
                if (ans[i] >= 'A' && ans[i] <= 'Z')
                    ans[i] = Convert.ToChar(ans[i] + 'a' - 'A');
                else if (ans[i] >= 'a' && ans[i] <= 'z')
                    ans[i] = Convert.ToChar(ans[i] + 'A' - 'a');
            }
            s=new string(ans);
            Put(s);
        }
    }
}

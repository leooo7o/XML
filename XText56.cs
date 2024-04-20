// File: "XText56"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            Task("XText56");
            string s=GetString();
            StreamReader f1 = new StreamReader(s);
            s=GetString();
            BinaryWriter f2= new BinaryWriter(new FileStream(s,FileMode.Create));
            char[] c = new char[128];
            int i = 0;
            while (f1.Peek() != -1)
            {
                char cc;
                int x;
                x = f1.Read();
                cc = (char)x;
                c[x] = cc;
            }
            for (i = 125; i > 31; i--)
            {
                if (c[i]!=0)
                {
                    char cc = c[i];
                    f2.Write(cc);
                }
            }
            f1.Close();
            f2.Close();
        }
    }
}

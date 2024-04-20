// File: "XText54"
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
            Task("XText54");
            string s1=GetString(), s2=GetString();
            StreamReader f1= new StreamReader(s1);
            BinaryWriter f2= new BinaryWriter(new FileStream(s2, FileMode.Create));
            int i = 0;
            char[] c = new char[128];
            while (f1.Peek() != -1)
            {
                int x = f1.Read();
                char cc = (char)x;
                if (c[x] == 0&&x>31)
                {
                    f2.Write(cc);
                    c[x] = 'A';
                }
            }
            f1.Close();
            f2.Close();
        }
    }
}

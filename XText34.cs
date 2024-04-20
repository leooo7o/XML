// File: "XText34"
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
            Task("XText34");
            string str;
            string s1=GetString(), s2 = "$T21$.tmp";
            StreamReader f1 = new StreamReader(s1);
            StreamWriter f2 = new StreamWriter(s2);
            int num = 0;
            while (f1.Peek() != -1)
            {
                str = f1.ReadLine();
                num = str.Length;
                if (num == 0)
                    f2.WriteLine("");
                else
                {
                    str =str.PadLeft(50);
                    f2.WriteLine(str);
                }
            }
            f1.Close();
            f2.Close();
            File.Delete(s1);
            FileInfo fi = new FileInfo(s2);
            fi.MoveTo(Path.Combine(s1));
        }
    }
}

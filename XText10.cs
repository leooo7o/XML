// File: "XText10"
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
            Task("XText10");
            int k=GetInt();
            string s1=GetString(), s2 = "$T21$.tmp";
            StreamReader sr = new StreamReader(s1);
            StreamWriter sw = new StreamWriter(s2);
            string s;
            while (sr.Peek() != -1)
            {
                s=sr.ReadLine();
                if (k == 0)
                    sw.WriteLine("");
                sw.WriteLine(s);
                k--;
            }
            sr.Close();
            sw.Close();
            File.Delete(s1);
            FileInfo fi = new FileInfo(s2);
            fi.MoveTo(Path.Combine(s1));
        }
    }
}

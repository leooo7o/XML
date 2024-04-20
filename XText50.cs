// File: "XText50"
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
            Task("XText50");
            string s, str;
            s=GetString();
            StreamReader f1 = new StreamReader(s);
            s = GetString();
            BinaryWriter f2 = new BinaryWriter(new FileStream(s, FileMode.Create));
            s = GetString();
            BinaryWriter f3 = new BinaryWriter(new FileStream(s, FileMode.Create));
            double x;
            char c;
            while (f1.Peek()!=-1)
            {
                str = f1.ReadLine();
                string num = str.Substring(30);
                double n = double.Parse(num);
                str=str.Substring(0,30);
                str = str.PadRight(80);
                f2.Write(str);
                f3.Write(n);
            }
            f1.Close();
            f2.Close();
            f3.Close();
        }
    }
}

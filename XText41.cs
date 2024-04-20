// File: "XText41"
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
            Task("XText41");
            string s1, s2, s3;
            string s;
            int x1 = 0, x2 = 0, x3 = 0;
            s=GetString();
            BinaryReader f1 = new BinaryReader(new FileStream(s,FileMode.Open));
            s = GetString();
            BinaryReader f2 = new BinaryReader(new FileStream(s, FileMode.Open));
            s = GetString();
            BinaryReader f3 = new BinaryReader(new FileStream(s, FileMode.Open));
            s = GetString();
            StreamWriter f4 = new StreamWriter(s);
            while (f1.BaseStream.Position<f1.BaseStream.Length)
            {
                x1=f1.ReadInt32();
                x2=f2.ReadInt32();
                x3=f3.ReadInt32();
                s1 = x1.ToString();
                s2 = x2.ToString();
                s3 = x3.ToString();
                s1 = s1.PadRight(20);
                s2=s2.PadRight(20);
                s3=s3.PadRight(20);
                s = "|" + s1 + s2 + s3 + "|";
                f4.WriteLine(s);
            }
            f1.Close();
            f2.Close();
            f3.Close();
            f4.Close();
        }
    }
}

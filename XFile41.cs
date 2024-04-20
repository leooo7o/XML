// File: "XFile41"
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
            Task("XFile41");
            string s1=GetString(), s2=GetString(), s3=GetString(),s4=GetString();
            string s;
            int x1 = 0, x2 = 0, x3 = 0;
            BinaryReader f1 = new BinaryReader(new FileStream(s1, FileMode.Open));
            BinaryReader f2 = new BinaryReader(new FileStream(s2, FileMode.Open));
            BinaryReader f3 = new BinaryReader(new FileStream(s3, FileMode.Open));
            StreamWriter f4 = new StreamWriter(s4);
            while (f1.BaseStream.Position<f1.BaseStream.Length)
            {
                x1 = f1.ReadInt32();
                x2=f2.ReadInt32();
                x3=f3.ReadInt32();
                s1 = x1.ToString();
                s2 = x2.ToString();
                s3 = x3.ToString();
                s1.PadRight(20);
                s2.PadRight(20);
                s3.PadRight(20);
                s = "|" + s1 + s2 + s3 + "|";
                Show(s);
                f4.WriteLine(s);
            }
            f1.Close();
            f2.Close();
            f3.Close();
            f4.Close();
        }
    }
}

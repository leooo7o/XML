// File: "XFile12"
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
            Task("XFile12");
            string s1, s2, s3;
            s1 = GetString();
            s2 = GetString();
            s3 = GetString();
            BinaryReader f1 = new BinaryReader(new FileStream(s1, FileMode.Open));
            BinaryWriter f2 = new BinaryWriter(new FileStream(s2, FileMode.Create));
            BinaryWriter f3 = new BinaryWriter(new FileStream(s3, FileMode.Create));
            int x = 0;
            while (f1.BaseStream.Position < f1.BaseStream.Length)
            {
                x = f1.ReadInt32();
                if (x % 2 == 0) f2.Write(x);
                else f3.Write(x);
            }
            f1.Close();
            f2.Close();
            f3.Close();
        }
    }
}

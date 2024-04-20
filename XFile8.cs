// File: "XFile8"
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
            Task("XFile8");
            String s1 = GetString();
            String s2 = GetString();
            BinaryWriter bw;
            BinaryReader br;
            br = new BinaryReader(new FileStream(s1, FileMode.Open));
            bw = new BinaryWriter(new FileStream(s2, FileMode.Create));
            double x1, x2;
            x1 = br.ReadDouble();
            bw.Write(x1);
            br.BaseStream.Seek(-sizeof(double), SeekOrigin.End);
            x2 = br.ReadDouble();
            bw.Write(x2);
            br.Close();
            bw.Close();
        }
    }
}

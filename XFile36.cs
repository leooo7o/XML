// File: "XFile36"
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
            Task("XFile36");
            string s1, s2 = "$F25$.tst";
            s1=GetString();
            BinaryReader f1 = new BinaryReader(new FileStream(s1, FileMode.Open));
            BinaryWriter f2 = new BinaryWriter(new FileStream(s2, FileMode.Create));
            int x;
            while (f1.PeekChar() != -1)
            {
                x = f1.ReadInt32();
                f2.Write(x);
            }
            f1.BaseStream.Seek(0,SeekOrigin.Begin);
            while (f1.PeekChar() != -1)
            {
                x = f1.ReadInt32();
                f2.Write(x);
            }
            f1.Close();
            f2.Close();
            File.Delete(s1);
            FileInfo fi = new FileInfo(s2);
            fi.MoveTo(Path.Combine(s1));
        }
    }
}

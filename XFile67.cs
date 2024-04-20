// File: "XFile67"
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
            Task("XFile67");
            string s1=GetString(), s2=GetString(), s3=GetString();
            int x;
            BinaryReader f1 = new BinaryReader(new FileStream(s1, FileMode.Open));
            BinaryWriter f2 = new BinaryWriter(new FileStream(s2, FileMode.Create));
            BinaryWriter f3 = new BinaryWriter(new FileStream(s3, FileMode.Create));
            while (f1.BaseStream.Position < f1.BaseStream.Length)
            {
                byte[] bytes = new byte[81];
                f1.Read(bytes,0,81);
                //string str = bytes.ToString();
                string str = Encoding.Default.GetString(bytes);
                str = str.Substring(1, 80);
                Show(str);
                x = int.Parse(str.Substring(0, 2));
                Show(x);
                f2.Write(x);
                x = int.Parse(str.Substring(3, 2));
                Show(x);
                f3.Write(x);
            }
            f1.Close();
            f2.Close();
            f3.Close();
        }
    }
}

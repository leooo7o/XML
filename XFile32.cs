// File: "XFile32"
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
            Task("XFile32");
            string s1 = GetString();
            string s2 = "test.tmp";
            BinaryReader br = new BinaryReader(new FileStream(s1, FileMode.Open));
            BinaryWriter bw = new BinaryWriter(new FileStream(s2, FileMode.Create));
            int a = (int)br.BaseStream.Length;
            int i = 0;
            while (br.PeekChar()!=-1)
            {
                int x;
                x = br.ReadInt32();
                if (i >= (a / 2/sizeof(int)))
                {
                    bw.Write(x);
                }
                i++;
            }
            br.Close();
            bw.Close();
            File.Replace(s2, s1, "a");
            File.Delete("a");
        }
    }
}

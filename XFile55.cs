// File: "XFile55"
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
            Task("XFile55");
			int len;
			string s=GetString();
			BinaryWriter fout = new BinaryWriter(new FileStream(s, FileMode.Create));
			int n=GetInt();
            for (int i = 0; i < n; i++)
            {
                s = GetString();
                BinaryReader f = new BinaryReader(new FileStream(s, FileMode.Open));
                len = ((int)f.BaseStream.Length) / sizeof(int);
                fout.Write(len);
                f.BaseStream.Seek(0, SeekOrigin.Begin);
                while (f.BaseStream.Position < f.BaseStream.Length)
                {
                    int x = f.ReadInt32();
                    fout.Write(x);
                }
                f.Close();
            }
            fout.Close();
        }
    }
}

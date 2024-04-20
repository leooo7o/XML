// File: "XText45"
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
            Task("XText45");
            string s=GetString();
            StreamReader f= new StreamReader(s);
            int num = 0;
            float sum = 0;
            while (f.Peek() != -1)
            {
                s = f.ReadLine();
                //if (!f.EndOfStream)
                //{
                    int len = s.Length;
                    for (int i = 0; i < len; i++)
                    {
                        if (s[i] == '.')
                        {
                            num++;
                            sum += float.Parse(s);
                        }
                    }
                //}
            }
            Put(num);
            Put(sum);
            f.Close();
        }
    }
}

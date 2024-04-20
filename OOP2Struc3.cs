// File: "OOP2Struc3"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public class TextView
        {
            // Do not change the implementation of the class
            int x, y;
            int width = 1, height = 1;
            public void GetOrigin(out int x, out int y)
            {
                x = this.x;
                y = this.y;
            }
            public void SetOrigin(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public void GetSize(out int width, out int height)
            {
                width = this.width;
                height = this.height;
            }
            public void SetSize(int width, int height)
            {
                this.width = width;
                this.height = height;
            }
        }

        public abstract class Shape
        {
            public abstract string GetInfo();
            public abstract void MoveBy(int a, int b);
        }
        public class RectShape : Shape
        {
            public TextView p;
            public RectShape(TextView p1)
            {
                p = p1;
            }
            public override string GetInfo()
            {
                string s;
                int i1, i2, i3, i4;
                p.GetOrigin(out i1,out i2);
                p.GetSize(out i3,out i4);
                string s2 = "(";
                s = "R" + s2 + i1.ToString() + "," + i2.ToString() + ")" + "(" + i3.ToString() + "," + i4.ToString() + ")";
                return s;
            }
            public override void MoveBy(int a, int b)
            {
                int i1 = 0, i2 = 0;
                p.GetOrigin(out i1,out i2);
                p.SetOrigin(i1 + a, i2 + b);
                p.GetSize(out i1,out i2);
                p.SetSize(i1 + a, i2 + b);
            }
        }
        public class TextShape : Shape
        {
            public TextView p;
            public TextShape(TextView p1)
            {
                p = p1;
            }
            public override string GetInfo()
            {
                string s;
                int i1, i2, i3, i4;
                p.GetOrigin(out i1,out i2);
                p.GetSize(out i3,out i4);
                string s2 = "(";
                s = "T" + s2 + i1.ToString() + "," +i2.ToString() + ")" + "(" +i3.ToString() + "," + i4.ToString() + ")";
                return s;
            }
            public override void MoveBy(int a, int b)
            {
                int i1 = 0, i2 = 0;
                p.GetOrigin(out i1,out i2);
                p.SetOrigin(i1 + a, i2 + b);
                p.GetSize(out i1,out i2);
                p.SetSize(i1 + a, i2 + b);
            }
        }
        // Implement the RectShape and TextShape descendant classes

        public static void Solve()
        {
            Task("OOP2Struc3");
            int n, a, b;
            n=GetInt();
            List<char> sig=new List<char>();
            List<int> itr=new List<int>();
            for (int i = 0; i < n; i++)
            {
                char c;
                int x;
                c=GetChar();
                sig.Add(c);
                x=GetInt();
                itr.Add(x);
                x = GetInt();
                itr.Add(x);
                x = GetInt();
                itr.Add(x);
                x = GetInt();
                itr.Add(x);
            }
            a = GetInt();
            b = GetInt();
            for (int i = 0; i < n; i++)
            {
                if (sig[i] == 'T')
                {
                    TextView a1 = new TextView();
                    a1.SetOrigin(itr[i * 4], itr[i * 4 + 1]);
                    a1.SetSize(itr[i * 4 + 2], itr[i * 4 + 3]);
                    Shape A = new TextShape(a1);
                    A.MoveBy(a, b);
                    Put(A.GetInfo());
                }
                else
                {
                    TextView a1 = new TextView();
                    a1.SetOrigin(itr[i * 4], itr[i * 4 + 1]);
                    a1.SetSize(itr[i * 4 + 2], itr[i * 4 + 3]);
                    Shape B = new RectShape(a1);
                    B.MoveBy(a, b);
                    Put(B.GetInfo());
                }
            }
        }
    }
}

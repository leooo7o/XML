// File: "OOP1Creat8"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class AbstractGraphic
        {
            public abstract AbstractGraphic Clone();
            public abstract void ChangeLocation(int x1, int y1, int x2, int y2);
            public abstract string Draw();
        }
        class Ellip : AbstractGraphic
        {
            int m1, m2, n1, n2;
            public override AbstractGraphic Clone()
            {
                return new Ellip();
            }
            public override void ChangeLocation(int x1, int y1, int x2, int y2)
            {
                m1 = x1;
                n1 = y1;
                m2 = x2;
                n2 = y2;
            }
            public override string Draw()
            {
                string s1 = "(";
                string s2 = ")";
                s1 = "Ellip" + s1 + m1.ToString() + "," + n1.ToString() + "," + m2.ToString() + "," + n2.ToString() + s2;
                return s1;
            }
        }
        class Line : AbstractGraphic
        {
            int m1, m2, n1, n2;
            public override AbstractGraphic Clone()
            {
                return new Line();
            }
            public override void ChangeLocation(int x1, int y1, int x2, int y2)
            {
                m1 = x1;
                n1 = y1;
                m2 = x2;
                n2 = y2;
            }
            public override string Draw()
            {
                string s1 = "(";
                string s2 = ")";
                s1 = "Line" + s1 + m1.ToString() + "," + n1.ToString() + "," + m2.ToString() + "," + n2.ToString() + s2;
                return s1;
            }
        }
        class Rect : AbstractGraphic
        {
            int m1, m2, n1, n2;
            public override AbstractGraphic Clone()
            {
                return new Rect();
            }
            public override void ChangeLocation(int x1, int y1, int x2, int y2)
            {
                m1 = x1;
                n1 = y1;
                m2 = x2;
                n2 = y2;
            }
            public override string Draw()
            {
                string s1 = "(";
                string s2 = ")";
                s1 = "Rect" + s1 + m1.ToString() + "," + n1.ToString() + "," + m2.ToString() + "," + n2.ToString() + s2;
                return s1;
            }
        }
        // Implement the Ellip, Line and Rect descendant classes

        public class GraphEditor
        {
            AbstractGraphic a1;
            AbstractGraphic a2;
            int sym;
            // Add required fields
            public GraphEditor(AbstractGraphic p1, AbstractGraphic p2)
            {
                a1 = p1;
                a2 = p2;
            }
            public void AddGraphic(int np, int x1, int y1, int x2, int y2)
            {
                if (np == 1)
                {
                    a1.ChangeLocation(x1, y1, x2, y2);
                    sym = 1;
                }
                else
                {
                    a2.ChangeLocation(x1, y1, x2, y2);
                    sym = 0;
                }
                // Implement the method
            }
            public string DrawAll()
            {
                if (sym == 1)
                    return a1.Draw();
                else
                    return a2.Draw();
                // Remove the previous statement and implement the method
            }
        }

        public static void Solve()
        {
            Task("OOP1Creat8");
            string s=GetString();
            int n=GetInt();
            int np, x1, y1, x2, y2;
            string sum="";
            if (s == "LE")
            {
                AbstractGraphic p1 = new Line();
                AbstractGraphic p2 = new Ellip();
                GraphEditor mp = new GraphEditor(p1.Clone(), p2.Clone());
                for (int i = 0; i < n; i++)
                {
                    np = GetInt();
                    x1 = GetInt();
                    y1 = GetInt();
                    x2 = GetInt();
                    y2 = GetInt();
                    AbstractGraphic A = p1.Clone();
                    AbstractGraphic B = p2.Clone();
                    //GraphEditor mp = new GraphEditor(A, B);
                    mp.AddGraphic(np, x1, y1, x2, y2);
                    if (i > 0)
                        sum = sum + " " + mp.DrawAll();
                    else
                        sum = sum + mp.DrawAll();
                    
                }
            }
            else if (s == "EL")
            {
                AbstractGraphic p1 = new Ellip();
                AbstractGraphic p2 = new Line();
                GraphEditor mp = new GraphEditor(p1.Clone(), p2.Clone());
                for (int i = 0; i < n; i++)
                {
                    np = GetInt();
                    x1 = GetInt();
                    y1 = GetInt();
                    x2 = GetInt();
                    y2 = GetInt();
                    AbstractGraphic A = p1.Clone();
                    AbstractGraphic B = p2.Clone();
                    //GraphEditor mp = new GraphEditor(A, B);
                    mp.AddGraphic(np, x1, y1, x2, y2);
                    if (i > 0)
                        sum = sum + " " + mp.DrawAll();
                    else
                        sum = sum + mp.DrawAll();
                }
            }
            else if (s == "RE")
            {
                AbstractGraphic p1 = new Rect();
                AbstractGraphic p2 = new Ellip();
                GraphEditor mp = new GraphEditor(p1.Clone(), p2.Clone());
                for (int i = 0; i < n; i++)
                {
                    np = GetInt();
                    x1 = GetInt();
                    y1 = GetInt();
                    x2 = GetInt();
                    y2 = GetInt();
                    AbstractGraphic A = p1.Clone();
                    AbstractGraphic B = p2.Clone();
                    //GraphEditor mp = new GraphEditor(A, B);
                    mp.AddGraphic(np, x1, y1, x2, y2);
                    if (i > 0)
                        sum = sum + " " + mp.DrawAll();
                    else
                        sum = sum + mp.DrawAll();
                }
            }
            else if (s == "ER")
            {
                AbstractGraphic p1 = new Ellip();
                AbstractGraphic p2 = new Rect();
                GraphEditor mp = new GraphEditor(p1.Clone(), p2.Clone());
                for (int i = 0; i < n; i++)
                {
                    np = GetInt();
                    x1 = GetInt();
                    y1 = GetInt();
                    x2 = GetInt();
                    y2 = GetInt();
                    AbstractGraphic A = p1.Clone();
                    AbstractGraphic B = p2.Clone();
                    //GraphEditor mp = new GraphEditor(A, B);
                    mp.AddGraphic(np, x1, y1, x2, y2);
                    if (i > 0)
                        sum = sum + " " + mp.DrawAll();
                    else
                        sum = sum + mp.DrawAll();
                }
            }
            else if (s == "RL")
            {
                AbstractGraphic p1 = new Rect();
                AbstractGraphic p2 = new Line();
                GraphEditor mp = new GraphEditor(p1.Clone(), p2.Clone());
                for (int i = 0; i < n; i++)
                {
                    np = GetInt();
                    x1 = GetInt();
                    y1 = GetInt();
                    x2 = GetInt();
                    y2 = GetInt();
                    AbstractGraphic A = p1.Clone();
                    AbstractGraphic B = p2.Clone();
                    //GraphEditor mp = new GraphEditor(A, B);
                    mp.AddGraphic(np, x1, y1, x2, y2);
                    if (i > 0)
                        sum = sum + " " + mp.DrawAll();
                    else
                        sum = sum + mp.DrawAll();
                }
            }
            else if (s == "LR")
            {
                AbstractGraphic p1 = new Line();
                AbstractGraphic p2 = new Rect();
                GraphEditor mp = new GraphEditor(p1.Clone(), p2.Clone());
                for (int i = 0; i < n; i++)
                {
                    np = GetInt();
                    x1 = GetInt();
                    y1 = GetInt();
                    x2 = GetInt();
                    y2 = GetInt();
                    AbstractGraphic A = p1.Clone();
                    AbstractGraphic B = p2.Clone();
                    //GraphEditor mp = new GraphEditor(A, B);
                    mp.AddGraphic(np, x1, y1, x2, y2);
                    if (i > 0)
                        sum = sum + " " + mp.DrawAll();
                    else
                        sum = sum + mp.DrawAll();
                }

            }
            Put(sum);
        }
    }
}

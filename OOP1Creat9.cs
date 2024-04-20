// File: "OOP1Creat9"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class Builder
        {
            public virtual void BuildStart() {}
            public virtual void BuildPartA() {}
            public virtual void BuildPartB() {}
            public virtual void BuildPartC() {}
            public abstract string GetResult();
        }
        public class ConcreteBuilder1:Builder
        {
            string info;
            public override void BuildStart()
            {
                info = "";
            }
            public override void BuildPartA()
            {
                info += "-1-";
            }
            public override void BuildPartB()
            {
                info += "-2-";
            }
            public override void BuildPartC()
            {
                info += "-3-";
            }
            public override string GetResult()
            {
                return info;
            }
        }
        public class ConcreteBuilder2 : Builder
        {
            string info;
            public override void BuildStart()
            {
                info = "";
            }
            public override void BuildPartA()
            {
                info += "="; 
                for (int i = 0; i < 1; i++) { info += "*"; }
                info += "=";
            }
            public override void BuildPartB()
            {
                info += "=";
                for (int i = 0; i < 2; i++) { info += "*"; }
                info += "=";
            }
            public override void BuildPartC()
            {
                info += "=";
                for (int i = 0; i < 3; i++) { info += "*"; }
                info += "=";
            }
            public override string GetResult()
            {
                return info;
            }
        }
        // Implement the ConcreteBuilder1
        //   and ConcreteBuilder2 descendant classes

        public class Director
        {
            Builder b;
            public Director(Builder b)
            {
                this.b = b;
            }
            public string GetResult()
            {
                return b.GetResult();
            }
            public void Construct(string templat)
            {
                for (int i = 0; i < templat.Length; i++)
                {
                    if (templat[i] == 'A')
                        b.BuildPartA();
                    else if (templat[i] == 'B')
                        b.BuildPartB();
                    else if (templat[i] == 'C')
                        b.BuildPartC();
                }
                // Implement the method
            }
        }

        public static void Solve()
        {
            Task("OOP1Creat9");
            for (int i = 0; i < 5; i++)
            {
                string s=GetString();
                Builder a1 = new ConcreteBuilder1();
                Builder a2 = new ConcreteBuilder2();
                Director A = new Director(a1);
                Director B = new Director(a2);
                A.Construct(s);
                B.Construct(s);
                Put(A.GetResult());
                Put(B.GetResult());
            }
        }
    }
}

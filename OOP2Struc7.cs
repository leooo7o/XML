// File: "OOP2Struc7"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class Component
        {
            public abstract string Show();
        }
        class ConcreteComponent : Component
        {
            string info;
            public override string Show()
            {
                return info;
            }
            public ConcreteComponent(string s)
            {
                this.info = s;
            }
        }
        // Implement the ConcreteComponent descendant class

        public abstract class Decorator : Component
        {
            protected Component comp;
        }
        class ConcreteDecoratorA : Decorator
        {
            public ConcreteDecoratorA(Component p1)
            {
                this.comp = p1;
            }
            public override string Show()
            {
                string s;
                s = "==" + comp.Show() + "==";
                return s;
            }
        }
        class ConcreteDecoratorB : Decorator
        {
            public ConcreteDecoratorB(Component p1)
            {
                this.comp = p1;
            }
            public override string Show()
            {
                string s;
                s = "(" + comp.Show() + ")";
                return s;
            }
        }
        // Implement the ConcreteDecoratorA
        //   and ConcreteDecoratorB descendant classes

        public static void Solve()
        {
            Task("OOP2Struc7");
            int n=GetInt();
            List<string> ans=new List<string>();
            for (int i = 0; i < n; i++)
            {
                string s1=GetString(), s2=GetString();
                Component a = new ConcreteComponent(s1);
                for (int j = 0; j < s2.Count(); j++)
                {
                    if (s2[j] == 'A')
                        a = new ConcreteDecoratorA(a);
                    else
                        a = new ConcreteDecoratorB(a);
                }
                ans.Add(a.Show());
            }
            for (int i = ans.Count() - 1; i >= 0; i--)
            {
                Put(ans[i]);
            }
        }
    }
}

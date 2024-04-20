// File: "OOP2Struc11"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class Flyweight
        {
            public abstract char Show(bool state);
        }
        class ConcreteFlyweight:Flyweight
        {
            public ConcreteFlyweight() { }
            public override char Show(bool state)
            {
                if (state == true)
                    return 'A';
                else
                    return 'a';
            }
        }
        class UnsharedConcreteFlyweight:Flyweight
        {
            char inf;
            public UnsharedConcreteFlyweight(char c) { this.inf = c; }
            public override char Show(bool state)
            {
                if ((state == true && inf <= 'Z' && inf >= 'A') || (state == false && inf <= 'z' && inf >= 'a'))
                    return inf;
                else if ((state == true && inf <= 'z' && inf >= 'a'))
                    return (char)(inf - 'a' + 'A');
                else
                    return (char)(inf + 'a' - 'A');
            }
        }
         class FlyweightFactory
        {
            Dictionary<char, Flyweight> cf=new Dictionary<char, Flyweight>();
            int count;
            public FlyweightFactory() { cf.Clear(); count = 0; }
            public Flyweight CreateFlyweight(char inf) 
            {
                if (cf.ContainsKey(inf))
                {
                    if (inf == 'a' || inf == 'A') { return cf[inf]; }
                    else
                    {
                        count++;
                        return cf[inf];
                    }
                }
                else
                {
                    if (inf == 'a') { if (cf.ContainsKey('A') ) { Flyweight fly = new UnsharedConcreteFlyweight(inf); cf[inf] = fly; return cf[inf]; } else { count++; Flyweight fly = new UnsharedConcreteFlyweight(inf); cf[inf] = fly; return cf[inf]; } }
                    if (inf == 'A') { if (cf.ContainsKey('a')) { Flyweight fly = new UnsharedConcreteFlyweight(inf); cf[inf] = fly; return cf[inf]; } else { count++; Flyweight fly = new UnsharedConcreteFlyweight(inf); cf[inf] = fly; return cf[inf]; } }
                    else
                    {
                        count++;
                        Flyweight fly = new UnsharedConcreteFlyweight(inf);
                        cf[inf] = fly;
                        return fly;
                    }
                }
            }
            public int getCount()
            {
                return this.count;
            }
        };
        class Client
        {
            FlyweightFactory f;
            List<Flyweight> fw;
            public Client()
            {
                f = new FlyweightFactory();
                fw = new List<Flyweight>();
            }
            public void MakeFlyweights(string inf)
            {
                for (int i = 0; i < inf.Length; i++)
                {
                    fw.Add(f.CreateFlyweight(inf[i]));
                }
            }
            public string ShowFlyweights(bool state)
            {
                string s="";
                for (int i = 0; i < fw.Count(); i++)
                {
                    s += fw[i].Show(state);
                }
                return s;
            }
            public int GetFlyweightCount()
            {
                return f.getCount();
            }
            public void del()
            {
                fw.Clear();
            }
        };
        // Implement the ConcreteFlyweight
        //   and UnsharedConcreteFlyweight descendant classes

        // Implement the FlyweightFactory and Client classes

        public static void Solve()
        {
            Task("OOP2Struc11");
            Client a = new Client();
            for (int i = 0; i < 5; i++)
            {
                string s=GetString();
                a.del();
                a.MakeFlyweights(s);
                Put(a.ShowFlyweights(true));
                Put(a.ShowFlyweights(false));
                Put(a.GetFlyweightCount());
            }
        }
    }
}

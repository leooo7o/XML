// File: "OOP3Behav15"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class Element
        {
            public abstract void Accept(Visitor v);
        }

        public class ConcreteElementA : Element
        {
            int val;
            public ConcreteElementA(int x)
            {
                val = x;
            }
            // Add required fields and methods
            public override void Accept(Visitor v)
            {
                v.VisitConcreteElementA(this);
                // Implement the method
            }
            public int getData()
            {
                return val;
            }
            public void setData(int newData)
            {
                val = newData;
            }
        }

        public class ConcreteElementB : Element
        {
            string val;
            public ConcreteElementB(string x)
            {
                val = x;
            }
            // Add required fields and methods
            public override void Accept(Visitor v)
            {
                v.VisitConcreteElementB(this);
                // Implement the method
            }
            public string getData()
            {
                return val;
            }
            public void setData(string newData)
            {
                val = newData;
            }
        }

        public class ConcreteElementC : Element
        {
            double val;
            public ConcreteElementC(double x)
            {
                val = x;
            }
            // Add required fields and methods
            public override void Accept(Visitor v)
            {
                v.VisitConcreteElementC(this);
                // Implement the method
            }
            public double getData()
            {
                return val;
            }
            public void setData(double newData)
            {
                val = newData;
            }
        }

        public class ObjectStructure
        {
            List<Element>struc;
            public ObjectStructure(List<Element> a)
            {
                struc=a;
                // Implement the constructor
            }
            public void Accept(Visitor v)
            {
                for(int i = 0; i < struc.Count; i++)
                {
                    struc[i].Accept(v);
                }
                //foreach (var e in struc)
                //    e.Accept(v);
            }
        }

        public abstract class Visitor
        {
            public abstract void VisitConcreteElementA(ConcreteElementA e);
            public abstract void VisitConcreteElementB(ConcreteElementB e);
            public abstract void VisitConcreteElementC(ConcreteElementC e);
        }
        public class ConcreteVisitor1 : Visitor
        {
            public override void VisitConcreteElementA(ConcreteElementA e)
            {
               Put(e.getData());
            }
            public override void VisitConcreteElementB(ConcreteElementB e)
            {
                Put(e.getData());
            }
            public override void VisitConcreteElementC(ConcreteElementC e)
            {
                Put(e.getData());
            }
        }
        public class ConcreteVisitor2 : Visitor
        {
            public override void VisitConcreteElementA(ConcreteElementA e)
            {
                e.setData(0 - e.getData());
            }
            public override void VisitConcreteElementB(ConcreteElementB e)
            {
                string newstr =new string(e.getData().ToCharArray().Reverse<char>().ToArray<char>());
                e.setData(newstr);
            }
            public override void VisitConcreteElementC(ConcreteElementC e)
            {
                e.setData(1.0 / e.getData());
            }
        }
        public class ConcreteVisitor3 : Visitor
        {
            int resultA;
            string resultB;
            double resultC;
            public ConcreteVisitor3()
            {
                resultA = 0;
                resultB = "";
                resultC = 1;
            }
            public override void VisitConcreteElementA(ConcreteElementA e)
            {
                resultA += e.getData();
            }
            public override void VisitConcreteElementB(ConcreteElementB e)
            {
                resultB += e.getData();
            }
            public override void VisitConcreteElementC(ConcreteElementC e)
            {
                resultC *= e.getData();
            }
            public void getA()
            {
                Put(resultA);
            }
            public void getB()
            {
                Put(resultB);
            }
            public void getC()
            {
                Put(resultC);
            }
        }
        // Implement the ConcreteVisitor1, ConcreteVisitor2
        //   and ConcreteVisitor3 descendant classes

        public static void Solve()
        {
            Task("OOP3Behav15");
            int num = GetInt();
            List<Element> ele = new List<Element>();
            for(int i=0; i<num;i++)
            {
                char sym = GetChar();
                if (sym == 'A')
                {
                    int x = GetInt();
                    ele.Add(new ConcreteElementA(x));
                }
                else if (sym == 'B')
                {
                    string x = GetString();
                    ele.Add(new ConcreteElementB(x));
                }
                else if (sym == 'C')
                {
                    double x = GetDouble();
                    ele.Add(new ConcreteElementC(x));
                }
            }
            ObjectStructure a = new ObjectStructure(ele);
            Visitor v1 = new ConcreteVisitor1();
            Visitor v2 = new ConcreteVisitor2();
            ConcreteVisitor3 v3 = new ConcreteVisitor3();
            a.Accept(v1);
            a.Accept(v2);
            a.Accept(v1);
            a.Accept(v3);
            v3.getA();
            v3.getB();
            v3.getC();
        }
    }
}

// File: "OOP3Behav16"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public class Context
        {
            public List<string> str = new List<string>();
            public List<double> val = new List<double>();
            public Context()
            {
                for(int i = 0; i < 10; i++)
                {
                    str.Add(((char)('a'+i)).ToString());
                    val.Add(1.0);
                }
            }
            public void setvar(int ind,string name, double value)
            {
                str[ind] = name;
                val[ind] = value;
            }
            public string getname(int ind)
            {
                return str[ind];
            }
            public double getvalue(int ind)
            {
                return val[ind];
            }
            // Add the constructor, required fields and methods
        }

        public abstract class AbstractExpression
        {
            public abstract string InterpretA(Context cont);
            public abstract string InterpretB(Context cont);
            public abstract double InterpretC(Context cont);
        }
        public class NontermMath : AbstractExpression
        {
            public AbstractExpression expr1;
            public AbstractExpression expr2;
            char op;
            public NontermMath(AbstractExpression expr1,AbstractExpression expr2,char op) { this.expr1 = expr1;this.expr2 = expr2;this.op = op; }
            public override string InterpretA(Context cont)
            {
                return "("+expr1.InterpretA(cont)+op.ToString()+expr2.InterpretA(cont)+")";
            }
            public override string InterpretB(Context cont)
            {
                return expr1.InterpretB(cont)+" "+ expr2.InterpretB(cont)+" "+op;
            }
            public override double InterpretC(Context cont)
            {
                if (op == '+')
                {
                    return expr1.InterpretC(cont) + expr2.InterpretC(cont);
                }
                else if (op == '-')
                {
                    return expr1.InterpretC(cont) - expr2.InterpretC(cont);
                }
                else if(op=='*')
                {
                    return expr1.InterpretC(cont) * expr2.InterpretC(cont);
                }
                else
                {
                    return expr1.InterpretC(cont) / expr2.InterpretC(cont);
                }
            }
        }
        public class TermConst : AbstractExpression
        {
            double value;
            public TermConst(double value) { this.value=value; }
            public override string InterpretA(Context cont)
            {
                return value.ToString("0.00");
            }
            public override string InterpretB(Context cont)
            {
                return value.ToString("0.00");
            }
            public override double InterpretC(Context cont)
            {
                return value;
            }
        }
        public class TermVar : AbstractExpression
        {
            int ind;
            public TermVar(int ind) { this.ind = ind; }
            public override string InterpretA(Context cont)
            {
                if (cont.str[ind][0] == 'V')
                    return "v" + ind.ToString();
                else
                    return cont.getname(ind);
            }
            public override string InterpretB(Context cont)
            {
                if (cont.str[ind][0] == 'V')
                    return "v" + ind.ToString();
                else
                    return cont.getname(ind);
            }
            public override double InterpretC(Context cont)
            {
                if (cont.getvalue(ind) != 1.0)
                    return cont.getvalue(ind);
                else
                    return 1.0;
            }
        }
        // Implement the TermConst, TermVar
        //   and NontermMath descendant classes

        public class Client
        {
            AbstractExpression expr;
            Context cont;
            public Client(AbstractExpression expr, Context cont)
            {
                this.expr = expr;
                this.cont = cont;
            }
            public string InterpretA()
            {
                return expr.InterpretA(cont);
            }
            public string InterpretB()
            {
                return expr.InterpretB(cont);
            }
            public double InterpretC()
            {
                return expr.InterpretC(cont);
            }
        }

        public static void Solve()
        {
            Task("OOP3Behav16");
            int n = GetInt();
            Context data = new Context();
            List<AbstractExpression> L = new List<AbstractExpression>();
            int index = 0;
            for(int i=0;i<n;i++)
            {
                char c = GetChar();
                if(c=='V')
                {
                    int x = GetInt();
                    L.Add(new TermVar(x));
                    index++;
                }
                else if(c=='C')
                {
                    double x = GetDouble();
                    L.Add(new TermConst(x));
                    index++;
                }
                else
                {
                    int x1 = GetInt();
                    int x2 = GetInt();
                    char op = GetChar();
                    L.Add(new NontermMath(L[x1], L[x2], op));
                }
            }
            int m = GetInt();
            for(int i=0;i<m;i++)
            {
                int x = GetInt();
                string s = GetString();
                double p = GetDouble();
                data.setvar(x,s, p);
            }
            Put(L[n - 1].InterpretA(data));
            Put(L[n - 1].InterpretB(data));
            Put(L[n - 1].InterpretC(data));
        }
    }
}

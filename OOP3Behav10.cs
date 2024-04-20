// File: "OOP3Behav10"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class State
        {
            public abstract string GetNextToken();
        }
        public class Context
        {
            private string text;
            private State currentState;
            public Context(string s)
            {
                text = s;
                currentState = new ConcreteStateNormal(0, this);
            }
            public char GetCharAt(int index) { return text[index]; }
            public void SetState(State newState) { currentState = newState; }
            public string GetNextToken()
            {
                return currentState.GetNextToken();
            }
        }
        public class ConcreteStateNormal : State
        {
            private Context ct=null;
            private int index=0;
            public ConcreteStateNormal(int x, Context p) { index = x; ct = p; }
            public override string GetNextToken()
            {
                string s = "";
                char c;
                for (int i = index; ; i++)
                {
                    c = ct.GetCharAt(i);
                    if (c == '.') { return s; ct.SetState(new ConcreteStateFin()); ct.SetState(new ConcreteStateFin()); }
                    if (c == '\"')
                    {
                        s = "Normal:" + s;
                        ct.SetState(new ConcreteStateString(i + 1, ct));
                        return s;
                    }
                    if (c == '{')
                    {
                        s = "Normal:" + s;
                        ct.SetState(new ConcreteStateComm(i + 1, ct));
                        return s;
                    }
                    else
                    {
                        s += c;
                    }
                }
            }
        }
        public class ConcreteStateString : State
        {
            private Context ct=null;
            private int index=0;
            public ConcreteStateString(int x, Context p) { index = x; ct = p; }
            public override string GetNextToken()
            {
                string s = "";
                char c;
                for (int i = index; ; i++)
                {
                    c = ct.GetCharAt(i);
                    if (c == '.') { s = "ErrString:" + s; ct.SetState(new ConcreteStateFin()); return s; }
                    if (c == '\"')
                    {
                        if (ct.GetCharAt(i + 1) == '\"')
                        {
                            s += "\"";
                            i++;
                        }
                        else
                        {
                            s = "String:" + s;
                            ct.SetState(new ConcreteStateNormal(i + 1, ct));
                            return s;
                        }
                    }
                    else
                    {
                        s = s + c.ToString();
                    }
                }
            }
        }
        public class ConcreteStateComm : State
        {
            private Context ct=null;
            private int index=0;
            public ConcreteStateComm(int x, Context p) { index = x; ct = p; }
            public override string GetNextToken()
            {
                string s = "";
                char c;
                for (int i = index; ; i++)
                {
                    c = ct.GetCharAt(i);
                    if (c == '.') { s = "ErrComm:" + s; ct.SetState(new ConcreteStateFin()); return s; }
                    if (c == '}')
                    {
                        s = "Comm:" + s;
                        ct.SetState(new ConcreteStateNormal(i + 1, ct));
                        return s;
                    }
                    else
                    {
                        s = s + c.ToString();
                    }
                }
            }
        }
        public class ConcreteStateFin : State
        {
            public override string GetNextToken()
            {
                string s = "err";
                return s;
            }
        }
        public static void Solve()
        {
            Task("OOP3Behav10");
            string s=GetString();
            Context A = new Context(s);
            string text;
            text = A.GetNextToken();
            while (text != "err")
            {
                Put(text);
                text = A.GetNextToken();
            }
        }
    }
}

// File: "OOP3Behav14"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class Request
        {
            public abstract string ToStr();
            public abstract string getparam();
        }
        public class RequestA : Request 
        {
            public int param;
            public RequestA(int x)
            {
                this.param = x;
            }
            public override string getparam()
            {
                return param.ToString();
            }
            public override string ToStr()
            {
                return "A:" + param.ToString();
                throw new NotImplementedException();
            }
        }
        public class RequestB : Request
        {
            string param;
            public RequestB(string s)
            {
                this.param = s;
            }
            public override string getparam()
            {
                return param;
            }
            public override string ToStr()
            {
                return "B:" + param;
                throw new NotImplementedException();
            }
        }
        // Implement the RequestA and RequestB descendant classes

        public class Handler
        {
            Handler successor;
            public Handler(Handler successor)
            {
                this.successor = successor;
            }
            public virtual void HandleRequest(Request req)
            {
                if (successor != null)
                {
                    successor.HandleRequest(req);
                }
                else
                {
                    Put("Request "+req.ToStr()+ " not processed");
                }
                // Implement the method
            }
        }
        public class HandlerA : Handler
        {
            int id;
            int param1;
            int param2;
            public HandlerA(Handler successor,int id,int param1,int param2):base(successor)
            {
                this.id = id;
                this.param1 = param1;
                this.param2 = param2;
            }
            public override void HandleRequest(Request req)
            {
                if (req.ToStr()[0] == 'A')
                { 
                    if(Convert.ToInt32(req.getparam()) >= param1 && Convert.ToInt32(req.getparam()) <= param2)
                    {
                        Put("Request " + req.ToStr() + " processed by handler " + id.ToString());
                        return;
                    }
                }
                base.HandleRequest(req);
            }
        }
        public class HandlerB : Handler
        {
            int id;
            string param1;
            string param2;
            public HandlerB(Handler successor, int id, string param1, string param2) : base(successor)
            {
                this.id = id;
                this.param1 = param1;
                this.param2 = param2;
            }
            public override void HandleRequest(Request req)
            {
                if (req.ToStr()[0] == 'B')
                {
                    if (string.CompareOrdinal(req.getparam(), param1) >= 0 && string.CompareOrdinal(req.getparam(), param2) <= 0)
                    {
                        Put("Request " + req.ToStr() + " processed by handler " + id);
                        return;
                    }
                }
                base.HandleRequest(req);
            }
        }
        // Implement the HandlerA and HandlerB descendant classes

        public class Client
        {
            Handler h;
            public Client(Handler h)
            {
                this.h = h;
            }
            public void SendRequest(Request req)
            {
                h.HandleRequest(req);
            }
        }

        public static void Solve()
        {
            Task("OOP3Behav14");
            int n = GetInt();
            Handler h = new Handler(null);
            for(int i=0;i<n; i++)
            {
                char c = GetChar();
                if(c=='A')
                {
                    int n1 = GetInt();
                    int n2 = GetInt();
                    h=new HandlerA(h,i,n1,n2);
                }
                else
                {
                    string s1 = GetString();
                    string s2 = GetString();
                    h = new HandlerB(h, i, s1, s2);
                }               
            }
            Client cl = new Client(h);
            int k = GetInt();
            for(int i=0;i<k;i++)
            {
                char c = GetChar();
                if (c == 'A')
                {
                    int x = GetInt();
                    cl.SendRequest(new RequestA(x));
                }
                else
                {
                    string s = GetString();
                    cl.SendRequest(new RequestB(s));
                }
            }
        }
    }
}

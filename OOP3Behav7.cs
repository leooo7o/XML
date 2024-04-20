// File: "OOP3Behav7"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class Aggregate
        {
            public abstract Iterator CreateIterator();
        }
        public class ConcreteAggregateA: Aggregate
        {
            public int data;
            public int x = 1;
            public ConcreteAggregateA(int data)
            {
                this.data = data;
            }
            public override Iterator CreateIterator()
            {
                return new ConcreteIteratorA(this);
                throw new NotImplementedException();
            }
        }
        public class ConcreteAggregateB : Aggregate
        {
            public string data;
            public int n = 0;
            public ConcreteAggregateB(string data)
            {
                this.data = data;
            }
            public override Iterator CreateIterator()
            {
                return new ConcreteIteratorB(this);
                throw new NotImplementedException();
            }
        }
        public class ConcreteAggregateC : Aggregate
        {
            public int x = 1;
            public int n = 0;
            public List<int> l = new List<int>();
            public ConcreteAggregateC(List<int>l)
            {
                this.l = l;
            }
            public override Iterator CreateIterator()
            {
                return new ConcreteIteratorC(this);
                throw new NotImplementedException();
            }
        }
        // Implement the ConcreteAggregateA, ConcreteAggregateB
        //   and ConcreteAggregateC descendant classes

        public abstract class Iterator
        {
            public abstract void First();
            public abstract void Next();
            public abstract bool IsDone();
            public abstract int CurrentItem();
        }
        public class ConcreteIteratorA : Iterator
        {
            ConcreteAggregateA aggregate;
            public ConcreteIteratorA(ConcreteAggregateA aggregate)
            {
                this.aggregate = aggregate;
            }
            public override void First()
            {
                aggregate.x = 1;
            }
            public override void Next()
            {
                aggregate.x = aggregate.x * 10;
            }
            public override bool IsDone()
            {
                return Convert.ToBoolean(aggregate.data) && Convert.ToBoolean(aggregate.data / aggregate.x == 0) || !Convert.ToBoolean(aggregate.data) && Convert.ToBoolean(aggregate.x == 10);
            }
            public override int CurrentItem()
            {
                return Math.Abs((aggregate.data / aggregate.x) % 10);
            }

        }
        public class ConcreteIteratorB : Iterator
        {
            ConcreteAggregateB aggregate;
            public ConcreteIteratorB(ConcreteAggregateB aggregate)
            {
                this.aggregate = aggregate;
            }
            public override void First()
            {
                aggregate.n = aggregate.data.Length - 1;
                while (aggregate.n >= 0 && (aggregate.data[aggregate.n] >= '0' && aggregate.data[aggregate.n] <= '9') == false)
                {
                    aggregate.n--;
                }
            }
            public override void Next()
            {
                aggregate.n--;
                while (aggregate.n >= 0 && (aggregate.data[aggregate.n] >= '0' && aggregate.data[aggregate.n] <= '9') == false)
                {
                    aggregate.n--;
                }
            }
            public override bool IsDone()
            {
                if (aggregate.n < 0)
                    return true;
                else
                    return false;
            }
            public override int CurrentItem()
            {
                return aggregate.data[aggregate.n] - '0';
            }
        }
        public class ConcreteIteratorC : Iterator
        {
            ConcreteAggregateC aggregate;
            public ConcreteIteratorC(ConcreteAggregateC aggregate)
            {
                this.aggregate = aggregate;
            }
            public override void First()
            {
                aggregate.n = aggregate.l.Count - 1;
                aggregate.x = 1;
            }
            public override void Next()
            {
                aggregate.x = aggregate.x * 10;
                int data = aggregate.l[aggregate.n];
                int divied = aggregate.x;
                if (Convert.ToBoolean(data) && data / divied == 0 || !Convert.ToBoolean(data) && divied == 10)
                {
                    aggregate.n--;
                    aggregate.x = 1;
                }
            }
            public override bool IsDone()
            {
                if (aggregate.n < 0)
                    return true;
                else
                    return false;
            }
            public override int CurrentItem()
            {
                return Math.Abs(aggregate.l[aggregate.n] / aggregate.x % 10);
            }
        }
        // Implement the ConcreteIteratorA, ConcreteIteratorB
        //   and ConcreteIteratorC descendant classes

        public static void Solve()
        {
            Task("OOP3Behav7");
            int n = GetInt();
            List<Aggregate> L = new List<Aggregate>();
            for(int i=0;i<n;i++)
            {
                char c = GetChar();
                if(c=='A')
                {
                    int x = GetInt();
                    L.Add(new ConcreteAggregateA(x));
                }
                else if(c=='B')
                {
                    string s = GetString();
                    L.Add(new ConcreteAggregateB(s));
                }
                else
                {
                    int x = GetInt();
                    List<int> ln = new List<int>();
                    for(int j = 0; j < x; j++)
                    {
                        int m = GetInt();
                        ln.Add(m);
                    }
                    L.Add(new ConcreteAggregateC(ln));
                }
            }
            for (int i = L.Count - 1; i >= 0; i--)
            {
                List<int> L3 = new List<int>();
                var it = L[i].CreateIterator();
                for (it.First(); !it.IsDone(); it.Next())
                {
                    L3.Add(it.CurrentItem());
                }
                int count = 0;
                foreach (int x in L3)
                {
                    count += x;
                }
                Put(count);
                foreach (int x in L3)
                {
                    Put(x);
                }

            }
        }
    }
}

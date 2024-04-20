// File: "OOP2Struc6"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class Device
        {
            public virtual void Add(Device d) {}
            public abstract string GetName();
            public abstract int GetTotalPrice();
        }
        public class SimpleDevice : Device
        {
            string name;
            int price;
            public SimpleDevice(string str,int x)
            {
                name = str; 
                price = x;
            }
            public override void Add(Device d)
            {
            }
            public override string GetName()
            {
                return this.name;
            }
            public override int GetTotalPrice()
            {
                return this.price;
            }
        }
        public class CompoundDevice : Device
        {
            string name;
            int price;
            List<Device> m;
            public CompoundDevice(string str, int x)
            {
                name = str;
                price = x;
                m = new List<Device>();
            }
            public override void Add(Device d)
            {
                this.m.Add(d);
            }
            public override string GetName()
            {
                return this.name;
            }
            public override int GetTotalPrice()
            {
                int x = price;
                for (int i=0;i<m.Count;i++) 
                { x += m[i].GetTotalPrice(); }
                return x;
            }
        }
        // Implement the SimpleDevice
        //   and CompoundDevice descendant classes

        public static void Solve()
        {
            Task("OOP2Struc6");
            int n=GetInt();
            List<string> v1=new List<string>();
            List<int> v2=new List<int>();
            List<int> v3=new List<int>();
            List<Device> v4=new List<Device>();
            List<Device> v5=new List<Device>();
            for (int i = 0; i < n; i++)
            {
                string s=GetString();
                int x=GetInt();
                v1.Add(s);
                v2.Add(x);
            }
            for (int i = 0; i < n; i++)
            {
                int x=GetInt();
                v3.Add(x);
                Device com = new CompoundDevice(v1[i], v2[i]);
                Device p = new SimpleDevice(v1[i], v2[i]);
                v4.Add(com);
                v5.Add(p);
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == v3[j])
                    {
                        v4[i].Add(v4[j]);
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (v1[i][0] >= 'a' && v1[i][0] <= 'z')
                {
                    Put(v5[i].GetName());
                    Put(v5[i].GetTotalPrice());
                }
                else
                {
                    Put(v4[i].GetName());
                    Put(v4[i].GetTotalPrice());
                }
            }
        }
    }
}

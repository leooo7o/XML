// File: "OOP3Behav6"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static bool num(string str)
        {
            if (str == "") return false;
            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] >= '0' && str[i] <= '9') || str[i] == '-')
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public abstract class AbstractComparable
        {
            public int IndexMax(List<AbstractComparable> a)
            {
                AbstractComparable ans = a[0];
                int max = 0;
                for (int i = 0; i < a.Count; i++)
                {
                    if (a[i].CompareTo(ans) > 0)
                    {
                        max = i;
                        ans = a[i];
                    }
                }
                return max;
            }
            public int LastIndexMax(List<AbstractComparable> a)
            {
                AbstractComparable ans = a[0];
                int max = 0;
                for (int i = 0; i < a.Count; i++)
                {
                    if (a[i].CompareTo(ans) >= 0)
                    {
                        max = i;
                        ans = a[i];
                    }
                }
                return max;
            }
            public int IndexMin(List<AbstractComparable> a)
            {
                AbstractComparable ans = a[0];
                int min = 0;
                for (int i = 0; i < a.Count; i++)
                {
                    if (a[i].CompareTo(ans) < 0)
                    {
                        min = i;
                        ans = a[i];
                    }
                }
                return min;
            }
            public int LastIndexMin(List<AbstractComparable> a)
            {
                AbstractComparable ans = a[0];
                int min = 0;
                for (int i = 0; i < a.Count; i++)
                {
                    if (a[i].CompareTo(ans) <= 0)
                    {
                        min = i;
                        ans = a[i];
                    }
                }
                return min;
            }
            public abstract int CompareTo(AbstractComparable other);

            // Implement the IndexMax, LastIndexMax, IndexMin
            //   and LastIndexMin static methods
        }
        public class NumberComparable :AbstractComparable {
        string text;
        public NumberComparable(string s) { text = s; }
        public override int CompareTo(AbstractComparable other)
        {
            NumberComparable a = (NumberComparable)(other);
            int x1, x2;
            if (num(text))
            {
                x1 = int.Parse(text);
            }
            else x1 = 0;
            if (num(a.text))
            {
                x2 = int.Parse(a.text);
            }
            else x2 = 0;
            if (x1 > x2)
                return 1;
            else if (x1 < x2)
                return -1;
            else
                return 0;
        }
    }
    public class LengthComparable : AbstractComparable {
    string text;
    public LengthComparable(string s) { text = s; }
    public override int CompareTo(AbstractComparable other)
    {
        LengthComparable a = (LengthComparable)(other);
        if (this.text.Length > a.text.Length)
            return 1;
        else if (this.text.Length < a.text.Length)
            return -1;
        else
            return 0;
    }
}
    public class TextComparable : AbstractComparable
{
    string text;
    public TextComparable(string s) { text = s; }
    public override int CompareTo(AbstractComparable other)
{
    TextComparable a = (TextComparable)(other);
    if (String.CompareOrdinal(this.text,a.text)>0)
        return 1;
    else if (this.text == a.text)
        return 0;
    else
        return -1;
}
}
// Implement the NumberComparable, LengthComparable
//   and TextComparable descendant classes

public static void Solve()
        {
            Task("OOP3Behav6");
            int n=GetInt(), k=GetInt();
            for (int i = 0; i < k; i++)
            {
                string c=GetString();
                List<AbstractComparable> V=new List<AbstractComparable>();
                for (int j = 0; j < n; j++)
                {
                    string s=GetString();
                    AbstractComparable a;
                    if (c == "N")
                    {
                        a = new NumberComparable(s);
                    }
                    else if (c == "L")
                    {
                        a = new LengthComparable(s);
                    }
                    else
                    {
                        a = new TextComparable(s);
                    }
                    V.Add(a);
                }
                Put(V[0].IndexMax(V));
                Put(V[0].LastIndexMax(V));
                Put(V[0].IndexMin(V));
                Put(V[0].LastIndexMin(V));
            }
        }
    }
}

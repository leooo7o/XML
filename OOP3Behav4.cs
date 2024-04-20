// File: "OOP3Behav4"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public class Validator
        {
            public virtual string Validate(string s)
            {
                return "";
            }
        }
        class EmptyValidator : Validator
        {
            public override string Validate(string s)
            {
                if (s == "")
                {
                    string text;
                    text = "!Empty text";
                    return text;
                }
                else
                {
                    string text = "";
                    return text;
                }
            }
        }

        class NumberValidator : Validator
        {
            public bool AllisNum(string str)
            {
                if (str == "") return false;
                for (int i = 0; i < str.Length; i++)
                {
                    int tmp = (int)str[i];
                    if (tmp >= 48 && tmp <= 57 || tmp == '-')
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
            public override string Validate(string s)
            {
                if (AllisNum(s))
                {
                    string text = "";
                    return text;
                }
                else
                {
                    string text = "!'" + s + "': not a number";
                    return text;
                }
            }
        }
            class RangeValidator : Validator
            {
                int max;
                int min;
                public bool AllisNum(string str)
                {
                    if (str == "") return false;
                    for (int i = 0; i < str.Length; i++)
                    {
                        int tmp = (int)str[i];
                        if (tmp >= 48 && tmp <= 57 || tmp == '-')
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
                public override string Validate(string s)
                {
                    string text;
                    int x;
                    if (AllisNum(s))
                    {
                        x = int.Parse(s);
                    }
                    else
                    {
                        text = "!'" + s + "': not in range" + " " + min.ToString() + ".." + max.ToString();
                        return text;
                    }
                    if (x >= min && x <= max)
                    {
                        return "";
                    }
                    else
                    {
                        text = "!'" + s + "': not in range" + " " + min.ToString() + ".." + max.ToString();
                        return text;
                    }
                }
                public RangeValidator(int a, int b)
                {
                    min = a;
                    max = b;
                }
            }
            // Implement the EmptyValidator, NumberValidator
            //   and RangeValidator descendant classes
            class TextBox
            {
                Validator v;
                string text;
                public TextBox() { v = new Validator(); text = ""; }
                public void SetText(string s) { text = s; }
                public void SetValidator(Validator h) { v = h; }
                public string Validate()
                {
                    string s = v.Validate(text);
                    return s;
                }
            }
            class TextForm
            {
                List<TextBox> tb;
                int n=0;
                public TextForm(int x)
                {
                n = x;
                tb = new List<TextBox>();
                for (int i = 0; i < x; i++)
                {
                    tb.Add(new TextBox());
                }
            }
                public void SetText(int ind, string text)
                {
                    tb[ind].SetText(text);
                }
                public void SetValidator(int ind, Validator v)
                {
                    tb[ind].SetValidator(v);
                }
                public string Validate()
                {
                    string s = "";
                    for (int i = 0; i < n; i++)
                    {
                        s += tb[i].Validate();
                    }
                    return s;
                }
            }
            // Implement the TextBox and TextForm classes

            public static void Solve()
            {
                Task("OOP3Behav4");
                int n = GetInt(), a = GetInt(), b = GetInt(), k = GetInt();
                List<string> ans = new List<string>();
                List<TextForm> v = new List<TextForm>();
            TextForm t;
            Show("continue");
            for (int i = 0; i < 5; i++)
            {
                t = new TextForm(n);
                v.Add(t);
            }
            Show("continue");
            for (int j = 0; j < k; j++)
            {
                int x = GetInt();
                char c = GetChar();

                if (c == 'N')
                {
                    for (int i = 0; i < 5; i++)
                    {
                        v[i].SetValidator(x, new NumberValidator());
                    }
                }
                else if (c == 'E')
                {
                    for (int i = 0; i < 5; i++)
                    {
                        v[i].SetValidator(x, new EmptyValidator());
                    }
                }
                else
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (a <= b)
                            v[i].SetValidator(x, new RangeValidator(a, b));
                        else
                            v[i].SetValidator(x, new RangeValidator(b, a));
                    }
                }
            }

            string s;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    s = GetString();
                    v[i].SetText(j, s);
                }
            }
            for (int i = 0; i < 5; i++)
            {
                Put(v[i].Validate());
            }
        }
        }
    }

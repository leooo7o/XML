// File: "OOP1Creat5"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class AbstractButton
        {
            public abstract string GetControl();
        }
        class Button1: AbstractButton
        {
            public string s;
            public Button1(string text) { s = text; }
            public override string GetControl()
            {
                string s2;
                s2=s.ToUpper();
                string text = "[" + s2 + "]";
                return text;
            }
        }
        class Button2 : AbstractButton
        {
            public string s;
            public Button2(string text)
            {
                s = text;
            }
            public override string GetControl()
            {
                string s2;
                s2=s.ToLower();
                string text = "<" + s2 + ">";
                return text;
            }
        }
        // Implement the Button1 and Button2 descendant classes

        public abstract class AbstractLabel
        {
            public abstract string GetControl();
        }
        class Label1 : AbstractLabel
        {
            public string s;
            public Label1(string text) { s = text; }
            public override string GetControl()
            {
                string s2;
                s2=s.ToUpper();
                string text = "=" + s2 + "=";
                return text;
            }
        }
        class Label2 : AbstractLabel
        {
            public string s;
            public Label2(string text) { s = text; }
            public override string GetControl()
            {
                string s2;
                s2=s.ToLower();
                string text = "\"" + s2 + "\"";
                return text;
            }
        }
        // Implement the Label1 and Label2 descendant classes

        public abstract class ControlFactory
        {
            public abstract AbstractButton CreateButton(string text);
            public abstract AbstractLabel CreateLabel(string text);
        }
        class Factory1 : ControlFactory
        {
            public override AbstractButton CreateButton(string text)
            {
                Button1 a1 = new Button1(text);
                return a1;
            }
            public override AbstractLabel CreateLabel(string text)
            {
                Label1 a1 = new Label1(text);
                return a1;
            }
        }
        class Factory2 : ControlFactory
        {
            public override AbstractButton CreateButton(string text)
            {
                Button2 a1 = new Button2(text);
                return a1;
            }
            public override AbstractLabel CreateLabel(string text)
            {
                Label2 a1 = new Label2(text);
                return a1;
            }
        }
        // Implement the Factory1 and Factory2 descendant classes

        public class Client
        {
            // Add required fields
            ControlFactory m_f;
            string s;
            public Client(ControlFactory f)
            {
                m_f = f;
            }
            public void AddButton(string text)
            {
                AbstractButton a = m_f.CreateButton(text);
                s = a.GetControl();
            }
            public void AddLabel(string text)
            {
                AbstractLabel a = m_f.CreateLabel(text);
                s = a.GetControl();
            }
            public string GetControls()
            {
                return s;
                // Remove the previous statement and implement the method
            }
        }

        public static void Solve()
        {
            Task("OOP1Creat5");
            int n=GetInt();
            string[] V=new string[n];
            for (int i = 0; i < n; i++)
            {
                V[i] = GetString();
            }
            string ans = "";
            for (int i = 0; i < n; i++)
            {
                if (V[i][0] == 'B')
                {
                    Client p = new Client(new Factory1());
                    p.AddButton(V[i].Substring(2));
                    ans += p.GetControls();
                    ans += " ";
                }
                else if (V[i][0] == 'L')
                {
                    Client p = new Client(new Factory1());
                    p.AddLabel(V[i].Substring(2));
                    ans += p.GetControls();
                    ans += " ";
                }
            }
            ans=ans.Substring(0,ans.Length-1);
            //ans[ans.Length - 1] = 0;
            Put(ans);
            string ans2 = "";
            for (int i = 0; i < n; i++)
            {
                if (V[i][0] == 'B')
                {
                    Client p = new Client(new Factory2());
                    p.AddButton(V[i].Substring(2));
                    ans2 += p.GetControls();
                    ans2 += " ";
                }
                else if (V[i][0] == 'L')
                {
                    Client p = new Client(new Factory2());
                    p.AddLabel(V[i].Substring(2));
                    ans2 += p.GetControls();
                    ans2 += " ";
                }
            }
            ans2 = ans2.Substring(0, ans2.Length - 1);
            Put(ans2);
        }
    }
}

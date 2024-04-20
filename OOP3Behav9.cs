// File: "OOP3Behav9"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static class OperationA
        {
            public static void ActionA()
            {
                Put("+A");
            }
            public static void UndoActionA()
            {
                Put("-A");
            }
        }

        public static class OperationB
        {
            public static void ActionB()
            {
                Put("+B");
            }
            public static void UndoActionB()
            {
                Put("-B");
            }
        }

        public static class OperationC
        {
            public static void ActionC()
            {
                Put("+C");
            }
            public static void UndoActionC()
            {
                Put("-C");
            }
        }

        public abstract class Command
        {
            public abstract void Execute();
            public abstract void Unexecute();
        }
        public class CommandA : Command
        {
            public override void Execute()
            {
                OperationA.ActionA();
            }
            public override void Unexecute()
            {
                OperationA.UndoActionA();
            }
        }
        public class CommandB : Command
        {
            public override void Execute()
            {
                OperationB.ActionB();
            }
            public override void Unexecute()
            {
                OperationB.UndoActionB();
            }
        }
        public class CommandC : Command
        {
            public override void Execute()
            {
                OperationC.ActionC();
            }
            public override void Unexecute()
            {
                OperationC.UndoActionC();
            }
        }
        public class MacroCommand : Command
        {
            List<Command> cmds=new List<Command>();
            public MacroCommand(Command cmd1,Command cmd2)
            {
                cmds.Add(cmd1);
                cmds.Add(cmd2);
            }
            public override void Execute()
            {
                for (int i = 0; i < cmds.Count(); i++) { cmds[i].Execute(); }
            }
            public override void Unexecute()
            {
                for (int i = cmds.Count() - 1; i >= 0; i--) { cmds[i].Unexecute(); }
            }
        }
        // Implement the CommandA, CommandB, CommandC
        //   and MacroCommand descendant classes

        public class Menu
        {
            List<Command> availcmds=new List<Command>();
            List<Command> lastcmds=new List<Command>();
            int undoIndex;
            // Add required fields
            public Menu(Command cmd1, Command cmd2)
            {
                Command a = cmd1;
                Command b = cmd2;
                MacroCommand c = new MacroCommand(a, b);
                availcmds.Add(a);
                availcmds.Add(b);
                availcmds.Add(c);
                undoIndex = -1;
            }
            public void Invoke(int cmdIndex)
            {
                availcmds[cmdIndex].Execute();
                lastcmds.RemoveRange(undoIndex+1, lastcmds.Count()-undoIndex-1);
                lastcmds.Add(availcmds[cmdIndex]);
                undoIndex = lastcmds.Count()-1;
                Show(undoIndex);
            }
            public void Undo(int count)
            {
                int x = count;
                int i = undoIndex;
                for (; i >= 0 && x > 0; i--)
                {
                    lastcmds[i].Unexecute();
                    x--;
                }
                undoIndex = i;
            }
            public void Redo(int count)
            {
                int x = count;
                int i = undoIndex + 1;
                for (; i < lastcmds.Count() && x > 0; i++)
                {
                    lastcmds[i].Execute();
                    x--;
                }
                undoIndex = i - 1;
            }
        }

        public static void Solve()
        {
            Task("OOP3Behav9");
            char c1=GetChar();
            char c2=GetChar();
            int n=GetInt();
            Command p1;
            Command p2;
            if (c1 == 'A')
                p1 = new CommandA();
            else if (c1 == 'B')
                p1 = new CommandB();
            else
                p1 = new CommandC();
            if (c2 == 'A')
                p2 = new CommandA();
            else if (c2 == 'B')
                p2 = new CommandB();
            else
                p2 = new CommandC();
            Menu m = new Menu(p1, p2);
            for (int i = 0; i < n; i++)
            {
                string s=GetString();
                if (s[0] == 'I')
                    m.Invoke(s[1] - '0');
                else if (s[0] == 'U')
                    m.Undo(s[1] - '0');
                else
                    m.Redo(s[1] - '0');
            }
        }
    }
}

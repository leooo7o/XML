// File: "OOP1Creat3"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class Animal
        {
            public abstract string GetInfo();
        }
        class Cobra : Animal
        {
            public override string GetInfo()
            {
                string s = "Cobra";
                return s;
            }
        }
        class Python : Animal
        {
            public override string GetInfo()
            {
                string s = "Python";
                return s;
            }
        }
        class Anaconda : Animal
        {
            public override string GetInfo()
            {
                string s = "Anaconda";
                return s;
            }
        }
        class Gorilla : Animal
        {
            public override string GetInfo()
            {
                string s = "Gorilla";
                return s;
            }
        }
        class Orangutan : Animal
        {
            public override string GetInfo()
            {
                string s = "Orangutan";
                return s;
            }
        }
        class Chimpanzee : Animal
        {
            public override string GetInfo()
            {
                string s = "Chimpanzee";
                return s;
            }
        }
        // Implement the Cobra, Python, Anaconda, Gorilla,
        //   Orangutan and Chimpanzee descendant classes

        public abstract class AnimalCreator
        {
            protected abstract Animal CreateAnimal(int n);
            public Animal[] GetZoo(int[] id)
            {
                Animal[] zoo = new Animal[id.Length];
                for (int i = 0; i < zoo.Length; i++)
                    zoo[i] = CreateAnimal(id[i]);
                return zoo;
            }
        }
        class SnakeCreator:AnimalCreator
        {
            protected override Animal CreateAnimal(int n)
            {
                if (n == 1)
                {
                    Cobra a1 = new Cobra();
                    return a1;
                }
                if (n == 2)
                {
                    Python a2 = new Python();
                    return a2;
                }
                else
                {
                    Anaconda a3 = new Anaconda();
                    return a3;
                }
            }
        }
        class ApeCreator : AnimalCreator
        {
            protected override Animal CreateAnimal(int n)
            {
                if (n == 1)
                {
                    Gorilla a1 = new Gorilla();
                    return a1;
                }
                if (n == 2)
                {
                    Orangutan a2 = new Orangutan();
                    return a2;
                }
                else
                {
                    Chimpanzee a3 = new Chimpanzee();
                    return a3;
                }
            }
        }
        // Implement the SnakeCreator and ApeCreator descendant classes

        public static void Solve()
        {
            Task("OOP1Creat3");
            int[] V = new int[5];
            Animal[] V1;
            Animal[] V2;
            for (int i = 0; i < 5; i++)
            {
                V[i] = GetInt();
            }
            SnakeCreator e1=new SnakeCreator();
            ApeCreator e2=new ApeCreator();
            V1 = e1.GetZoo(V);
            V2 = e2.GetZoo(V);
            for (int i = 0; i < V1.Length; i++)
            {
                Put(V1[i].GetInfo());
            }
            for (int i = 0; i < V2.Length; i++)
            {
                Put(V2[i].GetInfo());
            }
        }
    }
}

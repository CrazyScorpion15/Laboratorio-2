using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class Generics<T>
    {
        public class Node<T>
        {
            public T Name;
            public T Coach;
            public T CreationD;
            public T League;
            public Node<T> Front;
            public Node<T> Back;
        }
        Node<T> Head;
        public bool Add(T name, T coach, T creationd, T league)
        {
            Node<T> New = new Node<T>();
            New.Name = name;
            New.Coach = coach;
            New.CreationD = creationd;
            New.League = league;
            if (Head == null)
            {
                Head.Back = New;
            }
            Head = New;
            return true;
        }
    }
}

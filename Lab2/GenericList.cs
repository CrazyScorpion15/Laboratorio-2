using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class GenericList<T>
    {
        Node<T> Head;

        public bool Add<List>(T Value)
        {
            Node<T> Nuevo = new Node<T>
            {
                value = Value,
            };
            if (Head == null)
            {
                Nuevo.Previous = Head;
            }
            else
            {
                Nuevo.Next = Head;
            }
            return true;
        }
    }
}

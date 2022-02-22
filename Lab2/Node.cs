using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class Node<T>
    {
        public T value;
        public Node<T> Next;
        public Node<T> Previous;
    }
}

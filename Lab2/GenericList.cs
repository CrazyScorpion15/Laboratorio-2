using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class GenericList<T> : IEnumerable <T>
    {
        Node<T> Head;
        public void Add<List>(T Value)
        {
            Node<T> Nuevo = new Node<T>();
            Nuevo.value = Value;
            Nuevo.Next = Head;
            if(Head != null)
            {
                Head.Previous = Nuevo;
            }
            Head = Nuevo;
        }
        public bool Search<List>(T id)
        {

            for(Node<T> indice = Head; indice != null; indice = indice.Next)
            {
                /*
                if(indice.value == id)
                {

                }
                */
            }
            return true;
        }
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> node = Head;
            while(node != null)
            {
                yield return node.value;
                node = node.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}

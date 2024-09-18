using System;

namespace Listas_Cirular_Simplemente_Enlazada
{
    internal class Program
    {
        class SimpleCircularLinkedList<T>
        {
            class Node
            {
                public T Value { get; set; }
                public Node Next { get; set; }
                public Node(T value)
                {
                    Value = value;
                    Next = null;
                }
            }
            private Node Head { get; set; }
            public int Count { get; set; }

            public void InsertAtStart(T value)
            {
                Node newNode = new Node(value);
                if (Head == null)
                {
                    Head = newNode;
                    newNode.Next = Head;
                }
                else
                {
                    Node lastNode = SearchLastNode();
                    newNode.Next = Head;
                    lastNode.Next = newNode;
                    Head = newNode;
                }
                ++Count;
            }
            public void InsertAtEnd(T value)
            {
                if (Head == null)
                {
                    InsertAtStart(value);
                }
                else
                {
                    Node newNode = new Node(value);
                    Node lastNode = SearchLastNode();
                    lastNode.Next = newNode;
                    newNode.Next = Head;
                    ++Count;
                }
            }
            public void InsertAtPosition(T value, int position)
            {
                if (position == 0)
                {
                    InsertAtStart(value);
                }
                else if (position == Count)
                {
                    InsertAtEnd(value);
                }
                else if (position > Count)
                {
                    throw new NullReferenceException("No se puede hacer eso");
                }
                else
                {
                    Node previousNode = Head;
                    Node newNode = new Node(value);
                    int iterator = 0;
                    while (iterator < position - 1)
                    {
                        previousNode = previousNode.Next;
                        ++iterator;
                    }
                    Node positionNode = previousNode.Next;
                    previousNode.Next = newNode;
                    newNode.Next = positionNode;
                    ++Count;
                }
            }
            public void ModifyAtStart(T value)
            {
                if (Head == null)
                {
                    throw new NullReferenceException("no se puede");
                }
                else
                {
                    Head.Value = value;
                }
            }
            public void ModifyAtEnd(T value)
            {
                if (Head == null)
                {
                    ModifyAtStart(value);
                }
                else
                {
                    Node lastNode = SearchLastNode();
                    lastNode.Value = value;
                }
            }
            public void ModifyAtPosition(T value, int position)
            {
                if (position == 0)
                {
                    InsertAtStart(value);
                }
                else if (position == Count)
                {
                    InsertAtEnd(value);
                }
                else if (position > Count)
                {
                    throw new NullReferenceException("No se puede");
                }
                else
                {
                    Node current = Head;
                    int iterator = 0;
                    while (iterator < position)
                    {
                        current = current.Next;
                        iterator++;
                    }
                    current.Value = value;
                }
            }
            public T GetAtStart()
            {
                if (Head == null)
                {
                    throw new NullReferenceException("No se puede hacer eso");
                }
                else
                {
                    return Head.Value;
                }
            }
            public T GetAtEnd()
            {
                if (Head == null)
                {
                    return GetAtStart();
                }
                else
                {
                    Node lastNode = SearchLastNode();
                    return lastNode.Value;
                }
            }
            public T GetAtPosition(int position)
            {
                if(Count == 0)
                {
                    throw new NullReferenceException("No se puede");
                }
                else if(position == 0)
                {
                    return GetAtStart();
                }
                else if(position == Count)
                {
                    return GetAtEnd();
                }
                else
                {
                    Node current = Head;
                    int iterator = 0;
                    while (iterator < position)
                    {
                        current = current.Next;
                        iterator++;
                    }
                    return current.Value;
                }       
            } 
            public void DeleteAtStart()
            {
                if (Head == null)
                {
                    throw new NullReferenceException("La lista esta vacia");
                }
                else
                {
                    Node lastNode = SearchLastNode();
                    Node newHead = Head.Next;
                    Head.Next = null;
                    lastNode.Next = newHead;
                    Head = newHead;
                    --Count;
                }
            }
            public void DeleteAtEnd()
            {
                if (Head == null)
                {
                    DeleteAtStart();
                }
                else
                {
                    Node previousLastNode = Head;
                    while(previousLastNode.Next.Next != Head)
                    {
                        previousLastNode = previousLastNode.Next;
                    }
                    Node lastNode = previousLastNode.Next;
                    lastNode.Next = null;
                    lastNode = null;
                    previousLastNode.Next = Head;
                    --Count;
                }
            }
            public void DeleteAtPosition(int position)
            {
                if (position == 0)
                {
                    DeleteAtStart();
                }
                else if (position == Count)
                {
                    DeleteAtEnd();
                }
                else if(position > Count)
                {
                    throw new NullReferenceException("No se puede");
                }
                else
                {
                    Node previousNode = Head;
                    int iterator = 0;
                    while (iterator < position - 1) 
                    {
                        previousNode = previousNode.Next;
                        ++iterator;
                    }
                    Node currentNode = previousNode.Next;
                    Node nextNode = currentNode.Next;
                    currentNode.Next = null;
                    currentNode = null;
                    previousNode.Next = nextNode;
                    --Count; 
                }
            }
            private Node SearchLastNode()
            {
                Node tmp = Head;
                while (tmp.Next != Head)
                {
                    tmp = tmp.Next;
                }
                return tmp;
            }
            public void PrintAllNode()
            {
                Node tmp = Head;
                while(tmp.Next != Head)
                {
                    Console.Write(tmp.Value + "-");
                    tmp = tmp.Next;
                }
                Console.Write(tmp.Value);
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            SimpleCircularLinkedList<int> simpleCircularLinkedList = new SimpleCircularLinkedList<int>();
            simpleCircularLinkedList.InsertAtStart(5);
            simpleCircularLinkedList.InsertAtStart(4);
            simpleCircularLinkedList.InsertAtStart(2);
            simpleCircularLinkedList.InsertAtStart(7);
            simpleCircularLinkedList.InsertAtEnd(1);
            simpleCircularLinkedList.InsertAtEnd(3);
            simpleCircularLinkedList.InsertAtPosition(8,3);
            simpleCircularLinkedList.PrintAllNode();
            simpleCircularLinkedList.ModifyAtStart(12);
            simpleCircularLinkedList.ModifyAtEnd(6);
            simpleCircularLinkedList.ModifyAtPosition(13,3);
            simpleCircularLinkedList.PrintAllNode();
            Console.WriteLine("Inicio: " + simpleCircularLinkedList.GetAtStart());
            Console.WriteLine("Final: " + simpleCircularLinkedList.GetAtEnd());
            Console.WriteLine("Posicion 4: " + simpleCircularLinkedList.GetAtPosition(4));
            simpleCircularLinkedList.DeleteAtStart();
            simpleCircularLinkedList.DeleteAtStart();
            simpleCircularLinkedList.DeleteAtEnd();
            simpleCircularLinkedList.DeleteAtPosition(2);
            simpleCircularLinkedList.PrintAllNode();
            Console.ReadLine();
        }
    }
}

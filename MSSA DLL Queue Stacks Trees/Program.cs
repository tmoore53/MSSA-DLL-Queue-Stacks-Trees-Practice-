using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSA_DLL_Queue_Stacks_Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList2<int> myList = new LinkedList2<int>();
            myList.AddFirst(1);
            myList.AddFirst(2);
            myList.AddFirst(3);

            Console.WriteLine(myList);
            //Stack<int> mystack3 = new Stack<int>();  ///doesn't work properly yet!!!!
            //Doesn't work with integers
            //while (mystack3.Peek() != null)
            //{
            //    Console.WriteLine(mystack3.Pop());
            //}

            //stacking string values to mystack 
            Stack<string> mystack = new Stack<string>();
            mystack.Push("Saint");
            mystack.Push("Martin");
            mystack.Push("2020");
            mystack.Pop();
            //Console.WriteLine(mystack.Pop());
            //Console.WriteLine(mystack.Pop());
            //Console.WriteLine(mystack.Pop());

            Console.WriteLine(mystack);


            //application for queues: reverse the contents of a file
            StreamReader inFile = new StreamReader("input.txt");
            Stack<string> myStack2 = new Stack<string>();

            //read every line from the file
            string line = inFile.ReadLine();
            while(line!=null)
            {
                myStack2.Push(line);
                line = inFile.ReadLine();
            }
            Console.WriteLine(myStack2);
            inFile.Close();

            StreamWriter outFile = new StreamWriter("ouput.txt");
            while(myStack2.Peek()!=null)
            {
                outFile.WriteLine(myStack2.Pop());
            }
            outFile.Close();



            Queue myQueue = new Queue();
            myQueue.Enqueue(10);
            myQueue.Enqueue(20);
            myQueue.Enqueue(30);
            myQueue.Enqueue(40);
            Console.WriteLine(myQueue.Dequeue());
            Console.WriteLine(myQueue.Dequeue());
            Console.WriteLine(myQueue.Dequeue());
            Console.WriteLine(myQueue.Dequeue());


            Stack<int> myStack4 = new Stack<int>();
            myStack4.Push(10);
            myStack4.Push(20);
            myStack4.Push(30);
            myStack4.Push(40);
            Console.WriteLine(myStack4.Pop());
            Console.WriteLine(myStack4.Pop());
            Console.WriteLine(myStack4.Pop());
            Console.WriteLine(myStack4.Pop());

            BinarySearchTree myTree = new BinarySearchTree();
            myTree.Insert(21);
            myTree.Insert(3);
            myTree.Insert(-3);
            myTree.Insert(9);
            myTree.Insert(3);

            Console.WriteLine(myTree.GetMaxValue()) ;
        }

      

    }

    //Creating my own generic single linked list 
    class LinkedList2<T> : LinkedList<T> //inheritance
    {
        public override string ToString()
        {
            string ret = "";
            foreach (var value in this)
            {
                ret += value + " ";
            }
            //ret = string.Join(",", this);
            return ret;
        }
    }

    //creating my own genaric stack
    class Stack<T> 
    {
        //data
        LinkedList<T> allValues;

        //methods
        public void Push(T newValue)
        {
            allValues.AddFirst(newValue);
        }
        public T Pop()
        {
            if(allValues.Count>0)
            {
                T first = Peek();
                allValues.RemoveFirst();
                return first;
            }
            else
            {
                throw new Exception("the stack is empty ... you can't pop elements from it");
            }
        }
        public T Peek()
        {
            if (allValues.Count > 0)
                return allValues.First();
            else
            {
                Object result = null;
                return default(T);

            }
        }

        //ctor
        public Stack()
        {
            allValues = new LinkedList<T>();
        }

        public override string ToString()
        {
            string ret="";
            foreach(var val in allValues)
            {
                ret = ret+ val +"\n";
            }
            return ret;
        }
    }

    class Queue
    {
        //data
        LinkedList<int> allValues;

        //methods
        public void Enqueue(int value)
        {
            allValues.AddFirst(value);
        }

        public int Dequeue()
        {
            int lastValue = Peek();
            allValues.RemoveLast();
            return lastValue;
        }


        public int Peek()
        {
            return allValues.Last();
        }

        //ctor
        public Queue()
        {
            allValues = new LinkedList<int>();
        }
    }

    class Node
    {
        public int Value;
        public Node left, right;

        public Node(int newVal)
        {
            Value = newVal;
        }
    }

    class BinarySearchTree
    {
        //data
        Node root;

        //methods
        //isEmpty
        public bool IsEmpty()
        {
            return root == null;
        }

        //Insert
        public void Insert(int newValue)
        {
            //create node
            Node newNode = new Node(newValue);

            //if the tree is empty
            if (IsEmpty())
                root = newNode;
            else
            {
                Node finger = root;
                while(true)
                {
                    if(newValue<=finger.Value)
                    {
                        if(finger.left!=null)
                            finger = finger.left;
                        else
                        {
                            finger.left = newNode;
                            break;
                        }
                    }
                    else
                    {
                        if (finger.right != null)
                            finger = finger.right;
                        else
                        {
                            finger.right = newNode;
                            break;
                        }
                    }
                }
            }
        }

        //Delete
        //Traversals
        

        //GetMaxValue
        public int GetMaxValue()
        {
            if (IsEmpty())
                throw new Exception("no max can be found in an empty tree!");

            Node finger = root;
            while (finger.right != null)
                finger = finger.right;
            return finger.Value;
        }

        //GetMinValue

        //ctor
        public BinarySearchTree()
        {
            root = null;
        }
    }

}

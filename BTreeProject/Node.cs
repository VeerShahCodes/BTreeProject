using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTreeProject
{
    public class Node<T>
        where T : IComparable<T>
    {
        public List<T> keys;
        public List<Node<T>> children;
        public int KeyCount { get; private set; }
        public int ChildCount { get; private set; }

        public Node() 
        {
            keys = new List<T>(3);
            children = new List<Node<T>>(4);

            KeyCount = 0;
            ChildCount = 0;
        }

        public void AddKey(T value)
        {
            
            if(KeyCount < keys.Capacity)
            {
                
                int i = 0;
                if(KeyCount > 0)
                {
                    while (i < KeyCount && value.CompareTo(keys[i]) > 0)
                    {
                        i++;
                    }
                }

                keys.Insert(i, value);
                KeyCount++;

            }

        }
        public void Split(Node<T>? previous, int index)
        {
            if (previous != null)
            {
                previous.keys.Insert(index, keys[1]);
                T valLeft = keys[0];
                T valRight = keys[2];
                keys.Clear();
                keys.Add(valLeft);
                keys.Add(valRight);
                KeyCount = 2;
                
            }
            else
            {

                children.Add(new Node<T>());
                children.Add(new Node<T>());
                children[index].AddKey(keys[0]);
                children[index + 1].AddKey(keys[2]);
                ChildCount += 2;
                T value = keys[1];
                KeyCount = 1;
                keys.Clear();
                keys.Add(value);
            }
        }
        //public void TwoNodeSplit(Node<T> previous, int index)
        //{
        //    children.Add(new Node<T>());
        //    children.Add(new Node<T>());
        //    children[index].AddKey(keys[0]);
        //    children[index + 1].AddKey(keys[2]);
        //    ChildCount += 2;
        //    T value = keys[1];
        //    KeyCount = 1;
        //    keys.Clear();
        //    keys.Add(value);
        //}

        //public void ThreeNodeSplit(Node<T> previous, int index) 
        //{
        //    previous.AddKey(keys[1]);
        //    T leftVal = 
        //    keys.Clear();
        //    keys.Add(keys[0]);
        //    keys.Add(keys[2]);
        //    KeyCount = 2;
            
        //}
    }
}

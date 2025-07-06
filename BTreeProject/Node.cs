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


    }
}

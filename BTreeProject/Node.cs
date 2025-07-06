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
       

        public Node() 
        {
            keys = new List<T>(3);
            children = new List<Node<T>>(4);

           
        }

        public void AddKey(T value)
        {
            
           keys.Add(value);
            keys.Sort(); // Ensure keys are sorted after insertion

        }


    }
}

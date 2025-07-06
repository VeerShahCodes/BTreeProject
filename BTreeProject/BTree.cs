namespace BTreeProject
{
    public class BTree<T>
        where T : IComparable<T>
    {
        private Node<T> Root;
        public int NodeCount { get; private set; }
        public BTree()
        {
            Root = new Node<T>();
            NodeCount = 0;
        }

        public void Insert(T value)
        {
            if (Root.keys.Count == Root.keys.Capacity)
            {
                Node<T> newRoot = SplitTop(Root);
                Root = newRoot;
            }
            Root = InsertRec(Root, value);
            ;
        }
        private Node<T> InsertRec(Node<T> node, T value)
        {
            if (node.children.Count == 0)
            {
                node.AddKey(value);
                return node;
            }

            int index = 0;
            for (int i = 0; i < node.keys.Count; i++)
            {
                if (value.CompareTo(node.keys[i]) > 0)
                {
                    index++;
                }
            }
            if (node.children[index].keys.Count == node.children[index].keys.Capacity)
            {
                node = Split(node, index);
                index = 0;
                for (int i = 0; i < node.keys.Count; i++)
                {
                    if (value.CompareTo(node.keys[i]) > 0)
                    {
                        index++;
                    }
                }

            }
            node.children[index] = InsertRec(node.children[index], value);
            return node;
        }
        private Node<T> SplitTop(Node<T>? node)
        {
            Node<T> newNode = new Node<T>();

            newNode.AddKey(node.keys[1]);
            node.keys.RemoveAt(1);
            
            newNode.children.Add(new Node<T>());
            newNode.children[0].AddKey(node.keys[0]);
            node.keys.RemoveAt(0);
            newNode.children.Add(new Node<T>());
            newNode.children[1].AddKey(node.keys[0]);
            node.keys.RemoveAt(0);

            if (node.children.Count == 0)
            {
                return newNode;
            }
            newNode.children[0].children.Add(node.children.First());
            node.children.RemoveAt(0);
            newNode.children[0].children.Add(node.children.First());
            node.children.RemoveAt(0);
            newNode.children[1].children.Add(node.children.First());
            node.children.RemoveAt(0);
            newNode.children[1].children.Add(node.children.First());
            node.children.RemoveAt(0);
            return newNode;
        }
        private Node<T> Split(Node<T>? node, int index)
        {
            var temp = node.children[index];
            if(temp.keys.Count > 1)
            {
                node.AddKey(temp.keys[1]);
                temp.keys.RemoveAt(1);

            }


            Node<T> newNode = new Node<T>();
            node.children.Insert(index + 1, newNode);
            if(temp.keys.Count > 1)
            {
                newNode.AddKey(temp.keys[1]);
                temp.keys.RemoveAt(1);
            }

            //no children
            if (temp.children.Count == 0)
            {
                return node;
            }
            if (temp.children.Count > 2)
            {
                newNode.children.Add(temp.children[2]);
                temp.children.RemoveAt(2);
            }
            if(temp.children.Count > 2)
            {
                newNode.children.Add(temp.children[2]);
                temp.children.RemoveAt(2);

            }


            return node;









        }

        public Node<T> Search(T value)
        {
            if(Root == null)
            {
                return null;
            }
            return SearchRec(Root, value);
        }

        private Node<T> SearchRec(Node<T> node, T value)
        {
            if(node == Root)
            {
                if (node.keys.Contains(value))
                {
                    return node;
                }
            }

            if(node.children.Count == 0)
            {
                for (int i = 0; i < node.keys.Count; i++)
                {
                    if (node.keys[i].Equals(value))
                    {
                        return node;
                    }
                }
                return null;
            }

            int index = 0;
            for (int i = 0; i < node.keys.Count; i++)
            {
                if (value.CompareTo(node.keys[i]) > 0)
                {
                    index++;
                }
            }
            if (index >= node.children.Count)
            {
                return null;
            }

            if (node.children[index].keys.Contains(value))
            {
                return node.children[index];
            }
            else
            {
                return SearchRec(node.children[index], value);
            }
        }
    }
}

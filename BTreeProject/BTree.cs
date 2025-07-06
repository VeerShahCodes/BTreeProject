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

            Node<T> current = Root;
            Node<T>? previous = null;
            int index = 0;
            if(current.KeyCount == current.keys.Capacity)
            {
                current.Split(previous, index);

            }
            while (current.ChildCount > 0)
            {

                for (int i = 0; i < current.children.Count; i++)
                {
                    if (current.children[i].KeyCount == current.keys.Capacity)
                    {
                        current.children[i].Split(current, i);


                    }

                    if (value.CompareTo(current.children[i].keys[0]) < 0)
                    {
                        index = i;
                        break;
                    }
                    if(i == current.children.Count - 1)
                    {
                        index = i;

                    }

                }
                //previous = current;
                current = current.children[index];
            }
            current.AddKey(value);

            
        }
        public Node<T> SplitTop(Node<T>? node)
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
        public Node<T> Split(Node<T>? node, int index)
        {
            var temp = node.children[index];
           
            node.AddKey(temp.keys[1]);
            temp.keys.RemoveAt(1);
            
            Node<T> newNode = new Node<T>();
            node.children.Insert(index + 1, newNode);

            newNode.AddKey(temp.keys[1]);
            //add children


            temp.keys.RemoveAt(2);

            newNode.AddKey(temp.keys[2]);
            temp.keys.RemoveAt(2);

            return node;









        }
    }
}

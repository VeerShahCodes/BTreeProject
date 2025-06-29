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
    }
}

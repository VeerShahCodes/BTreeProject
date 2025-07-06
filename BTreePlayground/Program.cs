using BTreeProject;
namespace BTreePlayground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BTree<int> tree = new BTree<int>();

            tree.Insert(7);
            tree.Insert(8);
            tree.Insert(9);
            tree.Insert(10);
            tree.Insert(11);
            tree.Insert(6);
            tree.Insert(12);
            tree.Insert(13);
            tree.Insert(14);
            tree.Insert(1);
            tree.Insert(2);
            tree.Insert(3);
            Node<int> node = tree.Search(13);
            ;
        }
    }
}

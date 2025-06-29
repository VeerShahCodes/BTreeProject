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
            ;
        }
    }
}

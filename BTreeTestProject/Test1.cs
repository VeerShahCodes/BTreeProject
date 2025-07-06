using BTreeProject;
namespace BTreeTestProject
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void SearchTest()
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
            Assert.IsNotNull(node, "Node should not be null");
            Assert.AreEqual(13, node.keys[0], "Node should contain the value 13");
            Node<int> node1 = tree.Search(15);
            Assert.IsNull(node1, "Node should be null for non-existing value");
            Node<int> node2 = tree.Search(10);
            Assert.IsNotNull(node2, "Node should not be null for existing value");

        }
        [TestMethod]
        public void BigTest()
        {
            Random random = new Random();
            BTree<int> tree = new BTree<int>();
            List<int> values = new List<int>();
            int size = 1000;
            for (int i = 0; i < size; i++)
            {
                int value = random.Next(1, 1001);
                values.Add(value);
                tree.Insert(value);
            }           
            bool isTrue = true;
            for (int i = 0; i < values.Count; i++)
            {
                if(tree.Search(values[i]) == null)
                {
                    isTrue = false;
                    break;
                }
            }
            Assert.IsTrue(isTrue, "All values were found in the tree after insertion.");
        }
    }
}

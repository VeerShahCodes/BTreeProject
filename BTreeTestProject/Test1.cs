using BTreeProject;
namespace BTreeTestProject
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void InsertTest()
        {
            BTree<int> tree = new BTree<int>();
            tree.Insert(10);

        }
    }
}

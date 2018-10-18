using Microsoft.VisualStudio.TestTools.UnitTesting;
using Numbers;

namespace NumbersTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestEven()
        {
            Assert.IsTrue(NumbersOperations.IsEven(2), "Число 2 четное");
        }

        [TestMethod]
        public void TestSum()
        {
            Assert.AreEqual(NumbersOperations.GetSum(5, 7), 12);
        }

        [TestMethod]
        public void TestDivision()
        {
            Assert.AreNotEqual(NumbersOperations.GetDivision(15, 3), 0);
        }
    }
}

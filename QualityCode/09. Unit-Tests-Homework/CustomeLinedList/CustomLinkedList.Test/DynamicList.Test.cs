using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomLinkedList;

namespace CustomLinkedList.Test
{
    [TestClass]
    public class DynamicListTest
    {
        [TestMethod]
        public void Test_ConstructorInitialCountOfElementsIsZero()
        {
            var dynList = new DynamicList<int>();
            Assert.AreEqual<int>(0, dynList.Count, "Initialization of LinkedList contains elements instead to be zero.");
        }

        [TestMethod]
        public void Test_CountIsOneAfterAdditionOfOneElement()
        {
            var dynList = new DynamicList<int>();
            dynList.Add(100);
            Assert.AreEqual(100, dynList.Count, "Count property is not incremnented correctly after addition of the element.");
        }

        [TestMethod]
        public void Test_IndexReturnsFirstElementOneHundread()
        {
            var dynList = new DynamicList<int>();

        }
    }
}

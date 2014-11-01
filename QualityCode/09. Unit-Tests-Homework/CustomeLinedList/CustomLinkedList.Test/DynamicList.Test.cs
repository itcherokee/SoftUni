namespace CustomLinkedListTest
{
    using System;
    using CustomLinkedList;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DynamicListTest
    {
        #region Constructor tests

        [TestMethod]
        public void Test_ConstructorInitialCountOfElementsIsZero()
        {
            var dynList = new DynamicList<int>();
            Assert.AreEqual<int>(0, dynList.Count, "Initialization of LinkedList contains elements instead to be zero.");
        }
        #endregion

        #region Count method tests

        [TestMethod]
        public void Test_CountIsOneAfterAdditionOfOneElement()
        {
            var dynList = new DynamicList<int>();
            dynList.Add(100);
            Assert.AreEqual(1, dynList.Count, "Count property donot returns xorrect number of elements.");
        }
        #endregion

        #region Indexer (get/set) tests

        [TestMethod]
        public void Test_IndexGetReturnsFirstElementOneHundread()
        {
            var dynList = new DynamicList<int>();
            dynList.Add(100);
            Assert.AreEqual(100, dynList[0], "Index do not returns the correct value of an element at specified index.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "An index below the min element list border has been specified.")]
        public void Test_IndexGetAccessElementWithNegativeIndex()
        {
            var dynList = new DynamicList<int>();
            var element = dynList[-1];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "An index above the max element list border has been specified.")]
        public void Test_IndexGetAccessElementAboveLastElementIndex()
        {
            var dynList = new DynamicList<int>();
            dynList.Add(100);
            var element = dynList[5];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "An index equal to number of elements has been specified.")]
        public void Test_IndexGetAccessElementAtIndexEqualToCountOfElements()
        {
            var dynList = new DynamicList<int>();
            dynList.Add(100);
            var element = dynList[dynList.Count];
        }

        [TestMethod]
        public void Test_IndexGetReturnsLastElementOneHundread()
        {
            var dynList = new DynamicList<int>();
            dynList.Add(100);
            Assert.AreEqual(100, dynList[dynList.Count - 1], "Index do not returns the correct value of an element at specified index.");
        }

        [TestMethod]
        public void Test_IndexGetReturnsThirdElementOneHundread()
        {
            var dynList = new DynamicList<int>();
            dynList.Add(10);
            dynList.Add(50);
            dynList.Add(100);
            Assert.AreEqual(100, dynList[2], "Index do not returns the correct value of an element at specified index.");
        }

        [TestMethod]
        public void Test_IndexSetFirstElementOneHundread()
        {
            var dynList = new DynamicList<int>();
            dynList.Add(100);
            Assert.AreEqual(100, dynList[0], "Index do not set the correct value of an element at specified index.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "An index below the min element list border has been specified.")]
        public void Test_IndexSetElementWithNegativeIndex()
        {
            var dynList = new DynamicList<int>();
            dynList[-1] = 200;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "An index above the max element list border has been specified.")]
        public void Test_IndexSetElementAboveLastElementIndex()
        {
            var dynList = new DynamicList<int>();
            dynList[5] = 200;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "An index equal to number of elements has been specified.")]
        public void Test_IndexSetElementAtIndexEqualToCountOfElements()
        {
            var dynList = new DynamicList<int>();
            dynList[dynList.Count] = 200;
        }

        [TestMethod]
        public void Test_IndexSetLastElementOneHundread()
        {
            var dynList = new DynamicList<int>();
            dynList.Add(0);
            dynList[0] = 100;
            Assert.AreEqual(100, dynList[dynList.Count - 1], "Index do not set the correct value of an element at specified index.");
        }

        [TestMethod]
        public void Test_IndexSetThirdElementOneHundread()
        {
            var dynList = new DynamicList<int>();
            dynList.Add(10);
            dynList.Add(50);
            dynList.Add(70);
            dynList[2] = 100;
            Assert.AreEqual(100, dynList[2], "Index do not set the correct value of an element at specified index.");
        }
        #endregion

        #region Add method tests
        [TestMethod]
        public void Test_AddElementEqualToOneHundread()
        {
            var dynList = new DynamicList<int>();
            dynList.Add(100);
            Assert.AreEqual(100, dynList[0], "Not a correct value of an element has been added.");
        }

        [TestMethod]
        public void Test_AddTwoElements()
        {
            var dynList = new DynamicList<int>();
            dynList.Add(100);
            dynList.Add(200);
            Assert.AreEqual(2, dynList.Count, "Number of actual elements is different from added.");
        }
        #endregion

        #region RemoveAt method tests
        [TestMethod]
        public void Test_RemoveAtElementAtIndexOne()
        {
            var dynList = new DynamicList<int>();
            dynList.Add(10);
            dynList.Add(50);
            dynList.Add(100);
            dynList.RemoveAt(1);
            Assert.AreEqual(100, dynList[1], "RemoveAt donot removes the element at specified index correctly.");
        }

        [TestMethod]
        public void Test_RemoveAtElementAtLastIndex()
        {
            var dynList = new DynamicList<int>();
            dynList.Add(10);
            dynList.Add(50);
            dynList.Add(100);
            dynList.RemoveAt(dynList.Count - 1);
            Assert.AreEqual(50, dynList[dynList.Count - 1], "RemoveAt donot removes correctly the element at last position.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "An index below the min element list border has been specified.")]
        public void Test_RemoveAtElementWithNegativeIndex()
        {
            var dynList = new DynamicList<int>();
            dynList.Add(100);
            dynList.RemoveAt(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "An index above the max element list border has been specified.")]
        public void Test_RemoveAtElementAboveLastElementIndex()
        {
            var dynList = new DynamicList<int>();
            dynList.Add(100);
            dynList.RemoveAt(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "An index equal to number of elements has been specified.")]
        public void Test_RemoveAtElementAtIndexEqualToCountOfElements()
        {
            var dynList = new DynamicList<int>();
            dynList.Add(100);
            dynList.RemoveAt(dynList.Count);

        }
        #endregion

        #region Remove method tests
        [TestMethod]
        public void Test_RemoveFirstElementCheckedByValue()
        {
            var dynList = new DynamicList<int>();
            dynList.Add(10);
            dynList.Add(50);
            dynList.Add(100);
            dynList.Remove(10);
            Assert.AreEqual(
                50,
                dynList[0],
                "Remove do not removes the element with specified value correctly positioned first.");
        }

        [TestMethod]
        public void Test_RemoveLastElementCheckedByValue()
        {
            var dynList = new DynamicList<int>();
            dynList.Add(10);
            dynList.Add(50);
            dynList.Add(100);
            dynList.Remove(100);
            Assert.AreEqual(
                50,
                dynList[dynList.Count - 1],
                "Remove do not removes correctly the element with specified value positioned last.");
        }

        [TestMethod]
        public void Test_RemoveNonExistingElementCheckedByValue()
        {
            var dynList = new DynamicList<int>();
            dynList.Add(10);
            dynList.Add(50);
            dynList.Add(100);
            dynList.Remove(200);
            Assert.AreEqual(100, dynList[2], "Remove removes incorrectly non existing element.");
        }

        [TestMethod]
        public void Test_RemoveFirstElementByCheckingReturnedIndex()
        {
            var dynList = new DynamicList<int>();
            dynList.Add(10);
            dynList.Add(50);
            dynList.Add(100);
            var indexWhereFound = dynList.Remove(10);
            Assert.AreEqual(0, indexWhereFound, "Remove do not removes correctly first element (wrong index returned).");
        }

        [TestMethod]
        public void Test_RemoveLastElementByCheckingReturnedIndex()
        {
            var dynList = new DynamicList<int>();
            dynList.Add(10);
            dynList.Add(50);
            dynList.Add(100);
            var indexWhereFound = dynList.Remove(100);
            Assert.AreEqual(2, indexWhereFound, "Remove do not removes correctly last element (wrong index returned).");
        }

        [TestMethod]
        public void Test_RemoveNonExistingElementByCheckingReturnedIndex()
        {
            var dynList = new DynamicList<int>();
            dynList.Add(10);
            dynList.Add(50);
            dynList.Add(100);
            var indexWhereFound = dynList.Remove(110);
            Assert.AreEqual(-1, indexWhereFound, "Remove incorectly removes non existing element (index returned not -1).");
        }

        [TestMethod]
        public void Test_RemoveAllElementsAndListIsEmpty()
        {
            var dynList = new DynamicList<int>();
            dynList.Add(10);
            dynList.Remove(10);
            Assert.AreEqual(0, dynList.Count, "Remove do not removes correctly the last element and do not set list Count to be 0.");
        }
        #endregion

        #region IndexOf method tests
        [TestMethod]
        public void Test_IndexOfElementThatIsEqualToOneHundread()
        {
            var dynList = new DynamicList<int>();
            dynList.Add(100);
            var indexOfFoundElement = dynList.IndexOf(100);
            Assert.AreEqual(
                0,
                indexOfFoundElement,
                "IndexOf do not correctly identifies the index of searched existing element.");
        }

        [TestMethod]
        public void Test_IndexOfFirstElementThatIsEqualToOneHundread()
        {
            var dynList = new DynamicList<int>();
            dynList.Add(10);
            dynList.Add(50);
            dynList.Add(50);
            dynList.Add(100);
            dynList.Add(501);
            dynList.Add(150);
            dynList.Add(100);
            var indexOfFoundElement = dynList.IndexOf(100);
            Assert.AreEqual(
                3,
                indexOfFoundElement,
                "IndexOf do not correctly identifies the index of searched existing element.");
        }

        [TestMethod]
        public void Test_IndexOfNonExistingElement()
        {
            var dynList = new DynamicList<int>();
            dynList.Add(10);
            dynList.Add(50);
            dynList.Add(100);
            var indexOfNotFoundElement = dynList.IndexOf(110);
            Assert.AreEqual(
                -1,
                indexOfNotFoundElement,
                "IndexOf do not correctly returns -1 when element is not existing in the list.");
        }
        #endregion

        #region Contains method tests
        [TestMethod]
        public void Test_ContainsElementExisitsInList()
        {
            var dynList = new DynamicList<int>();
            dynList.Add(100);
            dynList.Add(10);
            dynList.Add(50);
            dynList.Add(99);
            dynList.Add(100);
            dynList.Add(501);
            dynList.Add(150);
            var mustBeTrue = dynList.Contains(99);
            Assert.IsTrue(mustBeTrue, "Contains do not identify correctly that exisitng element is in the list.");
        }

        [TestMethod]
        public void Test_ContainsElementNotExistingInList()
        {
            var dynList = new DynamicList<int>();
            dynList.Add(10);
            dynList.Add(50);
            dynList.Add(50);
            dynList.Add(1030);
            dynList.Add(501);
            dynList.Add(150);
            dynList.Add(1000);
            var mustBeFalse = dynList.Contains(100);
            Assert.IsFalse(mustBeFalse, "Contains do identify incorrectly that nonexisitng element is in the list.");

        }
        #endregion
    }
}

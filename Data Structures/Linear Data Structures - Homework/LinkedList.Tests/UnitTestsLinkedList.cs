namespace LinkedList.Tests
{
    using System;
    using System.Collections;
    //using System.Collections.Generic;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTestsLinkedList
    {
        [TestMethod]
        public void Add_EmptyList_ShouldAddElement()
        {
            // Arrange
            var list = new LinkedList.LinkedList<int>();

            // Act
            list.Add(5);

            // Assert
            Assert.AreEqual(1, list.Count);
            
            var items = new List<int>();
            list.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>(){ 5 });
        }

        [TestMethod]
        public void Add_SeveralElements_ShouldAddElementsCorrectly()
        {
            // Arrange
            var list = new LinkedList.LinkedList<int>();

            // Act
            list.Add(10);
            list.Add(5);
            list.Add(3);

            // Assert
            Assert.AreEqual(3, list.Count);

            var items = new List<int>();
            list.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { 10, 5 , 3 });
        }

        [TestMethod]
        public void Remove_OneElement_ShouldMakeListEmpty()
        {
            // Arrange
            var list = new LinkedList.LinkedList<int>();
            list.Add(5);

            // Act
            var element = list.Remove(0);

            // Assert
            Assert.AreEqual(5, element);
            Assert.AreEqual(0, list.Count);

            var items = new List<int>();
            list.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { });
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Remove_EmptyList_ShouldThrowException()
        {
            // Arrange
            var list = new LinkedList.LinkedList<int>();

            // Act
            var element = list.Remove(0);
        }

        [TestMethod]
        public void Remove_SeveralElements_ShouldRemoveElementsCorrectly()
        {
            // Arrange
            var list = new LinkedList.LinkedList<int>();
            list.Add(5);
            list.Add(6);
            list.Add(7);

            // Act
            var elementOne = list.Remove(0);
            var elementTwo = list.Remove(1);


            // Assert
            Assert.AreEqual(5, elementOne);
            Assert.AreEqual(7, elementTwo);
            Assert.AreEqual(1, list.Count);

            var items = new List<int>();
            list.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { 6 });
        }

        [TestMethod]
        public void Remove_FirstElement_ShouldMakeListEmpty()
        {
            // Arrange
            var list = new LinkedList.LinkedList<int>();
            list.Add(5);

            // Act
            var element = list.Remove(0);

            // Assert
            Assert.AreEqual(5, element);
            Assert.AreEqual(0, list.Count);

            var items = new List<int>();
            list.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { });
        }

       
        [TestMethod]
        public void RemoveLast_SeveralElements_ShouldRemoveElementsCorrectly()
        {
            // Arrange
            var list = new LinkedList.LinkedList<int>();
            list.Add(10);
            list.Add(9);
            list.Add(8);

            // Act
            var element = list.Remove(2);

            // Assert
            Assert.AreEqual(8, element);
            Assert.AreEqual(2, list.Count);

            var items = new List<int>();
            list.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { 10, 9 });
        }

        [TestMethod]
        public void ForEach_EmptyList_ShouldEnumerateElementsCorrectly()
        {
            // Arrange
            var list = new LinkedList.LinkedList<int>();

            // Act
            var items = new List<int>();
            list.ForEach(items.Add);

            // Assert
            CollectionAssert.AreEqual(items, new List<int>() { });
        }

        [TestMethod]
        public void ForEach_SingleElement_ShouldEnumerateElementsCorrectly()
        {
            // Arrange
            var list = new LinkedList.LinkedList<int>();
            list.Add(5);

            // Act
            var items = new List<int>();
            list.ForEach(items.Add);

            // Assert
            CollectionAssert.AreEqual(items, new List<int>() { 5 });
        }

        [TestMethod]
        public void ForEach_MultipleElements_ShouldEnumerateElementsCorrectly()
        {
            // Arrange
            var list = new LinkedList.LinkedList<string>();
            list.Add("Five");
            list.Add("Six");
            list.Add("Seven");

            // Act
            var items = new List<string>();
            list.ForEach(items.Add);

            // Assert
            CollectionAssert.AreEqual(items, 
                new List<string>() { "Five", "Six", "Seven" });
        }

        [TestMethod]
        public void IEnumerable_Foreach_MultipleElements()
        {
            // Arrange
            var list = new LinkedList.LinkedList<string>();
            list.Add("Five");
            list.Add("Six");
            list.Add("Seven");

            // Act
            var items = new List<string>();
            foreach (var element in list)
            {
                items.Add(element);
            }

            // Assert
            CollectionAssert.AreEqual(items,
                new List<string>() { "Five", "Six", "Seven" });
        }

        [TestMethod]
        public void IEnumerable_NonGeneric_MultipleElements()
        {
            // Arrange
            var list = new LinkedList.LinkedList<decimal>();
            list.Add(6m);
            list.Add(7.77m);

            // Act
            var enumerator = ((IEnumerable)list).GetEnumerator();
            var items = new List<object>();
            while (enumerator.MoveNext())
            {
                items.Add(enumerator.Current);
            }

            // Assert
            CollectionAssert.AreEqual(items, new List<object>() { 6m, 7.77m });
        }
    }
}

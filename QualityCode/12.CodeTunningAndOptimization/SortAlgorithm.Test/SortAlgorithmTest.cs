using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortAlgorithm.Test
{
    using SortAlgorithm;
    using System.Linq;

    [TestClass]
    public class SortAlgorithmTest
    {
        private int[] sortedAscending = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private int[] sortedDescending = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        private int[] nonSorted = { 2, 6, 3, 5, 9, 1, 4, 7, 10, 8 };
        private int[] singleElement = { 1 };
        private int[] someEqualElements = { 2, 1, 2, 5, 8, 3, 3, 2 };
        private int[] nonSortedNegative = { -11, -10, -9, -7, -8, -6, -5, 5, 4, 3, 2, 1, 0 }; // sorted: -11,-10,-9,-8,-7,-6,-5,0,1,2,3,4,5
        private double[] nonSortedNegativeDouble = { -11.3, -10.5, -9, -7, -8.03, -6, -5, 5.001, 5.0001, 3, 2.111, 1, 0.1 };// sorted: -11.3, -10.5, -9, -8.03, -7, -6, -5, 0.1, 1, 2.111, 3, 5.0001, 5.001
        private string[] nonSortedWords = { "azbc", "abc", "zabc" };

        // Test SelectionSort
        [TestMethod]
        public void SelectionTestSortedAsc()
        {
            var sorted = SortAlgorithms.SelectionSort(sortedAscending).ToArray();
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, sorted);

        }

        [TestMethod]
        public void SelectionTestSortedDesc()
        {
            var sorted = SortAlgorithms.SelectionSort(sortedDescending).ToArray();
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, sorted);
        }

        [TestMethod]
        public void SelectionTestUnsorted()
        {
            var sorted = SortAlgorithms.SelectionSort(nonSorted).ToList();
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, sorted);
        }

        [TestMethod]
        public void SelectionTestSingle()
        {
            var sorted = SortAlgorithms.SelectionSort(singleElement).ToArray();
            CollectionAssert.AreEqual(new[] { 1 }, sorted);
        }

        [TestMethod]
        public void SelectionTestSomeEqualElements()
        {
            var sorted = SortAlgorithms.SelectionSort(someEqualElements).ToArray();
            CollectionAssert.AreEqual(new[] { 1, 2, 2, 2, 3, 3, 5, 8 }, sorted);
        }

        [TestMethod]
        public void SelectionTestSomeSomeNegativeElements()
        {
            var sorted = SortAlgorithms.SelectionSort(nonSortedNegative).ToArray();
            CollectionAssert.AreEqual(new[] { -11, -10, -9, -8, -7, -6, -5, 0, 1, 2, 3, 4, 5 }, sorted);
        }

        [TestMethod]
        public void SelectionTestSomeSomeNegativeElementsDouble()
        {
            var sorted = SortAlgorithms.SelectionSort(nonSortedNegativeDouble).ToArray();
            CollectionAssert.AreEqual(new[] { -11.3, -10.5, -9, -8.03, -7, -6, -5, 0.1, 1, 2.111, 3, 5.0001, 5.001 }, sorted);
        }

        [TestMethod]
        public void SelectionTestNonSortedWords()
        {
            var sorted = SortAlgorithms.SelectionSort(nonSortedWords).ToArray();
            CollectionAssert.AreEqual(new[] { "abc", "azbc", "zabc" }, sorted);
        }

        // Test QuickSort
        [TestMethod]
        public void QuickTestSortedAsc()
        {
            var sorted = SortAlgorithms.QuickSort(sortedAscending).ToArray();
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, sorted);

        }

        [TestMethod]
        public void QuickTestSortedDesc()
        {
            var sorted = SortAlgorithms.QuickSort(sortedDescending).ToArray();
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, sorted);
        }

        [TestMethod]
        public void QuickTestUnsorted()
        {
            var sorted = SortAlgorithms.QuickSort(nonSorted).ToList();
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, sorted);
        }

        [TestMethod]
        public void QuickTestSingle()
        {
            var sorted = SortAlgorithms.QuickSort(singleElement).ToArray();
            CollectionAssert.AreEqual(new[] { 1 }, sorted);
        }

        [TestMethod]
        public void QuickTestSomeEqualElements()
        {
            var sorted = SortAlgorithms.QuickSort(someEqualElements).ToArray();
            CollectionAssert.AreEqual(new[] { 1, 2, 2, 2, 3, 3, 5, 8 }, sorted);
        }

        [TestMethod]
        public void QuickTestSomeSomeNegativeElements()
        {
            var sorted = SortAlgorithms.QuickSort(nonSortedNegative).ToArray();
            CollectionAssert.AreEqual(new[] { -11, -10, -9, -8, -7, -6, -5, 0, 1, 2, 3, 4, 5 }, sorted);
        }

        [TestMethod]
        public void QuickTestSomeSomeNegativeElementsDouble()
        {
            var sorted = SortAlgorithms.QuickSort(nonSortedNegativeDouble).ToArray();
            CollectionAssert.AreEqual(new[] { -11.3, -10.5, -9, -8.03, -7, -6, -5, 0.1, 1, 2.111, 3, 5.0001, 5.001 }, sorted);
        }

        [TestMethod]
        public void QuickTestNonSortedWords()
        {
            var sorted = SortAlgorithms.QuickSort(nonSortedWords).ToArray();
            CollectionAssert.AreEqual(new[] { "abc", "azbc", "zabc" }, sorted);
        }

        // Test Insertion Sort
        [TestMethod]
        public void InsertionTestSortedAsc()
        {
            var sorted = SortAlgorithms.InsertionSort(sortedAscending).ToArray();
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, sorted);

        }

        [TestMethod]
        public void InsertionTestSortedDesc()
        {
            var sorted = SortAlgorithms.InsertionSort(sortedDescending).ToArray();
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, sorted);
        }

        [TestMethod]
        public void InsertionTestUnsorted()
        {
            var sorted = SortAlgorithms.InsertionSort(nonSorted).ToList();
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, sorted);
        }

        [TestMethod]
        public void InsertionTestSingle()
        {
            var sorted = SortAlgorithms.InsertionSort(singleElement).ToArray();
            CollectionAssert.AreEqual(new[] { 1 }, sorted);
        }

        [TestMethod]
        public void InsertionTestSomeEqualElements()
        {
            var sorted = SortAlgorithms.InsertionSort(someEqualElements).ToArray();
            CollectionAssert.AreEqual(new[] { 1, 2, 2, 2, 3, 3, 5, 8 }, sorted);
        }

        [TestMethod]
        public void InsertionTestSomeSomeNegativeElements()
        {
            var sorted = SortAlgorithms.InsertionSort(nonSortedNegative).ToArray();
            CollectionAssert.AreEqual(new[] { -11, -10, -9, -8, -7, -6, -5, 0, 1, 2, 3, 4, 5 }, sorted);
        }

        [TestMethod]
        public void InsertionTestSomeSomeNegativeElementsDouble()
        {
            var sorted = SortAlgorithms.InsertionSort(nonSortedNegativeDouble).ToArray();
            CollectionAssert.AreEqual(new[] { -11.3, -10.5, -9, -8.03, -7, -6, -5, 0.1, 1, 2.111, 3, 5.0001, 5.001 }, sorted);
        }

        [TestMethod]
        public void InsertionTestNonSortedWords()
        {
            var sorted = SortAlgorithms.InsertionSort(nonSortedWords).ToArray();
            CollectionAssert.AreEqual(new[] { "abc", "azbc", "zabc" }, sorted);
        }
    }
}

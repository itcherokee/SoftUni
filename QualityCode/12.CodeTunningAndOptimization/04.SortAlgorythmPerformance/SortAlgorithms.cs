namespace SortAlgorithm
{
    using System;
    using System.Collections.Generic;

    public class SortAlgorithms
    {
        /// <summary>
        /// Selection Sort algorithm.
        /// </summary>
        /// <typeparam name="T">Type of the elements to be sorted.</typeparam>
        /// <param name="elements">Elements to be sorted as a collection.</param>
        /// <returns>Sorted elements collection.</returns>
        public static IList<T> SelectionSort<T>(IList<T> elements) where T : IComparable
        {
            if (elements.Count < 2)
            {
                return elements;
            }

            bool smallerExist;
            int currentSmallestNumberIndex;
            T elementToSwap;
            IList<T> result = new List<T>(elements);
            for (int outerIndex = 0; outerIndex < result.Count; outerIndex++)
            {
                currentSmallestNumberIndex = outerIndex;
                smallerExist = false;
                for (int innerIndex = outerIndex + 1; innerIndex < result.Count; innerIndex++)
                {
                    // Find smaller number compared to currently selected
                    if (result[innerIndex].CompareTo(result[currentSmallestNumberIndex]) < 0)
                    {
                        currentSmallestNumberIndex = innerIndex;
                        smallerExist = true;
                    }
                }

                if (smallerExist)
                {
                    // Smaller number has been found, so positions of numbers are swaped
                    elementToSwap = result[outerIndex];
                    result[outerIndex] = result[currentSmallestNumberIndex];
                    result[currentSmallestNumberIndex] = elementToSwap;
                }
            }

            return result;
        }

        /// <summary>
        /// Quick Sort algorithm.
        /// </summary>
        /// <typeparam name="T">Type of the elements to be sorted.</typeparam>
        /// <param name="elements">Elements to be sorted as a collection.</param>
        /// <returns>Sorted elements collection.</returns>
        public static IList<T> QuickSort<T>(IList<T> elements) where T : IComparable
        {
            // only one element in the array - nothing to sort
            if (elements.Count < 2)
            {
                return elements;
            }

            if (elements.Count == 2)
            {
                // Only 2 elements in the array - no need to create separate left/right arrays, just compare them.
                if (elements[0].CompareTo(elements[1]) > 0)
                {
                    var elementToSwap = elements[0];
                    elements[0] = elements[1];
                    elements[1] = elementToSwap;
                }

                return elements;
            }

            // Below code finds pivot element and start the real quick sort algorythm - left & right sub-arrays
            int pivotIndex = elements.Count / 2;
            var pivotValue = elements[pivotIndex];
            var leftArray = new List<T>();
            var rightArray = new List<T>();
            for (int index = 0; index < elements.Count; index++)
            {
                if (index == pivotIndex)
                {
                    // this is the pivot and we skip it
                    continue;
                }

                if (elements[index].CompareTo(pivotValue) <= 0)
                {
                    // "smaller" string value than value in the pivot
                    leftArray.Add(elements[index]);
                }
                else
                {
                    // "bigger" string value than value in the pivot
                    rightArray.Add(elements[index]);
                }
            }

            var result = new List<T>(elements.Count);

            // Itterate over left array - recursivly call Sort method
            result.AddRange(QuickSort(leftArray));

            // add current pivot element to current final array
            result.Add(pivotValue);

            // Itterate over right array - recursivly call Sort method
            result.AddRange(QuickSort(rightArray));
            return result;
        }

        /// <summary>
        /// Insertion Sort algorithm.
        /// </summary>
        /// <typeparam name="T">Type of the elements to be sorted.</typeparam>
        /// <param name="elements">Elements to be sorted as a collection.</param>
        /// <returns>Sorted elements collection.</returns>
        public static IList<T> InsertionSort<T>(IList<T> elements) where T : IComparable
        {
            if (elements.Count < 2)
            {
                return elements;
            }

            int currentIndex;
            T elementToSwap;
            IList<T> result = new List<T>(elements);
            for (int lastSortedIndex = 1; lastSortedIndex < result.Count; lastSortedIndex++)
            {
                currentIndex = lastSortedIndex;
                while (currentIndex > 0 && (result[currentIndex - 1].CompareTo(result[currentIndex]) > 0))
                {
                    elementToSwap = result[currentIndex];
                    result[currentIndex] = result[currentIndex - 1];
                    result[currentIndex - 1] = elementToSwap;
                    currentIndex -= 1;
                }
            }

            return result;
        }
    }
}

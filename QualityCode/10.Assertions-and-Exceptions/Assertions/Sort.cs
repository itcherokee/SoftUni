namespace AssertionsHomework
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public static class Sort
    {
        public static void SelectionSort<T>(T[] elements) where T : IComparable<T>
        {
            Debug.Assert(elements != null, "Input array to be sort, can not be null!");
            Debug.Assert(elements.Length > 0, "Input array to be sort, can not be empty!");
            Debug.Assert(elements.Length != 1, "Input array to be sort is already sorted as contains only 1 element!");

            for (int index = 0; index < elements.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(elements, index, elements.Length - 1);
                Swap(ref elements[index], ref elements[minElementIndex]);
            }

            var assertSortedElements = (T[])elements.Clone();
            Array.Sort(assertSortedElements);
            bool isSortedAssertSortedElements = !elements.Where((t, index) => !t.Equals(assertSortedElements[index])).Any();
            Debug.Assert(isSortedAssertSortedElements, "\"elements\" must be sorted before calling BinarySearch()!");
        }

        private static int FindMinElementIndex<T>(T[] elements, int startIndex, int endIndex) where T : IComparable<T>
        {
            Debug.Assert(elements != null, "Input array, can not be null!");
            Debug.Assert(elements.Length > 0, "Input array, can not be empty!");
            Debug.Assert(startIndex < elements.Length, "StartIndex can not be bigger then the number of elements in array!");
            Debug.Assert(startIndex >= 0, "StartIndex can not be negative value!");
            Debug.Assert(endIndex < elements.Length, "EndIndex can not be bigger then the number of elements in array!");
            Debug.Assert(endIndex >= startIndex, "EndIndex can not be smaller then the startIndex!");

            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (elements[i].CompareTo(elements[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            Debug.Assert(minElementIndex >= 0, "minElementIndex can not be of negative value!");

            return minElementIndex;
        }

        private static void Swap<T>(ref T elementOne, ref T elementTwo)
        {
            if (!typeof(T).IsValueType)
            {
                Debug.Assert(elementOne != null, "\"elementOne\" reference can not be null!");
                Debug.Assert(elementTwo != null, "\"elementTwo\" reference can not be null!");
            }

            var oldelementOne = elementOne;
            elementOne = elementTwo;
            elementTwo = oldelementOne;
        }
    }
}

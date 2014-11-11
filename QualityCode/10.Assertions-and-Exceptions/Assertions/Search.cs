namespace AssertionsHomework
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public class Search
    {
        public static int BinarySearch<T>(T[] elements, T elementToSearch) where T : IComparable<T>
        {
            Debug.Assert(elements != null, "\"elements\" can not be null!");
            Debug.Assert(elements.Length > 0, "\"elements\" can not be empty!");
            Debug.Assert(elementToSearch != null, "\"elementToSearch\" can not be null!");
            var assertSortedElements = (T[])elements.Clone();
            Array.Sort(assertSortedElements);
            bool isSortedAssertSortedElements = !elements.Where((t, index) => !t.Equals(assertSortedElements[index])).Any();
            Debug.Assert(isSortedAssertSortedElements, "\"elements\" must be sorted before calling BinarySearch()!");

            int result = BinarySearch(elements, elementToSearch, 0, elements.Length - 1);

            Debug.Assert(elements.Length > 0, "\"elements\" must not be empty!");
            Debug.Assert(result > -1, "\"result\"'s minimal returned number must be -1!");

            return result;
        }

        private static int BinarySearch<T>(T[] elements, T elementToSearch, int startIndex, int endIndex) where T : IComparable<T>
        {
            Debug.Assert(elements != null, "\"elements\" can not be null!");
            Debug.Assert(elements.Length > 0, "\"elements\" can not be empty!");
            Debug.Assert(elementToSearch != null, "\"elementToSearch\" can not be null!");
            Debug.Assert(startIndex < elements.Length, "StartIndex can not be bigger then the number of elements in array!");
            Debug.Assert(startIndex >= 0, "StartIndex can not be negative value!");
            Debug.Assert(endIndex < elements.Length, "EndIndex can not be bigger then the number of elements in array!");
            Debug.Assert(endIndex >= startIndex, "EndIndex can not be smaller then the startIndex!");

            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (elements[midIndex].Equals(elementToSearch))
                {
                    Debug.Assert(midIndex < elements.Length, "midIndex can not be bigger then the number of elements in array!");
                    Debug.Assert(midIndex >= 0, "midIndex can not be negative value!");

                    return midIndex;
                }

                if (elements[midIndex].CompareTo(elementToSearch) < 0)
                {
                    Debug.Assert(elements[midIndex].CompareTo(elementToSearch) < 0, "Search is running in the right side of array, but should run in left side!");

                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    Debug.Assert(elements[midIndex].CompareTo(elementToSearch) >= 0, "Search is running in the left side of array, but should run in right side!");

                    // Search on the left half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            return -1;
        }
    }
}

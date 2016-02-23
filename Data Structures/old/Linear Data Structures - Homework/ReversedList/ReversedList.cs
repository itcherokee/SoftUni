namespace ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ReversedList<T> : IEnumerable<T>, IEnumerable
    {
        private const byte DefaultCapacity = 16;
        private T[] array;


        public ReversedList(int capacity = DefaultCapacity)
        {
            this.array = new T[capacity];
            this.Count = 0;
            this.Capacity = capacity;
        }

        public ReversedList(IEnumerable<T> elements)
        {
            this.Count = elements.Count();
            this.Capacity = this.Count + DefaultCapacity;

            this.array = new T[this.Capacity];
            var tempArr = elements.ToArray();
            this.CopyArrayToSource(tempArr, this.array);
        }

        public int Count { get; private set; }

        public int Capacity { get; private set; }


        public T this[int index]
        {
            get
            {
                if (this.Count - 1 >= index || index >= 0)
                {
                    return this.array[this.Count - 1 - index];
                }

                throw new IndexOutOfRangeException("Invalid index specified");
            }

            set
            {
                if (this.Count - 1 >= index || index >= 0)
                {
                    this.array[this.Count - 1 - index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Invalid index specified");
                }
            }
        }

        public void Add(T item)
        {
            if (this.Count == this.Capacity)
            {
                GrowStorage();
            }

            this.array[this.Count] = item;
            this.Count++;
        }

        public T Remove(int index)
        {
            if (index < this.Count && index >= 0)
            {
                var element = this.array[index];
                this.array = this.array.Where((val, idx) => this.Count - 1 - idx != index).ToArray();
                this.Count--;
                return element;
            }

            throw new IndexOutOfRangeException("Invalid index provided.");
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void GrowStorage()
        {
            this.Capacity *= 2;
            T[] newArray = new T[this.Capacity];
            CopyArrayToSource(this.array, newArray);
            this.array = newArray;
        }

        private void CopyArrayToSource(T[] source, T[] target)
        {
            for (var i = 0; i < source.Length; i++)
            {
                target[i] = source[i];
            }
        }

        private void SliceArray(int start, int size)
        {

        }
    }
}

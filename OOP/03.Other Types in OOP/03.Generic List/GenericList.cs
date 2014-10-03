namespace VersionAttrtibute
{
    using System;
    using System.Linq;
    using System.Text;

    public class GenericList<T>
    {
        private const int InitialSize = 16;
        private T[] list;

        public GenericList(int capacity = InitialSize)
        {
            this.Initialize(capacity);
        }

        public int Capacity { get; private set; }

        public int Count { get; private set; }

        private bool IsFull
        {
            get
            {
                return this.Capacity == this.Count;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException("index", "Invalid index proveded!");
                }

                return this.list[index];
            }

            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException("index", "Invalid index proveded!");
                }

                this.list[index] = value;
            }
        }

        public void Clear()
        {
            this.Initialize();
        }

        public void Add(T element)
        {
            if (this.IsFull)
            {
                this.Enlarge();
            }

            this.list[this.Count] = element;
            this.Count++;
        }

        public void RemoveAt(int index)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("You can not perform remove element on an empty list!");
            }

            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException("index", "RemoveAt() index out of range!");
            }

            if (index != this.Count - 1)
            {
                var newList = new T[this.Capacity];
                for (int oldIndex = 0, newIndex = 0; oldIndex < this.Count; oldIndex++)
                {
                    if (oldIndex == index)
                    {
                        continue;
                    }

                    newList[newIndex] = this.list[oldIndex];
                    newIndex++;
                }

                this.list = newList;
            }

            this.Count--;
        }

        public void InsertAt(int index, T element)
        {
            if (this.Count == 0 && index > 0)
            {
                throw new InvalidOperationException(
                    "You can not insert element in an empty list on index different than zero!");
            }

            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException("index", "InsertAt() index out of range!");
            }

            if (this.IsFull)
            {
                this.Enlarge();
            }

            var newList = new T[this.Capacity];
            for (int newIndex = 0, oldIndex = 0; newIndex <= this.Count; newIndex++)
            {
                if (newIndex == index)
                {
                    newList[newIndex] = element;
                }
                else
                {
                    newList[newIndex] = this.list[oldIndex];
                    oldIndex++;
                }
            }

            this.list = newList;
            this.Count++;
        }

        public int IndexOf<TC>(TC element) where TC : IComparable, IComparable<T>
        {
            int position = -1;
            for (int index = 0; index < this.Count; index++)
            {
                if (element.CompareTo(this.list[index]) == 0)
                {
                    position = index;
                    break;
                }
            }

            return position;
        }

        public bool Contains<TC>(TC element) where TC : IComparable, IComparable<T>
        {
            bool isContained = false;
            for (int index = 0; index < this.Count; index++)
            {
                if (element.CompareTo(this.list[index]) == 0)
                {
                    isContained = true;
                    break;
                }
            }

            return isContained;
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            for (int index = 0; index < this.Count; index++)
            {
                output.AppendFormat("{0}\n", this.list[index].ToString());
            }

            return output.ToString();
        }

        public T Min()
        {
            if (this.Count > 0)
            {
                return this.list.Min();
            }

            throw new InvalidOperationException("Method can not be applied to an empty GenericList!");
        }

        public T Max()
        {
            if (this.Count > 0)
            {
                return this.list.Max();
            }

            throw new InvalidOperationException("Method can not be applied to an empty GenericList!");
        }

        private void Enlarge()
        {
            this.Capacity *= 2;
            var newList = new T[this.Capacity];
            this.list.CopyTo(newList, 0);
            this.list = newList;
        }

        private void Initialize(int capacity = InitialSize)
        {
            this.list = new T[capacity];
            this.Capacity = capacity;
            this.Count = 0;
        }
    }
}

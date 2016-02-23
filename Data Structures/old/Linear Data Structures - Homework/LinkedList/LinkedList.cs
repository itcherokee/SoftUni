namespace LinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable<T> where T: IComparable
    {
        private ListNode<T> head;
        private ListNode<T> tail;

        public int Count { get; private set; }

        public LinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        public void Add(T element)
        {
            var node = new ListNode<T>(element);
            if (this.Count == 0)
            {
                this.head = node;
                this.tail = node;
            }
            else
            {
                this.tail.NextNode = node;
                this.tail = node;
            }

            this.Count++;
        }

        public T Remove(int index)
        {
            if (index >= this.Count || index < 0)
            {
                throw new IndexOutOfRangeException("Invalid index specified.");
            }
            
            var currentNode = this.head;
            T value = currentNode.Value;
            if (index == 0) // first index - 0
            {
                this.head = this.head.NextNode;
            }
            else
            {
                for (int i = 0; i < this.Count - 1; i++)
                {
                    if (index == i + 1)  // index in the middle or last node
                    {
                        value = currentNode.NextNode.Value;
                        if (this.tail == currentNode.NextNode) // last node
                        {
                            this.tail = currentNode;
                            currentNode.NextNode = null;
                        }
                        else
                        {
                            currentNode.NextNode = currentNode.NextNode.NextNode;
                        }

                        break;
                    }

                    currentNode = currentNode.NextNode;
                }
            }

            this.Count--;
            return value;

        }

        public int FirstIndexOf(T item)
        {
            var index = 0;
            var currentNode = this.head;
            do
            {
                if (currentNode.Value.CompareTo(item) == 0)
                {
                    return index;
                }

                index++;
            } while (currentNode.NextNode != null);

            return -1;
        }

        public int LastIndexOf(T item)
        {
            var currentIndex = 0;
            var previousIndex = -1;
            var currentNode = this.head;
            do
            {
                if (currentNode.Value.CompareTo(item) == 0)
                {
                    if (previousIndex < currentIndex)
                    {
                        previousIndex = currentIndex;
                        
                    }
                }

                currentIndex++;
                currentNode = currentNode.NextNode;
            } while (currentNode != null);

            return previousIndex;
        }

        public void ForEach(Action<T> action)
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
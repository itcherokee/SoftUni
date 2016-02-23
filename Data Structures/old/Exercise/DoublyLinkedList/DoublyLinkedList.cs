using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    private class ListNode<T>
    {
        public T Value { get; private set; }

        public ListNode<T> PrevNode { get; set; }

        public ListNode<T> NextNode { get; set; }

        public ListNode(T value)
        {
            this.Value = value;
            this.PrevNode = null;
            this.NextNode = null;
        }
    }

    private ListNode<T> head;
    private ListNode<T> tail;

    public int Count { get; private set; }

    public DoublyLinkedList()
    {
        this.head = null;
        this.tail = null;
    }

    public void AddFirst(T element)
    {
        var node = new ListNode<T>(element);
        if (this.Count == 0)
        {
            this.head = node;
            this.tail = node;
        }
        else
        {
            this.head.PrevNode = node;
            node.NextNode = this.head;
            this.head = node;
        }

        this.Count++;
    }

    public void AddLast(T element)
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
            node.PrevNode = this.tail;
            this.tail = node;
        }

        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count > 0)
        {
            T value = this.head.Value;
            if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                this.head.NextNode.PrevNode = null;
                this.head = this.head.NextNode;
            }

            this.Count--;
            return value;

        }

        throw new InvalidOperationException("List is empty");
    }

    public T RemoveLast()
    {
        if (this.Count > 0)
        {
            T value = this.tail.Value;
            if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                this.tail = this.tail.PrevNode;
                this.tail.NextNode = null;
            }

            this.Count--;
            return value;
        }

        throw new InvalidOperationException("List is empty");
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

    public T[] ToArray()
    {
        var array = new T[this.Count];
        var currentNode = this.head;
        for (int i = 0; i < this.Count; i++)
        {
            array[i] = currentNode.Value;
            currentNode = currentNode.NextNode;
        }

        return array;
    }
}


class Example
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.AddLast(5);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(10);
        Console.WriteLine("Count = {0}", list.Count);

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveFirst();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveLast();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");
    }
}

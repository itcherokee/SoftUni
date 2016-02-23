namespace LinkedList
{
    public class ListNode<T>
    {
        public T Value { get; private set; }

        public ListNode<T> NextNode { get; set; }

        public ListNode(T value)
        {
            this.Value = value;
            this.NextNode = null;
        }
    }
}

namespace DistanceInLabyrinth
{
    using System;

    public class MyListNode<T>
    {
        public MyListNode(T value)
        {
            this.Value = value;

            this.LeftIsVisited = false;
            this.UpIsVisited = false;
            this.RightIsVisited = false;
            this.DownIsVisited = false;    
        }

        public T Value { get; set; }

        public MyListNode<T> PreviousNode { get; set; }

        public bool LeftIsVisited { get; set; }

        public bool UpIsVisited { get; set; }
        
        public bool RightIsVisited { get; set; }
        
        public bool DownIsVisited { get; set; }
    }
}

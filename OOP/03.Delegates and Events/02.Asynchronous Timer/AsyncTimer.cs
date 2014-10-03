namespace AsynchronousTimer
{
    using System;
    using System.Threading;

    public class AsyncTimer
    {
        private Action<int> function;
        private int maxCount;
        private int interval;
        private int count;
        private Thread timerThread;

        public AsyncTimer(Action<int> func, int ticks, int interval)
        {
            this.Interval = interval;
            this.MaxCounts = ticks;
            this.Task = func;
            this.count = 0;
        }

        private int Interval
        {
            get
            {
                return this.interval;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Interval can not be a negative value!");
                }

                this.interval = value;
            }
        }

        private int MaxCounts
        {
            get
            {
                return this.maxCount;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Count can not be a negative value!");
                }

                this.maxCount = value;
            }
        }

        private Action<int> Task
        {
            get
            {
                return this.function;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Task", "Action cannot be null");
                }

                this.function = value;
            }
        }

        /// <summary>
        /// Starts the background process
        /// </summary>
        public void Start()
        {
            this.timerThread = new Thread(new ThreadStart(this.DoWork));
            this.timerThread.Start();
            this.timerThread.IsBackground = true;
        }

        /// <summary>
        /// ThreadStart method delegate to be executed when timer starts
        /// </summary>
        private void DoWork()
        {
            while (this.count < this.MaxCounts)
            {
                this.count++;
                if (this.Task != null)
                {
                    this.Task(this.count);
                }

                Thread.Sleep(this.Interval);
            }

            this.timerThread.Abort();
        }
    }
}
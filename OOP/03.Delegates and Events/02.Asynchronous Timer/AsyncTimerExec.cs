// Task 2:  Create a class AsyncTimer that executes a given method each t seconds.
//          • The constructor should accept 3 arguments: Action (a method to be called on 
//            every t milliseconds), ticks (the number of times the method should be called) 
//            and t (time interval between each tick in milliseconds).
//          • The main program's execution should NOT be paused at any time (use some kind 
//            of background execution).

namespace AsynchronousTimer
{
    using System;
    using System.Threading;

    public class AsyncTimerExec
    {
        public static void Main()
        {
            AsyncTimer runningTimer = new AsyncTimer(Announce, 10, 1000);
            runningTimer.Start();
            Thread.Sleep(2020);
            Console.WriteLine("This is main program execution (delayed 2 sec.) not interupted by timer");
            Thread.Sleep(2500);
            Console.WriteLine("This is again main program execution not interupted by timer");
            Console.ReadKey();
        }

        private static void Announce(int tick)
        {
            Console.WriteLine("I'm a background process tick number {0}!", tick);
        }
    }
}

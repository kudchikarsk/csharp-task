﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Example_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int[]> parent = new Task<int[]>(() =>
            {
                var results = new int[3];
                new Task(() => {
                    Thread.Sleep(15000);
                    results[0] = 0;
                },
                TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[1] = 1,
                TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = 2,
                TaskCreationOptions.AttachedToParent).Start();
                return results;
            });
            parent.Start();
            var finalTask = parent.ContinueWith(
            parentTask => {
                foreach (int i in parentTask.Result)
                    Console.WriteLine(i);
            });
            finalTask.Wait();
            Console.ReadLine();
        }
    }
}

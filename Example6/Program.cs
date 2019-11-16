using System;
using System.Threading;
using System.Threading.Tasks;

namespace Example6
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int[]> parent = new Task<int[]>(() =>
            {
                var results = new int[3];
                TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent,
                TaskContinuationOptions.ExecuteSynchronously);
                tf.StartNew(() => {
                    Thread.Sleep(15000);
                    results[0] = 0;
                });
                tf.StartNew(() => results[1] = 1);
                tf.StartNew(() => results[2] = 2);
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
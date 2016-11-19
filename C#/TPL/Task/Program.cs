using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace TaskExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // simple task
            Task simpleTask = new Task(SimpleTaskAction);
            simpleTask.Start();

            // parameterized task
            Task parameterizedTask = new Task(ParameterizedTaskAction, "42");
            parameterizedTask.Start();

            // simple task with task creation option
            Task simpleTaskWithOption = new Task(SimpleTaskAction, TaskCreationOptions.LongRunning);
            simpleTaskWithOption.Start();

            // first task continuing with second task
            Task firstTask = new Task(firstTaskAction);
            firstTask.ContinueWith(secondTaskAction);
            firstTask.Start();

            // first task continuing with second task with task configuration options
            firstTask = new Task(firstTaskAction);
            firstTask.ContinueWith(secondTaskAction, TaskContinuationOptions.NotOnCanceled | TaskContinuationOptions.NotOnFaulted);
            // TaskContinuationOptions.NotOnCanceled | TaskContinuationOptions.NotOnFaulted is probably the same as TaskContinuationOptions.OnlyOnRanToCompletion
            // yes, beacause 131072 | 262144 = 393216
            firstTask.Start();

            Console.ReadLine();
        }

        static void SimpleTaskAction()
        {
            WriteLine(nameof(SimpleTaskAction));
        }

        static void ParameterizedTaskAction(object param)
        {
            WriteLine($"{nameof(ParameterizedTaskAction)},{param}");
        }

        static void simpleTaskWithOption()
        {
            WriteLine(nameof(simpleTaskWithOption));
        }

        private static void firstTaskAction()
        {
            WriteLine(nameof(firstTaskAction));
        }

        static void secondTaskAction(Task firstTask)
        {
            WriteLine($"{nameof(secondTaskAction)},{firstTask.Id}");
        }
    }
}

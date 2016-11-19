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

            // simple task with return value
            Task<int> computeFactorial = new Task<int>(computeFactorialAction, 5);
            computeFactorial.Start();
            WriteLine($"computeFactorial.Result={computeFactorial.Result}");

            Console.ReadLine();
        }

        private static int computeFactorialAction(object o)
        {
            return Factorial(Convert.ToInt32(o));
        }

        private static int Factorial(int v)
        {
            if (v == 0)
                return 1;

            return v * Factorial(v - 1);
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

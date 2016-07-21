using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Source: http://stackoverflow.com/questions/3416758

namespace OuterVariableTrap
{
    static class Program
    {
        static void Main(string[] args)
        {
            var actions = new List<Action>();

            for (var i = 0; i < 10; i++)
                actions.Add(() => Console.Write($"{i} "));

            // FIX:
            //actions.Clear();
            //for (var i = 0; i < 10; i++)
            //{
            //    int j = i;
            //    actions.Add(() => Console.Write($"{j} "));
            //}

            actions.ForEach(a => a());
            Console.ReadLine();
        }
    }
}

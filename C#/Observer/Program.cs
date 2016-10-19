using Observer.src.ex1;
using Observer.src.ex2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Subject
            // Na zmenu tohohle subjektu
            SubjectA sA = new SubjectA();

            // Observers..
            // Budou reagovat tito pozorovatele
            ObserverA oA = new ObserverA(sA);
            ObserverB oB = new ObserverB(sA);

            // Modification 1
            sA.SetValue(10);

            // Register can return IDisposable Unregister class
            // Unregister
            sA.Unregister(oA);

            // Modification 2
            sA.SetValue(42);

            // --
            Console.ReadLine();

            //
            // ----
            //
            Game g = new Game();

            // Players
            Player kuz1 = new Player(nameof(kuz1));
            Player mar5 = new Player(nameof(mar5));
            Player kor1 = new Player(nameof(kor1));
            Player tes2 = new Player(nameof(tes2));
            Player cvr1 = new Player(nameof(cvr1));

            // Still without observers
            g.AddPlayer(kuz1);

            // Observers
            Table table = new Table(g);
            Radio radio = new Radio(g);

            // With observers
            g.AddPlayer(kor1);
            g.AddPlayer(tes2);
            g.AddPlayer(cvr1);

            g.RemovePlayer(tes2);

            g.AddPlayer(mar5);

            g.RemovePlayer(mar5);

            // --
            Console.ReadLine();
        }
    }
}

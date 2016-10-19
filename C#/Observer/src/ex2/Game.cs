using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.src.ex2
{
    class Game : Subject
    {
        List<Player> players = new List<Player>();

        public void AddPlayer(Player p)
        {
            players.Add(p);
            Notify(this, $"{p} added");
        }

        public void RemovePlayer(Player p)
        {
            players.Remove(p);
            Notify(this, $"{p} removed");
        }
    }
}

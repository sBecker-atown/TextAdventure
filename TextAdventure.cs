using System.Collections;
using System.Diagnostics.SymbolStore;

namespace TextAdventure;

    public enum Direction
    {
        None, North, East, South, West,
    }

    class Program
    {
        static void Main(string[] args)
        {
            var gameworld = new Gameworld();
            gameworld.Start();  
        }
    }

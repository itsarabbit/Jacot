using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SFML.Window;

namespace BallGame.Engine
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.Run(new Vector2f(1920, 1080));
        }
    }
}

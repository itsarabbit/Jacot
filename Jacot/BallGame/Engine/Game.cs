using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

using SFML.Window;
using SFML.Graphics;

namespace BallGame.Engine
{
    static class Game
    {
        public static RenderWindow Window;

        public static void Run(Vector2f windowSize)
        {
            Window = new RenderWindow(new VideoMode((uint)windowSize.X, (uint)windowSize.Y), "BallGame", Styles.Close);
            
            Input.RegisterEvents(Window);


            Stopwatch watch = new Stopwatch();
            while (Window.IsOpen())
            {
                float deltaTime = (float)watch.Elapsed.TotalSeconds;
                watch.Restart();
                Input.Update();

                Window.DispatchEvents();
                Window.Clear(Color.White);

                Console.Clear();
                Console.WriteLine("FPS: " + 1/deltaTime);

                Window.Display();
            }
        }
    }
}

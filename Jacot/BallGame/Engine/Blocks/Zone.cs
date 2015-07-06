using System;
using System.Collections.Generic;
using System.Text;
using BallGame.Engine.Collision;
using SFML.Window;

namespace BallGame.Engine.Blocks
{
    class Zone
    {
        /// <summary>
        /// list of blocks. [X][Y]
        /// </summary>
        static List<List<Block>> BlockList;

        public Rectangle ZoneRectangle;

        public Zone(Rectangle rectangle)
        {
            ZoneRectangle = rectangle;
        }

        public Block FindBlock(int X, int Y)
        {
            X -= (int)ZoneRectangle.X;
            Y -= (int)ZoneRectangle.Y;
            if (X < 0 || Y < 0 || X > ZoneRectangle.Width || Y > ZoneRectangle.Height)
            {
                Console.WriteLine("Block was out of bounds.");
                return null;
            }
            return BlockList[X][Y];
        }
    }
}

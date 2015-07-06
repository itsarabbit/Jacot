using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using BallGame.Engine.Blocks;
using BallGame.Engine.Collision;
using SFML.Window;
using Zone = BallGame.Engine.Blocks.Zone;

namespace BallGame.Engine
{
    public static class WorldInfo
    {
        public static int WorldHeight = 200, WorldWidth = 400;
        public const int ChunkSize = 50;

        static List<Zone> ZoneList;

        static WorldInfo()
        {
            
        }

        static void CreateBlock(Block block)
        {
            BlockList[block.X][block.Y] = block;
            block.Initialize();
        }

        public static Block FindBlock(int X, int Y)
        {
            return BlockList[X][Y];
        }

        static Zone[] FindZones(int X, int Y)
        {
            Zone[] zone = new Zone[4];

            int Xfoo = (int)Math.Floor((decimal)(X / ChunkSize)) * ChunkSize;
            int Yfoo = (int)Math.Floor((decimal)(Y / ChunkSize)) * ChunkSize;
            foreach (Zone z in ZoneList)
            {
                if (z.ZoneRectangle.X == Xfoo && z.ZoneRectangle.Y == Yfoo)
                    zone[0] = z;
            }
            if (zone[0] == null)
            {
                zone[0] = new Zone(new Rectangle(new Vector2f(Xfoo, Yfoo), new Vector2f(100, 100)));
                ZoneList.Add(zone[0]);
                
            }
            Xfoo = (int)Math.Ceiling((decimal)(X / ChunkSize)) * ChunkSize;
            Yfoo = (int)Math.Floor((decimal)(Y / ChunkSize)) * ChunkSize;
            foreach (Zone z in ZoneList)
            {
                if (z.ZoneRectangle.X == Xfoo && z.ZoneRectangle.Y == Yfoo)
                    zone[1] = z;
            }
            if (zone[0] == null)
            {
                zone[0] = new Zone(new Rectangle(new Vector2f(Xfoo, Yfoo), new Vector2f(100, 100)));
                ZoneList.Add(zone[0]);

            }
            Xfoo = (int)Math.Ceiling((decimal)(X / ChunkSize)) * ChunkSize;
            Yfoo = (int)Math.Ceiling((decimal)(Y / ChunkSize)) * ChunkSize;
            foreach (Zone z in ZoneList)
            {
                if (z.ZoneRectangle.X == Xfoo && z.ZoneRectangle.Y == Yfoo)
                    zone[2] = z;
            }
            if (zone[0] == null)
            {
                zone[0] = new Zone(new Rectangle(new Vector2f(Xfoo, Yfoo), new Vector2f(100, 100)));
                ZoneList.Add(zone[0]);

            }
            Xfoo = (int)Math.Floor((decimal)(X / ChunkSize)) * ChunkSize;
            Yfoo = (int)Math.Ceiling((decimal)(Y / ChunkSize)) * ChunkSize;
            foreach (Zone z in ZoneList)
            {
                if (z.ZoneRectangle.X == Xfoo && z.ZoneRectangle.Y == Yfoo)
                    zone[3] = z;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SFML.Window;

namespace BallGame.Engine.Blocks
{
    public class AdjacentBlocks
    {
        public Block North, South, West, East, Northwest, Northeast, Southwest, Southeast;

        public bool IsAlone
        {
            get
            {
                if (North.BlockType != BlockType.None)
                    return false;
                if (South.BlockType != BlockType.None)
                    return false;
                if (West.BlockType != BlockType.None)
                    return false;
                if (East.BlockType != BlockType.None)
                    return false;
                return true;
            }
        }

        public void UpdateState(int X, int Y)
        {
            North = WorldInfo.FindBlock(X, Y - 1);
            South = WorldInfo.FindBlock(X, Y + 1);
            East = WorldInfo.FindBlock(X + 1, Y);
            West = WorldInfo.FindBlock(X - 1, Y);
        }

        public void UpdateStateNear(int X, int Y)
        {
            UpdateState(X, Y);
            Northeast = WorldInfo.FindBlock(X + 1, Y - 1);
            Southeast = WorldInfo.FindBlock(X + 1, Y + 1);
            Northwest = WorldInfo.FindBlock(X - 1, Y - 1);
            Southwest = WorldInfo.FindBlock(X - 1, Y + 1);
        }

        public void UpdateAdjacentBlocks()
        {
            North.Update();
            South.Update();
            West.Update();
            East.Update();
        }
    }
}

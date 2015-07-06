using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;

namespace BallGame.Engine.Blocks
{
    public abstract class Block
    {
        public BlockType BlockType = BlockType.Dirt;
        protected AdjacentBlocks AdjacentBlocks;
        public int X;
        public int Y;

        public virtual void Initialize()
        {
            Update();
            AdjacentBlocks.UpdateAdjacentBlocks();;
        }

        public virtual void Update()
        {
            AdjacentBlocks.UpdateState(X, Y);
        }
    }
}

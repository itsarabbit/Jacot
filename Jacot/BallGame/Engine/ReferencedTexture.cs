using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;

namespace BallGame.Engine
{
    class ReferencedTexture : Texture
    {
        public readonly string Filename;

        public ReferencedTexture(string path)
            : base(path)
        {
            Filename = path;
        }
    }
}

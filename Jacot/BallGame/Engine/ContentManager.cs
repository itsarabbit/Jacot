using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace BallGame.Engine
{
    static class ContentManager
    {
        private static Dictionary<string, ReferencedTexture> textureCache = new Dictionary<string, ReferencedTexture>();
        private static Dictionary<string, Font> fontCache = new Dictionary<string, Font>();

        public static float WindowScale
        {
            get
            {
                return Game.Window.Size.X / 1920;
            }
        }

        public static ReferencedTexture LoadTexture(string path)
        {
            ReferencedTexture texture;
            if (!textureCache.TryGetValue(path, out texture))
            {
                texture = new ReferencedTexture(path);
                texture.Smooth = true;
                textureCache[path] = texture;
            }
            return texture;
        }
        public static Font LoadFont(string path)
        {
            Font font;
            if (!fontCache.TryGetValue(path, out font))
            {
                font = new Font(path);
                fontCache[path] = font;
            }
            return font;
        }
    }
}
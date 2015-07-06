using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;

namespace BallGame.Engine.Collision
{
    struct Circle
    {
        public float Radius;
        public Vector2f Position;

        float X
        {
            get
            {
                return Position.X;
            }
        }
        float Y
        {
            get
            {
                return Position.Y;
            }
        }

        public Circle(Vector2f position, float radius)
        {
            Radius = radius;
            Position = position;
        }

        public bool Intersects(Circle circle)
        {
            if (Trig.PointDistance(Position, circle.Position) < Radius + circle.Radius) return true;
            return false;
        }

        public bool Intersects(Vector2f point)
        {
            if (Trig.PointDistance(Position, point) < Radius) return true;
            return false;
        }

        public bool Intersects(Rectangle rect)
        {
            if (!(new Rectangle(new Vector2f(Position.X - Radius, Position.Y - Radius), new Vector2f(Radius * 2, Radius * 2))).Intersects(rect)) return false;

            if (rect.Intersects(new Vector2f(Position.X - Radius, Position.Y)) || rect.Intersects(new Vector2f(Position.X + Radius, Position.Y))
                || rect.Intersects(new Vector2f(Position.X, Position.Y - Radius)) || rect.Intersects(new Vector2f(Position.X, Position.Y + Radius))) return true;

            if (Trig.PointDistance(rect.Position, Position) < Radius || Trig.PointDistance(new Vector2f(rect.X + rect.Width, rect.Y), Position) < Radius
                || Trig.PointDistance(new Vector2f(rect.X, rect.Y + rect.Height), Position) < Radius || Trig.PointDistance(new Vector2f(rect.X + rect.Width, rect.Y + rect.Height),
                Position) < Radius) return true;

            return false;
        }
    }
}

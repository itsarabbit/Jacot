using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;

namespace BallGame.Engine.Collision
{
    struct Rectangle
    {
        #region Variables
        public Vector2f Position, Size;
        public float X
        {
            get
            {
                return Position.X;
            }
        }
        public float Y
        {
            get
            {
                return Position.Y;
            }
        }
        public float Width
        {
            get
            {
                return Size.X;
            }
        }
        public float Height
        {
            get
            {
                return Size.Y;
            }
        }
        #endregion

        public Rectangle(Vector2f position, Vector2f size)
        {
            this.Position = position;
            this.Size = size;
        }

        public bool Intersects(Rectangle rect)
        {
            if (rect.X + rect.Width < X) return false;
            if (rect.Y + rect.Height < Y) return false;
            if (rect.X > X + Width) return false;
            if (rect.Y > Y + Height) return false;
            return true;
        }

        public bool Intersects(Vector2f point)
        {
            if (point.X > X && point.X < X + Width && point.Y > Y && point.Y < Y + Height) return true;

            return false;
        }

        public bool Intersects(Circle circle)
        {
            if (!Intersects(new Rectangle(new Vector2f(circle.Position.X - circle.Radius, circle.Position.Y - circle.Radius), new Vector2f(circle.Radius * 2, circle.Radius * 2)))) return false;

            if (Intersects(new Vector2f(circle.Position.X - circle.Radius, circle.Position.Y)) || Intersects(new Vector2f(circle.Position.X + circle.Radius, circle.Position.Y))
                || Intersects(new Vector2f(circle.Position.X, circle.Position.Y - circle.Radius)) || Intersects(new Vector2f(circle.Position.X, circle.Position.Y + circle.Radius))) return true;

            if (Trig.PointDistance(Position, circle.Position) < circle.Radius || Trig.PointDistance(new Vector2f(X + Width, Y), circle.Position) < circle.Radius
                || Trig.PointDistance(new Vector2f(X, Y + Height), circle.Position) < circle.Radius || Trig.PointDistance(new Vector2f(X + Width, Y + Height), circle.Position) < circle.Radius) return true;

            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;

namespace BallGame.Engine.Collision
{

    struct Line
    {
        public Vector2f Point1, Point2;

        float Angle
        {
            get
            {
                return Trig.PointDirection(Point1, Point2);
            }
        }

        public Line(Vector2f pos1, Vector2f pos2)
        {
            Point1 = pos1;
            Point2 = pos2;
        }

        public bool Intersects(Line line)
        {
            float denominator = ((Point2.X - Point1.X) * (line.Point2.Y - line.Point1.Y)) - ((Point2.Y - Point1.Y) * (line.Point2.X - line.Point1.X));
            float numerator1 = ((Point1.Y - line.Point1.Y) * (line.Point2.X - line.Point1.X)) - ((Point1.X - line.Point1.X) * (line.Point2.Y - line.Point1.Y));
            float numerator2 = ((Point1.Y - line.Point1.Y) * (Point2.X - Point1.X)) - ((Point1.X - line.Point1.X) * (Point2.Y - Point1.Y));

            if (denominator == 0) return numerator1 == 0 && numerator2 == 0;

            float r = numerator1 / denominator;
            float s = numerator2 / denominator;

            return (r >= 0 && r <= 1) && (s >= 0 && s <= 1);
        }

        public bool Intersects(Rectangle rectangle)
        {
            if (Intersects(new Line(new Vector2f(rectangle.X, rectangle.Y), new Vector2f(rectangle.X, rectangle.Y + rectangle.Height)))) return true;
            if (Intersects(new Line(new Vector2f(rectangle.X, rectangle.Y), new Vector2f(rectangle.X + rectangle.Width, rectangle.Y)))) return true;
            if (Intersects(new Line(new Vector2f(rectangle.X + rectangle.Width, rectangle.Y), new Vector2f(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height)))) return true;
            if (Intersects(new Line(new Vector2f(rectangle.X, rectangle.Y + rectangle.Height), new Vector2f(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height)))) return true;
            return false;
        }
    }
}

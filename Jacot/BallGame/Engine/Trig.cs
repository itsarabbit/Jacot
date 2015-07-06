using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;

namespace BallGame.Engine
{
    static class Trig
    {
        public static float PointDistance(float x1, float y1, float x2, float y2)
        {
            return (float)Math.Sqrt(Math.Pow(x2 - x1, 2f) + Math.Pow(y2 - y1, 2f));
        }

        public static double PointDistanceDouble(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2f) + Math.Pow(y2 - y1, 2f));
        }

        public static Vector2f RotateVector2f(Vector2f vector, float rotation)
        {
            return LengthDir(PointDistance(new Vector2f(), vector), PointDirection(new Vector2f(), vector) + rotation);
        }

        public static float RadToDeg(float radials)
        {
            return radials * (180f / (float)Math.PI);
        }

        public static float PointDirection(Vector2f first, Vector2f second)
        {
            return PointDirection(first.X, first.Y, second.X, second.Y);
        }

        public static float PointDistance(Vector2f first, Vector2f second)
        {
            return PointDistance(first.X, first.Y, second.X, second.Y);
        }

        public static float PointDirection(float x1, float y1, float x2, float y2)
        {
            float result = 360f - RadToDeg((float)Math.Atan2(y1 - y2, x2 - x1));

            if (result < 0f)
                result += 360f;
            else if (result > 360f)
                result -= 360f;

            return result;
        }

        public static float LengthDirX(float dist, float dir)
        {
            return (float)Math.Cos((360f - dir) * Math.PI / 180f) * dist;
        }

        public static float LengthDirY(float dist, float dir)
        {
            return (float)-Math.Sin((360f - dir) * Math.PI / 180f) * dist;
        }

        public static Vector2f LengthDir(float dist, float dir)
        {
            return new Vector2f(LengthDirX(dist, dir), LengthDirY(dist, dir));
        }

        public static float Normalize(float angle)
        {
            angle = angle % 360f;
            if (angle < 0f)
                angle += 360f;
            return angle;
        }

        public static float AngleDifference(float angle1, float angle2)
        {
            float difference = angle2 - angle1;
            while (difference < -180f)
                difference += 360f;
            while (difference > 180f)
                difference -= 360f;
            return difference;
        }
    }
}

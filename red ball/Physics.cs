using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace red_ball
{
    public class Force
    {
        private float Multiplier { get; set; }
        public Vector Direction { get; }
        private int time;
        public TypeForce typeForce { get; }

        public Force(float mult, Vector v, TypeForce t)
        {
            Multiplier = mult;
            Direction = v;
            time = 1;
            typeForce = t;
        }

        public static Force operator +(Force f1, Force f2)
        {
            return new Force(1, f1.Direction * f1.Multiplier + f2.Direction * f2.Multiplier);
        }
        public static bool operator ==(Force f1, Force f2)
        {
            return f1.Direction == f2.Direction && f1.Direction * f1.Multiplier == f2.Direction * f2.Multiplier;
        }

        public static bool operator !=(Force f1, Force f2)
        {
            return f1.Direction != f2.Direction || f1.Direction * f1.Multiplier != f2.Direction * f2.Multiplier;
        }

        public bool IsZeroForce()
        {
            return Direction.Length == 0;
        }
    }




    public class Point
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }
        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }

        public static Point operator *(Point p, float k)
        {
            return new Point(p.X * k, p.Y * k);
        }

        public static bool operator ==(Point p1, Point p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        public static bool operator !=(Point p1, Point p2)
        {
            return p1.X != p2.X || p1.Y != p2.Y;
        }
    }

    public class Vector
    {
        public Point start, end;
        public float Length
        {
            get
            {
                return (float)Math.Sqrt(Math.Pow(start.X - end.X, 2) + Math.Pow(start.Y - end.Y, 2));
            }
        }
        public Vector(Point _start, Point _end)
        {
            start = _start;
            end = _end;
        }

        public Vector((int x, int y) p1, (int x, int y) p2)
        {
            start = new Point(p1.x, p1.y);
            end = new Point(p2.x, p2.y);
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.start, v1.end + v2.end);
        }

        public static Vector operator *(Vector v, float k)
        {
            return new Vector(v.start * k, v.end * k);
        }

        public static bool operator ==(Vector v1, Vector v2)
        {
            return v1.start == v2.start && v1.end == v2.end && v1.Length == v2.Length;
        }

        public static bool operator !=(Vector v1, Vector v2)
        {
            return v1.start != v2.start || v1.end != v2.end || v1.Length != v2.Length;
        }
    }
}

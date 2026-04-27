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
        public int Time { get; private set; }
        public TypeForce typeForce { get; }

        /// <summary>
        /// Создает силу которая только появилась 
        /// </summary>
        public Force(float mult, Vector v, TypeForce t)
        {
            Multiplier = mult;
            Direction = v;
            Time = 1;
            typeForce = t;
        }

        /// <summary>
        /// Для сложения сил
        /// </summary>
        private Force(float mult, Vector v, TypeForce ty, int time)
        {
            Multiplier = mult;
            Direction = v;
            Time = time;
            typeForce = ty;
        }
        /// <summary>
        /// Складывает силы, у новой силы тип - это тип большей по модулю силы.
        /// </summary>
        public static Force operator +(Force f1, Force f2)
        {
            var d1 = f1.Direction * f1.Multiplier;
            var d2 = f2.Direction * f2.Multiplier;
            if (d1 > d2)
            {
                d1 *= (float)Math.Sign((int)f1.typeForce);
                d2 *= (float)Math.Sign((int)f2.typeForce);
                return new Force(1, d1 + d2, f1.typeForce);
            }
            else if (d1 < d2) 
            {
                d1 *= (float)Math.Sign((int)f1.typeForce);
                d2 *= (float)Math.Sign((int)f2.typeForce);
                return new Force(1, d1 + d2, f2.typeForce);
            }
            else
            {
                return Constant.zeroForce;
            }
           
        }
        public static bool operator ==(Force f1, Force f2)
        {
            return f1.Direction == f2.Direction && f1.Direction * f1.Multiplier == f2.Direction * f2.Multiplier;
        }

        public static bool operator !=(Force f1, Force f2)
        {
            return f1.Direction != f2.Direction || f1.Direction * f1.Multiplier != f2.Direction * f2.Multiplier;
        }

        public static Force operator /(Force f, float c)
        {
            return new Force(f.Multiplier, f.Direction / c, f.typeForce, f.Time) ;
        }
        public bool IsZeroForce()
        {
            return Direction.Length == 0;
        }

        public void Tick()
        {
            Time++;
        }

        public float CalculateDirMultLength()
        {
            return Direction.Length * Math.Sign( (int)typeForce);
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

        public Vector((float x, float y) p1, (float x, float y) p2)
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

        public static bool operator <(Vector v1, Vector v2)
        {
            return v1.Length < v2.Length;
        }

        public static bool operator >(Vector v1, Vector v2)
        {
            return v1.Length > v2.Length;
        }

        public static Vector operator /(Vector v, float c)
        {
            return new Vector(new Point(v.start.X / c, v.start.Y / c), new Point(v.end.X/c, v.end.Y/c)); 
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace red_ball
{
    internal class Constant
    {
        static public int sizeBall = 50;
        static public Force zeroForce = new Force(0, new Vector(new Point(0, 0), new Point(0, 0)));
    }
    public enum TypeBall
    {
        Base = 1,
        Stone = 3
    }

    public enum StateBall
    {
        OnFloor,
        InFall,
        InWater
    }
}

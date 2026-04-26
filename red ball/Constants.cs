using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace red_ball
{
    internal class Constant
    {
        static public int sizeBall = 20;
        static public Force zeroForce = new Force(0, new Vector(new Point(0, 0), new Point(0, 0)), TypeForce.None);
        static public Func<TypeBall, Force>gravityForce = (t) => new Force((float)t*9.8f, new Vector((0,0), (0,1)), TypeForce.Gravity);
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

    public enum DirectionMovement
    {
        Backward = -1,
        Forward = 1,
    }

    public enum TypeForce
    {
        Archimed = -4,
        MoveBackward,
        Friction,
        ForceJump,
        None,
        Gravity,
        MoveForward,
        
    }
}

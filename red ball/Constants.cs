using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace red_ball
{
    
    public static class Constant
    {
        /// <summary>
        /// Радиус мяча 
        /// </summary>
        static public int sizeBall = 50;
        /// <summary>
        /// Сила 0 (для обозначения отсутствия силы)
        /// </summary>
        static public Force zeroForce = new Force(0, new Vector(new Point(0, 0), new Point(0, 0)), TypeForce.None);
        /// <summary>
        /// Сила гравитации
        /// </summary>
        static public Func<TypeBall, Force>gravityForce = (t) => new Force((float)t/2, new Vector((0,0), (0,20)), TypeForce.Gravity);
        static public int MaxSpeed = 30;
    }

    /// <summary>
    /// Тип мяча, также используется как масса
    /// </summary>
    public enum TypeBall
    {
        Base = 1,
        Stone = 3
    }
    /// <summary>
    /// Указывает в каком положении нахожится мяч 
    /// </summary>
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
    /// <summary>
    /// Указывает на тип силы, нужен для направления
    /// </summary>
    public enum TypeForce
    {
        Archimed = -4,
        MoveBackward,
        Friction,
        Jump,
        None,
        Gravity,
        MoveForward,
        
    }
}

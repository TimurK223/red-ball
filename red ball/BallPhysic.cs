using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace red_ball
{
    partial class Ball
    {
        private static Dictionary<Keys, Action<Ball>> MoveDirection = new Dictionary<Keys, Action<Ball>>() {
            {Keys.A, (b) => b.forcesX[0] = new Force(1, new Vector((0, 0), (-Constant.sizeBall/2, 0)))},
            {Keys.D, (b) => b.forcesX[0] = new Force(1, new Vector( (0, 0),(Constant.sizeBall/2, 0)))},
            {Keys.Space, (b) => b.forcesY[0] = new Force(1, new Vector( (0,0), (0, -Constant.sizeBall/2))) }
        };
        private static Dictionary<Keys, Action<Ball>> NotMoveDirection = new Dictionary<Keys, Action<Ball>>() {
            {Keys.A, (b) => b.forcesX[0] = Constant.zeroForce},
            {Keys.D, (b) => b.forcesX[0] = Constant.zeroForce },
            {Keys.Space, (b) => b.forcesY[1] = Constant.zeroForce }
        };
        private Force[] forcesX = new Force[2] { Constant.zeroForce, Constant.zeroForce };
        private Force[] forcesY = new Force[2] { Constant.zeroForce, Constant.zeroForce };
        private float speedX;
        private float speedY;
        float[] acc = new float[2];
        private float maxSpeed;
    }
}

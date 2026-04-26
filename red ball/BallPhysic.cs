using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace red_ball
{
    partial class Ball
    {
        private static Dictionary<Keys, Action<Ball>> MoveDirection = new Dictionary<Keys, Action<Ball>>() {
            {Keys.A, (b) =>  b.Move(DirectionMovement.Backward)},
            {Keys.D, (b) => b.Move(DirectionMovement.Forward)},
            {Keys.Space, (b) => b.Jump()  } 
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
        public float minY = 500;
        private StateBall state;
        
        /// <summary>
        ///  Пересчитывает ускорение
        /// </summary>
        public void CalculateAcceleration()
        {
            var fX = forcesX.Aggregate((f1, f2) => f1 + f2);
            var fY = forcesY.Aggregate((f1, f2) => f1 + f2);
            var fXY = fX + fY;
            acc[0] = fXY.Direction.Length * Math.Sign((int)fXY.typeForce);
            acc[1] = fXY.Direction.Length * Math.Sign((int)fXY.typeForce);

        }

        public void CalculateSpeed()
        {
            speedX = acc[0];
            speedY = acc[1];
        }

        

        public void СalculateВisplacement()
        {
            center.X += speedX;
            center.Y = -(center.Y + speedY) >= -minY ? center.Y + speedY : minY;
        }

        public void Jump()
        {
            if (forcesY[0].IsZeroForce() && state == StateBall.OnFloor)
                forcesY[0] = new Force(1, new Vector((0, 0), (0, -20)));
        }

        public void Move(DirectionMovement dir)
        {

            if (state == StateBall.OnFloor)
            {
                forcesX[0] = new Force(1, new Vector((0,0), ((int)dir*20,0)));
                forcesX[1] = new Force(1/5, new Vector((0, 0), (-(int)dir * 20, 0)));
            }
            else
            {
                forcesX[0] = new Force(1 * 1/3, new Vector((0, 0), ((int)dir * 20, 0)));
                forcesX[1] = new Force(1 / 5 * 1/3, new Vector((0, 0), (-(int)dir * 20, 0)));
            }
        }

        public void ChangeState(StateBall newState)
        {
            state = newState; 
        }

        public StateBall GetState()
        {
            return state;
        }

        public void AddForce(KeyEventArgs e)
        {
            if (MoveDirection.ContainsKey(e.KeyCode)) MoveDirection[e.KeyCode](this);
            Update();
        }
        /// <summary>
        /// Не использовать, перегрузка создана только для тестов
        /// </summary>
        /// <param name="f"></param>
        public void AddForce(Force f)
        {
            if (f.typeForce == TypeForce.MoveForward || f.typeForce == TypeForce.MoveBackward)
            {  
                forcesX[0] = f;
                Update();
            }
            else
            {
                forcesY[1] = f;
            }
        }
       

        public void DeleteForce(KeyEventArgs e)
        {
            if (NotMoveDirection.ContainsKey(e.KeyCode))
            {
                forcesX[0] = Constant.zeroForce;
                forcesY[0] = Constant.zeroForce;
            }
            Update();
        }

    }
}

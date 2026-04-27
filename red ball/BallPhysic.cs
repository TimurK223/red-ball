using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace red_ball
{
    partial class Ball
    {
        private static Dictionary<Keys, Action<Ball>> MoveDirection = new Dictionary<Keys, Action<Ball>>() {
            {Keys.A, (b) =>  b.Move(TypeForce.MoveBackward)},
            {Keys.D, (b) => b.Move(TypeForce.MoveForward)},
            {Keys.Space, (b) => b.Jump()  } 
        };
        private static Dictionary<Keys, Action<Ball>> NotMoveDirection = new Dictionary<Keys, Action<Ball>>() {
            {Keys.A, (b) => b.forcesX[0] = Constant.zeroForce},
            {Keys.D, (b) => b.forcesX[0] = Constant.zeroForce },
            {Keys.Space, (b) => b.forcesY[1] = Constant.zeroForce }
        };
        private Force[] forcesX = new Force[2] { Constant.zeroForce, Constant.zeroForce };
        private Force[] forcesY = new Force[2] { Constant.zeroForce, Constant.zeroForce };
        public float SpeedX { get; private set; }
        public float SpeedY { get; private set; }
        public float [] Acc { get; private set; }
        private float maxSpeed;
        public float minY = 1000;
        private StateBall state;
        private Force Fx = Constant.zeroForce;
        private Force Fy = Constant.zeroForce;

        public void CalculateForces()
        {
            var newFx = forcesX.Aggregate((f1, f2) => f1 + f2);
            var newFy = forcesY.Aggregate((f1, f2) => f1 + f2);
            if (newFx != Fx) { Fx = newFx; }
            if (newFy != Fy) { Fy = newFy; }
        }
        /// <summary>
        ///  Пересчитывает ускорение
        /// </summary>
        public void CalculateAcceleration()
        {
            Acc[0] = Fx.CalculateDirMultLength() * Fx.Time;
            Acc[1] = Fy.CalculateDirMultLength() * Fy.Time;
            Fx.Tick();
            Fy.Tick();

        }

        public void CalculateSpeed()
        {
            if (Math.Abs(SpeedX) != maxSpeed || forcesX[0].IsZeroForce())
            {
                SpeedX = maxSpeed > Math.Abs(Acc[0]) ? Acc[0] : maxSpeed * Math.Sign((float)Fx.typeForce);
            }
            
            SpeedY = Acc[1];
        }

        

        public void СalculateВisplacement()
        {
            center.X += SpeedX;
            center.Y = -(center.Y + SpeedY) >= -minY ? center.Y + SpeedY : minY;
        }

        public void Jump()
        {
            if (forcesY[0].IsZeroForce() && state == StateBall.OnFloor)
            { 
                forcesY[0] = new Force(1, new Vector((0, 0), (0, 3)), TypeForce.Jump);
                CalculateForces();
                Update();
                forcesY[0] = Constant.zeroForce; 
                
            }
        }

        public void Move(TypeForce dir)
        {

            if (state == StateBall.OnFloor)
            {
                forcesX[0] = new Force(1 / (int)_typeBall, new Vector((0, 0), ( 3, 0)), dir);
                forcesX[1] = new Force(1 / 5 * (int)_typeBall, new Vector((0, 0), (3, 0)), (TypeForce)(-(int)dir));
                CalculateForces();
            }
            else
            {
                forcesX[0] = new Force(1 / 3 , new Vector((0, 0), (1, 0)), dir);
                forcesX[1] = new Force(1 / 5 / 3 * (int)_typeBall, new Vector((0, 0), (1, 0)), (TypeForce)(-(int)dir));
                CalculateForces();
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
            forcesY[1] = Constant.zeroForce;
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
                forcesX[1] = forcesX[0] / 1.05f;
                forcesX[0] = Constant.zeroForce;
                forcesY[0] = Constant.zeroForce;
                CalculateForces();
                Update();
            }
        }

    }
}

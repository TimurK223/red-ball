using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace red_ball
{
    public partial class Ball
    {   

        private TypeBall _typeBall {  get; set; }
        public int size = Constant.sizeBall;
        public Point center;
       
        public Ball(TypeBall typeBall, int size, Point center)
        {
            _typeBall = typeBall;
            this.size = size;
            this.center = center;
            this.speedX = 0;
            this.speedY = 0;
            this.maxSpeed = 0;
            forcesY[1] = new Force((float)typeBall, new Vector((0, 0), (0, 20))); 
        }

        

        public void AddForce (KeyEventArgs e)
        {
            if (MoveDirection.ContainsKey(e.KeyCode)) MoveDirection[e.KeyCode](this);
            Update();
        }

        public void DeleteForce(KeyEventArgs e)
        {
            if (NotMoveDirection.ContainsKey(e.KeyCode))
            {
                forcesX[0] =   Constant.zeroForce;
                forcesY[0] = Constant.zeroForce;
                speedX = 0;
                speedY = 0;
            }
            Update();
        }
        public void Update()
        {
            CalculateAcceleration();
            CalculateSpeed();
            СalculateВisplacement();
            
        }

        public void CalculateSpeed()
        {
            speedX = acc[0];
            speedY = acc[1];
        }

        public void CalculateAcceleration()
        {
            var fX  = forcesX.Aggregate((f1, f2) => f1 + f2);
            var fY = forcesY.Aggregate((f1, f2) => f1 + f2);
            var fXY = fX + fY;
            var dirX = fXY.Direction.end.X == 0 & fXY.Direction.start.X == 0 ? 0 : fXY.Direction.end.X / Math.Abs(fXY.Direction.end.X);
            var dirY = fXY.Direction.end.Y == 0 & fXY.Direction.start.Y == 0 ? 0 : fXY.Direction.end.Y / Math.Abs(fXY.Direction.end.Y);


            acc[0] = fXY.Direction.Length * dirX / (float)this._typeBall;
            acc[1] = fXY.Direction.Length * dirY/ (float)this._typeBall;

        }

        public void СalculateВisplacement()
        {
            center.X += speedX;
            center.Y += speedY;
        }

        
    }

   
}

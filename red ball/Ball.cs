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

        public TypeBall _typeBall {  get; private set; }
        public int size = Constant.sizeBall;
        public Point center;
       
        public Ball(TypeBall typeBall, Point center)
        {
            _typeBall = typeBall;
            this.center = center;
            this.SpeedX = 0;
            this.SpeedY = 0;
            this.maxSpeed = Constant.MaxSpeed;
            forcesY[1] = Constant.gravityForce(typeBall);
            Acc = new float[3];
        }

        
        public void Update()
        {
            if (forcesX[0].IsZeroForce() && (int)SpeedX !=0 )
            {
                forcesX[1] /= 1.05f; ;
                CalculateForces();


            }
            else
            {
                forcesX[1] = Constant.zeroForce;
                CalculateForces();
            }
            CalculateAcceleration();
            CalculateSpeed();
            СalculateВisplacement();
        }
    }
}

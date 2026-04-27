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
       
        public Ball(TypeBall typeBall, Point center)
        {
            _typeBall = typeBall;
            this.center = center;
            this.SpeedX = 0;
            this.SpeedY = 0;
            this.maxSpeed = Constant.sizeBall * 3 / (float)typeBall;
            forcesY[1] = Constant.gravityForce(typeBall);
            Acc = new float[3];
        }

        

        
        public void Update()
        {
            CalculateAcceleration();
            CalculateSpeed();
            СalculateВisplacement();
            
        }

        

        
    }

   
}

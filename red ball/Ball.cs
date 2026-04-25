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
            forcesY[1] = Constant.gravityForce(typeBall);
        }

        

        
        public void Update()
        {
            CalculateAcceleration();
            CalculateSpeed();
            СalculateВisplacement();
            
        }

        

        
    }

   
}

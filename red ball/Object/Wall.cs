using red_ball.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace red_ball.Object
{
    public class Wall : LevelObject
    {
        public Wall(Ball ball, float x, float y, float width, float height, Form form) : base(ball, x, y, width, height, form)
        {
            this.Ball = ball;
            this.Ball = ball;
            startX = x;
            startY = y + ball.minY;
            this.width = width;
            this.height = height;
            this.form = form;
        }

        public bool BallPositionY()
        {
            if (Ball.center.Y + Ball.size + 12 > CurY  && Ball.center.X >= CurX && Ball.center.X <= CurX+width ) 
                return true;
            return false;
        }
        public bool BallPositionRightX()
        {
            if ( Ball.center.X + Ball.size >=  CurX + width  )
                return true;
            return false;
        }

        public bool BallPositionLeftX()
        {
            if (Ball.center.X + Ball.size <= CurX )
                return true;
            return false;
        }



        public override void ChangeStateBall()
        {
            if (BallPositionY())
            {
                Ball.forcesY[1] = Constant.zeroForce ;
                Ball.ChangeState(StateBall.OnFloor);
            }
            else
            {
                Ball.ChangeState(StateBall.InFall);
            }

            if (BallPositionRightX())
            {
                Ball.allowMinX = CurX ;
            }

            if (BallPositionLeftX())
            {
                Ball.allowMaxX = CurX + width;
            }

            
        }
    }
}

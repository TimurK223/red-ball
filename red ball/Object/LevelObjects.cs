using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace red_ball.Object
{
    class LevelObject
    {
<<<<<<< Updated upstream
        
=======
        public float startX;
        public float startY;
        public float width;
        public float height;
        public Ball Ball { get; set; }
        public float CurX { get { return startX - Ball.center.X + Ball.size; } }
        public float CurY { get { return startY - Ball.center.Y - Ball.size; } }

        public Form form; 
        public LevelObject(Ball ball, float x, float y, float width, float height, Form form)
        {
            this.Ball = ball;
            startX = x;
            startY = y + ball.minY;
            this.width = width;
            this.height = height;
            this.form = form;
        }

        public bool MustBeDrawn()
        {
            var visibleRangeX = form.ClientSize.Width + 200; 
            var visibleRangeY = form.ClientSize.Height + 200;
            var leftX = Math.Abs(CurX) < visibleRangeX ;
            var rightX = Math.Abs(CurX + width)  < visibleRangeX ;
            var topY = Math.Abs(CurY) < visibleRangeY ;
            var bottomY = Math.Abs(CurY + height) < visibleRangeY ;
            return (leftX || rightX) && (topY || bottomY);
        }

        public virtual void Draw(ref float x, ref float y, ref float w, ref float h)
        {
            x = CurX;
            y = CurY;
            w = width;
            h = height;
        }

        public virtual void ChangeStateBall() { }

        public virtual bool BallPosition()
        {
            throw new NotImplementedException();
        }
>>>>>>> Stashed changes
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace red_ball
{
    public class Ball
    {   
        private static Dictionary<Keys, Action<Ball>> MoveDirection = new Dictionary<Keys, Action<Ball>>() { 
            {Keys.A, (b) => b.forcesX[0] = new Force(1, new Vector( new Point(0, 0), new Point(-Constant.sizeBall/2, 0)))},
            {Keys.D, (b) => b.forcesX[0] = new Force(1, new Vector( new Point(0, 0), new Point(Constant.sizeBall/2, 0)))},
            {Keys.Space, (b) => b.forcesY[1] = new Force(1, new Vector( new Point(0,0), new Point(0, -Constant.sizeBall/2))) }
        };
        private static Dictionary<Keys, Action<Ball>> NotMoveDirection = new Dictionary<Keys, Action<Ball>>() {
            {Keys.A, (b) => b.forcesX[0] = Constant.zeroForce},
            {Keys.D, (b) => b.forcesX[0] = Constant.zeroForce },
            {Keys.Space, (b) => b.forcesY[1] = Constant.zeroForce }
        }; 
        private TypeBall _typeBall {  get; set; }
        private Force[] forcesX = new Force[2] { Constant.zeroForce, Constant.zeroForce };
        private Force[] forcesY = new Force[2] {Constant.zeroForce, Constant.zeroForce};
        public int size = Constant.sizeBall;
        public Point center;
        private float speedX;
        private float speedY;
        float[] acc = new float[2];
        private float maxSpeed;
        public Graphics g;
        

        public Ball(TypeBall typeBall, int size, Point center)
        {
            _typeBall = typeBall;
            this.size = size;
            this.center = center;
            this.speedX = 0;
            this.speedY = 0;
            this.maxSpeed = 0;
            //forcesY[0] = new Force((float)_typeBall, new Vector()
        }

        public void PaintBall() // вынести 
        {
            float x = center.X - size;
            float y = center.Y - size;
            float width = 2 * size;
            float height = 2 * size;
            var pen = new Pen(Color.Black, 3);
            g.DrawEllipse(pen, x, y, width, height);
            g.FillEllipse(Brushes.Red, x, y, width, height);
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
                forcesX = new Force[2] { Constant.zeroForce, Constant.zeroForce };
                forcesY = new Force[2] { Constant.zeroForce, Constant.zeroForce };
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
        public void Move() // переработать 
        {
            PaintBall();
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

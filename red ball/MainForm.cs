using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace red_ball
{
    public partial class MainForm : Form
    {
        Ball ball;
        private Pen pen = new Pen(Color.Black, 3); 
        private Brush brush = Brushes.Red;

        public MainForm()
        {
            InitializeComponent();
            
            ball = new Ball(
                TypeBall.Base,
                new Point(0, 500)
            );
            levelObjects = new LevelObject[] { new Wall(ball, 0,1000,1000,1000,this) };
            var timer = new Timer();
            timer.Interval = 1;
            timer.Tick += FormPaint;
            KeyDown += Movee;
            KeyUp += StopMovee;
            timer.Start();

        }


        private void Movee(object ? sender, KeyEventArgs e)
        {
            ball.AddForce(e);
        }

        private void StopMovee(object? sender, KeyEventArgs e)
        {
            ball.DeleteForce(e);
        }

        private void FormPaint(object ? sender, EventArgs e) 
        {
            ball.CalculateForces();
            ball.Update();
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            float x = 0, y = 0, w = 0, h = 0;
            CalculateCenterPointBall(ref x, ref y, ref w, ref h);

            g.DrawEllipse(pen, x, y, w, h);
            g.FillEllipse(brush, x, y, w, h);

            foreach ( var obj  in levelObjects )
            {
                if (obj.MustBeDrawn())
                {
                    obj.Draw(ref objX, ref objY, ref objW, ref objH);
                    g.DrawRectangle(pen, objX, objY, objW, objH);
                    obj.ChangeStateBall();
                }
                if (ball.GetState() != StateBall.OnFloor)
                    ball.forcesY[1] = Constant.gravityForce(ball._typeBall);

            
            }
        }


        private void CalculateCenterPointBall(ref float x, ref float y, ref float w, ref float h) // метод для расчета центра круга так, чтобы он был вписан в квадрат
        {
            x = this.ball.center.X - this.ball.size;
            y = this.ball.center.Y - this.ball.size;
            w = 2 * this.ball.size;
            h = 2 * this.ball.size;
        }
    }
}
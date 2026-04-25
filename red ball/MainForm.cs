using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace red_ball
{
    public partial class MainForm : Form
    {
        Ball ball;

        public MainForm()
        {
            InitializeComponent();
            
            ball = new Ball(
                TypeBall.Base,
                50,
                new Point(500, 500)
            );

            var timer = new Timer();
            timer.Interval = 20;
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
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e) // Главный метод открисовки
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            using (Pen pen = new Pen(Color.Black, 3))
            {
                float x = 0, y = 0, w = 0, h = 0;
                CalculateCenterPointBall(ref x, ref y, ref w, ref h);

                g.DrawEllipse(pen, x, y, w, h);
                g.FillEllipse(Brushes.Red, x, y, w, h);
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
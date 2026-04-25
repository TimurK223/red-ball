using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace red_ball
{
    public partial class Form1 : Form
    {
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


        private void CalculateCenterPointBall(ref float x, ref float y, ref float w,ref float h) // метод для расчета центра круга так, чтобы он был вписан в квадрат
        {
            x = this.ball.center.X - this.ball.size;
            y = this.ball.center.Y - this.ball.size;
            w = 2 * this.ball.size;
            h = 2 * this.ball.size;
        }
    }
}

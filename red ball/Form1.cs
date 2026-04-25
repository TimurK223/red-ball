using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace red_ball
{
    public partial class Form1 : Form
    {
        Ball ball;
        Timer timer;

        public Form1()
        {
            InitializeComponent();
            
            ball = new Ball(
                TypeBall.Base,
                50,
                new Point(500, 500)
            );

            var timer = new Timer();
            timer.Interval = 20;
            timer.Tick += Paint;
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

        private void Paint(object ? sender, EventArgs e) 
        {
            Invalidate();
        }


    }
}
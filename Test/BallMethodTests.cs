using red_ball;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class BallMethodTests
    {

        [Test]
        public void BallChangedState()
        {

            var ball = new Ball(TypeBall.Base, 20, new Point(0, 0));
            ball.ChangeState(StateBall.OnFloor);
            var stateBool = ball.GetState() == StateBall.OnFloor;

            Assert.AreEqual(true, stateBool);
        }



        [Test]
        public void BallOnFloor()
        {
            var startPoint = new Point(500, 500);
            var ball = new Ball(TypeBall.Base, 20, new Point(500, 500));
            ball.ChangeState(StateBall.OnFloor);
            ball.Jump();
            ball.Update();
            var t = startPoint != ball.center;

            Assert.AreEqual(true, t);
        }

        [Test]
        public void BallInFall()
        {
            var startPoint = new Point(500, 500);
            var ball = new Ball(TypeBall.Base, 20, new Point(500, 500));
            ball.ChangeState(StateBall.InFall);
            ball.Jump();
            ball.Update();
            var t = startPoint == ball.center;

            Assert.AreEqual(true, t);
        }
    }

}


using red_ball;
using System.Reflection.Metadata;
using System.Windows.Forms;

namespace Test
{
    [TestFixture]
    public class PhysicsTests
    {
        
        //[Test]
        //public void MethodIsZeroForce()
        //{
        //    var force = new Force(1, new Vector((0, 0), (0, 0)));
        //    Assert.AreEqual(true, force.IsZeroForce()); 
        //}

        [Test]
        public void DifferentTypeBall()
        {

            var b1 = new Ball(TypeBall.Base, new Point(500, 500));
            var b2 = new Ball(TypeBall.Stone, new Point(500, 500));
            b2.Move(TypeForce.MoveForward);
            b1.Move(TypeForce.MoveForward);
            b2.Update();
            b1.Update();
            Assert.AreEqual(true, b1.center.X >  b2.center.X);
        }

        [Test]
        public void DifferentDirection()
        {
            var b1 = new Ball(TypeBall.Base, new Point(0, 500));
            var b2 = new Ball(TypeBall.Base, new Point(0, 500));
            b2.Move(TypeForce.MoveForward);
            b1.Move(TypeForce.MoveBackward);
            b2.Update();
            b1.Update();
            Assert.AreEqual(true, b1.center.X == -b2.center.X);
        }

        [TestCase(TypeForce.MoveForward, 3, 0) ]
        public void AccCalculateAccelerationTest(TypeForce typeForce, int result, int cell)
        {
            
            var b = new Ball(TypeBall.Base, new Point(0, 500));
            b.minY = 500;
            b.Move(TypeForce.MoveForward);
            b.Update();
            Assert.AreEqual(result, (int)b.Acc[cell]);
        }

        [TestCase(TypeForce.MoveForward, 3, 0,1)]
        [TestCase(TypeForce.MoveForward, 6, 0, 2)]
        public void CalculateSpeedXTest(TypeForce typeForce, int result, int cell, int time)
        {
            var b = new Ball(TypeBall.Base, new Point(0, 500));
            b.minY = 500;
            b.Move(TypeForce.MoveForward);
            for (var i = 0; i < time; i++)
            {
                b.CalculateForces();
                b.Update();
            }
            Assert.AreEqual(result, b.SpeedX);
        }

        [TestCase(TypeForce.Gravity, 10, 0, 1)]
        [TestCase(TypeForce.Gravity, 20, 0, 2)]
        public void CalculateSpeedYTest(TypeForce typeForce, int result, int cell, int time)
        {
            var b = new Ball(TypeBall.Base, new Point(0, 100));
            b.minY = 500;
            if (typeForce == TypeForce.Jump)
                b.Jump();
            for (var i = 0; i < time; i++)
            {
                b.CalculateForces();
                b.Update();
            }
            Assert.AreEqual(result, b.SpeedY);
        }




    }
}
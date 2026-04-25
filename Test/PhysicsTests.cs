
using red_ball;
using System.Windows.Forms;

namespace Test
{
    [TestFixture]
    public class PhysicsTests
    {
        [Test]
        public void MethodIsZeroForce()
        {
            var force = new Force(1, new Vector((0, 0), (0, 0)));
            Assert.AreEqual(true, force.IsZeroForce()); 
        }

        [Test]
        public void DifferentTypeBall()
        {

            var b1 = new Ball(TypeBall.Base, new Point(500, 500));
            var b2 = new Ball(TypeBall.Stone, new Point(500, 500));
            b2.Move(DirectionMovement.Forward);
            b1.Move(DirectionMovement.Forward);
            b2.Update();
            b1.Update();
            Assert.AreEqual(true, b1.center.X >  b2.center.X);
        }

        [Test]
        public void DifferentDirection()
        {
            var b1 = new Ball(TypeBall.Base, new Point(0, 500));
            var b2 = new Ball(TypeBall.Base, new Point(0, 500));
            b2.Move(DirectionMovement.Forward);
            b1.Move(DirectionMovement.Backward);
            b2.Update();
            b1.Update();
            Assert.AreEqual(true, b1.center.X == -b2.center.X);
        }

    }
}
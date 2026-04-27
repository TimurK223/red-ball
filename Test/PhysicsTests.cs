
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

        [TestCase(TypeForce.MoveForward, 1, 0) ]
        public void AccCalculateAccelerationTest(TypeForce typeForce, int result, int cell)
        {
            
            var b = new Ball(TypeBall.Base, new Point(0, 500));
            b.minY = 500;
            b.Move(TypeForce.MoveForward);
            b.Update();
            Assert.AreEqual(result, (int)b.Acc[cell].scalar);
        }

        [TestCase(TypeForce.MoveForward, 1, 0)]
        public void CalculateSpeedTest(TypeForce typeForce, int result, int cell)
        {
            var b = new Ball(TypeBall.Base, new Point(0, 500));
            b.minY = 500;
            b.Move(TypeForce.MoveForward);
            b.Update();
            Assert.AreEqual(result, b.SpeedX);
        }


        public static IEnumerable<Force[]> GetTestData()
        {
            yield return new Force[] { red_ball.Constant.zeroForce, new Force(1, new Vector((0,0), (1,1)), TypeForce.MoveForward)};
           
        }

        //[Test]
        //[TestCaseSource(nameof(GetTestData))]
        //public void ForcePlusForce(IEnumerable<Force> forces, int res)
        //{
        //    foreach (var f in forces)
        //    {

        //    }
        //}

        //[TestCase(new Force(1, new Vector((0,0), (0,0)), TypeForce.None), (Force) (new Force(1, new Vector((0, 0), (0, 0)), TypeForce.None)), 1)]
        //public void ForcePlusForce(Force f1, Force f2, int ResTime)
        //{
        //    var newF = f1 + f2;
        //    Assert.AreEqual(ResTime, newF.Time);
        //}

    }
}

using red_ball;

namespace Test
{
    public class Tests
    {
        [Test]
        public void MethodIsZeroForce()
        {
            var force = new Force(1, new Vector((0, 0), (0, 0)));
            Assert.AreEqual(true, force.IsZeroForce()); 
        }
    }
}
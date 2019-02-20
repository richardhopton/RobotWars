using NUnit.Framework;

namespace RobotWars.Tests.Helpers
{
    [TestFixture]
    public abstract class ContextSpecification
    {
        [SetUp]
        public void SetUp()
        {
            Establish();
            Because();
        }

        protected abstract void Establish();
        protected abstract void Because(); 
        
        [TearDown]
        public virtual void TearDown()
        {
        }

    }
}
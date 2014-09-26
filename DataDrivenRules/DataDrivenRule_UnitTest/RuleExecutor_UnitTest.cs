using DataDrivenRules;
using NUnit.Framework;

namespace DataDrivenRule_UnitTest
{
    [TestFixture]
    public class RuleExecutor_UnitTest
    {
        private RuleExecutor _executor;
       
        private void Setup()
        {
                _executor = new RuleExecutor();
        }

        [Test]
        public void RuleExecutor_PassClassAndMethodNamesAsString_CallsCorrectMethod()
        {
            Setup();
            _executor.Execute("DataDrivenRules", "SomeClass", "MethodA");
            Assert.AreEqual("MethodA", _executor.returnValue.ToString());
        }

        [Test]
        public void RuleExecutor_PassClassInstanceAndMethodNameAsString_CallsCorrectMethod()
        {
            Setup();
            var someClass = new SomeClass();
            _executor.Execute(someClass, "MethodA");
            Assert.AreEqual("MethodA", _executor.returnValue.ToString());
        }
    }
}

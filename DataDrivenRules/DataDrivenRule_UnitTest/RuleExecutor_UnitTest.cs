using System.Collections.Generic;
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

        [Test]
        public void RuleExecutor_PassClassInstanceAndMethodNameAsStringWithOneParameter_CallsCorrectMethod()
        {
            Setup();
            var someClass = new SomeClass();
            _executor.Execute(someClass, "MethodA");
            Assert.AreEqual("MethodA", _executor.returnValue.ToString());
        }

        [Test]
        public void Monkey()
        {
            Setup();
            var parameters = new Dictionary<string, object>();
            parameters.Add("count", 2);
            var someClass = new SomeClass();
            _executor.Execute(someClass, "MethodC", parameters);
            Assert.AreEqual("MethodC 2", _executor.returnValue.ToString());
        }

    }
}

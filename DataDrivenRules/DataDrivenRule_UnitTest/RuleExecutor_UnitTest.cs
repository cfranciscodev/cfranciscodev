using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void Monkey()
        {
            Setup();
            _executor.Execute("DataDrivenRules", "RuleExecutor", "MethodA");

            Assert.AreEqual("MethodA", _executor.returnValue.ToString());
        }
    }
}

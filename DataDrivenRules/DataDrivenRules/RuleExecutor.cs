using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DataDrivenRules
{
    public class RuleExecutor
    {
        public object returnValue;

        public void Execute(string nameSpace, string className, string methodName)
        {
            var classType = Type.GetType(nameSpace + "." + className);
            var contructInfo = classType.GetConstructor(Type.EmptyTypes);
            var classInstance = contructInfo.Invoke(new object[] { });

            var methodInfo = classType.GetMethod(methodName);
            returnValue = methodInfo.Invoke(classInstance, new object[] { });

        }

        public string MethodA()
        {
            return "MethodA";
        }

        public string MethodB()
        {
            return "MethodB";
        }
    }
}

using System;
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

        public void Execute(object classInstance, string methodName)
        {
            var classType = classInstance.GetType();
            var magicMethod = classType.GetMethod(methodName);
            returnValue = magicMethod.Invoke(classInstance, new object[] { });
        }


    }
}

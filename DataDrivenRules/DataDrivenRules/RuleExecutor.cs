using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            var methodInfo = classType.GetMethod(methodName);
            var parameters = methodInfo.GetParameters();
            foreach (ParameterInfo param in parameters)
            {
                Debug.WriteLine(param.Name + " is a " + param.ParameterType);
            }
            returnValue = methodInfo.Invoke(classInstance, new object[] { });
        }

        public void Execute(object classInstance, string methodName, Dictionary<string, Object> parameterDictionary)
        {
            var classType = classInstance.GetType();
            var methodInfo = classType.GetMethod(methodName);
            var methodParamInfo = methodInfo.GetParameters();
                
            var parametersToPass = new object[methodParamInfo.Count()];
            int loopCount = 0;
            foreach (var param in methodParamInfo)
            {
                parametersToPass[loopCount] = parameterDictionary[param.Name];
                loopCount += 1;
                Debug.WriteLine(param.Name + " is a " + param.ParameterType);
            }
            returnValue = methodInfo.Invoke(classInstance, parametersToPass);

        }

    }
}

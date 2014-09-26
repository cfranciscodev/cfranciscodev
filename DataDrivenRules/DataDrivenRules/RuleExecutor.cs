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
        public string calledMethod = string.Empty;

        public void Execute(string Class, string methodName)
        {
            Type objectExecutor = Type.GetType(Class);
            ConstructorInfo magicConstructor = objectExecutor.GetConstructor(Type.EmptyTypes);
            object magicClassObject = magicConstructor.Invoke(new object[] { });

            // Get the ItsMagic method and invoke with a parameter value of 100

            MethodInfo magicMethod = objectExecutor.GetMethod(methodName);
            object magicValue = magicMethod.Invoke(magicClassObject, new object[] { });

        }

        public void MethodA()
        {
            calledMethod = "MethodA";
        }

        public void MethodB()
        {
            calledMethod = "MethodB";
        }
    }
}

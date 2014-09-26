namespace DataDrivenRules
{
    public class SomeClass
    {
        public string MethodA()
        {
            return "MethodA";
        }

        public string MethodB()
        {
            return "MethodB";
        }

        public string MethodC(int count)
        {
            //, string foo, double blah, string grib
            return "MethodC " + count.ToString();
        }
    }
}

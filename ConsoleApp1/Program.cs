namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new TestClass();
            var testing = TestClass.SerializeXml(test.GetRoutingConfiguration());
        }
    }
}

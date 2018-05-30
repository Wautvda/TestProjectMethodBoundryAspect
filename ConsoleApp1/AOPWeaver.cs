using System;
using MethodBoundaryAspect.Fody.Attributes;

namespace ConsoleApp1
{
    public class AOPWeaver : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs arg)
        {
            Console.WriteLine("OnEntry");
        }

        public override void OnExit(MethodExecutionArgs arg)
        {
            Console.WriteLine("OnExit");
        }
    }
}

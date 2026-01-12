using System;
using System.Reflection;

namespace Off
{
    class Program 
    {
        static void Main()
        {
            Assembly assem = Assembly.GetExecutingAssembly();
            AssemblyName assemName = assem.GetName();
            Console.WriteLine("  Shouldn't be something here: {0}", assemName.Flags & AssemblyNameFlags.EnableJITcompileOptimizer);
        }
    }
}
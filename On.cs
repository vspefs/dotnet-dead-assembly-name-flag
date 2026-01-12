using System;
using System.Reflection;

[assembly: AssemblyFlags(AssemblyNameFlags.EnableJITcompileOptimizer)]

namespace On
{
    class Program 
    {
        static void Main()
        {
            Assembly assem = Assembly.GetExecutingAssembly();
            AssemblyName assemName = assem.GetName();
            Console.WriteLine("  Should be something here: {0}", assemName.Flags & AssemblyNameFlags.EnableJITcompileOptimizer);
        }
    }
}
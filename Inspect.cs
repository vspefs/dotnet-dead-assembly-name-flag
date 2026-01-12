using System;
using System.Reflection;

namespace Inspect
{
    class Program 
    {
        static bool InspectAssembly(string relativePath)
        {
            string path = System.IO.Path.GetFullPath(relativePath);
            Assembly assem = Assembly.LoadFile(path);
            AssemblyName assemName = assem.GetName();
            return (assemName.Flags & AssemblyNameFlags.EnableJITcompileOptimizer) != 0;
        }

        static void Main()
        {
            Console.WriteLine("  Rolsyn:");
            Console.WriteLine("    Should be something here: {0}", InspectAssembly("On.exe"));
            Console.WriteLine("    Shouldn't be something here: {0}", InspectAssembly("Off.exe"));
            Console.WriteLine("  IL:");
            Console.WriteLine("    Should be something here: {0}", InspectAssembly("On.il.exe"));
            Console.WriteLine("    Shouldn't be something here: {0}", InspectAssembly("Off.il.exe"));
        }
    }
}
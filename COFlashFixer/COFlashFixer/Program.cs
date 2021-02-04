using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace COFlashFixer
{
    class Program
    {
        static void Main(string[] args)
        {
            string ConquerExePath = Path.Combine(Directory.GetCurrentDirectory(), "Conquer.exe");
            string DllPath = Path.Combine(Directory.GetCurrentDirectory(), "COFlashFixer_DLL.dll");
            if (args.Length > 0)
            {
                ConquerExePath = args[0];
                DllPath = args[1];
            } else
            {
                Console.WriteLine("Specify Path of Conquer.exe (First Parameter) [Detected: {0}]", ConquerExePath);
                Console.WriteLine("Specify Path of Dll Fixer (Second Parameter) [Detected: {0}]", DllPath);
                Console.WriteLine("Is Valid? [Y/N]");
                string YN = Console.ReadLine().ToUpper();
                if (YN == "Y")
                {

                } else
                {
                    Console.WriteLine("Please run with the valid parameters.");
                }
            }
            Process p = Process.Start(ConquerExePath, "blacknull");
            if (!Injector.StartInjection(DllPath, (uint)p.Id))
            {
                Console.WriteLine("Error on injection. Path is valid?");
                Console.ReadKey();
            }
        }
    }
}

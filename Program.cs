using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Lab5console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = args[0], ks = "";

            foreach (Process process in Process.GetProcesses())
            {
                if (process.Id == int.Parse(s))
                {
                    IntPtr startOffset = process.MainModule.BaseAddress;
                    IntPtr endOffset = IntPtr.Add(startOffset, process.MainModule.ModuleMemorySize);

                    long s1 = (long)startOffset;
                    long e1 = (long)endOffset;

                    ProcessThreadCollection processThreads = process.Threads;
                    ks += "Current address: 0x" + Convert.ToString((long)processThreads[0].StartAddress, 16) + "\n";
                    ks += "Start address: 0x" + Convert.ToString(s1, 16) + "\n";
                    ks += "Size: 0x" + Convert.ToString((long)process.MainModule.ModuleMemorySize, 16) + "\n";
                    ks += "End adress: 0x" + Convert.ToString(e1, 16) + "\n";
                    Console.WriteLine(ks);
                    Console.ReadLine();
                }
            }
        }
    }
}

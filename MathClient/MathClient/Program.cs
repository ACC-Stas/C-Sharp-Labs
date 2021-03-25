using System;
using System.Runtime.InteropServices;

namespace MathClient {
    class Program {
        [DllImport("../../../../MathLibrary/Debug/MathLibrary.dll", CallingConvention = CallingConvention.StdCall)]
        static extern int Sum(int a, int b);
        static void Main(string[] args) {
            Console.WriteLine(Sum(5, 6));
        }
    }
}

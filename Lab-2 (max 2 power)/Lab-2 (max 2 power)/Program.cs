using System;

namespace Max2Power {
    class Program {
        static void Main() {
            ulong a = 1, b = 0;
            bool correctInput;
            do {
                correctInput = true;
                try {
                    Console.Write("Enter number a: ");
                    a = Convert.ToUInt64(Console.ReadLine());
                    Console.Write("Enter number b: ");
                    b = Convert.ToUInt64(Console.ReadLine());
                    if (b < a) {
                        Console.WriteLine("b must be bigger than a");
                        correctInput = false;
                    }
                }
                catch (FormatException ex) {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("It is not a number");
                    correctInput = false;
                } catch(OverflowException ex) {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Incorrect number");
                    correctInput = false;
                }
            } while (!correctInput);
            ulong right2Pow = 0, left2Pow = 0, max2Pow = 0;
            for(int i = 1; i < 64; i++) {
                if(a != 0) {
                    left2Pow += Number2Pow(a - 1, i);
                }
                right2Pow += Number2Pow(b, i);
            }
            max2Pow = right2Pow - left2Pow;
            Console.WriteLine($"Max power of 2 is {max2Pow}");
        }
        /// <summary>
        /// Calculate number that refers to amount of elements in 1*....*value, 
        /// that can be divided by 2 int some power
        /// </summary>
        /// <param name="value"></param>
        /// <param name="powOf2"></param>
        /// <returns></returns>
        static ulong Number2Pow(ulong value, int powOf2) {
            ulong amount = 0;
            ulong divider = 1;
            for(int i = 1; i <= powOf2; i++) {
                divider *= 2;
            }
            if(value % divider == 0 && value != 0) {
                value -= 1;
                amount++;
            }
            if(value != 0) {
                amount += (value - 1) / divider;
            }
            return amount;
        }
    }
}

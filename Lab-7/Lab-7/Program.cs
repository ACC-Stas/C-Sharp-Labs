using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_7 {
    class Program {
        static void Main(string[] args) {
            List<Fraction> fractions = new List<Fraction>() { //Creating fractions with different constructor types
                new Fraction(0.25),
                new Fraction(2),
                new Fraction(2, 4)
            };
            fractions = fractions.Concat(new List<Fraction>() { //Parsing from different string formats
                Fraction.Parse("1/3"),
                Fraction.Parse("3"),
                Fraction.Parse("-2(1/4)"),
                Fraction.Parse("-0.75")
            }).ToList();
            Console.WriteLine("Testing TryParse");
            Fraction testing;
            Console.WriteLine(Fraction.TryParse("Not a fraction", out testing));
            Console.WriteLine(Fraction.TryParse("27/54", out testing));
            Console.WriteLine(Fraction.TryParse("2(2/4)", out testing));
            Console.WriteLine(testing);
            fractions = fractions.Concat(new List<Fraction>() { //Math operations
                new Fraction(3, 4) + new Fraction(2, 3),
                new Fraction(5, 6) - new Fraction(1, 6),
                new Fraction(1, 9) * new Fraction(9, 4),
                new Fraction(2, 3) / new Fraction(3, 2),
            }).ToList();
            fractions.Add(new Fraction(7, 8).Clone() as Fraction); //Cloning fraction

            Console.WriteLine("Comparison operators");
            Console.WriteLine(new Fraction(3, 4) > new Fraction(2, 3));
            Console.WriteLine(new Fraction(5, 6) <= new Fraction(1, 6));
            Console.WriteLine(new Fraction(1, 2) == new Fraction(2, 4));
            Console.WriteLine(new Fraction(3, 4) != new Fraction(6, 8));

            Console.WriteLine("Converting to string in different formats and IFormattible implementation");
            testing = new Fraction(-5, 2);
            Console.WriteLine("{0:F}", testing);
            Console.WriteLine("{0:IF}", testing);
            Console.WriteLine("{0:I}", testing);
            Console.WriteLine("{0:D}", testing);
            Console.WriteLine("{0:D5}", testing);

            Console.WriteLine("Conversion operators and implementation of IConvertible");
            Console.WriteLine((int)testing);
            Console.WriteLine((double)testing);
            Console.WriteLine(Convert.ToBoolean(testing));
            Console.WriteLine(Convert.ToString(testing));

            Console.WriteLine("Sorting by using IComparable interface");
            fractions.Sort();
            foreach(var x in fractions) {
                Console.WriteLine(x);
            }

            Console.WriteLine("Division by zero exception");
            try {
                new Fraction(2, 0);
            }
            catch (ArgumentException ex) {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Trying to parse incorrect string exception");
            try {
                Fraction.Parse("Not a fraction");
            }
            catch (FormatException ex) {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Unsupported ToString() format exception");
            try {
                testing.ToString("Unsupported format");
            }
            catch (FormatException ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

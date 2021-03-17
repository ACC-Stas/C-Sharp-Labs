using System;

namespace Transport {
    class Program {
        static void Main(string[] args) {
            Car car = new Car(145, 4);
            Car car1 = new Car(1234, 6);
            Console.WriteLine(car.Move());
            Console.ReadKey();
            Console.WriteLine(car.Cost);
            Console.WriteLine(car.Number);
            Console.WriteLine(car1.Number);
            Console.WriteLine(car.Stop());
            Console.ReadKey();
        }
    }
}

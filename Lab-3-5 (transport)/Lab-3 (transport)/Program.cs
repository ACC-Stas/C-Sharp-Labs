using System;

namespace Transport {
    class Program {
        static void Main(string[] args) {
            Car car = new Car(145, 4);
            Car car1 = new Car(1234, 6);
            Console.ReadKey();
            Console.WriteLine(car.Cost);
            Console.WriteLine(car.Number);
            Console.WriteLine(car1.Number);
            car1.Name = "Super car";
            Console.WriteLine(car1.Stop());
            Console.ReadKey();
            Car zhiga = new Zhigul(1, 15);
            Console.WriteLine(zhiga.Move());
            Console.ReadKey();
            Car car2 = new Icar(0, 100500);
            Console.WriteLine(car2.Move());
            Console.ReadKey();
            Car car4 = new CyberTruck(1000, 500);
            Console.WriteLine(car4.Stop());
            Console.ReadKey();
        }
    }
}

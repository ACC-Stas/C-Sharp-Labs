using System;

namespace Transport {
    class Program {
        static void Main(string[] args) {
            Car car = new Car(145, 4);
            Car car1 = new Car(1234, 6);
            Cars cars = new Cars();
            cars[car.Number] = car;
            cars[car1.Number] = car1;
            Console.WriteLine(cars[0].Move());
            Console.ReadKey();
            Console.WriteLine(car.Cost);
            Console.WriteLine(car.Number);
            Console.WriteLine(cars[0].Number);
            Console.WriteLine(car1.Number);
            Console.WriteLine(cars[1].Number);
            Console.WriteLine(cars[1].Name);
            car1.Name = "Super car";
            Console.WriteLine(cars[1].Name);
            Console.WriteLine(car1.Stop());
            Console.ReadKey();
        }
    }
}

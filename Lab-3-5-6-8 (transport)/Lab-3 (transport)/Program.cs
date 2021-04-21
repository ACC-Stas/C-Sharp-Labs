using System;

namespace Transport {
    class Program {
        static void Main(string[] args) {
            Car car = new Car(145, 4);
            Car car1 = new Car(1234, 6);
            Console.WriteLine(car.Cost);
            Console.WriteLine(car.Number);
            Console.WriteLine(car1.Number);
            car1.Name = "Super car";
            Zhigul zhiga = new Zhigul(1, 15);
            Car car2 = new AppleCar(0, 100500);
            Car car4 = new CyberTruck(1000, 500);
            Console.WriteLine(car4.CompareTo(car2));
            zhiga.Destroy();
            Console.WriteLine(zhiga.Condition);
            AppleCar appleCar = new AppleCar(0, 1010101);
            appleCar.MakeOlder(800);
            Console.WriteLine(appleCar.Relevant);
            IBreakable breakableCar = new Zhigul(10, 25);
            Console.WriteLine(breakableCar.Condition);
            breakableCar.Destroy();
            Console.WriteLine("Testing Exceptions in Cars");
            Car car3 = new Zhigul(15, 12);
            Cars superCars = new Cars();
            superCars[car3.Number] = car3;
            try {
                Console.WriteLine(superCars[25].Name);
            } catch (System.Collections.Generic.KeyNotFoundException ex) {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Testing Events in Car");
            CyberTruck car5 = new CyberTruck(42, 500);
            car5.MoveNotification += (output) => Console.WriteLine("Move event was called:" + output);
            car5.StopNotification += (output) => Console.WriteLine("Stop event was called:" + output);
            car5.Move();
            car5.Stop();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Media;

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
            Console.WriteLine(car.Stop());
            Console.ReadKey();
        }
    }
    abstract class Vehicle {
        private int loadLimit;
        public int LoadLimit {
            get {
                return loadLimit;
            }
            set {
                if (value < 0) {
                    throw new Exception("loadLimit is positive number\n");
                }
                loadLimit = value;
            }
        }
        private int cost;
        public int Cost {
            get {
                return cost;
            }
            set {
                if (value < 0) {
                    throw new Exception("cost is positive number\n");
                }
                cost = value;
            }
        }
        public Vehicle(int loadLimit = 0, int cost = 0) {
            LoadLimit = loadLimit;
            Cost = cost;
        }
        abstract public string Move();
        abstract public string Stop();
    }
    class Cars {
        int numberOfCars = 0;
        private List<Car> cars;
        public Cars() {
            cars = new List<Car>();
        }
        public Car this[int index] {
            get {
                if (index < 0 && index >= numberOfCars) {
                    throw new Exception("There is no car with such index\n");
                }
                return cars[index];
            }
            set {
                cars.Insert(value.Number, value);
                numberOfCars++;
            }
        }
    }

    class Car : Vehicle {
        static int numberOfCars = 0;
        public Car(int loadLimit = 0, int cost = 0) : base(loadLimit, cost) {
            if (numberOfCars == Int32.MaxValue) {
                throw new Exception("Too many cars\n");
            }
            Number = numberOfCars;
            numberOfCars++;
        }
        public int Number { get; private set; }
        public override string Move() {
            SoundPlayer movement = new SoundPlayer(@"..\..\CarSounds\Move.wav");
            movement.Play();
            return "Car is riding";
        }
        public override string Stop() {
            SoundPlayer stopping = new SoundPlayer(@"..\..\CarSounds\Stop.wav");
            stopping.Play();
            return "Car is stopped";
        }
    }
}

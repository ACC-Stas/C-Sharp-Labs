using System;
using System.Media;
using System.Collections;

namespace Transport {
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
                if(value < 0) {
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
    class Car : Vehicle {
        static int numberOfCars = 0;
        public Car(int loadLimit = 0, int cost = 0) : base(loadLimit, cost) {
            if(numberOfCars == Int32.MaxValue) {
                throw new Exception("Too many cars\n");
            }
            Number = numberOfCars;
            numberOfCars++;
        }
        public int Number { get; private set; }
        private ArrayList cars;

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

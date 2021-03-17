using System;
using System.Media;

namespace Transport {
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

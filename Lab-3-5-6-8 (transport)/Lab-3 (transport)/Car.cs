using System;
using System.Media;

namespace Transport {
    class Car : Vehicle, IComparable<Car> {
        protected static int numberOfCars = 0;

        public Car(int loadLimit = 0, int cost = 0) : base(loadLimit, cost) {
            if (numberOfCars == Int32.MaxValue) {
                throw new Exception("Too many cars\n");
            }
            Number = numberOfCars;
            numberOfCars++;
        }
        public int CompareTo(Car car) {
            if(Number > car.Number) {
                return 1;
            } else if(Number < car.Number) {
                return -1;
            }
            else {
                return 0;
            }
        }
        public string Name { get; set; } = "Unnamed";
        public int Number { get; private set; }
        public override void Move() {
            SoundPlayer movement = new SoundPlayer(@"..\..\CarSounds\Move.wav");
            movement.Play();
        }
        public override void Stop() {
            SoundPlayer stopping = new SoundPlayer(@"..\..\CarSounds\Stop.wav");
            stopping.Play();
        }
    }
}

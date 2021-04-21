using System;
using System.Media;

namespace Transport {
    sealed class Zhigul : Car, IBreakable {
        public Zhigul(int loadLimit = 0, int cost = 0) : base(loadLimit, cost) {
            Name = "ZHIGUL";
            Condition = "Can be used";
        }
        public string Condition { get; set; }
        public string Destroy() {
            Condition = "Useless";
            return $"\"{Name}\" Car {Number} is destroyed";
        }
        public string Repair() {
            Condition = "Can be used";
            return $"\"{Name}\" Car {Number} is repaired";
        }
        public override string Move() {
            SoundPlayer movement = new SoundPlayer(@"..\..\CarSounds\MoveZhigul.wav");
            movement.Play();
            return $"\"{Name}\" Car {Number} is riding";
        }
        public override string Stop() {
            SoundPlayer stopping = new SoundPlayer(@"..\..\CarSounds\StopZhigul.wav");
            stopping.Play();
            return $"\"{Name}\" Car {Number} is stopped";
        }
    }
}

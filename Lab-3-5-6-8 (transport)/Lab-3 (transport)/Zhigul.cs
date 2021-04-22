using System;
using System.Media;

namespace Transport {
    sealed class Zhigul : Car, IBreakable {
        public delegate void CarOutPut(string output);
        public event CarOutPut MoveNotification;
        public event CarOutPut StopNotification;
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
        public override void Move() {
            SoundPlayer movement = new SoundPlayer(@"..\..\CarSounds\MoveZhigul.wav");
            movement.Play();
            MoveNotification?.Invoke($"\"{Name}\" Car {Number} is riding");
        }
        public override void Stop() {
            SoundPlayer stopping = new SoundPlayer(@"..\..\CarSounds\StopZhigul.wav");
            stopping.Play();
            StopNotification?.Invoke($"\"{Name}\" Car {Number} is riding");
        }
    }
}

using System;
using System.Media;

namespace Transport {
    sealed class Icar : Car {
        public Icar(int loadLimit = 0, int cost = 0) : base(loadLimit, cost) {
            Name = "ICAR";
        }
        public override string Move() {
            SoundPlayer movement = new SoundPlayer(@"..\..\CarSounds\MoveIcar.wav");
            movement.Play();
            return $"\"{Name}\" Car {Number} is riding";
        }
        public override string Stop() {
            SoundPlayer stopping = new SoundPlayer(@"..\..\CarSounds\StopIcar.wav");
            stopping.Play();
            return $"\"{Name}\" Car {Number} is stopped";
        }
    }
}

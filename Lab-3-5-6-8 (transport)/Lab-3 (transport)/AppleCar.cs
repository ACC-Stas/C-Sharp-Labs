using System;
using System.Media;

namespace Transport {
    sealed class AppleCar : Car, IObsoleteable {
        public AppleCar(int loadLimit = 0, int cost = 0) : base(loadLimit, cost) {
            Name = "ICAR";
            Relevant = true;
        }
        private int timeLeft = 150;
        public bool Relevant { get; private set; }
        public void MakeOlder(uint seconds) {
            if(timeLeft > 0) {
                timeLeft -= Convert.ToInt32(seconds);
                if(timeLeft < 0) {
                    Relevant = false;
                }
            }
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

using System;
using System.Media;

namespace Transport {
    sealed class AppleCar : Car, IObsoleteable {
        public delegate void CarOutPut(string output);
        public event CarOutPut MoveNotification;
        public event CarOutPut StopNotification;
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
        public override void Move() {
            SoundPlayer movement = new SoundPlayer(@"..\..\CarSounds\MoveIcar.wav");
            movement.Play();
            MoveNotification?.Invoke($"\"{Name}\" Car {Number} is riding");
        }
        public override void Stop() {
            SoundPlayer stopping = new SoundPlayer(@"..\..\CarSounds\StopIcar.wav");
            stopping.Play();
            StopNotification?.Invoke($"\"{Name}\" Car {Number} is riding");
        }
    }
}

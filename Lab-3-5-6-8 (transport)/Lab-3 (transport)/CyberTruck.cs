using System.Media;

namespace Transport {
    sealed class CyberTruck : Car {
        public delegate void CarOutPut(string output);
        public event CarOutPut MoveNotification;
        public event CarOutPut StopNotification;
        public CyberTruck(int loadLimit = 0, int cost = 0) : base(loadLimit, cost) {
            Name = "CYBERTRUCK";
        }
        public override void Move() {
            SoundPlayer movement = new SoundPlayer(@"..\..\CarSounds\MoveCyberTruck.wav");
            movement.Play();
            MoveNotification?.Invoke($"\"{Name}\" Car {Number} is riding");
        }
        public override void Stop() {
            SoundPlayer stopping = new SoundPlayer(@"..\..\CarSounds\StopCyberTruck.wav");
            stopping.Play();
            StopNotification?.Invoke($"\"{Name}\" Car {Number} is riding");
        }
    }
}

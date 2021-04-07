using System.Media;

namespace Transport {
    sealed class CyberTruck : Car {
        public CyberTruck(int loadLimit = 0, int cost = 0) : base(loadLimit, cost) {
            Name = "CYBERTRUCK";
        }
        public override string Move() {
            SoundPlayer movement = new SoundPlayer(@"..\..\CarSounds\MoveCyberTruck.wav");
            movement.Play();
            return $"\"{Name}\" Car {Number} is riding";
        }
        public override string Stop() {
            SoundPlayer stopping = new SoundPlayer(@"..\..\CarSounds\StopCyberTruck.wav");
            stopping.Play();
            return $"\"{Name}\" Car {Number} is stopped";
        }
    }
}

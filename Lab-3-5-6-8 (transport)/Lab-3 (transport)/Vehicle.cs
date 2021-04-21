using System;

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
                if (value < 0) {
                    throw new Exception("cost is positive number\n");
                }
                cost = value;
            }
        }
        public Vehicle(int loadLimit = 0, int cost = 0) {
            LoadLimit = loadLimit;
            Cost = cost;
        }
        abstract public void Move();
        abstract public void Stop();
    }
}

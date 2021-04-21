using System;
using System.Collections.Generic;

namespace Transport {
    class Cars {
        int numberOfVehicles = 0;
        private Dictionary<int, Car> cars;
        public Cars() {
            cars = new Dictionary<int, Car>();
        }
        public Car this[int index] {
            get {
                if (index < 0 && index >= numberOfVehicles) {
                    throw new IndexOutOfRangeException("There is no car with such number");
                }
                return cars[index];
            }
            set {
                if (index != value.Number) {
                    throw new IndexOutOfRangeException("Car can't be used with such number");
                }
                cars[value.Number] = value;
                numberOfVehicles++;
            }
        }
    }
}

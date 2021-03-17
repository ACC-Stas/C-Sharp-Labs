using System;
using System.Collections.Generic;

namespace Transport {
    class Cars {
        int numberOfCars = 0;
        private List<Car> cars;
        public Cars() {
            cars = new List<Car>();
        }
        public Car this[int index] {
            get {
                if (index < 0 && index >= numberOfCars) {
                    throw new Exception("There is no car with such index\n");
                }
                return cars[index];
            }
            set {
                cars.Insert(value.Number, value);
                numberOfCars++;
            }
        }
    }
}

using System;

namespace Lab2_GassLE_IP_61
{
    public class Car : Vehicle
    {
        private String carType;
        private String fuelType;
        private bool isWithTrailer;

        public Car(int price = 0, int maxSpeed = 0, int yearOfCarManufacture = 0, String carType = "", 
            String fuelType = "", bool isWithTrailer = false) : base(price, maxSpeed, yearOfCarManufacture)
        {
            this.carType = carType;
            this.fuelType = fuelType;
            this.isWithTrailer = isWithTrailer;
        }

        public Car(Car anotherCar)
        {
            price = anotherCar.price;
            yearOfCarManufacture = anotherCar.yearOfCarManufacture;
            maxSpeed = anotherCar.maxSpeed;
            isWithTrailer = anotherCar.isWithTrailer;
            carType = String.Copy(anotherCar.carType);
            fuelType = String.Copy(anotherCar.fuelType);
        }

        // Setting getters and setters for attributes
        public string CarType { get => carType; set => carType = value; }
        public string FuelType { get => fuelType; set => fuelType = value; }
        public bool IsWithTrailer { get => isWithTrailer; set => isWithTrailer = value; }

        public override string GetProperties()
        {
            String properties = "Type = [Car]\n" + CommonProperties() +
                "\tCar type = " + carType +
                "\n\tFuel type = " + fuelType +
                "\n\tIs with trailer = " + isWithTrailer + "\n";

            return properties;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) { throw new ArgumentNullException(); }
            if (obj.GetType() != typeof(Car)) { throw new MInvalidCastException("MInvalidCastException : Invalid cast exception!"); }
            Car car = (Car)obj;

            return (car.Price == this.price &&
                car.MaxSpeed == this.maxSpeed &&
                car.YearOfCarManufacture == this.yearOfCarManufacture &&
                car.CarType == this.carType &&
                car.FuelType == this.fuelType &&
                car.IsWithTrailer == this.isWithTrailer);
        }

        public static bool operator ==(Car car1, Car car2) { return car1.Equals(car2); }
        public static bool operator !=(Car car1, Car car2) { return !car1.Equals(car2); }

        public override int GetHashCode() { return price + maxSpeed + yearOfCarManufacture + carType.Length + fuelType.Length + (isWithTrailer == true ? 1 : 2); }
        public override object DeepCopy() { return new Car(this); }
    }

}

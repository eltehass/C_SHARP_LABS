using System;

namespace Lab2_GassLE_IP_61
{
    public class Lorry : Vehicle
    {
        private String engineType;
        private int numberOfWheels;

        public Lorry(int price = 0, int maxSpeed = 0, int yearOfCarManufacture = 0, 
            String engineType = "", int numberOfWheels = 0) : base(price, maxSpeed, yearOfCarManufacture)
        {
            this.engineType = engineType;
            this.numberOfWheels = numberOfWheels;
        }

        public Lorry(Lorry anotherLorry)
        {
            price = anotherLorry.price;
            yearOfCarManufacture = anotherLorry.yearOfCarManufacture;
            maxSpeed = anotherLorry.maxSpeed;
            numberOfWheels = anotherLorry.numberOfWheels;
            engineType = String.Copy(anotherLorry.engineType);
        }

        // Setting getters and setters for attributes
        public string EngineType { get => engineType; set => engineType = value; }
        public int NumberOfWheels { get => numberOfWheels; set => numberOfWheels = value; }

        public override string GetProperties()
        {
            String properties = "Type = [Lorry]\n" + CommonProperties() +
                "\tEngine type = " + engineType +
                "\n\tNumber of wheels = " + numberOfWheels + "\n";

            return properties;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) { throw new ArgumentNullException(); }
            if (obj.GetType() != typeof(Lorry)) { throw new MInvalidCastException("MInvalidCastException : Invalid cast exception!"); }
            Lorry lorry = (Lorry)obj;

            return (lorry.Price == this.price &&
                lorry.MaxSpeed == this.maxSpeed &&
                lorry.YearOfCarManufacture == this.yearOfCarManufacture &&
                lorry.EngineType == this.engineType &&
                lorry.NumberOfWheels == this.numberOfWheels);
        }

        public static bool operator ==(Lorry lorry1, Lorry lorry2) { return lorry1.Equals(lorry2); }
        public static bool operator !=(Lorry lorry1, Lorry lorry2) { return !lorry1.Equals(lorry2); }

        public override int GetHashCode() { return price + maxSpeed + yearOfCarManufacture + numberOfWheels + engineType.Length; }
        public override object DeepCopy() { return new Lorry(this); }
    }

}

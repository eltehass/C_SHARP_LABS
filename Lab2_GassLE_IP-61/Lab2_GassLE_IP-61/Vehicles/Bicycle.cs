using System;

namespace Lab2_GassLE_IP_61
{
    public class Bicycle : Vehicle
    {
        private String ramaType;
        private int wheelDiameter;

        public Bicycle(int price = 0, int maxSpeed = 0, int yearOfCarManufacture = 0, 
            String ramaType = "", int wheelDiameter = 0) : base(price, maxSpeed, yearOfCarManufacture)
        {
            this.ramaType = ramaType;
            this.wheelDiameter = wheelDiameter;
        }

        public Bicycle(Bicycle anotherBike)
        {
            price = anotherBike.price;
            yearOfCarManufacture = anotherBike.yearOfCarManufacture;
            maxSpeed = anotherBike.maxSpeed;
            wheelDiameter = anotherBike.wheelDiameter;
            ramaType = String.Copy(anotherBike.ramaType);
        }

        // Setting getters and setters for attributes
        public string RamaType { get => ramaType; set => ramaType = value; }
        public int WheelDiameter { get => wheelDiameter; set => wheelDiameter = value; }

        public override String GetProperties()
        {
            String properties = "Type = [Bicycle]\n" + CommonProperties() + 
                "\tRama type = " + ramaType +
                "\n\tWheel diameter = " + wheelDiameter + "\n";

            return properties;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) { throw new ArgumentNullException(); }
            if (obj.GetType() != typeof(Bicycle)) { throw new MInvalidCastException("MInvalidCastException : Invalid cast exception!"); }
            Bicycle bike = (Bicycle)obj;

            return (bike.Price == this.price &&
                bike.MaxSpeed == this.maxSpeed &&
                bike.YearOfCarManufacture == this.yearOfCarManufacture &&
                bike.RamaType == this.ramaType &&
                bike.WheelDiameter == this.wheelDiameter);
        }

        public static bool operator ==(Bicycle bike1, Bicycle bike2) { return bike1.Equals(bike2); }
        public static bool operator !=(Bicycle bike1, Bicycle bike2) { return !bike1.Equals(bike2); }

        public override int GetHashCode() { return price + maxSpeed + yearOfCarManufacture + wheelDiameter + ramaType.Length; }
        public override object DeepCopy() { return new Bicycle(this); }
    }

}

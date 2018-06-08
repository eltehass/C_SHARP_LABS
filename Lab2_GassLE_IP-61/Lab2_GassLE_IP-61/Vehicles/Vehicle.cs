using System;

namespace Lab2_GassLE_IP_61
{
    /**
     * An abstract class for describing vehicles with basic 
     * attributes and methods among which there is a general 
     * implementation, as well as abstract methods that 
     * the heirs need to implement in each class. 
     * For the convenience of work, the standard methods 
     * for each class were also overloaded such as Equals, ToString etc.
     * */
    public abstract class Vehicle
    {
        // standard attributes for any vehicle
        protected int price;
        protected int maxSpeed;
        protected int yearOfCarManufacture;

        // Setting getters and setters for attributes
        public int Price { get => price; set => price = value; }
        public int MaxSpeed { get => maxSpeed; set => maxSpeed = value; }
        public int YearOfCarManufacture { get => yearOfCarManufacture; set => yearOfCarManufacture = value; }

        // constructor with default values
        public Vehicle(int price = 0, int maxSpeed = 0, int yearOfCarManufacture = 0)
        {
            this.price = price;
            this.maxSpeed = maxSpeed;
            this.yearOfCarManufacture = yearOfCarManufacture;
        }

        // extracting the basic (general) characteristics of all transports
        protected String CommonProperties()
        {
            String properties = "\tPrice = " + price +
                    "\n\tMaxSpeed = " + maxSpeed +
                    "\n\tYearOfCarManufacture = " + yearOfCarManufacture + "\n";

            return properties;
        }

        /**
         * Overloaded method ToString for each class of the heir
         * which performs the method GetProperties of a 
         * particular implementation
         * */
        public override string ToString() { return GetProperties(); }

        /**
         * Creating an exact copy of this object
         * taking into account the reference attributes 
         **/
        public abstract object DeepCopy();

        // abstract method for getting properties for each class of the heir
        public abstract String GetProperties();

        /**
         * returning hashcode for each object
         * each successor class has its own implementation
         * */
        public abstract override int GetHashCode();// { return price + maxSpeed + yearOfCarManufacture; }

        public abstract override bool Equals(object obj);
        public static bool operator ==(Vehicle veh1, Vehicle veh2) { return veh1.Equals(veh2); }
        public static bool operator !=(Vehicle veh1, Vehicle veh2) { return !veh1.Equals(veh2); }

        //{
        //    if (obj.GetType() != typeof(Vehicle)) { return false; }
        //    Vehicle vehicle = (Vehicle)obj;

        //    return (vehicle.Price == this.price &&
        //        vehicle.MaxSpeed == this.maxSpeed &&
        //        vehicle.YearOfCarManufacture == this.yearOfCarManufacture);
        //}
    }

}

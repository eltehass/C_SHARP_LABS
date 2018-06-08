using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2_GassLE_IP_61
{
    /**
     * Class Garage, which is created to store and manage 
     * instances of the heirs of the Vehicle class. 
     * Internally, a WrapperList class object is stored, 
     * which represents a wrapper class for the 
     * List class with the response to the 
     * Add, Insert, and Update methods.
     * */
    class Garage
    {
        // list for all vehicles
        private WrapperList garageVehicles;

        public Garage() { garageVehicles = new WrapperList(); }
        public Garage(WrapperList list) { garageVehicles = (WrapperList) list.DeepCopy(); }

        // adding vehicle to garage
        public void AddVehicle(Vehicle vehicle) { garageVehicles.Add(vehicle); }

        // updating vehicle in the garage with a specific index
        public void UpdateVehicle(int index, Vehicle veh) { garageVehicles.UpdateAt(index, veh); }

        // getting vehicle from garage
        public Vehicle GetVehicle(int index) { return garageVehicles.GetAt(index); }

        // removing vehicle from garage
        public void RemoveAt(int index) { garageVehicles.RemoveAt(index); }

        // return count of vehicles in garage
        public int VehicleCount() { return garageVehicles.Size(); }

        /**
         * Creating an exact copy of this object
         * taking into account the reference attributes 
         **/
        public object DeepCopy() { return new Garage((WrapperList)garageVehicles.DeepCopy()); }

        /**
         * returning hashcode for each object
         * */
        public override int GetHashCode() { return garageVehicles.GetHashCode(); }

        /**
         * Makes checking two objects for equality. 
         * If both of them are garages, 
         * then the corresponding vehicles are checked.
         * */
        public override bool Equals(object obj)
        {
            if (obj == null) { throw new ArgumentNullException(); }
            if (obj.GetType() != typeof(Garage)) { throw new MInvalidCastException("MInvalidCastException : Invalid cast exception!"); }
            Garage garage = (Garage)obj;

            return (garage.garageVehicles.Equals(garageVehicles));
        }

        public static bool operator ==(Garage garage1, Garage garage2) { return garage1.Equals(garage2); }
        public static bool operator !=(Garage garage1, Garage garage2) { return !garage1.Equals(garage2); }

        public override string ToString() { return "Garage description: \n\n" + garageVehicles.ToString(); }
    }
}

using System;
using System.Collections.Generic;

namespace Lab2_GassLE_IP_61
{
    /**
     * Class WrapperList represents itself a wrapper class for a particular List class. 
     * It consists of the same methods, such as: Add, Remove and Update. 
     * When these methods are executed, events are triggered and alerts 
     * are received about changing the collection.
     * */
    class WrapperList
    {
        // list of our vehicles
        private List<Vehicle> vehicles;

        public delegate void MethodForHandlingEvents();

        //Events that store the methods inside themselves, to perform when calling themselves
        public event MethodForHandlingEvents OnAdd;
        public event MethodForHandlingEvents OnRemove;
        public event MethodForHandlingEvents OnUpdate;

        public WrapperList(List<Vehicle> vehs = null)
        {
            vehicles = (vehs != null) ? vehs : new List<Vehicle>(); 
            InitHandlers();
        }

        /**
         * Initialize listeners, where events are specified by 
         * methods for responding to adding, removing, or updating an item
         * */
        private void InitHandlers()
        {
            AbstractHandler handler1 = new AddElementHandler();
            AbstractHandler handler2 = new RemoveElementHandler();
            AbstractHandler handler3 = new UpdatedElementHandler();

            OnAdd += handler1.Message;
            OnRemove += handler2.Message;
            OnUpdate += handler3.Message;
        }

        // Add item
        public void Add(Vehicle vehicle)
        {
            OnAdd();
            vehicles.Add(vehicle);
        }

        // Remove item at some position
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= vehicles.Count) { throw new MIndexOutOfRangeException("IndexOutOfRangeException: Not right index!"); }

            OnRemove();
            vehicles.RemoveAt(index);
        }

        // Remove item
        public void RemoveVehicle(Vehicle vehicle)
        {
            foreach(Vehicle veh in vehicles)
            {
                if (veh.Equals(vehicle))
                {
                    vehicles.Remove(veh);
                    OnRemove();
                    return;
                }
            }
        }

        // Update item at some position
        public void UpdateAt(int index, Vehicle vehicle)
        {
            if (index < 0 || index >= vehicles.Count) { throw new MIndexOutOfRangeException("IndexOutOfRangeException: Not right index!"); }
            
            OnUpdate();
            vehicles[index] = vehicle;
        }

        // return size of the list of vehicles
        public int Size() { return vehicles.Count; }

        // return vehicle from some position in the list of vehicles
        public Vehicle GetAt(int index)
        {
            if (index < 0 || index >= vehicles.Count) { throw new MIndexOutOfRangeException("IndexOutOfRangeException: Not right index!"); }
            return vehicles[index];
        }

        /**
         * Creating an exact copy of this object
         * taking into account the reference attributes 
         **/
        public object DeepCopy()
        {
            List<Vehicle> newVehicles = new List<Vehicle>();
            for (int i = 0; i < Size(); i++)
            {
                Vehicle tmpVeh = (Vehicle) vehicles[i].DeepCopy();
                newVehicles.Add(tmpVeh);
            }

            return new WrapperList(newVehicles);
        }

        /**
        * returning hashcode
        * */
        public override int GetHashCode()
        {
            int hash = 0;
            foreach(Vehicle vehicle in vehicles) { hash += vehicle.GetHashCode(); }

            return hash;
        }

        /**
         * Makes checking two objects for equality
         * corresponding vehicles are checked for equals.
         * */
        public override bool Equals(object obj)
        {
            if (obj == null) { throw new ArgumentNullException(); }
            if (obj.GetType() != typeof(WrapperList)) { throw new MInvalidCastException("MInvalidCastException : Invalid cast exception!"); }
            WrapperList wrList = (WrapperList)obj;

            if (wrList.vehicles.Count != vehicles.Count) { return false; }

            for (int i = 0; i < vehicles.Count; i++)
            {
                if (!vehicles[i].Equals(wrList.vehicles[i])) { return false; }
            }

            return true;
        }

        public static bool operator ==(WrapperList list1, WrapperList list2) { return list1.Equals(list2); }
        public static bool operator !=(WrapperList list1, WrapperList list2) { return !list1.Equals(list2); }

        /**
         * returns a string consisting of a set of strings,
         * which is equal to the results of the same method 
         * of Vehicles objects
         * */
        public override string ToString()
        {
            String description = "";

            for (int i = 0; i < Size(); i++)
            {
                description += "----------------------------------\n" + vehicles[i].ToString() + "\n\n";
            }

            return description;
        }
    }
}

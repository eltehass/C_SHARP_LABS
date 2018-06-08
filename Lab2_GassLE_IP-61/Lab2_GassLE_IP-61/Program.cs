using System;
using System.Collections.Generic;

namespace Lab2_GassLE_IP_61
{
    class Program
    {
        static void Main(string[] args)
        {
            DemonstrationExample1();
            DemonstrationExample2();
            
            Console.Write("\nType any key for exit...");
            Console.ReadKey();
        }

        // returns a list with vehicles
        private static WrapperList CreateExampleListWithVehicles()
        {
            WrapperList list = new WrapperList();

            list.Add(new Car(150000, 180, 1998, "Sedan", "petrol", true));
            list.Add(new Car(250000, 230, 2013, "Sedan", "petrol"));
            list.Add(new Bicycle(1000, 35, 2015, "Standart", 15));
            list.Add(new Bicycle(300, 15, 1992, "Standart", 20));
            list.Add(new Lorry(10000000, 135, 2008, "Standart engine", 6));

            return list;
        }

        private static void DemonstrationExample1()
        {
            // Examples1
            Console.WriteLine("\nEXAMPLES1\n\n");

            // TestEquals1
            Vehicle veh1 = new Car(15000, 200, 2012, "Sed", "Standart", true);
            Vehicle veh2 = new Car(15000, 200, 2012, "Sed", "Standart", true);
            Console.WriteLine("TestEquals1\n" + veh1 + "\n" + veh2 + "\nIsEquals = " + veh1.Equals(veh2) + "\n\n"); // True

            // TestEquals2
            veh2.MaxSpeed = 132;
            Console.WriteLine("TestEquals2\n" + veh1 + "\n" + veh2 + "\nIsEquals = " + (veh1 == veh2) + "\n\n");    // False

            // TestEquals3
            veh2 = new Bicycle(1000, 35, 2005, "Simple", 4);
            try
            {
                Console.WriteLine("TestEquals3\n" + veh1 + "\n" + veh2 + "\nIsEquals = " + veh1.Equals(veh2) + "\n\n"); // False
            }
            catch (MInvalidCastException exc)
            {
                Console.WriteLine("TestEquals3\n" + veh1 + "\n" + veh2 + "\nIsEquals = False(" + exc.Message + ")\n\n"); // False
            }

            // TestEquals4
            veh2 = (Vehicle) veh1.DeepCopy();
            Console.WriteLine("TestEquals4\n" + veh1 + "\n" + veh2 + "\nIsEquals = " + (veh1 == veh2) + "\n\n");    // True

            // Example2
            WrapperList vehicles = new WrapperList();
            vehicles.Add(veh1);
            vehicles.Add(veh2);
            vehicles.Add(new Bicycle(100, 300, 2002, "Sim", 2));

            Garage garage1 = new Garage(vehicles);
            Garage garage2 = new Garage(vehicles);
            
            // True
            Console.WriteLine("TestEquals5\n" + garage1 + "\n" + garage2 + "\nIsEquals = " + (garage1.Equals(garage2)) + "\n\n");

            // False
            garage2.AddVehicle(new Lorry(100200, 170, 2015, "EngineStandart", 6));
            Console.WriteLine("TestEquals6\n" + garage1 + "\n" + garage2 + "\nIsEquals = " + (garage1.Equals(garage2)) + "\n\n");

            // True
            garage2 = (Garage) garage1.DeepCopy();
            Console.WriteLine("TestEquals7\n" + garage1 + "\n" + garage2 + "\nIsEquals = " + (garage1.Equals(garage2)) + "\n\n");
        }

        private static void DemonstrationExample2()
        {
            // Examples2
            Console.WriteLine("\nEXAMPLES2\n\n");

            Garage garage = new Garage();
            garage.AddVehicle(new Car(10100, 102, 1999, "SimCar", "TisIo", false));
            garage.AddVehicle(new Car(2000, 32, 1963, "OldCar", "Standart", true));
            garage.AddVehicle(new Car(2000, 32, 1963, "OldCar", "Standart", true));
            garage.AddVehicle(new Car(99022, 12, 1985, "OldCar", "Standart", true));

            garage.RemoveAt(1);
            garage.RemoveAt(2);

            garage.UpdateVehicle(0, new Bicycle(2000, 32));

            try
            {
                Vehicle vehicle = garage.GetVehicle(-5);
            } catch (MIndexOutOfRangeException exc)
            {
                Console.WriteLine(exc.Message);
            }
            
            Vehicle someVehicle = new Bicycle(200, 500);

            try
            {
                bool isEquals = garage.Equals(someVehicle);
            }
            catch (MInvalidCastException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }

}

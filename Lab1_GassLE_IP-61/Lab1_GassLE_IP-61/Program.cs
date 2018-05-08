using System;

/**
 * Варіант 3
 *   Между N пунктами (N<=50) заданы дороги длиной A(i,j), где I,J-номера пунктов. Дороги проложены на разной высоте и пересекаются только в общих пунктах. В начальный момент времени из заданных пунктов начинают двигаться с постоянной скоростью M роботов (M=2 или 3), независимо меняя направление движения только в пунктах. Роботы управляются таким образом, чтобы минимизировать время до встречи всех роботов в одном месте. Скорость I-того робота может быть равна 1 или 2. Остановка роботов запрещена.
 *   
 *   Задание:
 *   Создать программу, которая:
 *   1) при заданных N,M и сети дорог единичной длины (все имеющиеся A(i,j)=1) определяет минимальное время, через которое может произойти встреча всех M роботов, при этом начальное положение роботов и скорость их движения известны.
 *   2) Выполнить те же действия, что и в п. 1, но только для различных значений A(i,j).
 *   
 *   Примечание: В случае невозможности встречи всех M роботов в одном месте ни в какой момент времени в результате выполнения программы должно быть сформировано соответствующее сообщение.
 *   
 *   Требование к вводу-выводу:
 *   1) Все входные данные - целые неотрицательные числа;
 *   2) при задании сети дорог должно быть указано количество дорог - K и пункты их начала и конца в виде пар (i,j).
 *
 *  * */


namespace Lab1_GassLE_IP_61
{
    struct Robot
    {
        public int coordOfPoint;
        public int speed;
        public Robot(int coord, int sp)
        {
            coordOfPoint = coord;
            speed = sp;

        }
        public string ToString() { return "CoordOfPoint = " + coordOfPoint + ", Speed = " + speed; }
    }

    

    class Program
    {
        /*
         * For auto generation of all values 
         * at the very beginning of the program select yes (y). 
         * To set all the values, press the no (n)
         * */
        static void Main(string[] args)
        {
            Console.WriteLine("Made by Leonid Gass IP-61, Variant_3 :");

            // All roads' length equals '1'
            Console.WriteLine("\nTASK_1, where all roads' length = 1\n");
            Task(true);

            // All roads' length different and put from keyboard
            Console.WriteLine("\nTASK_2, where all roads' length different\n");
            Task(false);

            Console.Write("\nWrite any key to exit:");
            Console.ReadKey();
        }

        private static void Task(bool isAllRoadsEqualsOne)
        {
            Console.Write("Do you want to auto generate roads paths and robots(y/n): ");
            bool isAuto = Convert.ToChar(Console.ReadLine()) == 'y' ? true : false;

            int N;
            int M;

            int[,] roadsidуPoints;
            Robot[] robots;

            if (!isAuto)
            {
                Console.Write("Write N(number of settlements 2 .. 50): ");
                N = Convert.ToInt32(Console.ReadLine());               // number of settlements
                roadsidуPoints = CreateEmptyRoadsidyArray(N);          // distance from point to point, in case of inaccessibility -1

                Console.WriteLine("Write roads: ");
                GetPathValues(roadsidуPoints, isAllRoadsEqualsOne);

                Console.Write("Write M(number of robots 2 .. 3): ");
                M = Convert.ToInt32(Console.ReadLine());               // number of robots
                robots = new Robot[M];
                FillRobotsWithData(robots);
            } else
            {
                int a = new Random().Next() % 2;

                if (a == 0)
                {
                    N = 8;
                    M = 3;
                } else
                {
                    N = 5;
                    M = 2;
                }

                roadsidуPoints = CreateEmptyRoadsidyArray(N);       // distance from point to point, in case of inaccessibility -1
                robots = new Robot[M];
                AutoFillArrays(roadsidуPoints, robots, isAllRoadsEqualsOne);
            }

            Console.WriteLine("Roads paths: ");
            ShowArray(roadsidуPoints);

            int[,] distances = TreeHandler.FindDistances(roadsidуPoints);

            Console.WriteLine("Roads distances:");
            ShowArray(distances);

            FindBetterTimeForMeeting(distances, robots);
        }

        // Auto filling of roads and robots
        private static void AutoFillArrays(int[,] roadsidуPoints, Robot[] robots, bool isAllRoadsEqualsOne)
        {
            int[,] autoGeneretedPoints = null;
            Robot[] autoGeneretedRobots = null;

            if (isAllRoadsEqualsOne)
            {
                if (roadsidуPoints.GetLength(0) == 8)
                {
                    autoGeneretedPoints = new int[,] {
                    { 0, -1, -1, -1, 1, -1, 1, -1 },
                    { -1, 0, 1, -1, -1, -1, -1, 1 },
                    { -1, 1, 0, -1, -1, 1, -1, -1 },
                    { -1, -1, -1, 0, -1, 1, 1, -1 },
                    { 1, -1, -1, -1, 0, -1, -1, -1 },
                    { -1, -1, 1, 1, -1, 0, -1, -1 },
                    { 1, -1, -1, 1, -1, -1, 0, -1 },
                    { -1, 1, -1, -1, -1, -1, -1, 0 } };

                    autoGeneretedRobots = new Robot[] { new Robot(0, 2),
                                       new Robot(5, 1),
                                       new Robot(1, 2)};
                }
                else if (roadsidуPoints.GetLength(0) == 5)
                {
                    autoGeneretedPoints = new int[,] {
                    { 0, 1, -1, -1, -1 },
                    { 1, 0, 1, -1, -1 },
                    { -1, -1, 0, 1, 1 },
                    { -1, -1, 1, 0, 1 },
                    { -1, -1, 1, 1, 0 } };

                    autoGeneretedRobots = new Robot[] { new Robot(0, 2),
                                                                new Robot(3, 1)};
                }
            } else
            {
                if (roadsidуPoints.GetLength(0) == 8)
                {
                    autoGeneretedPoints = new int[,] {
                    { 0, -1, -1, -1, 4, -1, 2, -1 },
                    { -1, 0, 3, -1, -1, -1, -1, 4 },
                    { -1, 3, 0, -1, -1, 2, -1, -1 },
                    { -1, -1, -1, 0, -1, 5, 9, -1 },
                    { 4, -1, -1, -1, 0, -1, -1, -1 },
                    { -1, -1, 4, 5, -1, 0, -1, -1 },
                    { 2, -1, -1, 9, -1, -1, 0, -1 },
                    { -1, 4, -1, -1, -1, -1, -1, 0 } };
                    autoGeneretedRobots = new Robot[] { new Robot(0, 2),
                                       new Robot(5, 1),
                                       new Robot(1, 2)};
                }
                else if (roadsidуPoints.GetLength(0) == 5)
                {
                    autoGeneretedPoints = new int[,] {
                    { 0, 3, -1, -1, -1 },
                    { 3, 0, 4, -1, -1 },
                    { -1, -1, 0, 6, 1 },
                    { -1, -1, 6, 0, 4 },
                    { -1, -1, 1, 4, 0 } };
                    autoGeneretedRobots = new Robot[] { new Robot(0, 2),
                                       new Robot(3, 1)};
                }
            }

            Array.Copy(autoGeneretedRobots, robots, robots.GetLength(0));
            Array.Copy(autoGeneretedPoints, 0, roadsidуPoints, 0, autoGeneretedPoints.Length);

            ShowRobots(robots);
        }

        // Creating an initial empty array
        private static int[,] CreateEmptyRoadsidyArray(int size)
        {
            int[,] roadsidуPoints = new int[size, size];

            for (int i = 0; i < roadsidуPoints.GetLength(0); i++)
            {
                for (int j = 0; j < roadsidуPoints.GetLength(1); j++) { roadsidуPoints[i, j] = (i == j) ? 0 : -1; }
            }

            return roadsidуPoints;
        }

        // Array Output
        private static void ShowArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++) { Console.Write("{0:D2} ", array[i, j]); }
                Console.WriteLine();
            }
        }

        // Adding a path to an array of roads
        private static bool AddPath(int[,] roadsidуPoints, int firstPoint, int secondPoint, int distance)
        {
            if (firstPoint < 0 || firstPoint >= roadsidуPoints.GetLength(0) ||
                secondPoint < 0 || secondPoint >= roadsidуPoints.GetLength(0) ||
                distance <= 0)
            {
                Console.WriteLine("Invalid values!!! Try again.");
                return false;
            } else
            {
                roadsidуPoints[firstPoint, secondPoint] = distance;
                roadsidуPoints[secondPoint, firstPoint] = distance;
            }

            return true;
        }

        // Retrieving paths' values from the keyboard
        private static void GetPathValues(int[,] roadsidуPoints, bool isAllRoadsEqualOne)
        {
            int firstPoint = 0, secondPoint = 0;
            int distance = 0;

            Console.Write("Write K(count of roads): ");
            int K = Convert.ToInt32(Console.ReadLine());

            while (K <= 0)
            {
                Console.Write("Not right value of K. Try again: ");
                K = Convert.ToInt32(Console.ReadLine());
            }

            for (int roadIndex = 0; roadIndex < K; roadIndex++)
            {
                Console.WriteLine("\n\n:::ROAD_{0}:::", roadIndex + 1);

                Console.Write("Write A(first point 1..{0}): ", roadsidуPoints.GetLength(0));
                firstPoint = Convert.ToInt32(Console.ReadLine()) - 1;

                Console.Write("Write B(second point 1..{0}): ", roadsidуPoints.GetLength(0));
                secondPoint = Convert.ToInt32(Console.ReadLine()) - 1;

                if (!isAllRoadsEqualOne)
                {
                    Console.Write("Write L(distance between A and B): ");
                    distance = Convert.ToInt32(Console.ReadLine());
                } else { distance = 1; }

                if (!AddPath(roadsidуPoints, firstPoint, secondPoint, distance))
                {
                    Console.WriteLine("Invalid values!!! Try again.");
                    continue;
                }
            } 
        }

        // Filling robots with data
        private static void FillRobotsWithData(Robot[] robots)
        {
            for (int i = 0; i < robots.GetLength(0); i++)
            {
                Console.WriteLine("Robot{0}:", i + 1);

                Console.WriteLine("Write coord: ");
                robots[i].coordOfPoint = Math.Abs(Convert.ToInt32(Console.ReadLine())) - 1;

                bool isWrongSpeed = true;

                do
                {
                    Console.WriteLine("Write speed: ");
                    robots[i].speed = Math.Abs(Convert.ToInt32(Console.ReadLine()));

                    if (robots[i].speed != 0) { isWrongSpeed = false; }
                } while (isWrongSpeed);
            }
        }

        // Output of robots
        private static void ShowRobots(Robot[] robots)
        {
            for (int i = 0; i < robots.GetLength(0); i++)
            {
                Console.WriteLine("Robot{0}: {1}", i + 1, robots[i].ToString());
            }
        }

        // The method for performing the main task is to find the minimum meeting time and the point
        private static void FindBetterTimeForMeeting(int[,] distances, Robot[] robots)
        {
            double minTime = Int32.MaxValue;
            int pointWithMinTime = 0;

            for (int point = 0; point < distances.GetLength(0); point++)
            {
                bool isReachable = true;

                for (int robotIndex = 0; robotIndex < robots.GetLength(0); robotIndex++)
                {
                    if (distances[point, robots[robotIndex].coordOfPoint] == -1)
                    {
                        isReachable = false;
                        break;
                    } 
                }

                if (isReachable)
                {
                    double time = 0;
                    double maxTimeInThisPoint = 0;

                    for (int robotIndex = 0; robotIndex < robots.GetLength(0); robotIndex++)
                    {
                        time = distances[point, robots[robotIndex].coordOfPoint] * 1.0 / robots[robotIndex].speed;
                        if (time > maxTimeInThisPoint) { maxTimeInThisPoint = time; }
                    }

                    if (maxTimeInThisPoint < minTime)
                    {
                        minTime = maxTimeInThisPoint;
                        pointWithMinTime = point; 
                    }
                }
            }

            if (minTime != Int32.MaxValue)
                Console.WriteLine("Best time = {0} with meeting in point {1}", minTime, pointWithMinTime + 1);
            else
                Console.WriteLine("They can't meet!");
        }

    }
}

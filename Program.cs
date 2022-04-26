using System;

namespace CSharp.LabExercise2
{


    class Program
    {
        static void DifferentInputs()
        {
            
            string continueLoop;
            do
            {   
                Console.Clear();
                Console.WriteLine("Welcome to the Activity 1, 5 Different Inputs\n");
                int[] validInputs = new int[5];
                int iterator = 0;
                bool isExisting;
                while (iterator < 5)
                {
                    try
                    {
                        Console.Write("Enter number: ");
                        int input = Convert.ToInt32(Console.ReadLine());
                        isExisting = false;
                        if (input >= 10 && input <= 100)
                        {
                            foreach (int i in validInputs)
                            {
                                if (i != 0)
                                {
                                    Console.Write($"{i} ");
                                }
                            }

                            //check if value is existing
                            foreach (int i in validInputs)
                            {
                                if (i == input)
                                {
                                    Console.WriteLine($"\n{input} has already been entered");
                                    isExisting = true;
                                }
                            }

                            if (!isExisting)
                            {
                                Console.WriteLine($"{input} ");
                                validInputs[iterator] = input;
                                iterator++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Number must be between 10 and 100");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Input is not a number!");
                    }
                }

                Console.WriteLine("\nCongrats! You have created an Array with 5 Different Numbers");
                foreach (int i in validInputs)
                {
                  Console.Write($"{i} ");
                }

                Console.Write("\n\nTry Again? (y/n): ");
                continueLoop = Console.ReadLine();
            } while (continueLoop == "y" || continueLoop == "Y");

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey();
            Main();
        }
        static void LucianLasagna()
        {
            Console.Clear();
            Console.WriteLine("Welcome To Lucian's Exquisite Lasagna!");
            Console.WriteLine("\nPlease Select Action:");
            Console.WriteLine("[1] - Expected oven time in minutes");
            Console.WriteLine("[2] - Calculate the remaining oven time in minutes");
            Console.WriteLine("[3] - Calculate the preparation time in minutes");
            Console.WriteLine("[4] - Calculate the elapsed time in minutes");
            Console.WriteLine("[5] - Clear Console");
            Console.WriteLine("[6] - Exit Lucian's Exquisite Lasagna!");
            bool isLooping = true;
            while (isLooping)
            {
                Lasagna lasagna = new Lasagna();
                int actualMins;
                int layersAdded;

                Console.Write("Enter Selection: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine($"\nAccording to the cooking book, the expected oven time in minutes is {lasagna.ExpectedMinutesInOven()}\n");
                        break;
                    case "2":
                        Console.Write("\nEnter the actual minutes the lasagna has been in the oven: ");
                        try
                        {
                            actualMins = Convert.ToInt32(Console.ReadLine());
                            if (actualMins < 0)
                            {
                                Console.WriteLine($"Negative input detected! Actual minutes set to zero (0) . . .");
                                actualMins = 0;
                            }
                        }
                        catch
                        {
                            Console.WriteLine($"Invalid Input! Actual minutes set to zero (0) . . .");
                            actualMins = 0;
                        }
                        int minsRemaining = lasagna.RemainingMinutesInOven(actualMins);
                        if(minsRemaining == 0)
                        {
                            Console.WriteLine($"The lasagna is now perfectly cooked!\n");
                        }
                        else if(minsRemaining < 0)
                        {
                            Console.WriteLine($"Take the lasagna out of the oven! overcooked for {minsRemaining * -1} minutes\n");
                        }
                        else
                        {
                            Console.WriteLine($"The lasagna has to stay in the oven for {minsRemaining} minutes\n");
                        }
                        break;
                    case "3":
                        Console.Write("\nEnter the number of layers you added to the lasagna: ");
                        try
                        {
                            layersAdded = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine($"Invalid Input! Layers added set to zero (0) . . .");
                            layersAdded = 0;
                        } 
                        int preparationTimeInMinutes = lasagna.PreparationTimeInMinutes(layersAdded);
                        if(preparationTimeInMinutes == 0)
                        {
                            Console.WriteLine($"No layers added! You have spent {preparationTimeInMinutes} minutes preparing the lasagna\n");
                        }
                        else if(preparationTimeInMinutes < 0)
                        {
                            Console.WriteLine($"Please input approriate layer count!\n");
                        }
                        else
                        {
                            Console.WriteLine($"You have spent {preparationTimeInMinutes} minutes preparing the lasagna\n");
                        }
                        break;
                    case "4":
                        Console.Write("\nEnter the number of layers you added to the lasagna: ");
                        try
                        {
                            layersAdded = Convert.ToInt32(Console.ReadLine());
                            if (layersAdded < 0)
                            {
                                Console.WriteLine($"Negative input detected! Layers added set to zero (0) . . .");
                                layersAdded = 0;
                            }
                        }
                        catch
                        {
                            Console.WriteLine($"Invalid Input! Layers added set to zero (0) . . .");
                            layersAdded = 0;
                        }
                        Console.Write("Enter the actual minutes the lasagna has been in the oven: ");
                        try
                        {
                            actualMins = Convert.ToInt32(Console.ReadLine());
                            if (actualMins < 0)
                            {
                                Console.WriteLine($"Negative input detected! Actual minutes set to zero (0) . . .");
                                actualMins = 0;
                            }
                        }
                        catch
                        {
                            Console.WriteLine($"Invalid Input! Actual minutes set to zero (0) . . .");
                            actualMins = 0;
                        }
                        int elapsedTimeInMinutes = lasagna.ElapsedTimeInMinutes(layersAdded, actualMins);
                        Console.WriteLine($"\n{elapsedTimeInMinutes} minutes elapsed in preparing and cooking the lasagna\n");

                        break;
                    case "5":
                        LucianLasagna();
                        break;
                    case "6":
                        Console.WriteLine("\nLucian's Exquisite Lasagna Application Terminated!");
                        isLooping = false;
                        break;
                    default:
                        Console.Write("\nInvalid Selection! Try Again! . . .\n\n");
                        break;
                }
            }

            Console.Write("Press any key to return in Main Menu . . . ");
            Console.ReadKey();
            Main();
        }

        class Lasagna
        {
            public int ExpectedMinutesInOven()
            {
                int expectedMinutesInOven = 40;
                return expectedMinutesInOven;
            }

            public int RemainingMinutesInOven(int actualMins)
            {
                int remainingMinutesInOven = ExpectedMinutesInOven() - actualMins;
                return remainingMinutesInOven;
            }

            public int PreparationTimeInMinutes(int layerCount)
            {
                int minutesPerLayer = 2;
                int preparationTimeInMinutes = minutesPerLayer * layerCount;
                return preparationTimeInMinutes;
            }

            public int ElapsedTimeInMinutes(int layerCount, int actualMins)
            {
                int elapsedTimeInMinutes = PreparationTimeInMinutes(layerCount) + actualMins;
                return elapsedTimeInMinutes;
            }
        }
            static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome To My Lab Exercise 2 Application!");
                Console.WriteLine("\nPlease Select Exercise:");
                Console.WriteLine("[1] - Activity 1, 5 Different Inputs");
                Console.WriteLine("[2] - Lucian's Exquisite Lasagna");
                Console.WriteLine("[3] - Exit Application");
                Console.Write("Enter Selection: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        DifferentInputs();
                        break;
                    case "2":
                        Console.Clear();
                        LucianLasagna();
                        break;
                    case "3":
                        Console.WriteLine("\nApplication Terminated!");
                        Environment.Exit(-1);
                        break;
                    default:
                        Console.Write("\nInvalid Selection! Press Any Key To Try Again! . . . ");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}

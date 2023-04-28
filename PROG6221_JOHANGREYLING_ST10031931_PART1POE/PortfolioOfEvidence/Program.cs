using System;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Drawing;


namespace CG
{
    class Program
    {
        public static int  option = 0;

        public static void Main(String[] args)
        {

            RecipeFunctionality recipe = new RecipeFunctionality();
            recipe.arrTest();
            Console.WriteLine("Welcome");

            while (option == 0)
            {
                
                Menu();

                if (option > 6 || option < 1)
                {
                    Console.WriteLine( "Please choose a number between 1 and 6");
                    option = 0;
                }
                else
                {
                    //Checks what option was chosen and runs the corresponding method of the recipefunctionality class
                    switch (option)
                    {
                        case 1:
                            recipe.input();
                            break;

                        case 2:
                            recipe.output();
                            break;

                        case 3:
                            recipe.scale();
                            break;

                        case 4:
                            recipe.reset();
                            break;

                        case 5:
                            recipe.clear();
                            break;

                        case 6:
                            Environment.Exit(0);
                            break;
                    }

                    option = 0; //Makes sure that while is repeated
                }


            }


            //Code for showing the list of options that is available within the program
            static void Menu()
            {

                Console.WriteLine("\r\n" + "Please choose one of the coresponding options to continue:");
                Console.WriteLine("1. Enter new recipe.");
                Console.WriteLine("2. Display recipe.");
                Console.WriteLine("3. Scale recipe.");
                Console.WriteLine("4. Reset recipe quantities.");
                Console.WriteLine("5. Clear recipe.");
                Console.WriteLine("6. Exit Program." + "\r\n");

                option = Convert.ToInt32(Console.ReadLine());
            }


        }

        class RecipeFunctionality
        {
            //Variable declarations
            public static int iNumbers = 0, iSteps = 0;
            double scaleNum = 0, scaleNumKeep;

            //Array declarations
            static string[] Ingredients;
            static double[] Quantities;
            static double[] OriginalQuantities;
            static string[] Measurements;
            static string[] Steps;

            //Entering all the details of the new recipe
            public void input()
            {
                Console.WriteLine("Please enter the details for the recipe: " + "\r\n");

                //Repeating the process of entering the number of ingredients to ensure that the number is not less than or equal to zero
                while (iNumbers <= 0)
                {
                    Console.WriteLine("Enter the total number of ingredients:");
                    iNumbers = Convert.ToInt32(Console.ReadLine());

                    if (iNumbers <= 0)
                    {
                        Console.WriteLine("The number of ingredients can not be less than or equal to zero. Please try again.");
                    }
                }

                //Setting the sizes of the arrays before instantiating
                Ingredients = new string[iNumbers];
                Quantities = new double[iNumbers];
                Measurements = new string[iNumbers];
                OriginalQuantities = new double[iNumbers];

                //Intantiating the different arrays that will be used for the output and editting
                for (int i = 0; i < iNumbers; i++)
                {
                    Console.WriteLine("Name of Ingredient " + (i + 1));
                    Ingredients[i] = Console.ReadLine();

                    Console.WriteLine("Quantity of Ingredient " + (i + 1));
                    Quantities[i] = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Measurement Unit of Ingredient " + (i + 1));
                    Measurements[i] = Console.ReadLine();
                }

                //Repeating the process of entering the number of steps to ensure that the number is not less than or equal to zero
                while (iSteps <= 0)
                {
                    Console.WriteLine("Enter the total number steps within the recipe:");
                    iSteps = Convert.ToInt32(Console.ReadLine());

                    if (iSteps <= 0)
                    {
                        Console.WriteLine("The number of steps can not be less than or equal to zero. Please try again.");
                    }

                }

                //Setting the size of the array before instantiating
                Steps = new string[iSteps];

                //Instantiating the steps array that will be used for output
                for (int i = 0; i < iSteps; i++)
                {
                    Console.WriteLine("Write a short description for step " + (i + 1));
                    Steps[i] = Console.ReadLine();
                }

            }

            //Code for the display of the recipe
            public void output()
            {

                if (Ingredients.Length == 0) //Error test
                {
                    Console.WriteLine("There is no recipe to display");
                }
                else
                {
                Console.WriteLine("\r\n" + "List of Ingredients:");

                //Creating and outputting the list of ingredients
                for (int i = 0; i < Ingredients.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + Quantities[i] + " " + Measurements[i] + " " + Ingredients[i]);
                }

                Console.WriteLine("\r\n" + "The steps for the recipe are as follows:");

                //Creating and outputting the list of steps to follow for the recipe
                for (int i = 0; i < iSteps; i++)
                {
                    Console.WriteLine((i + 1) + ". " + Steps[i]);
                }
                }

            }

            //Code used for testing errors in the program class
            public void arrTest()
            {
                Ingredients = new string[iNumbers];
                Quantities = new double[iNumbers];
                Measurements = new string[iNumbers];
            }

            //Code for scaling the recipe
            public void scale()
            {

                if (Ingredients.Length == 0) //Error test
                {
                    Console.WriteLine("There is no recipe to scale");
                }
                else
                {
                    //Presenting scaling options
                    while (scaleNum == 0)
                    {
                        Console.WriteLine("\r\n" + "What scale would you like to factor the recipe by?");
                        Console.WriteLine("1. 0.5 times " + "\r\n" + "2. 2 times " + "\r\n" + "3. 3 times");

                        scaleNum = Convert.ToInt32(Console.ReadLine());

                        if (scaleNum > 3 || scaleNum < 1) //Error test
                        {
                            Console.WriteLine("Please choose an option between 1 and 3");
                            scaleNum = 0;
                        }
                        else
                        {
                            if (scaleNum == 1) //Setting the scale factor
                                scaleNum = 0.5;
                            else
                            if (scaleNum == 2)
                                scaleNum = 2;

                            else scaleNum = 3;
                        }
                    }

                    //Scaling the recipe and storing the original values in the memory
                    for (int i = 0; i < Quantities.Length; i++) 
                    {
                        OriginalQuantities[i] = Quantities[i];
                        Quantities[i] = Quantities[i] * scaleNum;
                    }

                    Console.WriteLine("Recipe has been scaled by " + scaleNum);

                    scaleNum = 0;
                }
            }

            //Code for resetting the recipe to its original quantities
            public void reset()
            {
                if (Ingredients.Length == 0) //Error test
                {
                    Console.WriteLine("There is no recipe qauntities to reset");
                }
                else
                {
                    //Replacing the new quantities with the old quantities from an array
                    for (int i = 0; i < Quantities.Length; i++)
                    {
                        Quantities[i] = OriginalQuantities[i];
                    }

                    Console.WriteLine("Recipe has been reset to original quantities ");
                }
            }

            //Code for clearing the recipe
            public void clear()
            {
                if (Ingredients.Length == 0) //Error test
                {
                    Console.WriteLine("There is no recipe to clear");
                }
                else
                {
                    //Clearing all the arrays
                    Array.Clear(Ingredients, 0, Ingredients.Length);
                    Array.Clear(Quantities, 0, Quantities.Length);
                    Array.Clear(Measurements, 0, Measurements.Length);
                    Array.Clear(Steps, 0, Steps.Length);

                    Ingredients = new string[0];
                    Quantities = new double[0];
                    Measurements = new string[0];

                    Console.WriteLine("Recipe has been cleared");
                }
            }



        }
    }
}

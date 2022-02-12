using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace B8IT117_CA_10553527
{
    class Program
    {
        static void Main(string[] args)
        {
            /* START OF TEST DATA */

            CommercialBuildings commercialBuildings = new CommercialBuildings();
            Rentals rentalBuildings = new Rentals();
            Sales saleBuildings = new Sales();

            Address commercialAddress = new Address("1", "Pallet Street", "KA10001");
            CommercialBuild commercialBuild = new CommercialBuild(commercialAddress, 2500, (2500 * .50), PurposeEnum.Industrial);

            Address rentalAddress = new Address("10", "Viridian Place", "KA20010");
            Rental rentalBuild = new Rental(rentalAddress, 60, 280.500, "Ash Ketchum", "ash@viridianhouse.com", 450);

            Address saleAddress = new Address("100", "Pewter Avenue", "KA30100");
            Sale saleBuild = new Sale(saleAddress, 200, 400.795, "Samuel Oak", "professoroak@palletresearchlaboratory.com", StatusEnum.Sale, 405000, DateTime.Now);

            commercialBuildings.Add(commercialBuild);
            rentalBuildings.Add(rentalBuild);
            saleBuildings.Add(saleBuild);

            /* END OF TEST DATA */

            bool shouldContinue = true;
            string upperChoice;

            while (shouldContinue)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("************************** \nBUILDING MANAGEMENT SYSTEM \n**************************");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("A. Add Commercial Building \nB. Add Residential Building for Rent \nC. Add Residential Building for Sale");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("D. Remove Commercial Building \nE. Remove Residential Building for Rent \nF. Remove Residential Building for Sale");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("G. Show Commercial Buildings \nH. Show Residential Buildings for Rent \nI. Show Residential Buildings for Sale");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("J. Update Sale Status of Residential Building \nK. Sort Commercial Buildings from Lowest to Highest SQ.FT. \nL. Update Rent of Rental Building");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("M. Exit Application");

                do
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("Selection: ");
                    string menuChoice = Console.ReadLine();
                    upperChoice = menuChoice.ToUpper();

                    if ((upperChoice != "A" && upperChoice != "B" && upperChoice != "C" && upperChoice != "D" 
                        && upperChoice != "E" && upperChoice != "F" && upperChoice != "G" && upperChoice != "H"
                        && upperChoice != "I" && upperChoice != "J" && upperChoice != "K" && upperChoice != "L"
                        && upperChoice != "M"))

                    {
                        Console.WriteLine("Choose a Letter.");
                    }
                    else if (upperChoice == "A")
                    {
                        Console.WriteLine("******************* \nNew Commercial Building \n*******************");
                        commercialBuildings.AddCommBuild();
                    }
                    else if (upperChoice == "B")
                    {
                        Console.WriteLine("**************** \nNew Residential (Rent) \n****************");
                        rentalBuildings.AddRentBuild();
                    }
                    else if (upperChoice == "C")
                    {
                        Console.WriteLine("**************** \nNew Residential (Sale) \n****************");
                        saleBuildings.AddSaleBuild();
                    }
                    else if (upperChoice == "D")
                    {
                        Console.WriteLine("************************** \nRemove Commercial Bulding \n**************************");
                        commercialBuildings.RemoveCommBuild();
                    }
                    else if (upperChoice == "E")
                    {
                        Console.WriteLine("************************* \nRemove Residential (Rent) \n*************************");
                        rentalBuildings.RemoveRentBuilding();
                    }
                    else if (upperChoice == "F")
                    {
                        Console.WriteLine("************************* \nRemove Residential (Sale) \n*************************");
                        saleBuildings.RemoveSaleBuild();
                    }
                    else if (upperChoice == "G")
                    {
                        Console.WriteLine("************** \nAll Commercial \n**************");
                        commercialBuildings.ShowCommBuild();
                    }
                    else if (upperChoice == "H")
                    {
                        Console.WriteLine("********************** \nAll Residential (Rent) \n**********************");
                        rentalBuildings.ShowRentBuild();
                    }
                    else if (upperChoice == "I")
                    {
                        Console.WriteLine("********************** \nAll Residential (Sale) \n**********************");
                        saleBuildings.ShowSaleBuild();
                    }
                    else if (upperChoice == "J")
                    {
                        Console.WriteLine("******************************** \nUpdate Residential Status (Sale) \n********************************");
                        saleBuildings.UpdateStatus();
                    }
                    else if (upperChoice == "K")
                    {
                        commercialBuildings.SortCommBuild();
                    }
                    else if (upperChoice == "L")
                    {
                        Console.WriteLine("****************************** \nUpdate Rent of Rental Building \n******************************");
                        rentalBuildings.UpdateRent();
                    }
                    else if (upperChoice == "M")
                    {
                        Console.WriteLine("Terminating...");
                        Environment.Exit(0);
                    }
                }
                while ((upperChoice != "A" && upperChoice != "B" && upperChoice != "C" && upperChoice != "D"
                && upperChoice != "E" && upperChoice != "F" && upperChoice !="G" && upperChoice != "H"
                && upperChoice != "I" && upperChoice != "J" && upperChoice != "K" && upperChoice != "L"
                && upperChoice != "M"));

                Console.WriteLine("Continue? \nY. \nN.");
                string cont, upperCont;

                do
                {                   
                    Console.Write("Selection: ");
                    cont = Console.ReadLine();
                    upperCont = cont.ToUpper();

                    switch (upperCont)
                    {
                        case "Y":
                            shouldContinue = true;
                            break;
                        case "N":
                            shouldContinue = false;
                            Console.WriteLine("Terminating...");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Enter Y or N.");
                            break;
                    }
                }
                while ((upperCont != "Y" && upperCont != "N"));
            }
        }
    }
}

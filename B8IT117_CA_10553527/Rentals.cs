using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B8IT117_CA_10553527
{
    class Rentals
    {

        public List<Rental> rentList = new List<Rental>();

        public void Add(Rental r)
        {
            rentList.Add(r);
        }

        public void ShowRentBuild()
        {
            foreach (Rental r in rentList)
            {
                Console.WriteLine(r.ToString());
            }
        }

        public void AddRentBuild()
        {
            Console.Write("Number: ");
            string number = Console.ReadLine();
            Console.Write("Street: ");
            string street = Console.ReadLine();
            Console.Write("Post Code: ");
            string postCode = Console.ReadLine();
            Console.Write("Square Footage: ");
            bool successFoot;
            double squareFootage;
            do
            {
                string strFootage = (Console.ReadLine());
                successFoot = double.TryParse(strFootage, out squareFootage);
                if (successFoot)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a Number.");
                    Console.Write("Square Footage: ");
                }
            }
            while (!successFoot);
            Console.Write("Valuation: ");
            bool successVal;
            double valuation;
            do
            {
                string strRates = (Console.ReadLine());
                successVal = double.TryParse(strRates, out valuation);
                if (successVal)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a Number.");
                    Console.Write("Valuation: ");
                }
            }
            while (!successVal);
            Console.Write("Owner Name: ");
            string ownerName = Console.ReadLine();
            Console.Write("Owner Email: ");
            string ownerEmail = Console.ReadLine();
            Console.Write("Rent: ");
            bool successRent;
            double rent;
            do
            {
                string strFootage = (Console.ReadLine());
                successRent = double.TryParse(strFootage, out rent);
                if (successRent)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a Number.");
                    Console.Write("Rent: ");
                }
            }
            while (!successRent);

            Address rentAddress = new Address(number, street, postCode);
            Rental rentBuild = new Rental(rentAddress, squareFootage, valuation, ownerName, ownerEmail, rent);
            Console.WriteLine(rentBuild);

            if (!CompareRentBuild(rentBuild))
            {
                rentList.Add(rentBuild);
                Console.WriteLine($"*** Added: {rentBuild.Address} ***");
            }
            else
            {
                Console.WriteLine("*** Already on Record ***");
            }
        }

        public bool CompareRentBuild(Rental rentBuild)
        {
            bool duplicate = false;

            foreach (Rental r in rentList)
            {
                if (rentBuild.Address == r.Address)
                {
                    duplicate = true;
                }
            }
            return duplicate;
        }

        public void RemoveRentBuilding()
        {
            string postCode;
            bool found = false;

            Console.Write("Enter Postcode: ");
            postCode = Console.ReadLine();

            string upperCode = postCode.ToUpper();

            for (int i = 0; i < rentList.Count; i++)
            {
                if (rentList[i].Address.PostCode == upperCode.Replace(" ", ""))
                {
                    found = true;
                    Console.WriteLine("Building -- {0} -- Removed", rentList[i].Address);
                    rentList.Remove(rentList[i]);
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("Doesn't Exist.");
            }
        }

        public void UpdateRent()
        {
            Console.Write("Enter Postcode: ");
            string postCode = Console.ReadLine();

            string upperCode = postCode.ToUpper();

            foreach (Rental r in rentList)
            {
                if (r.Address.PostCode == upperCode.Replace(" ", ""))
                {
                    Console.WriteLine($"Rent for {r.Address} is ${r.Rent}.");

                    bool successUpdate;
                    double rentUpdate;

                    do
                    {
                        Console.Write("New Rent: ");
                        string rent = (Console.ReadLine());
                        successUpdate = double.TryParse(rent, out rentUpdate);
                        if (successUpdate)
                        {
                            r.Rent = rentUpdate;
                            Console.WriteLine($"Rent Updated to ${r.Rent}");
                        }
                        else
                        {
                            Console.WriteLine("Enter a Number.");
                        }
                    }
                    while (!successUpdate);
                }
                else
                {
                    Console.WriteLine("No Match.");
                }
            }
        }      
    }
}

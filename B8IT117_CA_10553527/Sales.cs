using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace B8IT117_CA_10553527
{
    class Sales
    {

        public List<Sale> saleList = new List<Sale>();

        public void Add(Sale s)
        {
            saleList.Add(s);
        }

        public void ShowSaleBuild()
        {
            foreach (Sale s in saleList)
            {
                Console.WriteLine(s.ToString());
            }
        }

        public void AddSaleBuild()
        {
            string upperChoice;
            StatusEnum saleStatus = StatusEnum.Sale; /* Set to StatusEnum.Sale as default for overloaded constructor of class saleBuild. */

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
            Console.WriteLine("Status? \nA. Sale \nB. Sale Agreed \nC. Sold ");
            do
            {
                Console.Write("Selection: ");
                string menuChoice = Console.ReadLine();
                upperChoice = menuChoice.ToUpper();

                if ((upperChoice != "A" && upperChoice != "B" && upperChoice != "C"))
                {
                    Console.WriteLine("Enter A, B or C.");
                }
                else if (upperChoice == "A")
                {
                    saleStatus = StatusEnum.Sale;
                }
                else if (upperChoice == "B")
                {
                    saleStatus = StatusEnum.SaleAgreed;
                }
                else if (upperChoice == "C")
                {
                    saleStatus = StatusEnum.Sold;
                }
            }
            while ((upperChoice != "A" && upperChoice != "B" && upperChoice != "C"));

            Console.Write("Asking Price: ");
            bool successPrice;
            double askingPrice;
            do
            {
                string strPrice = (Console.ReadLine());
                successPrice = double.TryParse(strPrice, out askingPrice);
                if (successPrice)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a Number.");
                    Console.Write("Asking Price: ");
                }
            }
            while (!successPrice);

            DateTime dateEntered = DateTime.Now;

            Address saleAddress = new Address(number, street, postCode);
            Sale saleBuild = new Sale(saleAddress, squareFootage, valuation, ownerName, ownerEmail, saleStatus, askingPrice, dateEntered);
            Console.WriteLine(saleBuild);

            if (!CompareSaleBuild(saleBuild))
            {
                saleList.Add(saleBuild);
                Console.WriteLine($"*** Added: {saleBuild.Address} ***");
            }
            else
            {
                Console.WriteLine("*** Already on Record ***");
            }
        }

        public bool CompareSaleBuild(Sale saleBuild)
        {
            bool duplicate = false;

            foreach (Sale s in saleList)
            {
                if (saleBuild.Address == s.Address)
                {
                    duplicate = true;
                }
            }
            return duplicate;
        }

        public void RemoveSaleBuild()
        {
            string postCode;
            bool found = false;

            Console.Write("Enter Postcode: ");
            postCode = Console.ReadLine();

            string upperCode = postCode.ToUpper();

            for (int i = 0; i < saleList.Count; i++)
            {
                if (saleList[i].Address.PostCode == upperCode.Replace(" ", ""))
                {
                    found = true;
                    Console.WriteLine("Building -- {0} -- Removed", saleList[i].Address);
                    saleList.Remove(saleList[i]);
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("Doesn't Exist.");
            }
        }

        public void UpdateStatus()
        {
            Console.Write("Enter Postcode: ");
            string postCode = Console.ReadLine();

            string upperCode = postCode.ToUpper();

            foreach (Sale s in saleList)
            {
                if (s.Address.PostCode == upperCode.Replace(" ", ""))
                {
                    string upperStatus;

                    Console.WriteLine($"Status of {s.Address} is {s.Status}.");
                    Console.WriteLine("A. Sale \nB. Sale Agreed \nC. Sold");

                    do
                    {
                        Console.Write("Update: ");
                        string updateStatus = Console.ReadLine();
                        upperStatus = updateStatus.ToUpper();

                        switch (upperStatus)
                        {
                            case "A":
                                if (s.Status == StatusEnum.Sale)
                                {
                                    Console.WriteLine("Same Status.");
                                }
                                else
                                {
                                    s.Status = StatusEnum.Sale;
                                    Console.WriteLine("Updated to Sale");                                    
                                }
                                break;
                            case "B":
                                if (s.Status == StatusEnum.SaleAgreed)
                                {
                                    Console.WriteLine("Same Status.");
                                }
                                else
                                {
                                    s.Status = StatusEnum.SaleAgreed;
                                    Console.WriteLine("Updated to Sale Agreed");
                                }                            
                                break;
                            case "C":
                                if (s.Status == StatusEnum.Sold)
                                {
                                    Console.WriteLine("Same Status.");
                                }
                                else
                                {
                                    s.Status = StatusEnum.Sold;
                                    Console.WriteLine("Updated to Sold");
                                }
                                break;
                            default:
                                Console.WriteLine("Enter A, B, or C.");
                                break;
                        }
                    }
                    while ((upperStatus != "A" && upperStatus != "B" && upperStatus != "C"));
                }
                else
                {
                    Console.WriteLine("No Match.");
                }
            }
        }
    }
}

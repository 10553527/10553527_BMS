using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B8IT117_CA_10553527
{
    class CommercialBuildings
    {

        List<CommercialBuild> commercialList = new List<CommercialBuild>();

        public void Add(CommercialBuild c)
        {
            commercialList.Add(c);
        }

        public void ShowCommBuild()
        {
            foreach (CommercialBuild c in commercialList)
            {
                Console.WriteLine(c.ToString());
            }
        }

        public void AddCommBuild()
        {
            string upperChoice;
            PurposeEnum commPurpose = PurposeEnum.Industrial; /* Set to PurposeEnum.Industrial as default for overloaded constructor of class commBuild. */

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
            double rates = .5 * squareFootage; /* Rates are calculated at $0.50 per square foot for the purposes of this application */ 

            Console.WriteLine("Purpose? \nA. Retail \nB. Industrial \nC. Office ");

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
                    commPurpose = PurposeEnum.Retail;
                }
                else if (upperChoice == "B")
                {
                    commPurpose = PurposeEnum.Industrial;
                }
                else if (upperChoice == "C")
                {
                    commPurpose = PurposeEnum.Office;
                }
            }
            while ((upperChoice != "A" && upperChoice != "B" && upperChoice != "C"));

            Address commAddress = new Address(number, street, postCode);
            CommercialBuild commBuild = new CommercialBuild(commAddress, squareFootage, rates, commPurpose);

            if (!CompareCommBuild(commBuild))
            {
                commercialList.Add(commBuild);
                Console.WriteLine($"*** Added: {commBuild.Address} ***");
            }
            else
            {
                Console.WriteLine("Already on Record.");
            }
        }

        public bool CompareCommBuild(CommercialBuild commBuild)
        {
            bool duplicate = false;

            foreach (CommercialBuild c in commercialList)
            {
                if (commBuild.Address == c.Address)
                {
                    duplicate = true;
                }
            }
            return duplicate;
        }

        public void RemoveCommBuild()
        {
            string postCode;
            bool found = false;

            Console.Write("Enter Postcode: ");
            postCode = Console.ReadLine();

            string upperCode = postCode.ToUpper();

            for (int i = 0; i < commercialList.Count; i++)
            {
                if (commercialList[i].Address.PostCode == postCode.Replace(" ", ""))
                {
                    found = true;
                    Console.WriteLine("Building -- {0} -- Removed", commercialList[i].Address);
                    commercialList.Remove(commercialList[i]);
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("Doesn't Exist.");
            }
        }

        public void SortCommBuild()
        {
            commercialList.Sort((CommercialBuild x, CommercialBuild y) => x.SquareFootage.CompareTo(y.SquareFootage));
            Console.WriteLine("List Sorted!");
        }
    }
}

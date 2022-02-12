using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B8IT117_CA_10553527
{
    class Rental:Residential
    {
        public double Rent { get; set; }

        public Rental()
        { }

        public Rental(Address address, double squareFootage, double valuation, string ownerName, string ownerEmail, double rent)
            :base(address, squareFootage, valuation, ownerName, ownerEmail) /* address and squareFootage are from Building */
        {
            Rent = rent;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nRent: ${Rent} \n**********************";
        }
    }
}

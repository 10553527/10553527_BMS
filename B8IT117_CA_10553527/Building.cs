using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B8IT117_CA_10553527
{
    class Building
    {
        public Address Address { get; set; }
        public double SquareFootage { get; set; }

        public Building()
        { }

        public Building(Address address, double squareFootage)
        {
            Address = address;
            SquareFootage = squareFootage;
        }

        public override string ToString()
        {
            return $"Address: {Address} \nArea: {SquareFootage} SQ. FT.";
        }
    }
}

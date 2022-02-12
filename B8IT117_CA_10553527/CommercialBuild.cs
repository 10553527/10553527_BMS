using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B8IT117_CA_10553527
{
    class CommercialBuild:Building
    {
        public double Rates { get; set; }
        public PurposeEnum IntendedPurpose { get; set; }

        public CommercialBuild()
        { }

        public CommercialBuild(Address address, double squareFootage, double rates, PurposeEnum intendedPurpose)
            :base(address, squareFootage) 
        {
            Rates = rates;
            IntendedPurpose = intendedPurpose;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nRates: ${Rates} \nPurpose: {IntendedPurpose} \n**************";
        }
    }
}

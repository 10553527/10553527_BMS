using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B8IT117_CA_10553527
{
    class Residential:Building
    {
        public double Valuation { get; set; }
        public string OwnerName { get; set; }
        public string OwnerEmail { get; set; }

        public Residential()
        { }

        public Residential(Address address, double squareFootage, double valuation, string ownerName, string ownerEmail)
            : base(address, squareFootage)
        {
            Valuation = valuation;
            OwnerName = ownerName;
            OwnerEmail = ownerEmail;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nValuation: ${Valuation} \nOwner Name: {OwnerName} \nOwner Email: {OwnerEmail}";
        }
    }
}

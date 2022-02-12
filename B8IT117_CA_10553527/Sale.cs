using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B8IT117_CA_10553527
{
    class Sale:Residential
    {
        public StatusEnum Status { get; set; }
        public double AskingPrice { get; set; }
        public DateTime DateEntered { get; set; }

        public Sale()
        { }

        public Sale(Address address, double squareFootage, double valuation, string ownerName, string ownerEmail, StatusEnum status, double askingPrice, DateTime dateEntered)
            :base(address, squareFootage, valuation, ownerName, ownerEmail) /* address and squareFootage are from Building */
        {
            Status = status;
            AskingPrice = askingPrice;
            DateEntered = DateTime.Now;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nStatus: {Status} \nAsking Price: ${AskingPrice} \nDate Entered: {DateEntered} \n**********************";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B8IT117_CA_10553527
{
    class Address
    {
        public string Number { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }

        public Address()
        { }

        public Address(string number, string street, string postCode)
        {
            Number = number;
            Street = street;
            PostCode = postCode;
        }

        public override string ToString()
        {
            return $"{Number} {Street}, {PostCode}";
        }
    }
}

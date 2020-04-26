using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301
{
    class Address
    {
        private int street_number;
        private string street_name;
        private string suburb;

        public Address(int street_number,string street_name,string suburb)
        {
            this.Street_number = street_number;
            this.Street_name = street_name;
            this.Suburb = suburb;
        }

        public int Street_number { get => street_number; set => street_number = value; }
        public string Street_name { get => street_name; set => street_name = value; }
        public string Suburb { get => suburb; set => suburb = value; }

        public override string ToString()
        {
            return street_number + " " + street_name + ", " + suburb;
        }
    }
}

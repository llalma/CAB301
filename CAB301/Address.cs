using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301
{
    class Address
    {
        private int street_number;
        private int apartment_number;
        private string street_name;
        private int postcode;
        private string suburb;

        public Address(int street_number,int apartment_number,string street_name,int postcode,string suburb)
        {
            this.Street_number = street_number;
            this.Street_name = street_name;
            this.Apartment_number = apartment_number;
            this.Postcode = postcode;
            this.Suburb = suburb;
        }

        public int Street_number { get => street_number; set => street_number = value; }
        public int Apartment_number { get => apartment_number; set => apartment_number = value; }
        public string Street_name { get => street_name; set => street_name = value; }
        public int Postcode { get => postcode; set => postcode = value; }
        public string Suburb { get => suburb; set => suburb = value; }

        public override string ToString()
        {
            if(apartment_number <= 0)
            {
                return street_number + " " + street_name + ", " + postcode + ", " + suburb;
            }
            return "U " + apartment_number + ", " + street_number + " " + street_name + ", " + postcode + ", " + suburb;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301
{
    class Member
    {
        private string first_name;
        private string last_name;
        private Address address;
        private int phone_number;
        private MovieCollection movies;

        public Member(string first_name,string last_name,Address address,int phone_number)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.address = address;
            this.phone_number = phone_number;
        }

        public void Add_movie(Movie movie)
        {

        }

        public void Remove_movie(Movie movie)
        {

        }

        public string First_name { get => first_name; set => first_name = value; }
        public string Last_name { get => last_name; set => last_name = value; }
        public int Phone_number { get => phone_number; set => phone_number = value; }
        internal Address Address { get => address; set => address = value; }
    }
}
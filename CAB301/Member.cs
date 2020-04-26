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
        private Int64 phone_number;
        private MovieCollection movies;
        private string password;
        private string username;

        public Member(string first_name, string last_name, Address address, Int64 phone_number, string password)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.address = address;
            this.phone_number = phone_number;
            this.Username = last_name+first_name;
            this.Password = password;
        }

        public void Add_movie(Movie movie)
        {

        }

        public void Remove_movie(Movie movie)
        {

        }

        public string First_name { get => first_name; set => first_name = value; }
        public string Last_name { get => last_name; set => last_name = value; }
        public Int64 Phone_number { get => phone_number; set => phone_number = value; }
        internal Address Address { get => address; set => address = value; }
        public string Password { get => password; set => password = value; }
        public string Username { get => username; set => username = value; }
    }
}
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
        private MovieCollection rented_movies = new MovieCollection();

        public Member(string first_name, string last_name, Address address, Int64 phone_number, string password)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.address = address;
            this.phone_number = phone_number;
            this.Username = last_name.ToUpper()+first_name.ToUpper();
            this.Password = password;
        }

        public string Add_movie(Movie movie)
        {
            //Rent up to 10 movies at a time.
            if (rented_movies.Exists(movie.Title))
            {
                //Movie is already rented
                return "You already have " + movie.Title + " ,Movie not rented";
            }

            //Movie is not rented yet,
            if(rented_movies.Length() < 10)
            {
                //Member does not have greater than 10 movies
                rented_movies.Insert_node(movie);
                
                return "You successfully rented " + movie.Title;
            }
            //Member has rented too many movies
            return "You already have 10 movies. Return a movie before renting again.";
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
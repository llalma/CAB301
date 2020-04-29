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
            if (Rented_movies.Exists(movie.Title))
            {
                //Movie is already rented
                return "You already have " + movie.Title + " ,Movie not rented";
            }

            //Movie is not rented yet,
            if(Rented_movies.Length() < 10)
            {
                //Member does not have greater than 10 movies
                Rented_movies.Insert_node(movie);
                
                return "You successfully rented " + movie.Title;
            }
            //Member has rented too many movies
            return "You already have 10 movies. Return a movie before renting again.";
        }

        public string Remove_movie(Movie movie)
        {
            if (movie != null)
            {
                //Return movie only if in the users rented movies
                if (Rented_movies.Exists(movie.Title))
                {
                    //Movie is rented by user, so return movie
                    Rented_movies.Delete_node(movie.Title);
                    return "You have returned " + movie.Title;
                }
            }
            //Movie is not rented
            return "You do not have that rented.";
        }

        public string First_name { get => first_name; set => first_name = value; }
        public string Last_name { get => last_name; set => last_name = value; }
        public Int64 Phone_number { get => phone_number; set => phone_number = value; }
        internal Address Address { get => address; set => address = value; }
        public string Password { get => password; set => password = value; }
        public string Username { get => username; set => username = value; }
        public MovieCollection Rented_movies { get => rented_movies; set => rented_movies = value; }
    }
}
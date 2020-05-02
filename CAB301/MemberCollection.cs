using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301
{
    class MemberCollection
    {
        Array members = new Array();

        public void Populate()
        {
            Address address1 = new Address(38, "Elma st", "Salisbury");
            Member member1 = new Member("Liam", "H", address1, 61830947834, "0000");

           
            members.Add(member1);
        }

        public void Add(Member member)
        {
            members.Add(member);
        }

        public Boolean Remove(string first_name, string last_name)
        {
            return members.Remove(first_name, last_name);
        }

        public Boolean Exists(string first_name, string last_name)
        {
            //Returns true if a member does exist with the first and last name, returns false if a member does not exist.
            return members.Search(first_name, last_name) != null;
        }

        public Int64 Get_members_number(string first_name, string last_name)
        {
            Member member = members.Search(first_name, last_name);

            if(member != null)
            {
                return member.Phone_number;
            }
            return -1;
        }
        
        public Boolean Check_login_info(string username,string password)
        {
            //Returns true when username and password match input values.

            Member member = members.Search(username);

            if(member != null)
            {
                //Username exists in MembersCollection
                return (String.Compare(member.Username, username) == 0 && String.Compare(member.Password.ToString(), password) == 0);
            }
            return false;
           
        }

        public string Rent(string username,Movie movie)
        {
            return members.Rent(username,movie);
        }

        public string Return(string username, Movie movie)
        {
            return members.Return(username,movie);
        }

        public string Borrowed(string username)
        {
            //Shows borrowed movies by user.
            return members.Search(username).Rented_movies.Print_elements("Title");
        }
    }
}

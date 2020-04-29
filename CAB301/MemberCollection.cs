﻿using System;
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
            Member member1 = new Member("G", "G", address1, 0830947834, "0000");

            Member member2 = new Member("l", "h", address1, 9403758944, "0000");

            Address address2 = new Address(135, "Duporth ave", "Maroochydore");
            Member member3 = new Member("zack", "ben", address2, 1839347594, "1111");

            Address address3 = new Address(56, "john st", "Whyalla");
            Member member4 = new Member("John", "johnson", address3, 1739473954,"2222");

            members.Add(member1);
            members.Add(member2);
            members.Add(member3);
            members.Add(member4);
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
            return members.Search(first_name, last_name).Phone_number;
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

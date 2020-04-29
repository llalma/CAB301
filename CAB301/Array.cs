using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAB301
{
    class Array
    {
        Member[] members = new Member[100];
        int first_unused_index = 0;

        private int find_first_unused_index()
        {
            //Returns first unused index in members array, -1 if no avaliable positions
            for (int i = 0; i < members.Length; i++)
            {
                if (members[i] == null)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Add(Member member)
        {
            //Add element to array, no warning if index is over 100 though as said in slack that 10 is enough, so 100 should be fine. 
            //Makes all letetrs and first and last name caps to make searching easier.

            if (members[first_unused_index] != null)
            {
                first_unused_index = find_first_unused_index();
            }

            //Ensure names are all caps as they are compared msot often.
            member.First_name = member.First_name.ToUpper();
            member.Last_name = member.Last_name.ToUpper();

            members[first_unused_index] = member;

            //Guess that next position is avaliable, if not can use function from above.
            //This reduces runtime occassionaly.
            first_unused_index++;

            //Sort the array using insertion sort based on alphabetical order.
            Sort();
        }

        private void Sort()
        {
            //Sorts by alphabetical order, sorts by username, uses inserstion sort. Is better for almost sorted arrays.
            for (int i = 1; i < find_first_unused_index(); ++i)
            {
                Member member = members[i];
                string key =  member.Last_name.ToUpper() + member.First_name.ToUpper();
                int j = i - 1;

                // Move elements of arr[0..i-1], 
                // that are greater than key, 
                // to one position ahead of 
                // their current position 
                while (j >= 0 && String.Compare(members[j].Last_name + members[j].First_name, key) > 0)
                {
                    members[j + 1] = members[j];
                    j = j - 1;
                }
                members[j + 1] = member;
            }
        }

        public Boolean Remove(string first_name, string last_name)
        {
            //Remove member from list given full name. Returns true if member removed otherwise false.
            for (int i = 0; i < members.Length; i++)
            {
                //Save into variable to reduce processing time, assuming using linked lists when getting to variable
                Member member = members[i];
                if (String.Compare(member.First_name + member.Last_name, (first_name.ToUpper() + last_name.ToUpper())) == 0 && member != null)
                {
                    //Matching Name
                    members[i] = null;
                    first_unused_index = i;

                    return true;
                }
            }

            return false;
        }

        public Member Search(string first_name, string last_name)
        {
            //Returns the member given a first and last name. returns null if not in array.
            //Remove member from list given full name.

            int l = 0;
            int r = find_first_unused_index() - 1;
            string key = last_name.ToUpper() + first_name.ToUpper();

            while (l <= r)
            {
                int m = (l + r) / 2;
                if (key == members[m].Last_name + members[m].First_name)
                {
                    return members[m];
                }
                else if (String.Compare(key , members[m].Last_name + members[m].First_name)< 0)
                {
                    r = m - 1;
                }
                else
                {
                    l = m + 1;
                }
            }
            return null;
        }

        public Member Search(string username)
        {
            int l = 0;
            int r = find_first_unused_index() - 1;
            string key = username.ToUpper();

            while (l <= r)
            {
                int m = (l + r) / 2;
                if (key == members[m].Last_name + members[m].First_name)
                {
                    return members[m];
                }
                else if (String.Compare(key, members[m].Last_name + members[m].First_name) < 0)
                {
                    r = m - 1;
                }
                else
                {
                    l = m + 1;
                }
            }
            return null;
        }

        public string Rent(string username, Movie movie)
        {
            return Search(username).Add_movie(movie);
        }

        public string Return(string username, Movie movie)
        {
            return Search(username).Remove_movie(movie);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301
{
    class MemberCollection
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

            //Approaches
            //with for loop find first element which is not null O(n) time
            //in first postion of array save first open position, makes adding faster when adding at end of the list, makes removing same.
            //Skip lists?
            //ordered list?

            if(members[first_unused_index] != null)
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
        }

        public Boolean Remove(string first_name, string last_name)
        {
            //Remove member from list given full name. Returns true if member removed otherwise false.
            for(int i = 0; i < members.Length; i++)
            {
                //Save into variable to reduce processing time, assuming using linked lists when getting to variable
                Member member = members[i];
                if(String.Compare(member.First_name + member.Last_name, (first_name.ToUpper() + last_name.ToUpper())) == 0 && member != null)
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
            for (int i = 0; i < members.Length; i++)
            {
                //Save into variable to reduce processing time, assuming using linked lists when getting to variable
                Member member = members[i];
                if (member != null && String.Compare(member.First_name + member.Last_name, (first_name.ToUpper() + last_name.ToUpper())) == 0)
                {
                    return member;
                }
            }

            return null;
        }

        public Boolean Exists(string first_name, string last_name)
        {
            //Returns true if a member does exist with the first and last name, returns false if a member does not exist.
            return Search(first_name, last_name) != null;
        }
    }
}

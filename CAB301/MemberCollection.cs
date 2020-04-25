using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301
{
    class MemberCollection
    {
        Member[] members = new Member[100];
        int first_unused_index = 0;

        public void Add(Member member)
        {
            //Add element to array, no warning if index is over 100 though as said in slack that 10 is enough, so 100 should be fine.

            //Approaches
            //with for loop find first element which is not null O(n) time
            //in first postion of array save first open position, makes adding faster when adding at end of the list, makes removing same,

            members[first_unused_index] = member;
            first_unused_index++;            
        }

        public void Remove(string first_name, string last_name)
        {
            //Remove member from list given full name.
            for(int i = 0; i < members.Length; i++)
            {
                Member member = members[i];
                if(String.Compare(member.First_name + " " + member.Last_name, (first_name + " " + last_name)) == 0)
                {
                    //Matching Name

                }
            }
        }

        public Member Search()
        {
            Address address = new Address(9, 38, "Elma st", 4107, "Salisbury");
            return new Member("Liam", "Hulsman-Benson", address, 0414984327);
        }

        private Boolean check_member_exists()
        {
            return false;
        }
    }
}

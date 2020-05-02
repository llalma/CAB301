using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301
{
    class Ordered_Array
    {
        Movie[] ordered = new Movie[10];

        public void Insert(Movie movie)
        {
            if (!Exists(movie))
            {
                //If movie does not exist

                int last_used_space = Get_used_spaces();
                //If not 10 items in list
                if (ordered[9] == null)
                {
                    ordered[last_used_space] = movie;
                    Sort();
                }
                //If 10 elements, see if new movie is larger than movie is 10 position
                else
                {
                    if (ordered[9].Times_rented < movie.Times_rented)
                    {
                        //Replace 10th position, will reorder later
                        ordered[9] = movie;
                        Sort();
                    }
                    else
                    {
                        //Movie is not larger than the least number of times rented. So it can be ignored.
                        return;
                    }
                }
            }
            else
            {
                //If movie did exist in list already, just sort list.
                Sort();
            }
        }

        private void Sort()
        {
            //Sorts by number of time rented, uses inserstion sort. Is better for almost sorted arrays.
            for (int i = 1; i < Get_used_spaces(); ++i)
            {
                Movie movie = ordered[i];
                int key = movie.Times_rented;
                int j = i - 1;

                // Move elements of arr[0..i-1], 
                // that are greater than key, 
                // to one position ahead of 
                // their current position 
                while (j >= 0 && ordered[j].Times_rented > key)
                {
                    ordered[j + 1] = ordered[j];
                    j = j - 1;
                }
                ordered[j + 1] = movie;
            }
        }

        public string Get_list()
        {
            string output = "";
            for(int i = 9; i >= 0; i--)
            {
                if(ordered[i] != null)
                {
                    output += ordered[i].Title + " borrowed " + ordered[i].Times_rented + " times\n";
                }
            }

            //No most popular movies
            if(output == "")
            {
                return "No movies were rented more than 0 times.";
            }
            else
            {
                output = "The 10 most popular movies are: \n" + output;
            }

            return output;
        }

        private int Get_used_spaces()
        {
            //Returns the first empy position in array.
            for(int i = 0; i < 10; i++)
            {
                if(ordered[i] == null)
                {
                    //return last postion which has a movie in it.
                    return i;
                }
            }
            return 9;
        }

        private Boolean Exists(Movie movie)
        {
            //Check if movie already exists in list. returns true if it is in list.

            for (int i = 0; i < 10; i++)
            {
                if (ordered[i] != null)
                {
                    if(ordered[i] == movie)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

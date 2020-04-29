using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301
{
    class Ordered_list
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
                }
                //If 10 elements, see if new movie is larger than movie is 10 position
                else
                {
                    if (ordered[9].Times_rented < movie.Times_rented)
                    {
                        //Replace 10th position, will reorder later
                        ordered[9] = movie;
                        Sort(ordered ,0, Get_used_spaces());
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
                Sort(ordered,0, Get_used_spaces()-1);
            }
        }

        static private void Sort(Movie[] arr, int start, int end)
        {
            int pivot_indx = 0;

            if(start < end)
            {
                pivot_indx = Partition(arr, start, end);
                Sort(arr, start, pivot_indx - 1);
                Sort(arr, pivot_indx + 1, end);
            }
        }

        static private int Partition(Movie[] arr, int start, int end)
        {
            int pivot = arr[end].Times_rented;
            int i = start - 1;

            for(int j = start; j<end; j++)
            {
                if(arr[j].Times_rented <= pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }
            Swap(arr, i + 1, end);
            return i + 1;
        }

        static private void Swap(Movie[] arr,int a,int b)
        {
            Movie temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
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
            for(int i = 0; i < 9; i++)
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

            for (int i = 0; i < 9; i++)
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

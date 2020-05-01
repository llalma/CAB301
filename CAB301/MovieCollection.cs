using Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301
{
    public class MovieCollection
    {
        BST tree = new BST();
        Node root = null;
        Ordered_Array ordered = new Ordered_Array();

        public Node Populate()
        {
            Movie movie1 = new Movie("Movie 5", "The Rock", "No idea", 120, 2019,Genere.ACTION, Classification.MA15, 5 );
            Movie movie2 = new Movie("Movie 4", "Daniel Radcliffe", "No idea", 60, 2019, Genere.ADVENTURE, Classification.PG, 0);
            Movie movie3 = new Movie("Movie 2", "RGJ", "No idea", 240, 2011, Genere.ACTION, Classification.PG, 6);
            Movie movie4 = new Movie("Movie 1", "Chadwick Boseman", "Ryan Coogler", 60, 2014, Genere.SCI_FI, Classification.M15, 1);
            Movie movie5 = new Movie("Movie 7", "Christan Bale", "No idea", 1000, 2017, Genere.ACTION, Classification.MA15, 6);
            Movie movie6 = new Movie("Movie 6", "Chadwick Boseman", "Ryan Coogler", 60, 2019, Genere.SCI_FI, Classification.M15, 6);
            Movie movie7 = new Movie("Movie 3", "Christan Bale", "No idea", 1000, 2011, Genere.ACTION, Classification.MA15, 3);

            root = tree.Insert_node(root, movie1);
            root = tree.Insert_node(root, movie2);
            root = tree.Insert_node(root, movie3);
            root = tree.Insert_node(root, movie4);
            root = tree.Insert_node(root, movie5);
            root = tree.Insert_node(root, movie6);
            root = tree.Insert_node(root, movie7);


            return root;
        }

        public Boolean Exists(string title)
        {
            //Returns true if movie is in tree.
            if(tree.Search(root, title) != null)
            {
                return true;
            }
            return false;
        }

        public int Change_num_copies(string title,int copies)
        {
            //Increase the number of copies by the input copies. can be negative to decrease the number of copies.
            //Returns new number of copies for movies.

            Movie movie = Search(title);

            if (movie != null)
            {
                movie.Copies += copies;


                if (movie.Copies < 0)
                {
                    //If the number of copies is less than 0 remove movie from tree
                    Delete_node(title);
                    return 0;
                }
                return Search(title).Copies;
            }
            return -1;
        }

        public void Delete_node(string title)
        {
            root = tree.Delete_node(root, title);
        }

        public void Insert_node(Movie movie)
        {
            root = tree.Insert_node(root, movie);
        }

        public Movie Search(string title)
        {
            return tree.Search(root, title);
        }

        public void Print_tree()
        {
            Console.Out.WriteLine(BST.Print_tree(root,"",true,""));
        }

        public string Print_elements(string mode)
        {
            //Input can be Title to only print the titles of movies
            // or can be All to print all details about movie.

            return tree.In_order(root,mode);
        }

        public string Most_popular_list()
        {
            //Uses the list method that uses insertion sort, a list is always avaliable in top 10 order.
            return ordered.Get_list();
        }

        private void heapify(string[] movies, int n, int i)
        {
            // Find largest among root, left child and right child
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            string[] array_left = movies[left].Split(",");
            string[] array_right = movies[right].Split(",");
            string[] array_largest = movies[i].Split(",");

            //Compare first position of array as that is the number of times the movie has been rented.
            if (left < n && String.Compare(array_left[1], array_largest[1]) > 0)
                largest = left;

            if (right < n && String.Compare(array_right[1], array_largest[1]) > 0)
                largest = right;

            // Swap and continue heapifying if root is not largest
            if (largest != i)
            {
                //Swap elements of array
                string temp = movies[i];
                movies[i] = movies[largest];
                movies[largest] = temp;

                heapify(movies, n, largest);
            }
        }

        public string Most_popular_call()
        {
            //Everytime this is called a 10 ten list is  made from the tree. Reads in array using an in order read before sorting. uses min heap sort.
            string output = "";
            string[] movies = Print_elements("TOP10").Split("\n", StringSplitOptions.RemoveEmptyEntries);

            for (int i = (movies.Length-1)/2-1; i >= 0; i--)
            {
                heapify(movies, movies.Length, i);
            }

            //Just print first 10 movies.
            int length = movies.Length;

            if (length > 9)
            {
                length = 10;
            }

            for(int i = 0; i < movies.Length; i++)
            {
                string[] movie = movies[i].Split(",");

                //Only print movie if number of times rented does not == 0.
                if (movie[1] != "0")
                {
                    output = output + movie[0] + " borrowed " + movie[1] + " times\n";
                }
            }

            if(output == "")
            {
                return "No movies have ever been rented.";
            }
            else
            {
                return "Top 10 movies are:\n" + output;
            }       
        }

        public void Update_most_popular(Movie movie)
        {
            ordered.Insert(movie);
        }

        public int Length()
        {
            //Returns number of elements in tree
            return tree.Length(root);
        }
    }
}

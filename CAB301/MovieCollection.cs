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

            Movie movie = Search( title);
            movie.Copies += copies;


            if (movie.Copies < 0)
            {
                //If the number of copies is less than 0 remove movie from tree
                Delete_node( title);
                return 0;
            }
            return Search( title).Copies;
        }

        public Node Delete_node(string title)
        {
            return tree.Delete_node(root, title);
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

        public string Print_elements()
        {
            return tree.In_order(root);
        }

        public int Length()
        {
            //Returns number of elements in tree
            return tree.Length(root);
        }
    }
}

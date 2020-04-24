using System;
using Enums;

namespace CAB301
{
    class Program
    {
        static void Main(string[] args)
        {
            Movie movie1 = new Movie("Fast and Furious", "The Rock", "No idea",120, Genere.Action, Classification.MA15);
            Movie movie2 = new Movie("Harry Potter 1", "Daniel Radcliffe", "No idea", 60, Genere.Adventure, Classification.PG);
            Movie movie3 = new Movie("Avengers: Endgame", "RGJ", "No idea", 240, Genere.Action, Classification.PG);
            Movie movie4 = new Movie("Black Panther", "Chadwick Boseman", "Ryan Coogler", 60, Genere.Sci_Fi, Classification.M15);
            Movie movie5 = new Movie("The Dark Knight", "Christan Bale", "No idea", 1000, Genere.Action, Classification.MA15);

            Address address = new Address(9, 38, "Elma st", 4107, "Salisbury");
            Member member = new Member("Liam","Hulsman-Benson",address,0414984327);

            Node root = null;
            Binary_Search_Tree tree = new Binary_Search_Tree();
            root = tree.Insert_node(root,movie1);
            root = tree.Insert_node(root, movie2);
            root = tree.Insert_node(root, movie3);
            root = tree.Insert_node(root, movie4);
            root = tree.Insert_node(root, movie5);

            tree.get_tree(root);
        }
    }
}

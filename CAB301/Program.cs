using System;
using Enums;

namespace CAB301
{
    class Program
    {
        static void Main(string[] args)
        {
            //Movie collection stuff
/*            Movie movie1 = new Movie("d", "The Rock", "No idea",120, Genere.Action, Classification.MA15);
            Movie movie2 = new Movie("b", "Daniel Radcliffe", "No idea", 60, Genere.Adventure, Classification.PG);
            Movie movie3 = new Movie("f", "RGJ", "No idea", 240, Genere.Action, Classification.PG);
            Movie movie4 = new Movie("a", "Chadwick Boseman", "Ryan Coogler", 60, Genere.Sci_Fi, Classification.M15);
            Movie movie5 = new Movie("c", "Christan Bale", "No idea", 1000, Genere.Action, Classification.MA15);
            Movie movie6 = new Movie("e", "Chadwick Boseman", "Ryan Coogler", 60, Genere.Sci_Fi, Classification.M15);
            Movie movie7 = new Movie("g", "Christan Bale", "No idea", 1000, Genere.Action, Classification.MA15);

            Node root = null;
            MovieCollection tree = new MovieCollection();
            root = tree.Insert_node(root, movie1);
            root = tree.Insert_node(root, movie2);
            root = tree.Insert_node(root, movie3);
            root = tree.Insert_node(root, movie4);
            root = tree.Insert_node(root, movie5);
            root = tree.Insert_node(root, movie6);
            root = tree.Insert_node(root, movie7);
            root = tree.Insert_node(root, movie7);

            Console.WriteLine(MovieCollection.Print_tree(root, "", true, ""));
*/

            //Member stuff
            Address address = new Address(9, 38, "Elma st", 4107, "Salisbury");
            Member member = new Member("Liam","Hulsman-Benson",address,0414984327);

            MemberCollection members = new MemberCollection();
            members.Add(member);

            

           
        }
    }
}

using CAB301;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Enums;
using System;


namespace CAB301Tets
{
    [TestClass]
    public class UnitTest1
    {
        private Movie movie1, movie2, movie3, movie4, movie5, movie6, movie7;
        private Node root;
        private Binary_Search_Tree tree;

        [TestInitialize]
        public void TestInitialize()
        {
            movie1 = new Movie("c", "The Rock", "No idea", 120, Genere.Action, Classification.MA15);
            movie2 = new Movie("b", "Daniel Radcliffe", "No idea", 60, Genere.Adventure, Classification.PG);
            movie3 = new Movie("f", "RGJ", "No idea", 240, Genere.Action, Classification.PG);
            movie4 = new Movie("d", "Chadwick Boseman", "Ryan Coogler", 60, Genere.Sci_Fi, Classification.M15);
            movie5 = new Movie("a", "Christan Bale", "No idea", 1000, Genere.Action, Classification.MA15);
            movie6 = new Movie("e", "Chadwick Boseman", "Ryan Coogler", 60, Genere.Sci_Fi, Classification.M15);
            movie7 = new Movie("g", "Christan Bale", "No idea", 1000, Genere.Action, Classification.MA15);
        }

        [TestMethod]
        public void TestMethod1()
        {
            //Test the adding to tree is correct. Assumes print tree is correct

            //Create Movies
            Movie movie1 = new Movie("c", "The Rock", "No idea", 120, Genere.Action, Classification.MA15);
            Movie movie2 = new Movie("b", "Daniel Radcliffe", "No idea", 60, Genere.Adventure, Classification.PG);
            Movie movie3 = new Movie("f", "RGJ", "No idea", 240, Genere.Action, Classification.PG);
            Movie movie4 = new Movie("d", "Chadwick Boseman", "Ryan Coogler", 60, Genere.Sci_Fi, Classification.M15);
            Movie movie5 = new Movie("a", "Christan Bale", "No idea", 1000, Genere.Action, Classification.MA15);
            Movie movie6 = new Movie("e", "Chadwick Boseman", "Ryan Coogler", 60, Genere.Sci_Fi, Classification.M15);
            Movie movie7 = new Movie("g", "Christan Bale", "No idea", 1000, Genere.Action, Classification.MA15);

            //Add movies to tree
            Node root = null;
            Binary_Search_Tree tree = new Binary_Search_Tree();
            root = tree.Insert_node(root, movie1);
            root = tree.Insert_node(root, movie2);
            root = tree.Insert_node(root, movie3);
            root = tree.Insert_node(root, movie4);
            root = tree.Insert_node(root, movie5);
            root = tree.Insert_node(root, movie6);
            root = tree.Insert_node(root, movie7);


            string expected = "+ -:c\n + -Left:b\n | +-Left:a\n + -Right:f\n + -Left:d\n | +-Right:e\n + -Right:g\n";


            Console.Out.WriteLine(expected);

            string result = Binary_Search_Tree.Print_tree(root, "", true, "");

            Console.Out.WriteLine(result);

            Assert.AreEqual(expected, result);
        }
    }
}

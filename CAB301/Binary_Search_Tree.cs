using Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301
{
    class Node
    {
        //Use sum of title as key for movies, not a great solution, probs need a better idea
        public int key;
        public Movie movie;
        public Node left;
        public Node right;

        public Node(Movie movie)
        {
            this.key = movie.get_sum_of_title();
            this.movie = movie;
        }
    }
    class Binary_Search_Tree
    {
        //All nodes to left of current key are less

        public Node Insert_node(Node current_node,Movie movie)
        {
            if(current_node == null)
            {
                //If no root node
                current_node = new Node(movie);
            }
            else if (movie.get_sum_of_title() < current_node.key)
            {
                //key is less than current node, so go to left of current node
                current_node.left = Insert_node(current_node.left, movie);

            }
            else
            {
                //key is greater than current node, so go to right of current node
                current_node.right = Insert_node(current_node.right, movie);

            }

            return current_node;        
        }

        public Movie Search(Movie movie)
        {
            return new Movie("Fast and Furious", "The Rock", "No idea", 120, Genere.Action, Classification.MA15);
        }

        public Movie Search(int pos)
        {
            return new Movie("Fast and Furious", "The Rock", "No idea", 120, Genere.Action, Classification.MA15);
        }

        public void Delete_node(int pos)
        {

        }

        public void get_tree(Node root)
        {
            //Print Tree vertically
            int gap = 10;
            int[] output = new int[100];
            
            if(root == null)
            {
                //No data
                return;
            }

            //Print right side of tree first
            if(root.right != null)
            {
                get_tree(root.right);
            }
            
            
            




            
        }       
    }
}

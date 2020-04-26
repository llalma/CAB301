using Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301
{
    public class Node
    {
        //Use movie title as key. compares string using String.compare()
        public Movie movie;
        public Node left;
        public Node right;

        public Node(Movie movie)
        {
            this.movie = movie;
            this.left = null;
            this.right = null;
        }
    }

    public class MovieCollection
    {
        public Node Insert_node(Node root,Movie movie)
        {
            if(root == null)
            {
                //If no root node
                root = new Node(movie);
            }
            else if (String.Compare(movie.Title, root.movie.Title) < 0)
            {
                //key is less than current node, so go to left of current node
                root.left = Insert_node(root.left, movie);

            }
            else
            {
                //key is greater than current node, so go to right of current node
                root.right = Insert_node(root.right, movie);

            }

            return root;        
        }

        public Movie Search(Node root,string title)
        {
            //Find a movie in the tree by title.
            if(root == null)
            {
                //If movie not in tree
                return null;
            }
            else if(String.Compare(title,root.movie.Title) == 0)
            {
                //Same movie
                return root.movie;
            }
            else if (String.Compare(title, root.movie.Title) < 0)
            {
                //key less than current
                return Search(root.left, title);
            }
            else
            {
                //key to right
                return Search(root.right, title);
            }
        }

        private Node One_child_delete(Node root)
        {    
            //Return node when there is only 1 child.
            if(root.left == null)
            {
                return root.right;
            }
            else
            {
                return root.left;
            }
        }

        private Movie Min_key(Node root)
        {
            //Find in order sucessor to cuurrent root. basically find smallest value to right of current node
            //Given value when initially calling, is right of root wanted to find.

            while(root.left != null)
            {
                return Min_key(root.left);
            }
            return root.movie;
        }

        public Node Delete_node(Node root, string title)
        {
            //Delete Nofe from tree given a title of a movie

            //If tree is empty
            if (root == null)
            {
                return root;
            }

            //Search until key is found
            if(String.Compare(title,root.movie.Title) < 0)
            {
                //Move left
                root.left = Delete_node(root.left, title);
            }
            else if(String.Compare(title, root.movie.Title) > 0)
            {
                //Move right
                root.right = Delete_node(root.right, title);
            }
            else
            {
                //Remove this Node

                //Root has no children
                if(root.left == null && root.right == null)
                {
                    return null;
                }
                //Root only has 1 child.
                if(root.left != null ^ root.right != null)
                {
                    return One_child_delete(root);
                }
                //Root has 2 children.
                else
                {
                    //Make min key to right of current node, the current node.
                    root.movie = Min_key(root.right);
                    //Delete node you just made current node so there are no duplciates.
                    root.right = Delete_node(root.right, root.movie.Title);
                }
            }
            return root;
        }

        public static string Print_tree(Node root, String indent, Boolean last, string direction)
        {
            //Returns a string of the output of the current tree.
            //when calling use the following command Print_tree(root, "", true,"")

            string output = "";
            output += indent + "+ -" + direction + ":" + root.movie.Title + "\n";
            //Console.WriteLine(indent + "+-" + direction + ":" + root.movie.Title);
            indent += last ? "   " : "|  ";

            //Get Number of children in tree
            int childern_count = 0;
            if(root.left != null)
            {
                childern_count++;
            }
            if (root.right != null)
            {
                childern_count++;
            }

            if (childern_count == 1)
            {
                //If only 1 child print the child
                if(root.left != null)
                {
                    output += Print_tree(root.left, indent, true, "Left");
                }
                else
                {
                    output+= Print_tree(root.right, indent, true, "Right");
                }
            }
            else if(childern_count == 2)
            {
                //If 2 children print both children
                output += Print_tree(root.left, indent, false,"Left");
                output += Print_tree(root.right, indent, true,"Right");
            }

            return output;
        }

        public Boolean Exists(Node root, string title)
        {
            //Returns true if movie is in tree.
            if(Search(root, title) != null)
            {
                return true;
            }
            return false;
        }

        public int Change_num_copies(Node root,string title,int copies)
        {
            //Increase the numebr of copies by the input copies. can be negative to decrease the number of copies.
            //Returns new number of copies for movies.

            Movie movie = Search(root, title);
            movie.Copies += copies;


            if (movie.Copies <= 0)
            {
                //If the number of copies is 0 or goes below it remove movie from tree
                Delete_node(root, title);
                return 0;
            }
            return Search(root, title).Copies;
        }
    }
}

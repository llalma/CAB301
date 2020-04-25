using System;
using System.Collections.Generic;
using System.Text;
using Enums;

// 0 = main menu
// 1 = staff login
// 2 = staff menu
// 3 = add new movie for staff
// 4 = remove movie for staff

namespace CAB301
{
    class GUI
    {
        MovieCollection movies = new MovieCollection();
        Node root = null;
        Boolean exit = false;
        int screen = 0;

        public GUI()
        {
            while (exit == false)
            {
                if (screen == 0)
                {
                    Main_menu();
                }else if (screen == 1)
                {
                    Staff_login();
                }else if (screen == 2)
                {
                    Staff_menu();
                }else if(screen == 3)
                {
                    Add_new_movie();
                }else if(screen == 4)
                {
                    Remove_movie();
                }
                //Clear console
                Console.Clear();
            }
        }

        private void Main_menu()
        {
            Console.WriteLine("Welcome to the Community Library");
            Console.WriteLine("=============Main Menu============");
            Console.WriteLine("1. Staff Login");
            Console.WriteLine("2. Member Login");
            Console.WriteLine("0. Exit");
            Console.WriteLine("==================================");
            Console.WriteLine("Please make a selction  (1-2, or 0 for exit):");

            ConsoleKey key = Console.ReadKey().Key;
            //Add a line between user input and next print statement
            Console.WriteLine("");


            if (key == ConsoleKey.D0 || key == ConsoleKey.NumPad0)
            {
                exit = true;
            }
            else if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
            {
                //Next screen is staff login
                screen = 1;
            }
            else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
            {
                //Next screen is member login
                screen = 2;
            }
            else
            {
                //Invalid key
                screen = 0;
                Console.Out.WriteLine("Invalid Key please try again");
            }
        }

        private void Staff_login()
        {
            Console.WriteLine("===========Staff Login==========");
            Console.WriteLine("Username: ");
            string username = Console.ReadLine();

            Console.WriteLine("Password: ");
            string password = Console.ReadLine();

            if(String.Compare(username,"staff") == 0 && String.Compare(password, "today123") == 0)
            {
                //Successful login, next screen is staff menu.
                screen = 2;
            }
            else
            {
                //Incorrect login, next screen is main menu.
                Console.WriteLine("Incorrect Login");
                screen = 0;
            }
        }

        private void Add_new_movie()
        {
            Console.WriteLine("===========Add New Movie==========");
            Console.WriteLine("Title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Starring: ");
            string starring = Console.ReadLine();

            Console.WriteLine("Director: ");
            string director = Console.ReadLine();

            Console.WriteLine("Duration: ");
            int duration = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Genere: ");
            Genere genere = (Genere)Enum.Parse(typeof(Genere), Console.ReadLine().ToUpper());

            Console.WriteLine("Classification: ");
            Classification classification = (Classification)Enum.Parse(typeof(Classification), Console.ReadLine().ToUpper());

            //Add Movie to MovieCollection
            Movie movie = new Movie(title, starring, director, duration, genere, classification);
            root = movies.Insert_node(root,movie);
        }
        
        private void Remove_movie()
        {
            Console.WriteLine("===========Remove Movie==========");
            Console.WriteLine("Title: ");
            string title = Console.ReadLine();

            root = movies.Delete_node(root, title);
        }

        private void Staff_menu()
        {
            Console.WriteLine("===========Staff Menu==========");
            Console.WriteLine("1. Add a new movie DVD");
            Console.WriteLine("2. Remove a movie DVD");
            Console.WriteLine("3. Register a new Member");
            Console.WriteLine("4. Find a registerd member's phone number");
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("=================================");
            Console.WriteLine("Please make a selection (1-4 or 0 to return to main menu): ");

            ConsoleKey key = Console.ReadKey().Key;
            //Add a line between user input and next print statement
            Console.WriteLine("");

            if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
            {
                //Next screen is Add movies to library
                screen = 3;
            }
            if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
            {
                //Next screen is remove dvd from library
                screen = 4;
            }
        }

        private void Member_menu()
        {
            Console.WriteLine("===========Member Menu===========");
            Console.WriteLine("1. Display all movies");
            Console.WriteLine("2. Borrow a movie DVD");
            Console.WriteLine("3. Return a movie DVD");
            Console.WriteLine("4. List current borrowed movie DVDs");
            Console.WriteLine("5. Display top 10 most popular movies");
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("=================================");
            Console.WriteLine("Please make a selection (1-5 or 0 to return to main menu):");

            ConsoleKey key = Console.ReadKey().Key;
            //Add a line between user input and next print statement
            Console.WriteLine("");
        }


    }
}

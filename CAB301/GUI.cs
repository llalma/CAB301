using System;
using System.Collections.Generic;
using System.Text;
using Enums;

//assuming when deleting movie from movie colection it deletes all copies of the movie.

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
        string error = "";

        public GUI()
        {   
            while (exit == false)
            {
                //Print error message as console is cleared after each loop. after printing clear error message.
                Console.WriteLine(error);
                error = "";

                if (screen == 0)
                {
                    Main_menu();
                }else if (screen == 1)
                {
                    Staff_login();
                }
                else if (screen == 2)
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
            //Allows for blank passwords but not blank usernames. casesensative for username and password

            Console.WriteLine("===========Staff Login==========");
            string username = "";

            //Loop until a user name which is not blank is inputted
            while(username == "")
            {
                Console.WriteLine("Username: ");
                username = Console.ReadLine();
            }

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
                screen = 0;
                error = "Incorrect login information\n";
            }
        }

        private int Select_Genere()
        {
            int num_of_enums = Enum.GetNames(typeof(Genere)).Length;
            for (int i = 0; i < num_of_enums; i++)
            {
                Console.WriteLine(i+1 + ". " + (Genere)i);
            }

            Console.Out.WriteLine("Make Selection (1-" + num_of_enums + "): ");

            if(Int32.TryParse(Console.ReadLine(), out int selection))
            {
                return selection-1;
            }
            else
            {
                Console.WriteLine("Input error");
                return -1;
            }
        }

        private int Select_Classification()
        {
            int num_of_enums = Enum.GetNames(typeof(Classification)).Length;
            for (int i = 0; i < num_of_enums; i++)
            {
                Console.WriteLine(i+1 + ". " + (Classification)i);
            }

            Console.Out.WriteLine("Make Selection (1-" + num_of_enums + "): ");

            if (Int32.TryParse(Console.ReadLine(), out int selection))
            {
                return selection-1;
            }
            else
            {
                Console.WriteLine("Input error");
                return -1;
            }
        }

        private int Select_int_from_input()
        {
            //Cannot use release date of -1. all other int values are fines
            if (Int32.TryParse(Console.ReadLine(), out int selection))
            {
                return selection;
            }
            else
            {
                Console.WriteLine("Input error");
                return -1;
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

           
            int duration = -1;
            while (duration == -1)
            {
                Console.WriteLine("Duration: ");
                duration = Select_int_from_input();
            }

            //Loop until a valid Genere is selected  
            int selection = -1;
            while (selection < 0 || selection > 8) 
            {
                Console.WriteLine("Genere: ");
                selection = Select_Genere();
            }
            Genere genere = (Genere)selection;

            //Loop until a valid Classification is selected
            selection = -1;
            while(selection < 0 || selection > 3)
            {
                Console.WriteLine("Classification: ");
                selection = Select_Classification();
            }
            Classification classification = (Classification)selection;

            //Loop until a valid Year is selected
            int release_date = -1;
            while (release_date == -1)
            {
                Console.WriteLine("Release Date(Year): ");
                release_date = Select_int_from_input();
            }

            //Add Movie to MovieCollection
            Movie movie = new Movie(title, starring, director, duration, release_date, genere, classification);
            root = movies.Insert_node(root,movie);

            //Message if addition of movie worked or not
            if(movies.Moive_exists(root,title))
            {
                error = title + " successfully added to MovieCollection";
            }
            else
            {
                error = "Adding " + title +" failed";
            }
            screen = 2;
        }
        
        private void Remove_movie()
        {
            //Will say successfully removed movie even if movie wasnt originally in list.

            Console.WriteLine("===========Remove Movie==========");
            Console.WriteLine("Title: ");
            string title = Console.ReadLine();

            root = movies.Delete_node(root, title);

            //Message if removing movie worked or not
            if (!movies.Moive_exists(root, title))
            {
                error = title + " successfully removed from MovieCollection";
            }
            else
            {
                error = "Removing " + title + " failed";
            }
            screen = 2;
        }

        private void Resgister_member()
        {
            Console.WriteLine("===========Register Member==========");
            Console.WriteLine("Title: ");
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

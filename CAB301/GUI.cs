using System;
using System.Collections.Generic;
using System.Text;
using Enums;

//assuming when deleting movie from movie colection it deletes all copies of the movie.
//assuming when renting number of copies is reduced in moviecollection

// 0 = main menu
// 1 = staff login
// 2 = staff menu
// 3 = add new movie for staff
// 4 = remove movie for staff
// 5 = Show number of copies for staff

namespace CAB301
{
    class GUI
    {
        MovieCollection movies = new MovieCollection();
        MemberCollection members = new MemberCollection();
        Node root = null;
        Boolean exit = false;
        Screens screen = Screens.Main_menu;
        string error = "";

        public GUI()
        {   
            while (exit == false)
            {
                //Print error message as console is cleared after each loop. after printing clear error message.
                Console.WriteLine(error);
                error = "";

                if (screen == Screens.Main_menu)
                {
                    Main_menu();
                }else if (screen == Screens.Staff_login)
                {
                    Staff_login();
                }
                else if (screen == Screens.Staff_menu)
                {
                    Staff_menu();
                }else if(screen == Screens.Add_movie)
                {
                    Add_new_movie();
                }else if(screen == Screens.Remove_movie)
                {
                    Remove_movie();
                }else if(screen == Screens.Show_copies)
                {
                    show_copies();
                }else if(screen == Screens.Add_member)
                {
                    Resgister_member();
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
                screen = Screens.Staff_login;
            }
            else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
            {
                //Next screen is member login
                screen = Screens.Member_login;
            }
            else
            {
                //Invalid key
                screen = Screens.Main_menu;
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
                screen = Screens.Staff_menu;
            }
            else
            {
                //Incorrect login, next screen is main menu.
                screen = Screens.Main_menu;
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
            //Read intger from user input.
            if (Int32.TryParse(Console.ReadLine(), out int selection))
            {
                return selection;
            }
            return 0;
        }

        private void Add_new_movie()
        {
            Console.WriteLine("===========Add New Movie==========");
            Console.WriteLine("Title: ");
            string title = Console.ReadLine();

            if (movies.Exists(root,title))
            {
                //Movie already existed in tree, so change number of copies by input value. can be -ve, if number of copies goes to <= 0 movie is deleted from tree.

                //Loop until a valid number of copies is selected
                int num_copies = 0;
                while (num_copies == 0)
                {
                    Console.WriteLine("Enter the number of copies you would like to adjust the number of copies by: ");
                    num_copies = Select_int_from_input();

                    //Error message
                    if (num_copies == 0)
                    {
                        Console.Out.WriteLine("Input must not be 0, can be negative");
                    }
                    else
                    {
                        //output if movie is deleted from movies cause the number of copies is less than 1.
                        int output = movies.Change_num_copies(root, title, num_copies);
                        if (output == 0)
                        {
                            error = title + " Removed from tree";
                        }
                        else
                        {
                            //outputs for adding and removing copies of movies.
                            if(num_copies < 0)
                            {
                                error = -1 * num_copies + " copies of " + title + " removed.";
                            }
                            else
                            {
                                error = num_copies + " copies of " + title + " added.";

                            }
                        }
                       
                    }
                }

                
            }
            else
            {
                //Movie does not exit in tree, so add to tree
                Console.WriteLine("Starring: ");
                string starring = Console.ReadLine();

                Console.WriteLine("Director: ");
                string director = Console.ReadLine();


                int duration = 0;
                while (duration <= 0)
                {
                    Console.WriteLine("Duration: ");
                    duration = Select_int_from_input();

                    //Error message
                    if (duration <= 0)
                    {
                        Console.Out.WriteLine("Input must be greater than 0");
                    }
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
                while (selection < 0 || selection > 3)
                {
                    Console.WriteLine("Classification: ");
                    selection = Select_Classification();
                }
                Classification classification = (Classification)selection;

                //Loop until a valid Year is selected
                int release_date = 0;
                while (release_date <= 0)
                {
                    Console.WriteLine("Release Date(Year): ");
                    release_date = Select_int_from_input();

                    //Error message
                    if (release_date <= 0)
                    {
                        Console.Out.WriteLine("Input must be greater than 0");
                    }
                }

                //Loop until a valid number of copies is selected
                int num_copies = -1;
                while (num_copies < 1)
                {
                    Console.WriteLine("Number of copies: ");
                    num_copies = Select_int_from_input();

                    //Error message
                    if (num_copies <= 0)
                    {
                        Console.Out.WriteLine("Input must be greater than or equal to 1");
                    }
                }

                //Add Movie to MovieCollection
                Movie movie = new Movie(title, starring, director, duration, release_date, genere, classification, num_copies);
                root = movies.Insert_node(root, movie);

                //Message if addition of movie worked or not
                if (movies.Exists(root, title))
                {
                    error = title + " successfully added to MovieCollection";
                }
                else
                {
                    error = "Adding " + title + " failed";
                }
            }

            
            screen = Screens.Staff_menu;
        }

        private void Remove_movie()
        {
            //Will say successfully removed movie even if movie wasnt originally in list.

            Console.WriteLine("===========Remove Movie==========");
            Console.WriteLine("Title: ");
            string title = Console.ReadLine();

            root = movies.Delete_node(root, title);

            //Message if removing movie worked or not
            if (!movies.Exists(root, title))
            {
                error = title + " successfully removed from MovieCollection";
            }
            else
            {
                error = "Removing " + title + " failed";
            }
            screen = Screens.Staff_menu;
        }

        private void show_copies()
        {
            Console.WriteLine("===========Show remianing copies==========");
            Console.WriteLine("Title: ");
            string title = Console.ReadLine();

            if (movies.Exists(root, title))
            {
                error = movies.Search(root, title).Copies + " of " + title + " are in the library.";
            }
            else
            {
                error = "Movie does not exist";
            }
            
            screen = Screens.Staff_menu;
        }

        private Int64 check_input_phone_number()
        {
            //Read phone number from user input.
            //needs sperate reading from Select_int_from_input as this needs to return an int64.
            if (Int64.TryParse(Console.ReadLine(), out Int64 selection))
            {
               return selection;
            }
            return 0;
        }

        private Boolean Password_check(string password)
        {
            //A true return is a valid password.
            return password.Length == 4;
        }

        private void Resgister_member()
        {
            Console.WriteLine("===========Register Member==========");
            Console.WriteLine("First name: ");
            string first_name = Console.ReadLine();

            Console.WriteLine("Last name: ");
            string last_name =  Console.ReadLine();

            if (members.Exists(first_name, last_name))
            {
                //Member exists
                error = "Member with name "+ first_name + " " + last_name +" already exists";
            }
            else
            {
                //Member does not exist

                //Street number, loop until number greater than 0
                int street_number = 0;
                while (street_number <= 0)
                {
                    Console.WriteLine("Street Number: ");
                    street_number = Select_int_from_input();

                    //Error message
                    if (street_number <= 0)
                    {
                        Console.Out.WriteLine("Input must be greater than 0");
                    }
                }

                //Street name
                Console.WriteLine("Street name: ");
                string street_name = Console.ReadLine();

                //Subrub name
                Console.WriteLine("Suburb name: ");
                string Suburb_name = Console.ReadLine();

                //Phone number, loop until valid number
                Int64 phone_number = 0;
                while (phone_number >= 1000000000 && phone_number <= 9999999999)
                {
                    phone_number = check_input_phone_number();

                    //Error message
                    if (phone_number <= 0)
                    {
                        Console.Out.WriteLine("Input error");
                    }
                }

                //4 digit password
                string password = "";
                while (!Password_check(password))
                {
                    Console.WriteLine("Password (4 digits): ");
                    password = Console.ReadLine();

                    //Error message
                    if (!Password_check(password))
                    {
                        Console.Out.WriteLine("Input error");
                    }
                }


                //Create member and add to MemberColelction
                Address address = new Address(street_number, street_name, Suburb_name);
                Member member = new Member(first_name, last_name, address, phone_number, password);
                members.Add(member);

                //Message if addition of movie worked or not
                if (members.Exists(first_name,last_name))
                {
                    error = first_name + " " + last_name + " successfully added to MovieCollection";
                }
                else
                {
                    error = "Adding " + first_name + " " + last_name + " failed";
                }
                screen = Screens.Staff_menu;
            }
        }

        private void Staff_menu()
        {
            Console.WriteLine("===========Staff Menu==========");
            Console.WriteLine("1. Add a new movie DVD");
            Console.WriteLine("2. Remove a movie DVD");
            Console.WriteLine("3. Register a new Member");
            Console.WriteLine("4. Find a registerd member's phone number");
            Console.WriteLine("5. Show number of copies remaining");
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("=================================");
            Console.WriteLine("Please make a selection (1-4 or 0 to return to main menu): ");

            ConsoleKey key = Console.ReadKey().Key;
            //Add a line between user input and next print statement
            Console.WriteLine("");

            if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
            {
                //Next screen is Add movies to library
                screen = Screens.Add_movie;
            }
            else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
            {
                //Next screen is remove movie from library
                screen = Screens.Remove_movie;
            }
            else if (key == ConsoleKey.D5 || key == ConsoleKey.NumPad5)
            {
                //Next screen is show number of copies in library
                screen = Screens.Show_copies;
            }
            else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
            {
                screen = Screens.Add_member;
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

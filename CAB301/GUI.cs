using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
        Boolean exit = false;
        Screens screen = Screens.Main_menu;
        string error = "";
        string logged_in = "";



        public GUI()
        {
            //This is the main function which switches between screens in the GUI.

            //Populate member and movie data
            Populate();

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
                }else if(screen == Screens.Add_member)
                {
                    Register_member();
                }else if(screen == Screens.Get_number)
                {
                    Get_number();
                }else if(screen == Screens.Member_login)
                {
                    Member_login();
                }else if(screen == Screens.Member_menu)
                {
                    Member_menu();
                }else if(screen == Screens.Display_movies)
                {
                    Display_movies();
                }else if(screen == Screens.Rent_movie)
                {
                    Rent_movie();
                }else if(screen == Screens.Return_movie)
                {
                    Return_movie();
                }else if(screen == Screens.Borrowed_movies) {
                    Show_borrowed_movies();
                }else if(screen == Screens.Most_popular)
                {
                    Most_popular();
                }
                //Clear console
                Console.Clear();
            }
        }

        private void Populate()
        {
            movies.Populate();
            members.Populate();
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
                error = "Invalid Key please try again";
            }
        }

        /// <summary>
        /// Staff functions below
        /// </summary>
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
            string title = Console.ReadLine().ToUpper();

            if (movies.Exists(title))
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
                        int output = movies.Change_num_copies(title, num_copies);
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
                movies.Insert_node( movie);

                //Message if addition of movie worked or not
                if (movies.Exists( title))
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
            string title = Console.ReadLine().ToUpper();

            movies.Delete_node(title);

            //Message if removing movie worked or not
            if (!movies.Exists(title))
            {
                error = title + " successfully removed from MovieCollection";
            }
            else
            {
                error = "Removing " + title + " failed";
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
            //Return true if password is length of 4 and only using numbers.
            
            //Check string is length of 4
            if(password.Length != 4)
            {
                return false;
            }

            //Check array only contains numbers
            char[] arr = password.ToCharArray();
            for (int i = 0; i < 4; i++)
            {
                //Check each digit is a integer.
                if ((int)arr[i] < (int)'0' || (int)arr[i] > (int)'9')
                {
                    return false;
                }
            }

            return true;       
        }

        private void Register_member()
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
                Console.WriteLine("Phone Number: ");
                Int64 phone_number = check_input_phone_number();

                //4 digit password
                string password = "";
                while (!Password_check(password))
                {
                    Console.WriteLine("Password (4 digits): ");

                    //Prevents non digit inputs
                    password = Console.ReadLine();


                    //Error message, password_check prevents negative numbers and numbers not length of 4.
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
            }
            screen = Screens.Staff_menu;
        }

        private void Get_number()
        {
            Console.WriteLine("===========Get Members Number==========");
            Console.WriteLine("First name: ");
            string first_name = Console.ReadLine();

            Console.WriteLine("Last name: ");
            string last_name = Console.ReadLine();

            //Output message and return to staff menu screen
            Int64 number = members.Get_members_number(first_name, last_name);

            if(number == -1)
            {
                error = "User does not exist";
            }
            else
            {
                error = first_name + " " + last_name + " Phone number is: " + number;
            }
            screen = Screens.Staff_menu;
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
                screen = Screens.Add_movie;
            }
            else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
            {
                //Next screen is remove movie from library
                screen = Screens.Remove_movie;
            }
            else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
            {
                screen = Screens.Add_member;
            }
            else if (key == ConsoleKey.D4 || key == ConsoleKey.NumPad4)
            {
                screen = Screens.Get_number;
            }
            else if (key == ConsoleKey.D0 || key == ConsoleKey.NumPad0)
            {
                screen = Screens.Main_menu;
            }
            else
            {
                //Not needed but to simplify reading the code.
                error = "Invalid input";
                screen = Screens.Staff_menu;
            }
        }

        /// <summary>
        /// Member functions below
        /// </summary>

        private void Member_login()

        {
            //Allows for blank passwords but not blank usernames. casesensative for username and password

            Console.WriteLine("===========Member Login==========");
            string username = "";

            //Loop until a user name which is not blank is inputted
            while (username == "")
            {
                Console.WriteLine("Username (LastNameFirstName): ");
                username = Console.ReadLine();
            }

            Console.WriteLine("Password: ");
            string password = Console.ReadLine();

            if (members.Check_login_info(username.ToUpper(),password))
            {
                //Successful login, next screen is staff menu.
                screen = Screens.Member_menu;
                logged_in = username.ToUpper();
            }
            else
            {
                //Incorrect login, next screen is main menu.
                screen = Screens.Main_menu;
                error = "Incorrect login information\n";
            }
        }

        private void Display_movies()
        {
            error = movies.Print_elements("All");
            if(error == "")
            {
                error = "No movies in the library";
            }
            screen = Screens.Member_menu;
        }

        private void Rent_movie()
        {
            Console.WriteLine("===========Rent Movie==========");
            Console.WriteLine("Title: ");
            string title = Console.ReadLine();
            Movie movie = movies.Search(title.ToUpper());

            if (movie != null && movie.Copies > 0)
            {
                error = members.Rent(logged_in,movie);

                //Increaes the number of times rented, using the statement below instead of passing movie colleciton into the functions.
                if (error.Contains("successfully"))
                {
                    //Increase times rentedand remove 1 from avaliable copies in libarary
                    movie.Increase_times_rented();
                    //Check if list needs to be updated, for movies most times rented
                    movies.Update_most_popular(movie);
                }
            }
            else
            {
                error = "The library does not have a copy of " + title;
            }
            //Return to Member menu
            screen = Screens.Member_menu;
        }

        private void Return_movie()
        {
            Console.WriteLine("===========Return Movie==========");
            Console.Out.WriteLine("Title: ");
            string title = Console.ReadLine();
            Movie movie = movies.Search(title.ToUpper()); ;

            //Return movie
            error = members.Return(logged_in, movie);

            if (error.Contains(movie.Title))
            {
                movies.Change_num_copies(title.ToUpper(), 1);
            }
           
            //Return to member menu.
            screen = Screens.Member_menu;
        }

        private void Show_borrowed_movies()
        {
            error = members.Borrowed(logged_in);

            //If no movies were rented.
            if(error == "")
            {
                error = "You do not have any movies rented";
            }
            else
            {
                //Add some text to start of message
                error = "You have the following movies rented:\n" + error;
            }

            screen = Screens.Member_menu;
        }

        private void Most_popular()
        {
            //Can switch comments for the 2 lines below to switch between the method which calls a function to sort and the list method.
            //Currently the call method is being used.
            //error = movies.Most_popular_list();
            error = movies.Most_popular_call();

            screen = Screens.Member_menu;
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

            if (key == ConsoleKey.D0 || key == ConsoleKey.NumPad0)
            {
                //Next screen is Main menu
                screen = Screens.Main_menu;

                //Log out user.
                logged_in = "";
            }
            else if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
            {
                //Next screen is Show movies
                screen = Screens.Display_movies;
            }
            else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
            {
                //Next screen is Show movies
                screen = Screens.Rent_movie;
            }else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
            {
                screen = Screens.Return_movie;
            }
            else if (key == ConsoleKey.D4 || key == ConsoleKey.NumPad4)
            {
                screen = Screens.Borrowed_movies;
            }
            else if (key == ConsoleKey.D5 || key == ConsoleKey.NumPad5)
            {
                screen = Screens.Most_popular;
            }
            else
            {
                error = "Invalid input";
                screen = Screens.Member_menu;
            }
        }




    }
}

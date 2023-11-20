using System;

namespace Cinema
{
    class Cinema
    {
        static string[] Movies = new string[] { };
        static void Main(string[] args)
        {

            StartingPoint();
            Console.ReadKey();
        }

        static void StartingPoint()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("WELCOME TO THE CINEMA OF CHRIS");
            Console.WriteLine("-------------------------------");

            Console.WriteLine("Who is Going to WATCH ? ");
            Console.WriteLine("User Or Manager");
            string UserInput = Console.ReadLine();

            if (UserInput == "Manager")
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("Welcome To Manger Menu\n");
                Console.WriteLine("Please Enter The Code : \n");
                Console.WriteLine("---------------------------");
                string ManagerInput = Console.ReadLine();

                if(ManagerInput == "Manager123") // THE CODE TO ENTER THE MANAGEMENT MOVIE MENU
                {
                    ManagerMenu();
                }
                else
                {
                    Console.WriteLine($"{ManagerInput} is Wrong Returning to Starting Point...");
                    StartingPoint();
                }
            }
            else
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine("MOVIES THAT ARE AVAILABLE");
                DisplayMovie();
                Console.WriteLine("--------------------------");

                for (int i = 0; i < Movies.Length; i++)
                {
                    Console.WriteLine($"{Movies[i]}");
                }

                Console.WriteLine("Return to the MainPoint By Pressing E");
                string choice = Console.ReadLine();

                if(choice == "E")
                {
                    ConfirmExit();
                }
            }
        }

        static void ConfirmExit()
        {
            Console.WriteLine("Press Y For Exiting The Cinema Program\n");
            Console.WriteLine("Press N For Going Back to the Cinema Menu\n");
            string confirm = Console.ReadLine();

            if (confirm.ToUpper() == "Y")
            {
                Console.WriteLine("Exiting the Main Cinema Porgram...");
            }

            else if (confirm.ToUpper() == "N")
            {
                StartingPoint();
            }

            else
            {
                Console.WriteLine("Invalid choice. Please enter 'Y' or 'N'.");
                ConfirmExit();
            }

        }


        static void ManagerMenu()
        {
            while (true)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("1. Add A New Movie To Users Menu");
                Console.WriteLine("2. Delete The Movie From Users Menu");
                Console.WriteLine("3. Display Current Moveis");
                Console.WriteLine("4. Exit From The Managers Menu");
                Console.WriteLine("-------------------------------------"); // DROP DOWN MANAGERS MENU

                int ManagersChoice;
                if (!int.TryParse(Console.ReadLine(), out ManagersChoice) || ManagersChoice > 4)
                {
                    Console.WriteLine("Enter A Right Type Of Choice");
                }

                switch (ManagersChoice)
                {
                    case 1:
                        AddMovie();
                        break;

                    case 2:
                        RemoveMovie();
                        break;

                    case 3:
                        DisplayMovie();
                        break;

                    case 4:
                        StartingPoint();
                        return;
                }
            }
        }

        static void AddMovie()
        {
            Console.WriteLine("Enter The Name Of the Movie");
            string movieInput = Console.ReadLine();


            if(Array.Exists(Movies, elements => elements ==  movieInput)) // TYPE TO ALREADY EXISTING MOVIES 
            {
                Console.WriteLine($"{movieInput} is Already in the Current Movies");
            }
            else
            {
                bool added = false;


                for (int i = 0; i < Movies.Length; i++)
                {
                    if (Movies[i] == null)
                    {
                        Movies[i] = movieInput;
                        added = true;
                        Console.WriteLine($"{movieInput} Has been Added");
                        break;
                    }
                }

                if (!added)
                {
                    Array.Resize(ref Movies, Movies.Length + 1);
                    Movies[Movies.Length - 1] = movieInput;
                    Console.WriteLine($"'{movieInput}' Has been added to the movies list.");
                }
            }
        }

        static void RemoveMovie()
        {
            Console.WriteLine("Enter The Movie That You Want to Remove");
            string movieToRemove = Console.ReadLine();

            bool removed = false;
            bool movieFound = false;

            for(int i = 0; i < Movies.Length;i++)
            {
                if (Movies[i] == movieToRemove)
                {
                    Movies[i] = null;
                    removed = true;
                    Console.WriteLine($"{movieToRemove} Has Been Removed From The List");
                    break;
                }
            }

            if(!removed)
            {
                Console.WriteLine($"'{movieToRemove}' Was not found in the movies list.");
            }
            else
            {
                Movies = Movies.Where(x => x != null).ToArray();
            }
        }

        static void DisplayMovie()
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("CURRENT MOVIES TO WATCH");
            Console.WriteLine("-------------------------");

            foreach(string movie in Movies)
            {
                Console.WriteLine(movie);
            }
        }
    }
}
internal class Program
{
    //____
    //|   |
    //|   O
    //|  /|\
    //|  / \
    //---------

    private static void Main(string[] args)
    {

        List<string> fruitsAndVegetables = new List<string>()
        {
            "Apple", "Banana", "Broccoli", "Pear", "Tomato", "Carrot", "Strawberry", "Avocado", "Onion", "Pineapple"
        };

        List<string> vehicles = new List<string>()
        {
            "Car", "Bicycle", "Truck", "Motorcycle", "Scooter", "Tractor", "Plane", "Boat", "Tram", "Bus"
        };

        List<string> school = new List<string>()
        {
            "Teacher", "Student", "Blackboard", "Books", "Pen", "Class", "Textbook", "Computer", "Library", "Phone"
        };

        List<string> programmingLanguages = new List<string>()
        {
           "Python", "Java", "C++", "JavaScript", "Ruby", "PHP", "Swift", "Kotlin", "C", "Lua" 

        };

        List<string> furniture = new List<string>()
        {
            "Chair", "Table", "Sofa", "Wardrobe", "Bed", "Armchair", "Wall", "Shelf", "Mirror"

        };

        List<string> pcComponents = new List<string>()
        {
           "RAM", "CPU", "GPU", "Motherboard", "HDD", "SSD", "CD-ROM", "Disk"

        };

        List<string> words = new List<string>();

        Console.WriteLine("Select category:");
        Console.WriteLine("1 - Fruits and vegetables;");
        Console.WriteLine("2 - Vehicles;");
        Console.WriteLine("3 - School;");
        Console.WriteLine("4 - Programming languages;");
        Console.WriteLine("5 - Furniture;");
        Console.WriteLine("6 - PC components;");
        Console.WriteLine("0 - Exit;");
        while (true)
        {
            Console.Write("> ");
            var key = Console.ReadKey();
            Console.Write("\n");

            try
            {
                int mode = int.Parse(key.KeyChar.ToString());

                if (mode > 7 || mode < 0)
                {
                    Console.WriteLine("Error. Try again!");
                }
                else
                {
                    if(mode == 1)
                    {
                        words.AddRange(fruitsAndVegetables);
                        Console.Clear();
                        break;
                    }
                    if (mode == 2)
                    {
                        words.AddRange(vehicles);
                        Console.Clear();
                        break;
                    }
                    if (mode == 3)
                    {
                        words.AddRange(school);
                        Console.Clear();
                        break;
                    }
                    if (mode == 4)
                    {
                        words.AddRange(programmingLanguages);
                        Console.Clear();
                        break;
                    }
                    if (mode == 5)
                    {
                        words.AddRange(furniture);
                        Console.Clear();
                        break;
                    }
                    if (mode == 6)
                    {
                        words.AddRange(pcComponents);
                        Console.Clear();
                        break;
                    } 
                    if (mode == 0)
                    {
                        Environment.Exit(0);
                    }
                }
            } catch (Exception)
            {
                Console.WriteLine("Error. Try again!");
            }
        }


        Random rand = new Random();

        
        string line = " ";
        string head = " ";
        string body = " ";
        string leftHand = " ";
        string rightHand = " ";
        string leftLeg = " ";
        string rightLeg = " ";

        string lineD = "|";
        string headD = "O";
        string bodyD = "|";
        string leftHandD = "/";
        string rightHandD = "\\";
        string leftLegD = "/";
        string rightLegD = "\\";


        string word = words[rand.Next(0, words.Count-1)].ToLower();
        string unfinishedWord;

        List<char> guessedLetters = new List<char>();

        Char clicked = ' ';

        bool win = false;
        int wrongGuesses = 0;

        List<string> limbs = new List<string>()
        {
            line,head,body,leftHand,rightHand,leftLeg,rightLeg
        };

        List<string> limbsD = new List<string>()
        {
            lineD,headD,bodyD,leftHandD,rightHandD,leftLegD,rightLegD
        };



        while (true)
        {
            clicked = ' ';
            unfinishedWord = "";

            
            // This is very inefficient way to check if the key is pressed but im too lazy now to make it better
            if (Console.KeyAvailable)
            {
                clicked = char.ToLower(Console.ReadKey().KeyChar);
            }

            

            if(clicked != ' ')
            {
                

                if (!word.ToCharArray().Contains(clicked))
                {
                    if (!guessedLetters.Contains(clicked))
                    {
                        limbs[wrongGuesses] = limbsD[wrongGuesses];
                        wrongGuesses++;

                    }
                }

                guessedLetters.Add(clicked);
            }



            foreach(char charr in word.ToCharArray())
            {
                if (guessedLetters.Contains(charr))
                {
                    unfinishedWord += charr;

                } else
                {
                    unfinishedWord += "_";
                }
            }

            if(unfinishedWord == word)
            {
                win = true;
                break;
            }

            if (wrongGuesses >= limbs.Count())
            {
                win = false;
                break;
            }

               

            
            Console.Write("\nWord: " + unfinishedWord + "\n");
            Console.Write("Number of wrong guesses: " + wrongGuesses + "  \n");
            Console.Write("_____" + "\n");
            Console.Write("|" + "   " + limbs[0] + "\n");
            Console.Write("|" + "   " + limbs[1] + "\n");
            Console.Write("|" + "  " + limbs[3] + limbs[2] + limbs[4] + "\n");
            Console.Write("|" + "  " + limbs[5] + " " + limbs[6] + "\n");
            Console.Write("---------------\n");

            

            Thread.Sleep(200);
            Console.Clear();
        }

        Console.Clear();
        if (win)
        {
            Console.WriteLine("Congratulation! You won!");
        } else
        {
            Console.WriteLine("You died :(");
            Console.WriteLine("The word was: " + word);
        }
        Console.WriteLine("Click any button to exit!");
        Console.ReadKey();



    }
}
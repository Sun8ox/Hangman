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

        List<string> ovocieAndZelenina = new List<string>()
        {
            "Jablko", "Banán", "Brokolica", "Hruška", "Paradajka", "Mrkva", "Jahody", "Avokádo", "Cibuľa", "Ananás"
        };

        List<string> vozidlá = new List<string>()
        {
            "Auto", "Bicykel", "Kamión", "Motorka", "Skúter", "Traktor", "Lietadlo", "Loď", "Električka", "Autobus"
        };

        List<string> škola = new List<string>()
        {
            "Učiteľ", "Študent", "Tabuľa", "Knihy", "Pero", "Trieda", "Učebnica", "Počítač", "Knižnica", "Peračník", "Mobil"
        };

        List<string> programovacieJazyky = new List<string>()
        {
           "Python", "Java", "C++", "JavaScript", "Ruby", "PHP", "Swift", "Kotlin", "C", "Lua" 

        };

        List<string> nábytok = new List<string>()
        {
           "Stolička", "Stôl", "Pohovka", "Skriňa", "Posteľ", "Kreslo", "Stena", "Polica", "Zrkadlo"

        };

        List<string> komponenty = new List<string>()
        {
           "RAM", "CPU", "GPU", "Motherboard", "HDD", "SSD", "Zdroj", "CD-ROM", "Disk"

        };

        List<string> slova = new List<string>();

        Console.WriteLine("Vyber si tému ktorú budeš hrať");
        Console.WriteLine("1 - Ovocie a zelenina; 2 - Vozidlá; 3 - Škola; 4 - Programovacie jazyky; 5 - Nábytok; 6 - Počítačové komponenty");
        while (true)
        {
            Console.Write("\n> ");
            var key = Console.ReadKey();
            Console.Write("\n");

            try
            {
                int mode = int.Parse(key.KeyChar.ToString());

                if (mode > 7 || mode < 0)
                {
                    Console.WriteLine("Error. Skús to znovu!");
                }
                else
                {
                    if(mode == 1)
                    {
                        slova.AddRange(ovocieAndZelenina);
                        Console.Clear();
                        break;
                    }
                    else if (mode == 2)
                    {
                        slova.AddRange(vozidlá);
                        Console.Clear();
                        break;
                    }
                    else if (mode == 3)
                    {
                        slova.AddRange(škola);
                        Console.Clear();
                        break;
                    }
                    else if (mode == 4)
                    {
                        slova.AddRange(programovacieJazyky);
                        Console.Clear();
                        break;
                    }
                    else if (mode == 5)
                    {
                        slova.AddRange(nábytok);
                        Console.Clear();
                        break;
                    }
                    else if (mode == 6)
                    {
                        slova.AddRange(komponenty);
                        Console.Clear();
                        break;
                    }
                }
            } catch (Exception)
            {
                Console.WriteLine("Error. Skús to znovu!");
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


        string slovo = slova[rand.Next(0, slova.Count-1)].ToLower();
        string nedokonceneSlovo;

        List<char> tipnutePismenka = new List<char>();

        Char clicked = ' ';

        bool win = false;
        int zletipy = 0;

        List<string> koncatiny = new List<string>()
        {
            line,head,body,leftHand,rightHand,leftLeg,rightLeg
        };

        List<string> koncatinyD = new List<string>()
        {
            lineD,headD,bodyD,leftHandD,rightHandD,leftLegD,rightLegD
        };



        while (true)
        {
            clicked = ' ';
            nedokonceneSlovo = "";

            if (Console.KeyAvailable)
            {
                clicked = char.ToLower(Console.ReadKey().KeyChar);
            }

            

            if(clicked != ' ')
            {
                

                if (!slovo.ToCharArray().Contains(clicked))
                {
                    if (!tipnutePismenka.Contains(clicked))
                    {
                        koncatiny[zletipy] = koncatinyD[zletipy];
                        zletipy++;

                    }
                }

                tipnutePismenka.Add(clicked);
            }



            foreach(char charr in slovo.ToCharArray())
            {
                if (tipnutePismenka.Contains(charr))
                {
                    nedokonceneSlovo += charr;

                } else
                {
                    nedokonceneSlovo += "_";
                }
            }

            if(nedokonceneSlovo == slovo)
            {
                win = true;
                break;
            }

            if (zletipy >= koncatiny.Count())
            {
                win = false;
                break;
            }

               

            
            Console.Write("\nSlovo: " + nedokonceneSlovo + "\n");
            Console.Write("Počet zlých tipov: " + zletipy + "  \n");
            Console.Write("_____" + "\n");
            Console.Write("|" + "   " + koncatiny[0] + "\n");
            Console.Write("|" + "   " + koncatiny[1] + "\n");
            Console.Write("|" + "  " + koncatiny[3] + koncatiny[2] + koncatiny[4] + "\n");
            Console.Write("|" + "  " + koncatiny[5] + " " + koncatiny[6] + "\n");
            Console.Write("---------------\n");

            

            Thread.Sleep(200);
            Console.Clear();
        }

        Console.Clear();
        if (win)
        {
            Console.WriteLine("Gratulujem! Vyhral si");
        } else
        {
            Console.WriteLine("Zomrel si :(");
            Console.WriteLine("Slovo bolo: " + slovo);
        }
        Console.WriteLine("Klikni hocičo aby si pokračoval!");
        Console.ReadKey();



    }
}
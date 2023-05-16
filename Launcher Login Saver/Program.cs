public static class ZaverecnyProjekt
{
    private class Udaje
    {
        public Udaje(string jmeno, string heslo)
        {
            Heslo = heslo;
            Jmeno = jmeno;
        }
        public static bool cyklus = true;
        public string Jmeno;
        public string Heslo;
    }

    private static class Program
    {
        private static string[] platformy = { "Steam", "Discord", "Spotify", "XBOX", "PlayStation", "EpicGames", "Minecraft", "RiotGames"};
        public static void PřidejUdaje(string jmeno, string heslo)
        {
            Console.Clear();
            Console.WriteLine($"Vyber launcher:\n");
            foreach (var platform in platformy) Console.WriteLine(platform);
            Console.WriteLine();
            string volbaLauncher = Console.ReadLine();
            File.WriteAllText(volbaLauncher + ".txt", jmeno + ";" + heslo);
        }

        public static void UkazVsechnyUdaje()
        {
            Console.Clear();
            foreach(var platform in platformy)
            {
                if (!File.Exists(platform + ".txt"))
                {
                    Console.WriteLine($"{platform} - nezadáno");
                    continue;
                }

                string[] data = File.ReadAllText(platform + ".txt").Split(';');
                string jmeno = data[0];
                string heslo = data[1];

                Console.WriteLine($"{platform} - {jmeno}, {heslo}");
            }
            Console.ReadKey();
        }

        public static void UkazUdajePodlePlatformy()
        {
            Console.Clear();
            Console.WriteLine($"Vyber launcher:\n");
            foreach (var platform in platformy) Console.WriteLine(platform);
            Console.WriteLine();
            string volbaLauncher = Console.ReadLine();

            if (!File.Exists(volbaLauncher + ".txt"))
            {
                Console.WriteLine($"{volbaLauncher} - nezadáno");
                return;
            }

            string[] data = File.ReadAllText(volbaLauncher + ".txt").Split(';');
            string jmeno = data[0];
            string heslo = data[1];

            Console.WriteLine($"{volbaLauncher} - {jmeno}, {heslo}");
            Console.ReadKey();
        }
    }
    public static void UkonciProgram()
    {
        Environment.Exit(0);
    }
    
    public static void Main()
    {
        while (Udaje.cyklus == true)
        {
            Console.Clear();
            try
            {
                char vyber = AnsiConsole.Ask<char>("[green]Přidat (p), Zobrazit (z), Jen vybraná platforma (v), Ukončit (u): [/]");
                if (vyber == 'p')
                {
                    Console.Clear();
                    string jmeno = AnsiConsole.Ask<string>("[blue]Zadej jmeno: [/]");
                    string heslo = AnsiConsole.Ask<string>("[blue]Zadej heslo: [/]");
                    Program.PřidejUdaje(jmeno, heslo);
                }

                
                else if (vyber == 'z')
                {
                    Program.UkazVsechnyUdaje();
                }

                else if (vyber == 'v')
                {
                    Program.UkazUdajePodlePlatformy();
                }
                else if (vyber == 'u') 
                { 
                    UkonciProgram();


                }
            }
            catch (Exception)
            {
                Console.WriteLine("dal si spatny input si poop"); break;
            }
        }
    }
}

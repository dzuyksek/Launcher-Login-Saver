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
        }
    }

    public static void Main()
    {
        while (Udaje.cyklus == true)
        {
            Console.Clear();
            try
            {
                Console.WriteLine(" přidat(p), zobrazit(z)");
                char vyber = char.Parse(Console.ReadLine());
                if (vyber == 'p')
                {
                    Console.Clear();
                    Console.WriteLine("Zadej Jmeno ");
                    string jmeno = Console.ReadLine();
                    Console.WriteLine("Zadej heslo loupaku");
                    string heslo = Console.ReadLine();
                    Program.PřidejUdaje(jmeno, heslo);
                }

                
                else if (vyber == 'z')
                {
                    Program.UkazVsechnyUdaje();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("dal si spatny input si poop"); break;
            }
        }
    }
}

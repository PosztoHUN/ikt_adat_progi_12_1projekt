namespace nosztalgiaVillamos
{
    internal class Program
    {
        class Villamos
        {
            public int Palyaszam;
            public int GyartasEv;
            public int NosztalgiaEv;
            public string Telephely;
            public bool UtasSzallitas;

            public Villamos(string sor)
            {
                string[] szelet = sor.Split('\t');
                Palyaszam = int.Parse(szelet[0]);
                GyartasEv = int.Parse(szelet[1]);
                NosztalgiaEv = int.Parse(szelet[2]);
                Telephely = szelet[3];
                UtasSzallitas = int.Parse(szelet[4]) == 1 ? true : false;

            }


        }
        /*Melyik telephelyhez tartozik a legtöbb villamos?
        Hány villamos tartozik a Ferencváros telephelyhez?
        Melyik a legrégebben gyártott villamos?*/
        static void Main(string[] args)
        {
            List<Villamos> villamosok = new List<Villamos>();
            StreamReader beFajl = new StreamReader("nosztalgiavillamos.txt");
            while (!beFajl.EndOfStream)
            {
                villamosok.Add(new Villamos(beFajl.ReadLine()));
            }

            Console.WriteLine($"{villamosok.Count} villamos van a fájlban.");

            Dictionary<string, int> telephelyek = new Dictionary<string, int>();
            foreach (var villamos in villamosok)
            {
                if (telephelyek.ContainsKey(villamos.Telephely))
                {
                    telephelyek[villamos.Telephely]++;
                }
                else
                {
                    telephelyek.Add(villamos.Telephely, 1);
                }
            }
            foreach (var telephely in telephelyek)
            {
                if (telephely.Value == telephelyek.Values.Max())
                    {
                    Console.WriteLine($"{telephely.Key} telephelyhez tartozik a legtöbb villamos: {telephely.Value} db");
                    }
                if (telephely.Key == "Ferencváros")
                {
                    Console.WriteLine($"\nA Ferencváros telephelyhez tartozó villamosok száma: {telephely.Value} db");
                }
            }
            int minEv = 2026;
            int minIndex = -1;
            for (int i = 0; i < villamosok.Count; i++)
            {
                if (villamosok[i].GyartasEv < minEv)
                {
                    minEv = villamosok[i].GyartasEv;
                    minIndex = i;
                }
            }

            if (minIndex != -1)
            {
                Console.WriteLine($"A legrégebben gyártott villamos: {villamosok[minIndex].Palyaszam}, " +
                                  $"Gyártás éve: {villamosok[minIndex].GyartasEv}, " +
                                  $"Telephely: {villamosok[minIndex].Telephely}");
            }




        }
    }
}

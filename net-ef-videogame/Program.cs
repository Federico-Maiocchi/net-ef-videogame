using Microsoft.Identity.Client;

namespace net_ef_videogame
{
    internal class Program
    {
        
        static void Main(string[] args)
        {

            using (var db = new VideogameContext())
            {
                while (true)
                {
                    Console.WriteLine("Menu:");

                    Console.WriteLine("1. Inserisci una nuova software house");
                    Console.WriteLine("2. Inserisci un nuovo videogioco");
                    Console.WriteLine("3. Trova gioco per id");
                    Console.WriteLine("4. Trova gioco per Nome");
                    Console.WriteLine("0. Esci");

                    Console.Write("Scelta: ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:

                            Console.WriteLine("Inserisci il nome software house:");
                            string nameSoftwareHouse = Console.ReadLine();

                            SoftwareHouse softwareHouse = new SoftwareHouse()
                            {
                                Name = nameSoftwareHouse,
                            };

                            VideogameContext dbSofotwareHouse = new VideogameContext();
                            dbSofotwareHouse.Add(softwareHouse);
                            dbSofotwareHouse.SaveChanges();
                            break;

                        case 2:

                            Console.WriteLine("Inserisci il nome del videogioco:");
                            string nameVideogame = Console.ReadLine();

                            Console.WriteLine("Inserisci una panoramica del videogioco:");
                            string overviewVideogame = Console.ReadLine();

                            Console.WriteLine("Inserisci l'ID della software house che ha prodotto il videogioco:");
                            int softwareHouseId = int.Parse(Console.ReadLine());

                            Videogame videogame = new Videogame()
                            {
                                Name = nameVideogame,
                                Overview = overviewVideogame,
                                SoftwarehouseId = softwareHouseId
                            };

                            VideogameContext dbVideogame = new VideogameContext();
                            dbVideogame.Add(videogame);
                            dbVideogame.SaveChanges();
                            break;

                        case 3:
                            Console.WriteLine("Ricerca videogioco per id");

                            int searchId = int.Parse(Console.ReadLine());

                            var videogameIdquery = db.Videogames.FirstOrDefault(v => v.VideogmaeId == searchId );

                            if (videogameIdquery != null)
                            {
                                Console.WriteLine($"Videogioco trovato: {videogameIdquery.Name}");
                                
                            }
                            else
                            {
                                Console.WriteLine("Nessun videogioco trovato con l'ID specificato.");
                            }


                            break;

                        case 4:
                            Console.WriteLine("Ricerca videogioco per nome");

                            string searchName = Console.ReadLine();

                            var videogames = db.Videogames.Where(v => v.Name.ToLower().Contains(searchName.ToLower())).ToList();

                            if (videogames.Any())
                            {
                                Console.WriteLine("Videogiochi trovati:");
                                foreach (var itemVideogame in videogames)
                                {
                                    Console.WriteLine($"- {itemVideogame.Name}");
                                    
                                }
                            }
                            else
                            {
                                Console.WriteLine("Nessun videogioco trovato con il nome specificato.");
                            }

                            break;

                        case 0:
                            return;

                        default:
                            Console.WriteLine("Numero non valido nella scelta.");
                            break;
                    }
                }
            }
        }

        


            
       
    }
}

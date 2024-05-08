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
                    int choice;
                    if (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("Input non valido. Inserire un numero.");
                        continue;
                    }

                    switch (choice)
                    {
                        // creazione software house
                        case 1:

                            Console.WriteLine("Inserisci il nome software house:");
                            string nameSoftwareHouse = Console.ReadLine();
                            VideogameManager.AddNewSoftwareHouse(db, nameSoftwareHouse);
                            Console.WriteLine("Software house aggiunta con successo.");
                            break;


                        // creazione gioco
                        case 2:

                            Console.WriteLine("Inserisci il nome del videogioco:");
                            string nameVideogame = Console.ReadLine();

                            Console.WriteLine("Inserisci una panoramica del videogioco:");
                            string overviewVideogame = Console.ReadLine();

                            Console.WriteLine("Inserisci l'ID della software house che ha prodotto il videogioco:");
                            int softwareHouseId;
                            if (!int.TryParse(Console.ReadLine(), out softwareHouseId))
                            {
                                Console.WriteLine("Input non valido per l'ID della software house.");
                                break;
                            }

                            VideogameManager.AddNewVideogame(db, nameVideogame, overviewVideogame, softwareHouseId);
                            Console.WriteLine("Videogioco aggiunto con successo.");
                            break;


                        // ricerca gioco tramite id
                        case 3:

                            Console.WriteLine("Ricerca videogioco per id:");
                            int searchId;
                            if (!int.TryParse(Console.ReadLine(), out searchId))
                            {
                                Console.WriteLine("Input non valido per l'ID del videogioco.");
                                break;
                            }

                            var videogame = VideogameManager.FindGameById(db, searchId);
                            if (videogame != null)
                            {
                                Console.WriteLine($"Videogioco trovato: {videogame.Name}");
                            }
                            else
                            {
                                Console.WriteLine("Nessun videogioco trovato con l'ID specificato.");
                            }
                            break;


                        // ricerca gioco tramite nome
                        case 4:

                            Console.WriteLine("Ricerca videogioco per nome:");
                            string searchName = Console.ReadLine();

                            var videogames = VideogameManager.FindGameByName(db, searchName);

                            if (videogames.Any())
                            {
                                Console.WriteLine("Videogiochi trovati:");
                                foreach (var itemVideogame in videogames)
                                {
                                    Console.WriteLine($"Nome - {itemVideogame.Name}");
                                    Console.WriteLine($"Descriione - {itemVideogame.Overview}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Nessun videogioco trovato con il nome specificato.");
                            }
                            break;


                        // delete
                        case 5:

                            Console.WriteLine("Elimina videogioco per ID:");
                            int deleteId;
                            if (!int.TryParse(Console.ReadLine(), out deleteId))
                            {
                                Console.WriteLine("Input non valido per l'ID del videogioco.");
                                break;
                            }

                            VideogameManager.DeleteVideogameById(db, deleteId);
                            break;

                        // uscita dal menu
                        case 0:
                            return;

                        
                        default:
                            Console.WriteLine("Scelta non valida.");
                            break;
                    }
                }
            }
        }    
       
    }
}

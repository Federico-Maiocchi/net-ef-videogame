using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    internal class VideogameManager
    {
        // Metodo per aggiungere una nuova software house
        public static void AddNewSoftwareHouse(string nameSoftwareHouse)
        {
            using (var db = new VideogameContext())
            {
                var softwareHouse = new SoftwareHouse()
                {
                    Name = nameSoftwareHouse,
                };

                db.SoftwareHouses.Add(softwareHouse);
                db.SaveChanges();
            }
        }

        // Metodo per aggiungere un nuovo videogioco
        //public static void AddNewVideogame(string nameVideogame, string overviewVideogame, int softwareHouseId)
        //{
        //    using (var db = new VideogameContext())
        //    {
        //        var softwareHouse = db.SoftwareHouses.Find(softwareHouseId);

        //        if (softwareHouse != null)
        //        {
        //            var videogame = new Videogame()
        //            {
        //                Name = nameVideogame,
        //                Overview = overviewVideogame,
        //                SoftwareHouse = softwareHouse
        //            };

        //            db.Videogames.Add(videogame);
        //            db.SaveChanges();
        //        }
        //    }
        //}

        public static void AddNewVideogame(Videogame v)
        {
            using VideogameContext db = new VideogameContext();
            db.Add(v);
            db.SaveChanges();
        }

        // Metodo per trovare un videogioco con il suo id
        public static Videogame FindGameById(int searchId)
        {
            using (var db = new VideogameContext())
            {
                return db.Videogames.FirstOrDefault(v => v.VideogmaeId == searchId);
            }
        }

        // Metodo che trova un videogioco per il suo nome
        public static List<Videogame> FindGameByName(string searchName)
        {
            using (var db = new VideogameContext())
            {
                return db.Videogames.Where(v => v.Name.ToLower().Contains(searchName.ToLower())).ToList();
            }
        }

        // Metodo per eliminare un videogioco tramite id
        public static bool DeleteVideogameById(int gameId)
        {
            using (var db = new VideogameContext())
            {
                var videogameToDelete = db.Videogames.FirstOrDefault(v => v.VideogmaeId == gameId);

                if (videogameToDelete != null)
                {
                    db.Videogames.Remove(videogameToDelete);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }
    }
}


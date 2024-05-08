using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    internal class VideogameManager
    {
        //metodo per aggiungere una nuova software house
        public static void AddNewSoftwareHouse(VideogameContext db, string nameSoftwareHouse)
        {
            var softwareHouse = new SoftwareHouse()
            {
                Name = nameSoftwareHouse,
            };

            db.SoftwareHouses.Add(softwareHouse);
            db.SaveChanges();
        }

        //metodo per aggiungere un nuovo videogioco
        public static void AddNewVideogame(VideogameContext db, string nameVideogame, string overviewVideogame, int softwareHouseId)
        {
            var softwareHouse = db.SoftwareHouses.Find(softwareHouseId);

            if (softwareHouse != null)
            {
                var videogame = new Videogame()
                {
                    Name = nameVideogame,
                    Overview = overviewVideogame,
                    SoftwareHouse = softwareHouse
                };

                db.Videogames.Add(videogame);
                db.SaveChanges();
            }
        }

        //metodo per trovare un videogioco con il suo id
        public static Videogame FindGameById(VideogameContext db, int searchId)
        {
            return db.Videogames.FirstOrDefault(v => v.VideogmaeId == searchId);
        }

        //metodo che trova un videogioco per il suo nome
        public static List<Videogame> FindGameByName(VideogameContext db, string searchName)
        {
            return db.Videogames.Where(v => v.Name.ToLower().Contains(searchName.ToLower())).ToList();
        }

        //metodo per elimare videgioco tramite id
        public static void DeleteVideogameById(VideogameContext db, int gameId)
        {
            var videogameToDelete = db.Videogames.FirstOrDefault(v => v.VideogmaeId == gameId);

            db.Videogames.Remove(videogameToDelete);
            db.SaveChanges();
        }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    public class SoftwareHouse
    {
        [Key]
        public int SoftwareHouseId { get; set; }

        public string Name { get; set; }

        //public int TaxId { get; set; }

        //public string city {  get; set; }

        //public string country { get; set; }

        

        public List<Videogame> Videogame { get; set; } // 1 : N Videogame

        public SoftwareHouse() { }

        public SoftwareHouse(int softwareHouseId, string name, List<Videogame> videogame)
        {
            SoftwareHouseId = softwareHouseId;
            Name = name;
            Videogame = videogame;
        }
    }
}

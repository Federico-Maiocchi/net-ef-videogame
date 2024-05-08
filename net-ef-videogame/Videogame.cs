using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    // definire il nome della tabella
    [Table("videogame")]
    // definisco unico l'attributo per l'entità Name
    [Index(nameof(Name), IsUnique = true)]
    public class Videogame
    {
        //identifico la chiave primaria - id
        [Key]
        public int VideogmaeId { get; set; }

        public string Name {  get; set; }

        // ? - il campo può avere vaolori NULL
        public string? Overview { get; set; }

        // possiamo rinominare il nome della colonna da ReleaseDate -> release_date
        /*[Column("release_date")]
        public DateTime ReleaseDate {  get; set; } */


        public int SoftwarehouseId { get; set; }

        public SoftwareHouse SoftwareHouse { get; set; }

        public Videogame()
        {

        }

        public Videogame(int videogmaeId, string name, string? overview, int softwarehouseId)
        {
            VideogmaeId = videogmaeId;
            Name = name;
            Overview = overview;
            SoftwarehouseId = softwarehouseId;
        }
    }

   
}

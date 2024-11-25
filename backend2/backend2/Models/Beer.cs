using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend2.Models
{
    public class Beer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BeerID { get; set; }

        public string BeerName { get; set; }

        public int BrandID { get; set; }

        //[Column(TypeName = "decimal(18,2)")]
        //public decimal Alchool { get; set; }


        [ForeignKey("BrandID")] // Correcto: Relación basada en BrandID
        public virtual Brand Brand { get; set; } // Propiedad de navegación
    }
}

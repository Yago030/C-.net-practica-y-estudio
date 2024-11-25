using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend2.Models
{
    public class Brand
    {

        [Key] //para usar primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // esto hara que sea auto incrementable 
        public int BrandID { get; set; }

        public string Name { get; set; }




    }
}

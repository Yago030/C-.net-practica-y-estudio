using backend2.Models;

namespace backend2.DTOs
{
    public class BeerUpdateDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }

}
}

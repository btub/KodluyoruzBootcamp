using System.ComponentModel.DataAnnotations;

namespace IntroWebApi6.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Ad alanı boş olamaz!")]
        public string? Name { get; set; }
        
        public string? Description { get; set; }
        
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        
        public int CategoryId { get; set; }
        public string? ImageUrl { get; set; }
        public double Discount { get; set; }
        public int Stock { get; set; }
    }
}

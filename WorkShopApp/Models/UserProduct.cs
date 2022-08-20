using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkShopApp.Models
{
    public class UserProduct
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("User")]
        public int UserId { get; set; }
        
        [ForeignKey("Product")]
        public int ProductId { get; set; }
       
        [Required(ErrorMessage = "*")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "*")]
        public string Address { get; set; }
       
        [Required(ErrorMessage = "*")]
        [RegularExpression("^(01)[0-2,5]{1}[0-9]{8}$", ErrorMessage = "please enter valid phone number")]
        public string Phone { get; set; }
        
        [Required(ErrorMessage = "*")]
        public double TotalPrice { get; set; }
        public DateTime OrderedAt { get; set; } = DateTime.Now;

        public User User { get; set; }
        public Product Product { get; set; }
    }
}

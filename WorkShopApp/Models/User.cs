using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WorkShopApp.Models.Enums;

namespace WorkShopApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
       
        [DisplayName("First Name")]
        [Required(ErrorMessage ="*")]
        public string FirstName { get; set; }
       
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "*")]
        public string LastName { get; set; }
       
        [DisplayName("User Name")]
        [Required(ErrorMessage = "*")]
        public string UserName { get; set; }
       
        [Required(ErrorMessage = "*")]
        [RegularExpression("^(01)[0-2,5]{1}[0-9]{8}$", ErrorMessage = "please enter valid phone number")]
        public string Phone { get; set; }
      
        [Required(ErrorMessage = "*")]
        [RegularExpression(@"^[\w-]+(\.[\w-]+)*@([a-z0-9-]+(\.[a-z0-9-]+)*?\.[a-z]{2,6}|(\d{1,3}\.){3}\d{1,3})(:\d{4})?$", ErrorMessage = "please enter valid email address")]
        public string Email { get; set; }
      
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
      
        [Required(ErrorMessage = "*")]
        public string Address { get; set; }
        public Role Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

     
        public ICollection<UserProduct> UserProducts { get; set; }
    }
}

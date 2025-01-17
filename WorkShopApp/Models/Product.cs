﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkShopApp.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="*")]
        public string Name { get; set; }

        [Required(ErrorMessage ="*")]
        public string Description { get; set; }
        
        [Required(ErrorMessage ="*")]
        public double Price { get; set; }

        public int Discount { get; set; } 
        
        [Required(ErrorMessage ="*")]
        public int Quantity { get; set; }
       
        [Required(ErrorMessage ="*")]
        [DisplayName("Category")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }


        public Category Category { get; set; }
        public List<UserProduct> UserProducts { get; set; }
    }
}

﻿using System.ComponentModel.DataAnnotations;

namespace Library.ViewModels
{
    public class CategoryViewModel
    {  
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = null!;
    }
}

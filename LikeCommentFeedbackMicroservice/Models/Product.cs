﻿using System.ComponentModel.DataAnnotations.Schema;

namespace LikeCommentFeedbackMicroservice.Models
{
    // ????????
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }
        public string Category { get; set; } // enum?
    }
}

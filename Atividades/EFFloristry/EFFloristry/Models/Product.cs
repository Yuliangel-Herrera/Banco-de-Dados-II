using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;

namespace EFFloristry.Models
{
    public class Product
    {
        [Key]
            public int Id { get; set; }
            public string ProductDescription { get; set; } = string.Empty;
            public decimal Price { get; set; }
            public string Category { get; set; } = string.Empty;
            public int Stock { get; set; }
    }
}


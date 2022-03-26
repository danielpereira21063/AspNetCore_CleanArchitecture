using CleanArchMvc.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; private set; }
        [Required(ErrorMessage = "The description is required")]
        [MinLength(5)]
        [MaxLength(200)]
        public string Description { get; private set; }
        [Required(ErrorMessage = "The price is required")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public decimal Price { get; private set; }
        [Required(ErrorMessage = "The stock is required")]
        [Range(1, 9999)]
        [DisplayName("Stock")]
        public int Stock { get; private set; }
        [MaxLength(250)]
        [DisplayName("Product image")]
        public string Image { get; private set; }
        public int CategoryId { get; set; }
        [DisplayName("Categories")]
        public Category Category { get; set; }
    }
}

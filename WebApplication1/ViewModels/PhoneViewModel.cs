using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class PhoneViewModel
    {
        public int Id { get; set; }
        [Required]
        [Remote(action: "IsPhoneNameAvailable", controller: "Validation", ErrorMessage = "Name is already taken")]
        public string Name { get; set; }
        [Required]
        [Range(100, 20000)]
        public int Price { get; set; }
        [Required]
        public int? BrandId { get; set; }
        public Brand? Brand { get; set; }
    }
}

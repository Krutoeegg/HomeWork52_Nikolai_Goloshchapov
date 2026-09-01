using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Brand
    {
        public int Id { get; set; }
        [Remote(action: "IsBrandNameAvailable", controller: "Validation", ErrorMessage = "Name is already taken")]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [Remote(action: "IsDateValid", controller: "Validation", ErrorMessage = "Date is not valid")]
        public DateOnly CreatedAt { get; set; }
    }
}

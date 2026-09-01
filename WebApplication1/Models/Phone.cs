using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Phone
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public int? BrandId { get; set; }
    public Brand? Brand { get; set; }
    public List<Review>? Reviews { get; set; }
}
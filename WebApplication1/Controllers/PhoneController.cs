using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers;

public class PhoneController : Controller
{
    private MobileContext _context;

    public PhoneController(MobileContext context)
    {
        _context = context;
    }
    
    public IActionResult Index()
    {
        List<Phone> phones = _context.Phones.Include(b => b.Brand).ToList();
        return View(phones);
    }
    
    public IActionResult Create()
    {
        List<Brand> brands = _context.Brands.ToList();
        ViewBag.Brands = brands;
        return View();
    }

    [HttpPost]
    public IActionResult Create(PhoneViewModel? phone)
    {
        if (ModelState.IsValid)
        {
            Phone p = new Phone()
            {
                Name = phone.Name,
                Price = phone.Price,
                BrandId = phone.BrandId
            };
            _context.Phones.Add(p);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
    
    public IActionResult Edit(int? id)
    {
        List<Brand> brands = _context.Brands.ToList();
        ViewBag.Brands = brands;
        if (id.HasValue)
        {
            Phone? phone = _context.Phones.FirstOrDefault(p => p.Id == id);
            if (phone != null)
            {
                return View(phone);
            }
        }
        return NotFound();
    }

    [HttpPost]
    public IActionResult Edit(Phone? phone)
    {
        if (phone!=null)
        {
            _context.Phones.Update(phone);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int? id)
    {
        if (id.HasValue)
        {
            Phone? phone = _context.Phones.FirstOrDefault(p => p.Id == id);
            if (phone != null)
            {
                return View(phone);
            }
        }
        return NotFound();
    }

    public IActionResult ConfirmDelete(int? id)
    {
        if (id.HasValue)
        {
            Phone? phone = _context.Phones.FirstOrDefault(p => p.Id == id);
            if (phone != null)
            {
                _context.Remove(phone);
                _context.SaveChanges();
            }
        }
        return RedirectToAction("Index");
    }

    public IActionResult Details(int? id)
    {
        if (!id.HasValue)
        {
            return NotFound();
        } 
            
            Phone? phone = _context.Phones.FirstOrDefault(p => p.Id == id);
            if (phone == null)
            {
                return NotFound();
            }

            var phoneReview = new PhoneReviewsViewModel
            {
                _phone = phone,
                _review = _context.Reviews.Where(r => r.PhoneId == id).ToList(),
                 NewReview = new Review { PhoneId = phone.Id }
            };
            return View(phoneReview);
    }   
}
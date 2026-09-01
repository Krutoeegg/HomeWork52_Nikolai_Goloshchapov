using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ValidationController : Controller
    {
        private MobileContext _context;
        public ValidationController(MobileContext context)
        {
            _context = context;
        }
        [AcceptVerbs("Get", "Post")]
        public bool IsBrandNameAvailable(string name)
        {
            return !_context.Brands.Any(b => b.Name == name);

        }
        [AcceptVerbs("Get", "Post")]
        public bool IsPhoneNameAvailable(string name)
        {
            return !_context.Phones.Any(p => p.Name == name);

        }
        [AcceptVerbs("Get", "Post")]
        public bool IsDateValid(DateOnly date)
        {
            var dateTime = DateOnly.FromDateTime(DateTime.Now);
            var invalidFutureDate = dateTime.AddYears(100);
            var invalidPastDate = dateTime.AddYears(-100);
            if (date > invalidFutureDate || date < invalidPastDate)
                return false;
            return true;


        }
    }
}

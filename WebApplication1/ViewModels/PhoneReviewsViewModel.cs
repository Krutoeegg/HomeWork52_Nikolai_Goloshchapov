using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class PhoneReviewsViewModel
    {
        public Phone _phone { get; set; }
        public List<Review> _review { get; set; }
        public Review NewReview { get; set; }

    }
}

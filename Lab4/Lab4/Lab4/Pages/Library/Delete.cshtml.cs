using Lab4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace Lab4.Pages.Library
{
    public class DeleteModel : PageModel
    {

        private readonly CustomerDbContext _apiContext;
        public DeleteModel(CustomerDbContext apiContext)
        {
            _apiContext = apiContext;
        }


        public Customer Customer { get; set; }

        public IActionResult OnGet(int id)
        {
            Customer = _apiContext.Customers.FirstOrDefault(x => x.CustomerId == id);
            return Page();
        }

        public IActionResult OnPost(int id)
        {

            var ct = _apiContext.Customers.Find(id);
            if (ct != null)
            {
                _apiContext.Customers.Remove(ct);
                _apiContext.SaveChanges();
            }

            return RedirectToPage("Index");
        }

        
    }
}

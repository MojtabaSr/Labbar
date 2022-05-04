using Lab4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lab4.Pages.Library
{
    public class EditModel : PageModel
    {
        private readonly CustomerDbContext _apiContext;

        public EditModel(CustomerDbContext apiContext)
        {
            _apiContext = apiContext;
        }

        public Customer Customer { get; set; }
        public IActionResult OnGet(int Id)
        {
            Customer = _apiContext.Customers.FirstOrDefault(x => x.CustomerId == Id);
            return Page();
        }

        public IActionResult OnPost(Customer customer)
        {
            _apiContext.Customers.Update(customer);
            _apiContext.SaveChanges();

            return RedirectToPage("Index");
        }

    }
}

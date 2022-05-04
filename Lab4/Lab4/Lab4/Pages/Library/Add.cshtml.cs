using Lab4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace Lab4.Pages.Library
{
    public class AddModel : PageModel
    {

        private readonly CustomerDbContext _apiContext;

        public AddModel(CustomerDbContext apiContext)
        {
            _apiContext = apiContext;
        }

        public Customer Customer { get; set; }

        public IActionResult OnPost(Customer customer)
        {
            _apiContext.Customers.Add(customer);
            _apiContext.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}

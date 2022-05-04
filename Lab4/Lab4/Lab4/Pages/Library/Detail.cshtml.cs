using Lab4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace Lab4.Pages.Library
{
    public class DetailModel : PageModel
    {
        private readonly CustomerDbContext _apiContext;

        public DetailModel(CustomerDbContext apiContext)
        {
            _apiContext = apiContext;
        }

        
        public Customer Customer { get; set; }
        public List<Book> Books { get; set; }

        public void OnGet(int id)
        {
            Customer= _apiContext.Customers.FirstOrDefault(x=>x.CustomerId==id);

            Books = _apiContext.Books.Where(x => x.CustomerId == id).ToList();
        }
    }
}

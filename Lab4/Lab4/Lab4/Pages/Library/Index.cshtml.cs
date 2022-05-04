using Lab4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab4.Pages.Library
{
    public class IndexModel : PageModel
    {
        private readonly CustomerDbContext _apiContext;

        public IndexModel(CustomerDbContext apiContext)
        {
            _apiContext = apiContext;
        }


        public IEnumerable<Customer> Customers { get; set; }
        public async Task OnGet()
        {
            Customers = await _apiContext.Customers.ToListAsync();
        }
    }
}

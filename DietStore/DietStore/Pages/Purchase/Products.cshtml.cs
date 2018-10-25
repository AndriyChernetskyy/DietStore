using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DietStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DietStore.Pages.Purchase
{
    public class ProductsModel : PageModel
    {
        private readonly StoreContext _storeContext;
        public List<Product> products { get; set; }
        public ProductsModel(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task OnGetAsync()
        {
            products = await _storeContext.Products.AsNoTracking().ToListAsync();
        }
    }
}
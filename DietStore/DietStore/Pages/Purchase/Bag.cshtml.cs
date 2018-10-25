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
    public class BagModel : PageModel
    {
        private readonly StoreContext _storeContext;

        public List<PurchaseModel> Purchases { get; set; }

        public double TotalSum { get; set; } = 0;
        
        public BagModel(StoreContext context)
        {
            _storeContext = context;
        }

        public async Task OnGetAsync()
        {
            Purchases = await _storeContext.Purchased.AsNoTracking().ToListAsync();
            foreach (var purchase in Purchases)
            {
                TotalSum += purchase.NumberOfItems * purchase.Price;
            }           
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var purchase = await _storeContext.Purchased.FindAsync(id);

            if(purchase != null)
            {
                _storeContext.Purchased.Remove(purchase);
                await _storeContext.SaveChangesAsync();
            }

            return RedirectToPage();
        }


        public async Task<IActionResult> OnPostAddItemAsync(int id)
        {
            var purchase = await _storeContext.Purchased.FindAsync(id);
            if (purchase != null)
            {
                ++purchase.NumberOfItems;
                await _storeContext.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSubstractItemAsync(int id)
        {
            var purchase = await _storeContext.Purchased.FindAsync(id);
            if(purchase != null)
            {
                --purchase.NumberOfItems;
                if (purchase.NumberOfItems == 0)
                {
                    _storeContext.Purchased.Remove(purchase);
                }
                await _storeContext.SaveChangesAsync();
            }
            return RedirectToPage();
        }

    }
}
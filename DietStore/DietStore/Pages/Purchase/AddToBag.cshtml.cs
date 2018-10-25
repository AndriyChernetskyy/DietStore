using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DietStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DietStore.Pages.Purchase
{
    public class AddToBagModel : PageModel
    {
        private readonly StoreContext _storeContext;
        
        public PurchaseModel Purchase { get; set; }

        public AddToBagModel(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = await _storeContext.Products.FindAsync(id);
            
            Purchase = new PurchaseModel { NameOfPurchase = product.Name, Price = product.Price, NumberOfItems = 1};
            if (ModelState.IsValid)
            {
                _storeContext.Purchased.Add(Purchase);
                await _storeContext.SaveChangesAsync();
                return RedirectToPage("./Bag");
            }
            return Page();
        }
    }
}
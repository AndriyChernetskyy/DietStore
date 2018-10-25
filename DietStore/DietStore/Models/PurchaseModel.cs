using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietStore.Models
{
    public class PurchaseModel
    {
        public int Id { get; set; }

        public string NameOfPurchase { get; set; }

        public double Price { get; set; } 

        public int NumberOfItems { get; set; }
    }
}

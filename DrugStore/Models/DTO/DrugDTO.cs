using System;
using System.Data.SqlTypes;

namespace DrugStore.Models.DTO
{
    public class DrugDTO
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; } //производитель
        public decimal Price { get; set; }
        public string Batch { get; set; } // серия препарата
        public DateTime ShelfLife { get; set; }
        public double InStock { get; set; }
  //      public decimal QuantityForSale { get; set; }
    }
}
using DrugStore.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DrugStore.Models.DTO
{
    public class CartDTO
    {
        //public DateTime DateBuy { get; set; }

        //public decimal Amount { get; set; }
        //public double Count { get; set; }
        //public int? ClientId { get; set; }

        //public Client Client { get; set; }

        //public Drug Drug { get; set; }
        //public int? DrugId { get; set; }

        private List<CartLineDTO> lineCollection = new List<CartLineDTO>();
        public IEnumerable<CartLineDTO> Lines { get { return lineCollection; } }
        public void AddItem(Drug drug, int quantity)
        {
            CartLineDTO line = lineCollection.
                Where(d => d.Drug.Id == drug.Id).FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLineDTO { Drug = drug, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveLine(Drug drug)
        {
            lineCollection.RemoveAll(l => l.Drug.Id == drug.Id);
        }
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Drug.Price * e.Quantity);
        }
        public void Clear()
        {
            lineCollection.Clear();
        }
    }

    public class CartLineDTO
    {
        public Drug Drug { get; set; }
        public int Quantity { get; set; }
    }
}
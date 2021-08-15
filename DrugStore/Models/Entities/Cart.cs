using DrugStore.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DrugStore.Models.Entities
{
    public class Cart : BaseEntity<int>
    {
       
        private List<CartLine> lineCollection = new List<CartLine>();
        public IEnumerable<CartLine> Lines { get { return lineCollection; } }
        //public void AddItem(Drug drug, decimal quantity)
        //{
        //    CartLine line = lineCollection.
        //        Where(d => d.Drug.Id == drug.Id).FirstOrDefault();
        //    if (line == null)
        //    {
        //        lineCollection.Add(new CartLine { Drug = drug, Quantity = quantity });
        //    }
        //    else
        //    {
        //        line.Quantity += quantity;
        //    }
        //}
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

        internal void AddItem(Drug drug, int quantity)
        {
            CartLine line = lineCollection.
                 Where(d => d.Drug.Id == drug.Id).FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine { Drug = drug, Quantity = quantity });
            }
            else
            {
               line.Quantity += quantity;
            }
        }
    }
    public class CartLine : BaseEntity<int>
    {
        public Drug Drug { get; set; }
        public int Quantity { get; set; }
    }
}
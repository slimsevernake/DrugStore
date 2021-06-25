using DrugStore.Models.Base;
using System.Collections.Generic;
using System.Linq;

namespace DrugStore.Models.Entities
{
    public class Cart : BaseEntity<int>
    {
        //public DateTime DateBuy { get; set; }
        //public decimal _amount;

        //public decimal Amount {
        //    get
        //    {
        //        return _amount;
        //    }

        //    set
        //    {
        //        if (value > 0)
        //        {
        //            _amount = value;
        //        }
        //        else
        //        {
        //            _amount = 0;
        //        }
        //    }
        //}
        //public double _count;
        //public double Count {
        //    get
        //    {
        //        return _count;
        //    }

        //    set
        //    {
        //        if (value > 0)
        //        {
        //            _count = value;
        //        }
        //        else
        //        {
        //            _count = 0;
        //        }
        //    }
        //}
        //public int? ClientId { get; set; }

        //public Client Client { get; set; }
        //public Drug Drug { get; set; }
        //public int? DrugId { get; set; }
        private List<CartLine> lineCollection = new List<CartLine>();
        public IEnumerable<CartLine> Lines { get { return lineCollection; } }
        public void AddItem(Drug drug, int quantity)
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
    public class CartLine : BaseEntity<int>
    {
        public Drug Drug { get; set; }
        public int Quantity { get; set; }
    }
}
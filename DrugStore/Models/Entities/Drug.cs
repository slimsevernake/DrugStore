using DrugStore.Models.Base;
using System;
using System.Data.SqlTypes;

namespace DrugStore.Models.Entities
{
    public class Drug : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; } //производитель
        public decimal _price;
        public decimal Price
        {
            get
            {
                return _price;
            }

            set
            {
                if (value > 0)
                {
                    _price = value;
                }
                else
                {
                    _price = 0;
                }
            }
        }

        //public decimal _quantityForSale;
        //public decimal QuantityForSale
        //{
        //    get
        //    {
        //        return _quantityForSale;
        //    }

        //    set
        //    {
        //        if (value > 0)
        //        {
        //            _quantityForSale = value;
        //        }
        //        else
        //        {
        //            _quantityForSale = 0;
        //        }
        //    }
        //}

        public string Batch { get; set; } // серия препарата
        public DateTime ShelfLife { get; set; }
        public double InStock { get; set; }
        public Drug() {
            Name = "";
            Manufacturer = "";
            Price = 0;
            Batch = "";
            ShelfLife = new DateTime();
            InStock = 0;
             }

        //public IEnumerator GetEnumerator()
        //{
        //    return ListDrugs.GetEnumerator();
        //}


        /*  public List<Drug> ListDrugs { get; set; }
          public Drug()
          {
              ListDrugs = new List<Drug>();
          }
        */


    }
}
using DrugStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrugStore.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public Drug Drug { get; set; }
        public string ReturnUrl { get; set; }
        public CartIndexViewModel()
        {

        }
    }
}
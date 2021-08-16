using DrugStore.Models.Entities;
using DrugStore.Models.Repository;
using DrugStore.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DrugStore.Models;

namespace DrugStore.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        // GET: Purchase
        private IDrugsRepository repository;
        public DrugContext db = new DrugContext();
        public CartController(IDrugsRepository repo)
        {
            repository = repo;
        }

        public ViewResult CartIndex(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl

            });

            
        }
        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
      //  [HttpPost]
        public ActionResult AddToCart(int? Id, string returnUrl)
        {
      
            Drug drug = db.Drugs.Find(Id);
           // decimal myQuantity = 0;
           //// myQuantity = (decimal)quantity;
           // myQuantity = 1;
            if (drug != null && drug.InStock > 0)
            {
                GetCart().AddItem(drug, 1);
               
                    drug.InStock = (double)(drug.InStock - 1);

                    db.SaveChanges();
                
            }
            else
            {
                TempData["notice"] = "Препарат остутствует на складе";
              
            }
            return RedirectToAction("CartIndex", new{returnUrl });
        }

        
        public ActionResult RemoveFromCart(int? Id, string returnUrl)
        {
            Drug drug = db.Drugs.Find(Id);
            //Drug drug = repository.IDrugs.FirstOrDefault(d => d.Name == drugName);
            if (drug != null)
            {
                GetCart().RemoveLine(drug);
                drug.InStock = drug.InStock + 1;

                db.SaveChanges();
            }
            return RedirectToAction("CartIndex", new { returnUrl });
        }
        public CartController()
        {
           
        }

    }
}
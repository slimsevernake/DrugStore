using DrugStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DrugStore.Models.Database
{
    public class DrugInitializer : CreateDatabaseIfNotExists<DrugContext>
    {
       // private UnitOfWork ef = UnitOfWork.Instance;
        protected override void Seed(DrugContext ctx)
        {

          //  var drug1 = new Drug
          //  {
          //      Name = "Амоксиклав 2Х табл. 1000 мг №14",
          //      Manufacturer = "Sandoz",
          //      Price = 198m,
          //      Batch = "KY5485",
          //      ShelfLife = new DateTime(2022, 09, 01),
          //      InStock = 20
          //  };

          //  var drug2 = new Drug
          //  {
          //      Name = "Амоксиклав КВИКТАБ табл. (500+125) мг №20",
          //      Manufacturer = "Sandoz",
          //      Price = 187.25m,
          //      Batch = "КЕ2354",
          //      ShelfLife = new DateTime(2022, 11, 01),
          //      InStock = 12d
          //  };
          //  var drug3 = new Drug
          //  {
          //      Name = "Амоксил ДТ табл. 500 мг №20",
          //      Manufacturer = "Артериум",
          //      Price = 76.90m,
          //      Batch = "219503",
          //      ShelfLife = new DateTime(2022, 02, 01),
          //      InStock = 1.5d
          //  };
          //  var drug4 = new Drug
          //  {
          //      Name = "Амоксил-К табл. 1000 мг №14",
          //      Manufacturer = "Артериум",
          //      Price = 128m,
          //      Batch = "0017279",
          //      ShelfLife = new DateTime(2022, 02, 01),
          //      InStock = 8d
          //  };

          //  var client1 = new Client
          //  {
          //      FirstName = "Vasiliy",
          //      MiddleName = "Ivanivich",
          //      LastName = "Pupkin",
          //      Age = 33,
          //      Email = "vasya@gmail.com",
          //      Phone = "380501234567"
          //  };

          //  var client2 = new Client
          //  {
          //      FirstName = "Mariya",
          //      MiddleName = "Sergeevna",
          //      LastName = "Orlova",
          //      Age = 45,
          //      Email = "masha@gmail.com",
          //      Phone = "380679856213"
          //  };


          //  //ef.PurchasesRepository.Create(new Purchase
          //  //{

          //  //    DateBuy = new DateTime(2021, 02, 01),
          //  //    Count = 1d,
          //  //    Amount = 187.25m,
          //  //    Drug = drug2,
          //  //    Client = client1
          //  //});

          //  //ef.PurchasesRepository.Create(new Purchase
          //  //{

          //  //    DateBuy = new DateTime(2021, 02, 01),
          //  //    Count = 1d,
          //  //    Amount = 198m,
          //  //    Drug = drug1,
          //  //    Client = client2
          //  //});

          //  //var purch1 = new Purchase
          //  //{
          //  //    DateBuy = new DateTime(2021, 02, 01),
          //  //    Count = 1f,
          //  //    Amount = 187.25m,
          //  //    Drug = drug2,
          //  //    Client = client1

          //  //};

          //  //var purch2 = new Purchase
          //  //{
          //  //    DateBuy = new DateTime(2021, 02, 01),

          //  //    Count = 1f,
          //  //    Amount = 198m,
          //  //    Drug = drug1,
          //  //    Client = client2

          //  //};
          //  Purchase purchase = new Purchase();
          //  purchase.AddItem(drug1, 1);
          //  purchase.AddItem(drug2, 2);
          //  purchase.AddItem(drug3, 3);
          //  List<PurchaseLine> results = purchase.Lines.OrderBy(d => d.Drug.Id).ToList();

          //  ctx.Drugs.Add(drug1);
          //  ctx.Drugs.Add(drug2);
          //  ctx.Drugs.Add(drug3);
          //  ctx.Drugs.Add(drug4);
          //  ctx.Clients.Add(client1);
          //  ctx.Clients.Add(client2);
          //  ctx.Purchases.Add(purchase);
          //  //ctx.Purchases.Add(purch2);

          //  // ctx.SaveChanges();
          ////  ef.Save();
          //  ctx.SaveChanges();
        }
    }
}
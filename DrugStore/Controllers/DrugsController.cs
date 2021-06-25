using DrugStore.Models.Database;
using DrugStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.SqlTypes;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;

namespace DrugStore.Controllers
{
    public class DrugsController : Controller
    {
        // GET: Drugs
        // IXLWorksheet worksheet;
        public DrugContext db = new DrugContext();
      
        // GET: Drugs
        public ActionResult Index()
        {
            return View(db.Drugs.ToList());
        }

        // GET: Drugs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drug drug = db.Drugs.Find(id);
            if (drug == null)
            {
                return HttpNotFound();
            }
            return View(drug);
        }

        // GET: Drugs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Drugs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Manufacturer,Price,Batch,ShelfLife,InStock")] Drug drug)
        {
            if (ModelState.IsValid)
            {
                db.Drugs.Add(drug);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drug);
        }

        // GET: Drugs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drug drug = db.Drugs.Find(id);
            if (drug == null)
            {
                return HttpNotFound();
            }
            return View(drug);
        }

        // POST: Drugs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Manufacturer,Price,Batch,ShelfLife,InStock")] Drug drug)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drug).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drug);
        }

        // GET: Drugs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drug drug = db.Drugs.Find(id);
            if (drug == null)
            {
                return HttpNotFound();
            }
            return View(drug);
        }

        // POST: Drugs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Drug drug = db.Drugs.Find(id);
            db.Drugs.Remove(drug);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //[HttpPost]
        //public ActionResult Import(HttpPostedFileBase fileExcel)
        //{
        //    Drug drug = new Drug();
        //    if (ModelState.IsValid)
        //    {

        //       // IXLWorksheet worksheet;
        //        using (XLWorkbook workBook = new XLWorkbook(fileExcel.InputStream, XLEventTracking.Disabled))
        //        {

        //            var worksheet = workBook.Worksheet(1);
        //            //foreach (IXLWorksheet worksheet in workBook.Worksheets)
        //            //{
        //            //    PhoneBrand phoneBrand = new PhoneBrand();
        //            //    phoneBrand.Title = worksheet.Name;

        //            foreach (IXLColumn column in worksheet.ColumnsUsed())
        //            {

        //                //    PhoneModel phoneModel = new PhoneModel();
        //                //    phoneModel.Title = column.Cell(1).Value.ToString();

        //                foreach (IXLRow row in worksheet.RowsUsed().Skip(1))
        //                    {
        //                        try
        //                        {
        //                    ///PricePosition pricePosition = new PricePosition();
        //                    //pricePosition.Problem = row.Cell(1).Value.ToString();
        //                    //pricePosition.Price = row.Cell(column.ColumnNumber()).Value.ToString();
        //                    //phoneModel.PricePositions.Add(pricePosition);

        //                        drug.Name = row.Cell(1).Value.ToString(); 
        //                        drug.Manufacturer = row.Cell(2).Value.ToString();
        //                        drug.Price = (decimal)row.Cell(3).Value;
        //                        drug.Batch = row.Cell(4).Value.ToString();
        //                        drug.ShelfLife = (DateTime)row.Cell(5).Value;
        //                        drug.InStock = (float)row.Cell(6).Value;

        //                        db.Drugs.Add(drug);
        //                    }
        //                        catch (Exception)
        //                        {
        //                            //logging
        //                           // drug.ErrorsTotal++;
        //                        }
        //                   // db.Drugs.Add(drug);
        //                }

        //                // phoneBrand.PhoneModels.Add(phoneModel);
        //                // }
        //              //  db.Drugs.Add(drug);
        //             //  db.Drugs.ToList();

        //            }

        //        }
        //        //например, здесь сохраняем все позиции из прайса в БД

        //     return View(drug);
        //    }

        //     return RedirectToAction("Index");
        //}


        [HttpPost]
        public ActionResult Import(HttpPostedFileBase excelfile)
        {
          
            if (excelfile == null || excelfile.ContentLength == 0)
            {
                ViewBag.Error = "Please select a Excel file.<br>";
                return View("Index");
            }
            else
            {
                if (excelfile.FileName.EndsWith("xls") || excelfile.FileName.EndsWith("xlsx"))
                {
                    string path = Server.MapPath("~/Content/" + excelfile.FileName);
                    //if (System.IO.File.Exists(path))
                    //    System.IO.File.Delete(path);
                    //excelfile.SaveAs(path);
                    Excel.Application application = new Excel.Application();
                    Excel.Workbook workbook = application.Workbooks.Open(path);
                    Excel.Worksheet worksheet = workbook.ActiveSheet;
                    Excel.Range range = worksheet.UsedRange;
                    List<Drug> drugs = new List<Drug>();
                    for (int row = 2; row <= 43; row++)
                    {
                        Drug d = new Drug();
                        d.Id = Convert.ToInt32(((Excel.Range)range.Cells[row, 1]).Value);
                        d.Name = ((Excel.Range)range.Cells[row, 2]).Text;
                        d.Manufacturer = ((Excel.Range)range.Cells[row, 3]).Text;
                        d.Price = Convert.ToDecimal(((Excel.Range)range.Cells[row, 4]).Value);
                        d.Batch = ((Excel.Range)range.Cells[row, 5]).Text;
                        d.ShelfLife = Convert.ToDateTime(((Excel.Range)range.Cells[row, 6]).Value);
                        d.InStock = Convert.ToDouble(((Excel.Range)range.Cells[row, 7]).Value);
                        drugs.Add(d);
                        db.Drugs.Add(d);
                        db.SaveChanges();
                    }
                  
                    ViewBag.drugs = drugs;
                   
                    return View("Import");
                }
                else
                {
                    ViewBag.Error = "File type is incorrect.<br>";
                    return View("Index");
                }
              
            }
           
        }
        


        [HttpPost]
        public FileResult Export()
        {

            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[7] { new DataColumn("Id"),
                                                     new DataColumn("Name"),
                                                     new DataColumn("Manufacturer"),
                                                     new DataColumn("Price"),
                                                     new DataColumn("Batch"),
                                                     new DataColumn("ShelfLife"),
                                                     new DataColumn("InStock") });
                    

            var drug = from Drug in db.Drugs select Drug;

            foreach (var d in drug)
            {
                dt.Rows.Add(d.Id, d.Name, d.Manufacturer, d.Price,
                    d.Batch, d.ShelfLife, d.InStock);
            }

            using (XLWorkbook wb = new XLWorkbook()) //Install ClosedXml from Nuget for XLWorkbook  
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream()) //using System.IO;  
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DrugsExcelFile.xlsx");
                }
            }
        }

        }
}
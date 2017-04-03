using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class ReceiptsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Receipts
        public ActionResult Index()
        {
            var receipts = db.Receipts.Include(d => d.Ingridients);
            return View(receipts.ToList());
        }

        // GET: Receipts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipts receipts = db.Receipts.Find(id);
            if (receipts == null)
            {
                return HttpNotFound();
            }
            return View(receipts);
        }

        // GET: Receipts/Create
        public ActionResult Create()
        {
            ViewBag.Ingridient_Id = new SelectList(db.Ingridients, "Ingridient_Id", "IngridientName", "Ingridient_Quantity");
            return View();
        }

        // POST: Receipts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Receipt_Id,ReceiptName,Ingridient_Id, Ingridient_Quantity")] Receipts receipts)
        {
            if (ModelState.IsValid)
            {
                db.Receipts.Add(receipts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ingridient_Id = new SelectList(db.Ingridients, "Ingridient_Id", "IngridientName", "Ingridient_Quantity");
            return View(receipts);
        }

        // GET: Receipts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipts receipts = db.Receipts.Find(id);
            if (receipts == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ingridient_Id = new SelectList(db.Ingridients, "Ingridient_Id", "IngridientName", "Ingridient_Quantity");
            return View(receipts);
        }

        // POST: Receipts/Edit/5/
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Receipt_Id,ReceiptName,Ingridient_Id, Ingridient_Quantity")] Receipts receipts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receipts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ingridient_Id = new SelectList(db.Ingridients, "Ingridient_Id", "IngridientName", "Ingridient_Quantity");
            return View(receipts);
        }

        // GET: Receipts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipts receipts = db.Receipts.Find(id);
            if (receipts == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ingridient_Id = new SelectList(db.Ingridients, "Ingridient_Id", "IngridientName", "Ingridient_Quantity");
            return View(receipts);
        }

        // POST: Receipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Receipts receipts = db.Receipts.Find(id);
            db.Receipts.Remove(receipts);
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
    }
}

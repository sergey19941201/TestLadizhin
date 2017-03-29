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
    public class IngridientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<string> ReceiptsList = new List<string>();

        // GET: Ingridients
        public ActionResult Index()
        {
            var ingridients = db.Ingridients.Include(i => i.Receipts);
            return View(ingridients.ToList());
        }

        // GET: Ingridients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingridients ingridients = db.Ingridients.Find(id);
            if (ingridients == null)
            {
                return HttpNotFound();
            }
            return View(ingridients);
        }

        // GET: Ingridients/Create
        public ActionResult Create()
        {
            //ViewBag.Receipt_Id = new SelectList(db.Receipts, "Receipt_Id", "ReceiptName");

            //ViewBag.Ingridient_Id = new SelectList(db.Receipts, "Ingridient_Id", "IngridientName");
            return View();
        }

        // POST: Ingridients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ingridient_Id,IngridientName,Quantity")] Ingridients ingridients)
        {
            if (ModelState.IsValid)
            {
                db.Ingridients.Add(ingridients);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ingridients);
        }

        // GET: Ingridients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingridients ingridients = db.Ingridients.Find(id);
            if (ingridients == null)
            {
                return HttpNotFound();
            }
            return View(ingridients);
        }

        // POST: Ingridients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ingridient_Id,IngridientName,Receipt_Id,Quantity")] Ingridients ingridients)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingridients).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.Receipt_Id = new SelectList(db.Receipts, "Receipt_Id", "ReceiptName", ingridients.Receipt_Id);
            return View(ingridients);
        }

        // GET: Ingridients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingridients ingridients = db.Ingridients.Find(id);
            if (ingridients == null)
            {
                return HttpNotFound();
            }
            return View(ingridients);
        }

        // POST: Ingridients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ingridients ingridients = db.Ingridients.Find(id);
            db.Ingridients.Remove(ingridients);
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

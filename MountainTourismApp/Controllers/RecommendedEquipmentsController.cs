using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MountainTourismApp.Models;

namespace MountainTourismApp.Controllers
{
    public class RecommendedEquipmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RecommendedEquipments
        public ActionResult Index()
        {
            return View(db.RecommendedEquipment.ToList());
        }

        public ActionResult Pravilnik()
        {
            return View();
        }

        // GET: RecommendedEquipments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecommendedEquipment recommendedEquipment = db.RecommendedEquipment.Find(id);
            if (recommendedEquipment == null)
            {
                return HttpNotFound();
            }
            return View(recommendedEquipment);
        }

        // GET: RecommendedEquipments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecommendedEquipments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,hotDesc,coldDesc")] RecommendedEquipment recommendedEquipment)
        {
            if (ModelState.IsValid)
            {
                db.RecommendedEquipment.Add(recommendedEquipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recommendedEquipment);
        }

        // GET: RecommendedEquipments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecommendedEquipment recommendedEquipment = db.RecommendedEquipment.Find(id);
            if (recommendedEquipment == null)
            {
                return HttpNotFound();
            }
            return View(recommendedEquipment);
        }

        // POST: RecommendedEquipments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,hotDesc,coldDesc")] RecommendedEquipment recommendedEquipment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recommendedEquipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recommendedEquipment);
        }

        // GET: RecommendedEquipments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecommendedEquipment recommendedEquipment = db.RecommendedEquipment.Find(id);
            if (recommendedEquipment == null)
            {
                return HttpNotFound();
            }
            return View(recommendedEquipment);
        }

        // POST: RecommendedEquipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecommendedEquipment recommendedEquipment = db.RecommendedEquipment.Find(id);
            db.RecommendedEquipment.Remove(recommendedEquipment);
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

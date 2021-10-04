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
    public class FinalReservationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FinalReservations
        public ActionResult Index()
        {
            return View(db.FinalReservations.ToList());
        }

        // GET: FinalReservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinalReservation finalReservation = db.FinalReservations.Find(id);
            if (finalReservation == null)
            {
                return HttpNotFound();
            }
            return View(finalReservation);
        }

        // GET: FinalReservations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FinalReservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,userEmail,finalSherpa,gpsFile,mountain")] FinalReservation finalReservation)
        {
            if (ModelState.IsValid)
            {
                db.FinalReservations.Add(finalReservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(finalReservation);
        }

        // GET: FinalReservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinalReservation finalReservation = db.FinalReservations.Find(id);
            if (finalReservation == null)
            {
                return HttpNotFound();
            }
            return View(finalReservation);
        }

        // POST: FinalReservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,userEmail,finalSherpa,gpsFile,mountain")] FinalReservation finalReservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(finalReservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(finalReservation);
        }

        // GET: FinalReservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinalReservation finalReservation = db.FinalReservations.Find(id);
            if (finalReservation == null)
            {
                return HttpNotFound();
            }
            return View(finalReservation);
        }

        // POST: FinalReservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FinalReservation finalReservation = db.FinalReservations.Find(id);
            db.FinalReservations.Remove(finalReservation);
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

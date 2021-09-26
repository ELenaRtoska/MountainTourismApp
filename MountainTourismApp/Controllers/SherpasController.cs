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
    public class SherpasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sherpas
        public ActionResult Index(int? id)
        {
            ViewBag.parm = id;
            return View(db.Sherpa.Where(b => b.GPSFileId == id).ToList());
            // return View(db.Sherpa.ToList());
        }

        // GET: Sherpas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sherpa sherpa = db.Sherpa.Find(id);
            if (sherpa == null)
            {
                return HttpNotFound();
            }
            return View(sherpa);
        }

        // GET: Sherpas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sherpas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GPSFileId,ImageURL,name,licence,description,yearsOfExperience")] Sherpa sherpa)
        {
            if (ModelState.IsValid)
            {
                db.Sherpa.Add(sherpa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sherpa);
        }

        // GET: Sherpas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sherpa sherpa = db.Sherpa.Find(id);
            if (sherpa == null)
            {
                return HttpNotFound();
            }
            return View(sherpa);
        }

        // POST: Sherpas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GPSFileId,ImageURL,name,licence,description,yearsOfExperience")] Sherpa sherpa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sherpa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sherpa);
        }

        // GET: Sherpas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sherpa sherpa = db.Sherpa.Find(id);
            if (sherpa == null)
            {
                return HttpNotFound();
            }
            return View(sherpa);
        }

        // POST: Sherpas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sherpa sherpa = db.Sherpa.Find(id);
            db.Sherpa.Remove(sherpa);
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

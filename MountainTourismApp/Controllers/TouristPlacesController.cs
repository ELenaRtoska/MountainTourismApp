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
    public class TouristPlacesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult IndexAll()
        {
             return View(db.TouristPlaces.ToList());
        }

        // GET: TouristPlaces
        public ActionResult Index(int? id)
        {
            ViewBag.parm = id;
            return View(db.TouristPlaces.Where(b => b.SherpaId == id).ToList());
        }


        // GET: TouristPlaces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristPlace touristPlace = db.TouristPlaces.Find(id);
            if (touristPlace == null)
            {
                return HttpNotFound();
            }
            return View(touristPlace);
        }

        // GET: TouristPlaces/Create
        public ActionResult Create(int? id)
        {
            ViewBag.parm = id;
            return View();
        }

        // POST: TouristPlaces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SherpaId,ImageURL,name,description")] TouristPlace touristPlace)
        {
            if (ModelState.IsValid)
            {
                db.TouristPlaces.Add(touristPlace);
                db.SaveChanges();
                //return RedirectToAction("Index");
            }

            var a = "https://localhost:44386/TouristPlaces/Index/" + touristPlace.SherpaId.ToString();
            return Redirect(a);
        }

        // GET: TouristPlaces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristPlace touristPlace = db.TouristPlaces.Find(id);
            ViewBag.parm = touristPlace.SherpaId;
            if (touristPlace == null)
            {
                return HttpNotFound();
            }
            return View(touristPlace);
        }

        // POST: TouristPlaces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SherpaId,ImageURL,name,description")] TouristPlace touristPlace)
        {
            if (ModelState.IsValid)
            {
                db.Entry(touristPlace).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
            }
            var a = "https://localhost:44386/TouristPlaces/Index/" + touristPlace.SherpaId.ToString();
            return Redirect(a);
        }

        // GET: TouristPlaces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristPlace touristPlace = db.TouristPlaces.Find(id);
            ViewBag.parm = touristPlace.SherpaId;
            if (touristPlace == null)
            {
                return HttpNotFound();
            }
            return View(touristPlace);
        }

        // POST: TouristPlaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TouristPlace touristPlace = db.TouristPlaces.Find(id);
            db.TouristPlaces.Remove(touristPlace);
            db.SaveChanges();

            var a = "https://localhost:44386/TouristPlaces/Index/" + touristPlace.SherpaId.ToString();
            return Redirect(a);
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

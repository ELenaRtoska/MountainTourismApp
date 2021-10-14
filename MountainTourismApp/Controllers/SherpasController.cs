using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MountainTourismApp.Models;

namespace MountainTourismApp.Controllers
{
    public class SherpasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult IndexAll()
        {
             return View(db.Sherpa.ToList());
        }

        // GET: Sherpas
        public ActionResult Index(int id)
        {
            ViewBag.parm = id;

            var mountainGPS = db.GPSFile.Where(b => b.Id == id).ToList().FirstOrDefault().mountainId;
            ViewBag.mountain = mountainGPS;

            return View(db.Sherpa.Where(b => b.GPSFileId == id).ToList());

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
        public ActionResult Create(int? id)
        {
            ViewBag.parm = id;
            return View();
        }

        // POST: Sherpas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GPSFileId,ImageURL,name,licence,description,yearsOfExperience,club,hikers,dateTime")] Sherpa sherpa)
        {
            if (ModelState.IsValid)
            {
                db.Sherpa.Add(sherpa);
                db.SaveChanges();
                //return RedirectToAction("Index");
            }

            //return View(sherpa);
            //ViewBag.parm = sherpa.GPSFileId;
            var a = "https://localhost:44386/Sherpas/Index/" + sherpa.GPSFileId.ToString();
            return Redirect(a);
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


            ViewBag.parm = id;

            var userEmail = this.User.Identity.Name;
            ViewBag.userEmail = userEmail;

            var finalSherpa = db.Sherpa.Where(b => b.Id == id).ToList().FirstOrDefault().name;
            var gpsFileSherpa = db.Sherpa.Where(b => b.Id == id).ToList().FirstOrDefault().GPSFileId;
            ViewBag.finalSherpa = finalSherpa;

            var gpsFile = db.GPSFile.Where(b => b.Id == gpsFileSherpa).ToList().FirstOrDefault().description;
            var mountainGPS = db.GPSFile.Where(b => b.Id == gpsFileSherpa).ToList().FirstOrDefault().mountainId;
            ViewBag.gpsFile = gpsFile;

            var mountain = db.Mountains.Where(b => b.Id == mountainGPS).ToList().FirstOrDefault().Name;
            ViewBag.mountain = mountain;
            return View(sherpa);
        }

        // POST: Sherpas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GPSFileId,ImageURL,name,licence,description,yearsOfExperience,club,hikers,dateTime")] Sherpa sherpa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sherpa).State = EntityState.Modified;
                db.SaveChanges();
                // return RedirectToAction("Index");
            }
            

            int _id = sherpa.Id;
            db.Sherpa.Where(b => b.Id == _id).ToList().FirstOrDefault().hikers++;
            db.SaveChanges();
            FinalReservation finalReservation = new FinalReservation();
            var userEmail = this.User.Identity.Name;
            var finalSherpa = db.Sherpa.Where(b => b.Id == _id).ToList().FirstOrDefault().name;
            var gpsFileSherpa = db.Sherpa.Where(b => b.Id == _id).ToList().FirstOrDefault().GPSFileId;
            var gpsFile = db.GPSFile.Where(b => b.Id == gpsFileSherpa).ToList().FirstOrDefault().description;
            var mountainGPS = db.GPSFile.Where(b => b.Id == gpsFileSherpa).ToList().FirstOrDefault().mountainId;
            var mountain = db.Mountains.Where(b => b.Id == mountainGPS).ToList().FirstOrDefault().Name;
            var dateTime = db.Sherpa.Where(b => b.Id == _id).ToList().FirstOrDefault().dateTime;
            var hikers = db.Sherpa.Where(b => b.Id == _id).ToList().FirstOrDefault().hikers;
            ViewBag.mountain = mountain;
            finalReservation.userEmail = userEmail;
            finalReservation.finalSherpa = finalSherpa;
            finalReservation.gpsFile = gpsFile;
            finalReservation.mountain = mountain;
            finalReservation.dateTime = dateTime;
            finalReservation.hikers = hikers;
            db.FinalReservations.Add(finalReservation);
            db.SaveChanges();

            return Redirect("https://localhost:44386/FinalReservations");

        }

        // GET: Sherpas/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.parm = db.Sherpa.Where(b => b.Id == id).ToList().FirstOrDefault().GPSFileId;
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
            //ViewBag.parm = sherpa.GPSFileId;
            var a = "https://localhost:44386/Sherpas/Index/" + sherpa.GPSFileId.ToString();
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

        public ActionResult ListTouristPlaces(int? id)
        {
            return RedirectToAction("Index", new RouteValueDictionary(new { Controller = "TouristPlaces", Action = "Index", Id = id }));
        }

        


    }
}

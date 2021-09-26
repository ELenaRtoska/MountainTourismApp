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
    public class MountainsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Mountains
        public ActionResult Index()
        {
            return View(db.Mountains.ToList());
        }

        // GET: Mountains/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mountain mountain = db.Mountains.Find(id);
            if (mountain == null)
            {
                return HttpNotFound();
            }
            return View(mountain);
        }

        // GET: Mountains/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mountains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ImageURL,Raiting,Description")] Mountain mountain)
        {
            if (ModelState.IsValid)
            {
                db.Mountains.Add(mountain);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mountain);
        }

        // GET: Mountains/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mountain mountain = db.Mountains.Find(id);
            if (mountain == null)
            {
                return HttpNotFound();
            }
            return View(mountain);
        }

        // POST: Mountains/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ImageURL,Raiting,Description")] Mountain mountain)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mountain).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mountain);
        }

        // GET: Mountains/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mountain mountain = db.Mountains.Find(id);
            if (mountain == null)
            {
                return HttpNotFound();
            }
            return View(mountain);
        }

        // POST: Mountains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mountain mountain = db.Mountains.Find(id);
            db.Mountains.Remove(mountain);
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

        public ActionResult ListGPSFiles(int? id)
        {
            return RedirectToAction("Index", new RouteValueDictionary(new { Controller = "GPSFiles", Action = "Index", Id = id }));
        }
        
    }
}

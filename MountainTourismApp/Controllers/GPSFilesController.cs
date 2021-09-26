using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MountainTourismApp.Models;

namespace MountainTourismApp.Controllers
{
    public class GPSFilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GPSFiles
        public ActionResult Index(int? id)
        {
            ViewBag.parm = id;
            return View(db.GPSFile.Where(b => b.mountainId == id).ToList());
           // return View(db.GPSFile.ToList());
        }


        // GET: GPSFiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GPSFile gPSFile = db.GPSFile.Find(id);
            if (gPSFile == null)
            {
                return HttpNotFound();
            }
            return View(gPSFile);
        }

        // GET: GPSFiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: GPSFiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GPSFile gPSFile = db.GPSFile.Find(id);
            if (gPSFile == null)
            {
                return HttpNotFound();
            }
            return View(gPSFile);
        }

        // POST: GPSFiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Edit([Bind(Include = "Id,mountainId,title,description,distance,positiveD,negativeD,uploadFile")] GPSFile gPSFile)
         {
             if (ModelState.IsValid)
             {
                 db.Entry(gPSFile).State = EntityState.Modified;
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }
             return View(gPSFile);
         }
         

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,mountainId,title,description,distance,positiveD,negativeD,uploadFile")] GPSFile gPSFile)
        {
            string fileName = System.IO.Path.GetFileNameWithoutExtension(gPSFile.uploadFile.FileName);
                string extension = System.IO.Path.GetExtension(gPSFile.uploadFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                gPSFile.filePath = "~/GPSFile/" + fileName;
                gPSFile.title = fileName;
                fileName = Path.Combine(Server.MapPath("~/GPSFile/"), fileName);
                gPSFile.uploadFile.SaveAs(fileName);

                db.GPSFile.Add(gPSFile);
                db.SaveChanges();

                ModelState.Clear();
            return View();
        }
        
        // GET: GPSFiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GPSFile gPSFile = db.GPSFile.Find(id);
            if (gPSFile == null)
            {
                return HttpNotFound();
            }
            return View(gPSFile);
        }

        // POST: GPSFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GPSFile gPSFile = db.GPSFile.Find(id);
            db.GPSFile.Remove(gPSFile);
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

        [HttpGet]
        public ActionResult View(int id)
        {
            GPSFile GPSFileModel = new GPSFile();
            GPSFileModel = db.GPSFile.Where(x => x.Id == id).FirstOrDefault();
            this.downloadFile(GPSFileModel.title);
            //return View();
            //return RedirectToAction("Index", "GPSFile");
            return RedirectToAction("Index", "Mountain");
        }


        public void downloadFile(String file)
        {
            try
            {
                String fileName = file;
                String filePath = Server.MapPath("~/GPSFile/" + fileName);

                Response.Clear();
                Response.ClearHeaders();
                Response.ClearContent();
                Response.AddHeader("Content-Disposition", "attachment; fileName=" + fileName);
                Response.Flush();
              //  HttpContext.ApplicationInstance.CompleteRequest();
                Response.TransmitFile(filePath);
                Response.End();

                ViewBag.message = "";
            }
            catch(Exception ex)
            {
                ViewBag.message = ex.Message.ToString();
            }
        }

        public ActionResult ListSherpas(int? id)
        {
            return RedirectToAction("Index", new RouteValueDictionary(new { Controller = "Sherpas", Action = "Index", Id = id }));
        }

        /*  public ActionResult Index2(int id)
          {
              ViewBag.parm = id;
              return View(db.GPSFile.Where(b => b.mountainId == id).ToList());
          }
          */

    }
}

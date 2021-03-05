using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetAnimals.Data;
using PetAnimals.Models;

namespace PetAnimals.Controllers
{
    public class CurrentOwnersController : Controller
    {
        private PetAnimalsContext db = new PetAnimalsContext();

        // GET: CurrentOwners
        public ActionResult Index()
        {
            var currentOwners = db.CurrentOwners.Include(c => c.Owner).Include(c => c.Pet);
            return View(currentOwners.ToList());
        }

        // GET: CurrentOwners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrentOwner currentOwner = db.CurrentOwners.Find(id);
            if (currentOwner == null)
            {
                return HttpNotFound();
            }
            return View(currentOwner);
        }

        // GET: CurrentOwners/Create
        public ActionResult Create()
        {
            ViewBag.OwnerId = new SelectList(db.Owners, "OwnerId", "Name");
            ViewBag.PetId = new SelectList(db.Pets, "PetId", "PetName");
            return View();
        }

        // POST: CurrentOwners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CurrentId,PetId,OwnerId")] CurrentOwner currentOwner)
        {
            if (ModelState.IsValid)
            {
                db.CurrentOwners.Add(currentOwner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OwnerId = new SelectList(db.Owners, "OwnerId", "Name", currentOwner.OwnerId);
            ViewBag.PetId = new SelectList(db.Pets, "PetId", "PetName", currentOwner.PetId);
            return View(currentOwner);
        }

        // GET: CurrentOwners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrentOwner currentOwner = db.CurrentOwners.Find(id);
            if (currentOwner == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerId = new SelectList(db.Owners, "OwnerId", "Name", currentOwner.OwnerId);
            ViewBag.PetId = new SelectList(db.Pets, "PetId", "PetName", currentOwner.PetId);
            return View(currentOwner);
        }

        // POST: CurrentOwners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CurrentId,PetId,OwnerId")] CurrentOwner currentOwner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(currentOwner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerId = new SelectList(db.Owners, "OwnerId", "Name", currentOwner.OwnerId);
            ViewBag.PetId = new SelectList(db.Pets, "PetId", "PetName", currentOwner.PetId);
            return View(currentOwner);
        }

        // GET: CurrentOwners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrentOwner currentOwner = db.CurrentOwners.Find(id);
            if (currentOwner == null)
            {
                return HttpNotFound();
            }
            return View(currentOwner);
        }

        // POST: CurrentOwners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CurrentOwner currentOwner = db.CurrentOwners.Find(id);
            db.CurrentOwners.Remove(currentOwner);
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

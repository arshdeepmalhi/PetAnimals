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
    public class SpeciesController : Controller
    {
        private PetAnimalsContext db = new PetAnimalsContext();

        // GET: Species
        public ActionResult Index()
        {
            return View(db.Species.ToList());
        }

        // GET: Species/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specie specie = db.Species.Find(id);
            if (specie == null)
            {
                return HttpNotFound();
            }
            return View(specie);
        }

        // GET: Species/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Species/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SpecieId,SpecieName")] Specie specie)
        {
            if (ModelState.IsValid)
            {
                db.Species.Add(specie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(specie);
        }

        // GET: Species/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specie specie = db.Species.Find(id);
            if (specie == null)
            {
                return HttpNotFound();
            }
            return View(specie);
        }

        // POST: Species/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SpecieId,SpecieName")] Specie specie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(specie);
        }

        // GET: Species/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specie specie = db.Species.Find(id);
            if (specie == null)
            {
                return HttpNotFound();
            }
            return View(specie);
        }

        // POST: Species/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Specie specie = db.Species.Find(id);
            db.Species.Remove(specie);
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

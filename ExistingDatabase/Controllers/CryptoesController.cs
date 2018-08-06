using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExistingDatabase.Models;

namespace ExistingDatabase.Controllers
{
    public class CryptoesController : Controller
    {
        private coreDBEntities db = new coreDBEntities();

        // GET: Cryptoes
        public ActionResult Index()
        {
            return View(db.Cryptoes.ToList());
        }

        // GET: Cryptoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crypto crypto = db.Cryptoes.Find(id);
            if (crypto == null)
            {
                return HttpNotFound();
            }
            return View(crypto);
        }

        // GET: Cryptoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cryptoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CryptoName,Type,Price,Country")] Crypto crypto)
        {
            if (ModelState.IsValid)
            {
                db.Cryptoes.Add(crypto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(crypto);
        }

        // GET: Cryptoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crypto crypto = db.Cryptoes.Find(id);
            if (crypto == null)
            {
                return HttpNotFound();
            }
            return View(crypto);
        }

        // POST: Cryptoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CryptoName,Type,Price,Country")] Crypto crypto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crypto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(crypto);
        }

        // GET: Cryptoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crypto crypto = db.Cryptoes.Find(id);
            if (crypto == null)
            {
                return HttpNotFound();
            }
            return View(crypto);
        }

        // POST: Cryptoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Crypto crypto = db.Cryptoes.Find(id);
            db.Cryptoes.Remove(crypto);
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

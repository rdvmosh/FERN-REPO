using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorkOrderSite.DAL;
using WorkOrderSite.Models;

namespace WorkOrderSite.Controllers
{
    public class PrimaryContactsController : Controller
    {
        private WorkOrderContext db = new WorkOrderContext();

        // GET: PrimaryContacts
        public ActionResult Index()
        {
            return View(db.PrimaryContact.ToList());
        }

        // GET: PrimaryContacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrimaryContact primaryContact = db.PrimaryContact.Find(id);
            if (primaryContact == null)
            {
                return HttpNotFound();
            }
            return View(primaryContact);
        }

        // GET: PrimaryContacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrimaryContacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrimaryContactID,PrimaryContactFName,PrimaryContactLName,PrimaryContactPhoneNumber,PrimaryContactEmail")] PrimaryContact primaryContact)
        {
            if (ModelState.IsValid)
            {
                db.PrimaryContact.Add(primaryContact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(primaryContact);
        }

        // GET: PrimaryContacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrimaryContact primaryContact = db.PrimaryContact.Find(id);
            if (primaryContact == null)
            {
                return HttpNotFound();
            }
            return View(primaryContact);
        }

        // POST: PrimaryContacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrimaryContactID,PrimaryContactFName,PrimaryContactLName,PrimaryContactPhoneNumber,PrimaryContactEmail")] PrimaryContact primaryContact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(primaryContact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(primaryContact);
        }

        // GET: PrimaryContacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrimaryContact primaryContact = db.PrimaryContact.Find(id);
            if (primaryContact == null)
            {
                return HttpNotFound();
            }
            return View(primaryContact);
        }

        // POST: PrimaryContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrimaryContact primaryContact = db.PrimaryContact.Find(id);
            db.PrimaryContact.Remove(primaryContact);
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

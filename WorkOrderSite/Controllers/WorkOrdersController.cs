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
using System.Data.Entity.Infrastructure;

namespace WorkOrderSite.Controllers
{

    [Authorize(Roles = "Admin")]
    public class WorkOrdersController : Controller
    {
        
        private void PopulateLocationDropDownList(object selectedLocation = null)
        {
            var departmentsQuery = from d in db.Locations
            orderby d.LocationName
            select d;
            ViewBag.DepartmentID = new SelectList(departmentsQuery, "LocationID",
               "LocationName", selectedLocation);
        }
        private WorkOrderContext db = new WorkOrderContext();

        // GET: WorkOrders
        public ActionResult Index()
        {
            return View(db.WorkOrderSite.ToList());
        }

        // GET: WorkOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder workOrder = db.WorkOrderSite.Find(id);
            if (workOrder == null)
            {
                return HttpNotFound();
            }
            return View(workOrder);
        }

        // GET: WorkOrders/Create
        public ActionResult Create()
        {
            PopulateLocationDropDownList();
            return View();
        }

        // POST: WorkOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkOrderID,LocationID,WorkerID,PrimaryContactID,WorkOrderTitle,WorkOrderDescription,WorkOrderPriority,WorkOrderRequestDate,WorkOrderRequiredDate,WorkOrderCompletedDate,Resolution")] WorkOrder workOrder)
        {
            if (ModelState.IsValid)
            {
                db.WorkOrderSite.Add(workOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateLocationDropDownList(workOrder.LocationID);
            return View(workOrder);
        }

        // GET: WorkOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder workOrder = db.WorkOrderSite.Find(id);
            if (workOrder == null)
            {
                return HttpNotFound();
            }
            return View(workOrder);
        }

        // POST: WorkOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkOrderID,LocationID,WorkerID,PrimaryContactID,WorkOrderTitle,WorkOrderDescription,WorkOrderPriority,WorkOrderRequestDate,WorkOrderRequiredDate,WorkOrderCompletedDate,Resolution")] WorkOrder workOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workOrder);
        }

        // GET: WorkOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder workOrder = db.WorkOrderSite.Find(id);
            if (workOrder == null)
            {
                return HttpNotFound();
            }
            return View(workOrder);
        }

        // POST: WorkOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkOrder workOrder = db.WorkOrderSite.Find(id);
            db.WorkOrderSite.Remove(workOrder);
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

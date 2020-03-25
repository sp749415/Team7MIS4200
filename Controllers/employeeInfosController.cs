using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Team7MIS4200.DAL;
using Team7MIS4200.Models;

namespace Team7MIS4200.Controllers
{
    public class employeeInfosController : Controller
    {
        private Team7MIS4200Context db = new Team7MIS4200Context();

        // GET: employeeInfos
        public ActionResult Index()
        {
            return View(db.EmployeeInfos.ToList());
        }

        // GET: employeeInfos/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeeInfo employeeInfo = db.EmployeeInfos.Find(id);
            if (employeeInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeInfo);
        }

        // GET: employeeInfos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: employeeInfos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "employeeID,firstName,lastName,email,phone")] employeeInfo employeeInfo)
        {
            if (ModelState.IsValid)
            {
                employeeInfo.employeeID = Guid.NewGuid();
                db.EmployeeInfos.Add(employeeInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeInfo);
        }

        // GET: employeeInfos/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeeInfo employeeInfo = db.EmployeeInfos.Find(id);
            if (employeeInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeInfo);
        }

        // POST: employeeInfos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "employeeID,firstName,lastName,email,phone")] employeeInfo employeeInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeInfo);
        }

        // GET: employeeInfos/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeeInfo employeeInfo = db.EmployeeInfos.Find(id);
            if (employeeInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeInfo);
        }

        // POST: employeeInfos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            employeeInfo employeeInfo = db.EmployeeInfos.Find(id);
            db.EmployeeInfos.Remove(employeeInfo);
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

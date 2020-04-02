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
using Microsoft.AspNet.Identity;


namespace Team7MIS4200.Controllers
{
    public class employeeInfoesController : Controller
    {
        private Team7MIS4200Context db = new Team7MIS4200Context();

        // GET: employeeInfoes
        public ActionResult Index()
        {
            return View(db.EmployeeInfos.ToList());
        }

        // GET: employeeInfoes/Details/5
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

        // GET: employeeInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: employeeInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "employeeID,BusinessUnit,firstName,lastName,email,phone,hireDate")] employeeInfo employeeInfo)
        {
            if (ModelState.IsValid)
            {
                // employeeInfo.ID = Guid.NewGuid(); // original new GUID
                Guid memberID; // create a new variable to hold the GUID
                Guid.TryParse(User.Identity.GetUserId(), out memberID);
                employeeInfo.employeeID = memberID;
                //employeeInfo.employeeID = Guid.NewGuid();
                db.EmployeeInfos.Add(employeeInfo);
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    
                }

                return View("DuplicateUser");


            }    
              
          
        }

        // GET: employeeInfoes/Edit/5
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

        // POST: employeeInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "employeeID,BusinessUnit,firstName,lastName,email,phone,hireDate")] employeeInfo employeeInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeInfo);
        }

        // GET: employeeInfoes/Delete/5
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

        // POST: employeeInfoes/Delete/5
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

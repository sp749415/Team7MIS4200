using Microsoft.AspNet.Identity;
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
    public class employeeInfoesController : Controller
    {
        private Team7MIS4200Context db = new Team7MIS4200Context();

        // GET: employeeInfoes
        public ActionResult Index(string searchString)
        {
            if (User.Identity.IsAuthenticated)
            {
               var testusers = from u in db.EmployeeInfos select u;
               if (!String.IsNullOrEmpty(searchString))
                   {
                    testusers = testusers.Where(u =>
                   u.lastName.Contains(searchString)
                   || u.firstName.Contains(searchString));
                    // if here, users were found so view them
                    return View(testusers.ToList());                  
                    }            

                return View(db.EmployeeInfos.ToList());
            }
            else
            {
                return View("NotAuthenticated"); 
            }

            
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
        public ActionResult Create([Bind(Include = "employeeID,BusinessUnit,firstName,lastName,email,phone,hireDate,bio")] employeeInfo employeeInfo)
        {
            if (ModelState.IsValid)
            {
                // employeeInfo.employeeID = Guid.NewGuid();
                Guid memberID; // create a new variable to hold the guid
                Guid.TryParse(User.Identity.GetUserId(), out memberID);
                employeeInfo.employeeID = memberID;
                db.EmployeeInfos.Add(employeeInfo);
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    //throw;
                }

                return View("DuplicateUser");
                
            }

            return View(employeeInfo);
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
            Guid memberID;
            Guid.TryParse(User.Identity.GetUserId(), out memberID);
            if (employeeInfo.employeeID == memberID)
            {
                return View(employeeInfo);
            }
            else
            {
                return View("NotAuthenticated");
            }

            
        }

        // POST: employeeInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "employeeID,BusinessUnit,firstName,lastName,email,phone,hireDate,bio")] employeeInfo employeeInfo)
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

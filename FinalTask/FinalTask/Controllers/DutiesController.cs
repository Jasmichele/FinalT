using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalTask;
using FinalTask.Models;

namespace FinalTask.Controllers
{
    public class DutiesController : Controller
    {
        private DutyTEntities1 db = new DutyTEntities1();

        // GET: Duties
        public ActionResult Index()
        {
            return View(db.Duties.ToList());
        }

        // GET: Duties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Duty duty = db.Duties.Find(id);
            if (duty == null)
            {
                return HttpNotFound();
            }
            return View(duty);
        }

        // GET: Duties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Duties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DutyId,DutyName,Description,DutyDueDate,DutyCompletion")] Duty duty)
        {
            if (ModelState.IsValid)
            {
                db.Duties.Add(duty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(duty);
        }

        // GET: Duties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Duty duty = db.Duties.Find(id);
            if (duty == null)
            {
                return HttpNotFound();
            }
            return View(duty);
        }

        // POST: Duties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DutyId,DutyName,Description,DutyDueDate,DutyCompletion")] Duty duty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(duty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(duty);
        }

        // GET: Duties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Duty duty = db.Duties.Find(id);
            if (duty == null)
            {
                return HttpNotFound();
            }
            return View(duty);
        }

        // POST: Duties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Duty duty = db.Duties.Find(id);
            db.Duties.Remove(duty);
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

        public ActionResult Due()
        {
            DutyTEntities1 db = new DutyTEntities1();

            var dueToday = from e in db.Users
                           join t in db.Duties
                           on e.DutyId equals t.DutyId
                           where t.DutyDueDate == DateTime.Today
                           select new TodayModel
                           {
                               Task = t,
                               Employee = e
                           };

            return View(dueToday);

        }
    }
}

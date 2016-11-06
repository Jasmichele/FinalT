using FinalTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalTask.Controllers
{
    public class CompletedController : Controller
    {
        // GET: Completed
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TodCompl()
        {
            DutyTEntities1 db = new DutyTEntities1();

            var compT = from e in db.Users
                           join t in db.Duties
                           on e.DutyId equals t.DutyId
                           where t.DutyCompletion == DateTime.Today
                           select new CompToday
                           {
                               Task = t,
                               Employee = e
                           };

            return View(compT);
        }

        public ActionResult TmwTask()
        {

            DutyTEntities1 db = new DutyTEntities1();

            DateTime tom = DateTime.Today.AddDays(1);

            var tmwT = from t in db.Duties
                        where t.DutyDueDate == tom
                        select new TmwTask
                        {
                            Task = t,
                           
                        };

            return View(tmwT);
        }

        public ActionResult TmwComp()
        {

            DutyTEntities1 db = new DutyTEntities1();

            DateTime tom = DateTime.Today.AddDays(1);

            var tmwT = from t in db.Duties
                       where t.DutyDueDate == tom
                       && t.DutyCompletion == tom
                       select new TmwComp
                       {
                           Task = t,

                       };

            return View(tmwT);
        }
    }
}
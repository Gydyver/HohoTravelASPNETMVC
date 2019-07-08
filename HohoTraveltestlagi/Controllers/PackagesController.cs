using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HohoTraveltestlagi;

namespace HohoTravelV11.Controllers
{
    public class PackagesController : Controller
    {
        private HohoTraveltestlagiEntities db = new HohoTraveltestlagiEntities();

        // GET: Packages
        public ActionResult Login(Admin objaccount)
        {
            if (ModelState.IsValid)
            {
                using (db)
                {
                    var obj = db.Admins.Where(a => a.AdmEmail.Equals(objaccount.AdmEmail) && a.Password.Equals(objaccount.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["Adm_ID"] = obj.AdmID.ToString();
                        Session["Adm_Email"] = obj.AdmEmail.ToString();
                        return RedirectToAction("Dashboard");
                    }
                }
            }
            return View(objaccount);
        }

        public ActionResult Index()
        {
            if (Session["Adm_ID"] != null)
            {
                return View(db.Packages.ToList());
            }
            else
            {
                return RedirectToAction("Login","Admins");
            }
        }

        public ActionResult tesIndex()
        {
            return View(db.Packages.ToList());
        }

        // GET: Packages/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Adm_ID"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Package package = db.Packages.Find(id);
                if (package == null)
                {
                    return HttpNotFound();
                }
                return View(package);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        // GET: Packages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Packages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Package package)
        {
            if (ModelState.IsValid)
            {
                package.IsDeleted = "1";
                db.Packages.Add(package);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(package);
        }

        // GET: Packages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        // POST: Packages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PackID,PackName,PackTrip,PackPrice,IsDeleted")] Package package)
        {
            if (ModelState.IsValid)
            {
                package.IsDeleted = "1";
                db.Entry(package).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(package);
        }

        // GET: Packages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        // POST: Packages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Package package = db.Packages.Find(id);
            //db.Packages.Remove(package);
            package.IsDeleted = "2";
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

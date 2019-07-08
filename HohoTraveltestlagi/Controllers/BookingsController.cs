using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HohoTraveltestlagi.OtherLib;

namespace HohoTraveltestlagi.Controllers
{
    public class BookingsController : Controller
    {
        private HohoTraveltestlagiEntities db = new HohoTraveltestlagiEntities();

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
        // GET: Bookings
        public ActionResult Index()
        {
            if (Session["Adm_ID"] != null)
            {
                var bookings = db.Bookings.Include(b => b.Package);
                var tes = bookings.ToList();
                var tesakhir = tes.Count();
                return View(bookings.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Admins");
            }

        }

        //public ActionResult List(string option, string search)
        //{
        //    if (option == "ID_Cust")
        //    {
        //        return View(db.Service_Order.Where(x => x.ID_Cust.ToString() == search || search == null));
        //    }
        //    else
        //    {
        //        return View(db.Service_Order.Where(x => x.ID_Order.ToString().StartsWith(search) || search == null));
        //    }
        //}

        //public ActionResult tesIndex()
        //{
        //    var bookings = db.Bookings.Include(b => b.Package);
        //    return View(bookings.ToList());
        //}

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            ViewBag.PackID = new SelectList(db.Packages, "PackID", "PackName");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "BookID,BookDate,PackID,CustName,CustEmail,CustPhNum,TravelDate,Quantity,BookMessage,BookStatus")] Booking booking)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        booking.BookStatus = "1";
        //        db.Bookings.Add(booking);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.PackID = new SelectList(db.Packages, "PackID", "PackName", booking.PackID);
        //    return View(booking);
        //}

        public ActionResult Create(int id,int price, Booking booking)
        {
            if (ModelState.IsValid)
            {
                using (db)
                {
                    booking.PackID = id;
                    //booking.BookStatus = "";
                    booking.BookPrice = price;
                    booking.BookStatus = "Waiting";
                    booking.IsDeleted = "1";
                    booking.BookDate = DateTime.Today; ;
                    db.Bookings.Add(booking);
                    db.SaveChanges();


                    //var total = db.Packages.Where(p => p.PackID == booking.PackID);


                    //var email = db.EmployeeHistory.Where(e => e.EmployeeNumber == empNumber).OrderByDescending(e => e.Updated).FirstorDefault();

                    //emp = emp.OrderBy(e => e.Updated);

                    //var email = db.Bookings.Where(xx => xx.CustEmail == booking.CustEmail).OrderByDescending(xx => xx.CustEmail).SingleOrDefault();
                    var email = booking.CustEmail;
                    var total = booking.BookPrice * booking.Quantity;

                    GMailer mailer = new GMailer();
                    mailer.ToEmail = email;
                    mailer.Subject = "Booking is Success";
                    mailer.Body = "Thanks for your order " + booking.CustName + "\n\n Berikut adalah rincian order anda.\n" +
                        "ID Order : " + booking.BookID + "\nHarga : Rp. " + booking.BookPrice + "\n" + "Quantity : " + booking.Quantity + "\n\n" + "Total : " + total +"\n\n"+
                        "Pesanan anda akan segere diproses setelah melakukan pembayaran melalui nomor rekening resmi kami yang tertera dibawah ini.\n\n BCA a/n Selena Gomez\n"+
                        "Setelah melakukan pembayaran, diharapkan melakukan konfirmasi dengan mengirimkan bukti transfer melalui kontak kami dibawah ini\n Email : hohotravel@gmail.com"+
                        "WA: 081312345678";
                    mailer.IsHtml = false;
                    mailer.Send();

                    //return RedirectToAction("BookDetails",booking);
                    return RedirectToAction("tesIndex","Packages");
                }
            }

            ViewBag.PackID = new SelectList(db.Packages, "PackID", "PackName", booking.PackID);
            return View(booking);
        }

        //public ActionResult BookDetails(int id, DateTime BookDate, int PackID, string CustName, string CustEmail, string CustPhNum, DateTime TravelDate, int Quantity, string BookMsg, Booking booking)
        //{
        //    Booking bk = new Booking
        //    {
        //        BookID= id,
        //        BookDate = BookDate,
        //        PackID = PackID,
        //        CustName = CustName,
        //        CustEmail =CustEmail,
        //        CustPhNum = CustPhNum,
        //        TravelDate = TravelDate,
        //        Quantity = Quantity,
        //        BookMessage = BookMsg
        //    };
        //    ViewData["BookingInfo"] = bk;


        //    return View();
        //}

        public ActionResult BookDetails(Booking booking)
        {
            //Booking bc = new Booking()
            //ViewData["BookingInfo"] = bc;
            //TempData["BookingInfo"] = booking;
            //ViewBag.BookingInfo = booking;
            //var data = (Booking)ViewData["BookingInfo"];
            //var BookingInfo = TempData["BookingInfo"] as Booking;
            return View();
        }

        public ActionResult Complete(Booking booking)
        {
            //db.Bookings.Add(booking);
            //db.SaveChanges();
            return View();
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.PackID = new SelectList(db.Packages, "PackID", "PackName", booking.PackID);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Booking booking)
        {
            if (ModelState.IsValid)
            {
                booking.IsDeleted = "1";
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PackID = new SelectList(db.Packages, "PackID", "PackName", booking.PackID);
            return View(booking);
        }


        // GET: Bookings/Edit/5
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.PackID = new SelectList(db.Packages, "PackID", "PackName", booking.PackID);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Booking booking)
        {
            if (ModelState.IsValid)
            {
                booking.IsDeleted = "1";
                booking.BookStatus = "Paid";
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();

                var email = booking.CustEmail;

                GMailer mailer = new GMailer();
                mailer.ToEmail = email;
                mailer.Subject = "Payment is Success";
                mailer.Body = "Thanks for your Payment " + booking.CustName + "\n\n Your Payment is finish. Have a nice trip with us\n\n ";
                mailer.IsHtml = false;
                mailer.Send();

                return RedirectToAction("Index");
            }
            ViewBag.PackID = new SelectList(db.Packages, "PackID", "PackName", booking.PackID);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            booking.BookStatus = "2";
            //db.Bookings.Remove(booking);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ThankYou()
        {
            return View();
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

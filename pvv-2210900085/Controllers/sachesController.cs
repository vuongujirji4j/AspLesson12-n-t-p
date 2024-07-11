using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using pvv_2210900085.Models;

namespace pvv_2210900085.Controllers
{
    public class sachesController : Controller
    {
        private sach_2210900085Entities db = new sach_2210900085Entities();

        // GET: saches
        public ActionResult PvvIndex()
        {
            var sach = db.sach.Include(s => s.nhaxuatban);
            return View(sach.ToList());
        }

        // GET: saches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sach sach = db.sach.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // GET: saches/Create
        public ActionResult Create()
        {
            ViewBag.manxb = new SelectList(db.nhaxuatban, "manxb", "tennhaxuatban");
            return View();
        }

        // POST: saches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "masach,tensach,sotrang,namxb,tentacgia,manxb")] sach sach)
        {
            if (ModelState.IsValid)
            {
                db.sach.Add(sach);
                db.SaveChanges();
                return RedirectToAction("PvvIndex");
            }

            ViewBag.manxb = new SelectList(db.nhaxuatban, "manxb", "tennhaxuatban", sach.manxb);
            return View(sach);
        }

        // GET: saches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sach sach = db.sach.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            ViewBag.manxb = new SelectList(db.nhaxuatban, "manxb", "tennhaxuatban", sach.manxb);
            return View(sach);
        }

        // POST: saches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "masach,tensach,sotrang,namxb,tentacgia,manxb")] sach sach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PvvIndex");
            }
            ViewBag.manxb = new SelectList(db.nhaxuatban, "manxb", "tennhaxuatban", sach.manxb);
            return View(sach);
        }

        // GET: saches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sach sach = db.sach.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // POST: saches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sach sach = db.sach.Find(id);
            db.sach.Remove(sach);
            db.SaveChanges();
            return RedirectToAction("PvvIndex");
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

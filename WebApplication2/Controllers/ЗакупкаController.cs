using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ЗакупкаController : Controller
    {
        private Course_ProjectEntities1 db = new Course_ProjectEntities1();

        // GET: Закупка
        public ActionResult Index()
        {
            return View(db.Закупка.ToList());
        }

        // GET: Закупка/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Закупка закупка = db.Закупка.Find(id);
            if (закупка == null)
            {
                return HttpNotFound();
            }
            return View(закупка);
        }

        // GET: Закупка/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Закупка/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create([Bind(Include = "ID_закупки,Общая_цена,Дата_закупки,Дата_поставки")] Закупка закупка)
        {
            if (ModelState.IsValid)
            {
                db.Закупка.Add(закупка);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(закупка);
        }

        // GET: Закупка/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Закупка закупка = db.Закупка.Find(id);
            if (закупка == null)
            {
                return HttpNotFound();
            }
            return View(закупка);
        }

        // POST: Закупка/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "ID_закупки,Общая_цена,Дата_закупки,Дата_поставки")] Закупка закупка)
        {
            if (ModelState.IsValid)
            {
                db.Entry(закупка).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(закупка);
        }

        // GET: Закупка/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Закупка закупка = db.Закупка.Find(id);
            if (закупка == null)
            {
                return HttpNotFound();
            }
            return View(закупка);
        }

        // POST: Закупка/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Закупка закупка = db.Закупка.Find(id);
            db.Закупка.Remove(закупка);
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

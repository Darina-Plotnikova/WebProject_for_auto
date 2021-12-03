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
    public class Состав_закупкиController : Controller
    {
        private Course_ProjectEntities1 db = new Course_ProjectEntities1();

        // GET: Состав_закупки
        public ActionResult Index()
        {
            var состав_закупки = db.Состав_закупки.Include(с => с.Закупка).Include(с => с.Материал);
            return View(состав_закупки.ToList());
        }

        // GET: Состав_закупки/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Состав_закупки состав_закупки = db.Состав_закупки.Find(id);
            if (состав_закупки == null)
            {
                return HttpNotFound();
            }
            return View(состав_закупки);
        }

        // GET: Состав_закупки/Create
        public ActionResult Create()
        {
            ViewBag.ID_закупки = new SelectList(db.Закупка, "ID_закупки", "ID_закупки");
            ViewBag.ID_материала = new SelectList(db.Материал, "ID_материала", "Наименование");
            return View();
        }

        // POST: Состав_закупки/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_закупки,ID_материала,Количество,Цена")] Состав_закупки состав_закупки)
        {
            if (ModelState.IsValid)
            {
                db.Состав_закупки.Add(состав_закупки);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_закупки = new SelectList(db.Закупка, "ID_закупки", "ID_закупки", состав_закупки.ID_закупки);
            ViewBag.ID_материала = new SelectList(db.Материал, "ID_материала", "Наименование", состав_закупки.ID_материала);
            return View(состав_закупки);
        }

        // GET: Состав_закупки/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Состав_закупки состав_закупки = db.Состав_закупки.Find(id);
            if (состав_закупки == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_закупки = new SelectList(db.Закупка, "ID_закупки", "ID_закупки", состав_закупки.ID_закупки);
            ViewBag.ID_материала = new SelectList(db.Материал, "ID_материала", "Наименование", состав_закупки.ID_материала);
            return View(состав_закупки);
        }

        // POST: Состав_закупки/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_закупки,ID_материала,Количество,Цена")] Состав_закупки состав_закупки)
        {
            if (ModelState.IsValid)
            {
                db.Entry(состав_закупки).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_закупки = new SelectList(db.Закупка, "ID_закупки", "ID_закупки", состав_закупки.ID_закупки);
            ViewBag.ID_материала = new SelectList(db.Материал, "ID_материала", "Наименование", состав_закупки.ID_материала);
            return View(состав_закупки);
        }

        // GET: Состав_закупки/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Состав_закупки состав_закупки = db.Состав_закупки.Find(id);
            if (состав_закупки == null)
            {
                return HttpNotFound();
            }
            return View(состав_закупки);
        }

        // POST: Состав_закупки/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Состав_закупки состав_закупки = db.Состав_закупки.Find(id);
            db.Состав_закупки.Remove(состав_закупки);
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

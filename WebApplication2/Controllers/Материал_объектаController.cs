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
    public class Материал_объектаController : Controller
    {
        private Course_ProjectEntities1 db = new Course_ProjectEntities1();

        // GET: Материал_объекта
        public ActionResult Index()
        {
            var материал_объекта = db.Материал_объекта.Include(м => м.Материал).Include(м => м.Объект);
            return View(материал_объекта.ToList());
        }

        // GET: Материал_объекта/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Материал_объекта материал_объекта = db.Материал_объекта.Find(id);
            if (материал_объекта == null)
            {
                return HttpNotFound();
            }
            return View(материал_объекта);
        }

        // GET: Материал_объекта/Create
        public ActionResult Create()
        {
            ViewBag.ID_материала = new SelectList(db.Материал, "ID_материала", "Наименование");
            ViewBag.ID_объекта = new SelectList(db.Объект, "ID_объекта", "Наименование_заказа");
            return View();
        }

        // POST: Материал_объекта/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_объекта,ID_материала,Единицы_измерения,Количество_материала")] Материал_объекта материал_объекта)
        {
            if (ModelState.IsValid)
            {
                db.Материал_объекта.Add(материал_объекта);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_материала = new SelectList(db.Материал, "ID_материала", "Наименование", материал_объекта.ID_материала);
            ViewBag.ID_объекта = new SelectList(db.Объект, "ID_объекта", "Наименование_заказа", материал_объекта.ID_объекта);
            return View(материал_объекта);
        }

        // GET: Материал_объекта/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Материал_объекта материал_объекта = db.Материал_объекта.Find(id);
            if (материал_объекта == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_материала = new SelectList(db.Материал, "ID_материала", "Наименование", материал_объекта.ID_материала);
            ViewBag.ID_объекта = new SelectList(db.Объект, "ID_объекта", "Наименование_заказа", материал_объекта.ID_объекта);
            return View(материал_объекта);
        }

        // POST: Материал_объекта/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_объекта,ID_материала,Единицы_измерения,Количество_материала")] Материал_объекта материал_объекта)
        {
            if (ModelState.IsValid)
            {
                db.Entry(материал_объекта).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_материала = new SelectList(db.Материал, "ID_материала", "Наименование", материал_объекта.ID_материала);
            ViewBag.ID_объекта = new SelectList(db.Объект, "ID_объекта", "Наименование_заказа", материал_объекта.ID_объекта);
            return View(материал_объекта);
        }

        // GET: Материал_объекта/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Материал_объекта материал_объекта = db.Материал_объекта.Find(id);
            if (материал_объекта == null)
            {
                return HttpNotFound();
            }
            return View(материал_объекта);
        }

        // POST: Материал_объекта/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Материал_объекта материал_объекта = db.Материал_объекта.Find(id);
            db.Материал_объекта.Remove(материал_объекта);
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

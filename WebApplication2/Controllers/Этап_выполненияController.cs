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
    public class Этап_выполненияController : Controller
    {
        private Course_ProjectEntities1 db = new Course_ProjectEntities1();

        // GET: Этап_выполнения
        public ActionResult Index()
        {
            var этап_выполнения = db.Этап_выполнения.Include(э => э.Объект);
            return View(этап_выполнения.ToList());
        }

        // GET: Этап_выполнения/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Этап_выполнения этап_выполнения = db.Этап_выполнения.Find(id);
            if (этап_выполнения == null)
            {
                return HttpNotFound();
            }
            return View(этап_выполнения);
        }

        // GET: Этап_выполнения/Create
        public ActionResult Create()
        {
            ViewBag.ID_объекта = new SelectList(db.Объект, "ID_объекта", "Наименование_заказа");
            return View();
        }

        // POST: Этап_выполнения/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_объекта,ID_этапа,Дата,Название___этапа")] Этап_выполнения этап_выполнения)
        {
            if (ModelState.IsValid)
            {
                db.Этап_выполнения.Add(этап_выполнения);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_объекта = new SelectList(db.Объект, "ID_объекта", "Наименование_заказа", этап_выполнения.ID_объекта);
            return View(этап_выполнения);
        }

        // GET: Этап_выполнения/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Этап_выполнения этап_выполнения = db.Этап_выполнения.Find(id);
            if (этап_выполнения == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_объекта = new SelectList(db.Объект, "ID_объекта", "Наименование_заказа", этап_выполнения.ID_объекта);
            return View(этап_выполнения);
        }

        // POST: Этап_выполнения/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_объекта,ID_этапа,Дата,Название___этапа")] Этап_выполнения этап_выполнения)
        {
            if (ModelState.IsValid)
            {
                db.Entry(этап_выполнения).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_объекта = new SelectList(db.Объект, "ID_объекта", "Наименование_заказа", этап_выполнения.ID_объекта);
            return View(этап_выполнения);
        }

        // GET: Этап_выполнения/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Этап_выполнения этап_выполнения = db.Этап_выполнения.Find(id);
            if (этап_выполнения == null)
            {
                return HttpNotFound();
            }
            return View(этап_выполнения);
        }

        // POST: Этап_выполнения/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Этап_выполнения этап_выполнения = db.Этап_выполнения.Find(id);
            db.Этап_выполнения.Remove(этап_выполнения);
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

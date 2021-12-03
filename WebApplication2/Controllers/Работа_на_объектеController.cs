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
    public class Работа_на_объектеController : Controller
    {
        private Course_ProjectEntities1 db = new Course_ProjectEntities1();

        // GET: Работа_на_объекте
        public ActionResult Index()
        {
            var работа_на_объекте = db.Работа_на_объекте.Include(р => р.Объект).Include(р => р.Сотрудник);
            return View(работа_на_объекте.ToList());
        }

        // GET: Работа_на_объекте/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Работа_на_объекте работа_на_объекте = db.Работа_на_объекте.Find(id);
            if (работа_на_объекте == null)
            {
                return HttpNotFound();
            }
            return View(работа_на_объекте);
        }

        // GET: Работа_на_объекте/Create
        public ActionResult Create()
        {
            ViewBag.ID_объекта = new SelectList(db.Объект, "ID_объекта", "Наименование_заказа");
            ViewBag.ID_сотрудника = new SelectList(db.Сотрудник, "ID_сотрудника", "ФИО");
            return View();
        }

        // POST: Работа_на_объекте/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_объекта,ID_сотрудника,Выполняемая_работа")] Работа_на_объекте работа_на_объекте)
        {
            if (ModelState.IsValid)
            {
                db.Работа_на_объекте.Add(работа_на_объекте);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_объекта = new SelectList(db.Объект, "ID_объекта", "Наименование_заказа", работа_на_объекте.ID_объекта);
            ViewBag.ID_сотрудника = new SelectList(db.Сотрудник, "ID_сотрудника", "ФИО", работа_на_объекте.ID_сотрудника);
            return View(работа_на_объекте);
        }

        // GET: Работа_на_объекте/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Работа_на_объекте работа_на_объекте = db.Работа_на_объекте.Find(id);
            if (работа_на_объекте == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_объекта = new SelectList(db.Объект, "ID_объекта", "Наименование_заказа", работа_на_объекте.ID_объекта);
            ViewBag.ID_сотрудника = new SelectList(db.Сотрудник, "ID_сотрудника", "ФИО", работа_на_объекте.ID_сотрудника);
            return View(работа_на_объекте);
        }

        // POST: Работа_на_объекте/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_объекта,ID_сотрудника,Выполняемая_работа")] Работа_на_объекте работа_на_объекте)
        {
            if (ModelState.IsValid)
            {
                db.Entry(работа_на_объекте).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_объекта = new SelectList(db.Объект, "ID_объекта", "Наименование_заказа", работа_на_объекте.ID_объекта);
            ViewBag.ID_сотрудника = new SelectList(db.Сотрудник, "ID_сотрудника", "ФИО", работа_на_объекте.ID_сотрудника);
            return View(работа_на_объекте);
        }

        // GET: Работа_на_объекте/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Работа_на_объекте работа_на_объекте = db.Работа_на_объекте.Find(id);
            if (работа_на_объекте == null)
            {
                return HttpNotFound();
            }
            return View(работа_на_объекте);
        }

        // POST: Работа_на_объекте/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Работа_на_объекте работа_на_объекте = db.Работа_на_объекте.Find(id);
            db.Работа_на_объекте.Remove(работа_на_объекте);
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

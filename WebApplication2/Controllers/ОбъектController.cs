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
    public class ОбъектController : Controller
    {
        private Course_ProjectEntities1 db = new Course_ProjectEntities1();

        // GET: Объект
        public ActionResult Index()
        {
            var объект = db.Объект.Include(о => о.Клиент);
            return View(объект.ToList());
        }

        // GET: Объект/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Объект объект = db.Объект.Find(id);
            if (объект == null)
            {
                return HttpNotFound();
            }
            return View(объект);
        }

        // GET: Объект/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.ID_заказчика = new SelectList(db.Клиент, "ID_клиента", "Название___организации");
            return View();
        }

        // POST: Объект/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create([Bind(Include = "ID_объекта,Наименование_заказа,ID_заказчика,Дата_принятия_заказа,Срок_выполнения_работ,Вид_работ,Статус_заказа")] Объект объект)
        {
            if (ModelState.IsValid)
            {
                db.Объект.Add(объект);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_заказчика = new SelectList(db.Клиент, "ID_клиента", "Название___организации", объект.ID_заказчика);
            return View(объект);
        }

        // GET: Объект/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Объект объект = db.Объект.Find(id);
            if (объект == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_заказчика = new SelectList(db.Клиент, "ID_клиента", "Название___организации", объект.ID_заказчика);
            return View(объект);
        }

        // POST: Объект/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "ID_объекта,Наименование_заказа,ID_заказчика,Дата_принятия_заказа,Срок_выполнения_работ,Вид_работ,Статус_заказа")] Объект объект)
        {
            if (ModelState.IsValid)
            {
                db.Entry(объект).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_заказчика = new SelectList(db.Клиент, "ID_клиента", "Название___организации", объект.ID_заказчика);
            return View(объект);
        }

        // GET: Объект/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Объект объект = db.Объект.Find(id);
            if (объект == null)
            {
                return HttpNotFound();
            }
            return View(объект);
        }

        // POST: Объект/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Объект объект = db.Объект.Find(id);
            db.Объект.Remove(объект);
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

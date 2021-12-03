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
    public class МатериалController : Controller
    {
        private Course_ProjectEntities1 db = new Course_ProjectEntities1();

        // GET: Материал
        public ActionResult Index()
        {
            return View(db.Материал.ToList());
        }

        // GET: Материал/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Материал материал = db.Материал.Find(id);
            if (материал == null)
            {
                return HttpNotFound();
            }
            return View(материал);
        }

        // GET: Материал/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Материал/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create([Bind(Include = "ID_материала,Наименование,Вид_товара,Количество,Единицы_измерения,Минимальное_количество")] Материал материал)
        {
            if (ModelState.IsValid)
            {
                db.Материал.Add(материал);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(материал);
        }

        // GET: Материал/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Материал материал = db.Материал.Find(id);
            if (материал == null)
            {
                return HttpNotFound();
            }
            return View(материал);
        }

        // POST: Материал/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "ID_материала,Наименование,Вид_товара,Количество,Единицы_измерения,Минимальное_количество")] Материал материал)
        {
            if (ModelState.IsValid)
            {
                db.Entry(материал).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(материал);
        }

        // GET: Материал/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Материал материал = db.Материал.Find(id);
            if (материал == null)
            {
                return HttpNotFound();
            }
            return View(материал);
        }

        // POST: Материал/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Материал материал = db.Материал.Find(id);
            db.Материал.Remove(материал);
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

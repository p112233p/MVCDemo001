using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class prodclassesController : Controller
    {
        private ProductTestEntities db = new ProductTestEntities();

        // GET: prodclasses
        public ActionResult Index()
        {
            return View(db.prodclass.ToList());
        }

        // GET: prodclasses/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            prodclass prodclass = db.prodclass.Find(id);
            if (prodclass == null)
            {
                return HttpNotFound();
            }
            return View(prodclass);
        }

        // GET: prodclasses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: prodclasses/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "p_classid,p_classname,p_display,p_playseq,p_status")] prodclass prodclass)
        {
            if (ModelState.IsValid)
            {
                db.prodclass.Add(prodclass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prodclass);
        }

        // GET: prodclasses/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            prodclass prodclass = db.prodclass.Find(id);
            if (prodclass == null)
            {
                return HttpNotFound();
            }
            return View(prodclass);
        }

        // POST: prodclasses/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "p_classid,p_classname,p_display,p_playseq,p_status")] prodclass prodclass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prodclass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prodclass);
        }

        // GET: prodclasses/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            prodclass prodclass = db.prodclass.Find(id);
            if (prodclass == null)
            {
                return HttpNotFound();
            }
            return View(prodclass);
        }

        // POST: prodclasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            prodclass prodclass = db.prodclass.Find(id);
            db.prodclass.Remove(prodclass);
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

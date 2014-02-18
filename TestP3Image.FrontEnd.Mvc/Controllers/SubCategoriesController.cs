using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestP3Image.FrontEnd.Mvc.Models;

namespace TestP3Image.FrontEnd.Mvc.Controllers
{
    public class SubCategoriesController : Controller
    {
        private FormsBuilderModel db = new FormsBuilderModel();

        //
        // GET: /SubCategories/

        public ActionResult Index()
        {
            var subcategories = db.SubCategories.Include(s => s.Category);
            return View(subcategories.ToList());
        }

        //
        // GET: /SubCategories/Details/5

        public ActionResult Details(int id = 0)
        {
            SubCategory subcategory = db.SubCategories.Find(id);
            if (subcategory == null)
            {
                return HttpNotFound();
            }
            return View(subcategory);
        }

        //
        // GET: /SubCategories/Create

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Description");
            return View();
        }

        //
        // POST: /SubCategories/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubCategory subcategory)
        {
            if (ModelState.IsValid)
            {
                db.SubCategories.Add(subcategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Description", subcategory.CategoryId);
            return View(subcategory);
        }

        //
        // GET: /SubCategories/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SubCategory subcategory = db.SubCategories.Find(id);
            if (subcategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Description", subcategory.CategoryId);
            return View(subcategory);
        }

        //
        // POST: /SubCategories/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubCategory subcategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subcategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Description", subcategory.CategoryId);
            return View(subcategory);
        }

        //
        // GET: /SubCategories/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SubCategory subcategory = db.SubCategories.Find(id);
            if (subcategory == null)
            {
                return HttpNotFound();
            }
            return View(subcategory);
        }

        //
        // POST: /SubCategories/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubCategory subcategory = db.SubCategories.Find(id);
            db.SubCategories.Remove(subcategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
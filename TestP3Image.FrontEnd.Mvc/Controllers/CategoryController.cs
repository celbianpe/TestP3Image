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
    public class CategoryController : Controller
    {

        private FormsBuilderModel db = new FormsBuilderModel();
        //
        // GET: /Category/

        public ActionResult Index()
        {
            var list = db.Categories.Include(t=> t.SubCategories);

            ViewBag.Tree = list.toNodeList();

            return View(list.ToList());
        }




        public ActionResult Details(int id = 0)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        public ActionResult Show(int Id)
        {
            
            List<Category> elementsList = new List<Category>();
            Category detail;
            using (var context = new FormsBuilderModel())
            {
                detail = context.Categories.Include("SubCategories.Fields").FirstOrDefault(t => t.Id == Id);
               
            }
            

            ViewBag.Tree = detail.SubCategories.toNodeList();

            return View(detail); 
        
        }

        public ActionResult Create()
        {
            return View();
        }
        

        [HttpPost]
        public ActionResult Create(Category entry)
        {
            if (ModelState.IsValid)
            { 
                try
                {
                    using (var context = new FormsBuilderModel())
                    {
                        context.Categories.Add(entry);
                        context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                catch(Exception E){
                     ModelState.AddModelError("Category", "Houston have a problem : " + E.Message);
                     return View(entry);       
                }
             
            }
            return View(entry);
        }

        public ActionResult Edit(int id = 0)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        //
        // POST: /SubCategories/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public ActionResult Delete(int id = 0)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        //
        // POST: /SubCategories/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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

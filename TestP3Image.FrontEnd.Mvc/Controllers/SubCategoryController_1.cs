using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestP3Image.FrontEnd.Mvc.Models;

namespace TestP3Image.FrontEnd.Mvc.Controllers
{
    public class SubCategoryController_1 : Controller
    {
        //
        // GET: /SubCategory/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int Id)
        {
            using (var context = new FormsBuilderModel())
            {
                
                //var categoryDetail =  context.CategoryEntries.Include("SubCategories").Find(t => t.Id == Id);
                

                //return View(categoryDetail);

            }

            return View();
            
        }

        public ActionResult Show(int Id)
        {

            var elementsList = new List<SubCategory>();
            SubCategory detail;
            using (var context = new FormsBuilderModel())
            {
                detail = context.SubCategories.Include("Fields").FirstOrDefault(t => t.Id == Id);

            }

            ViewBag.Tree = detail.Fields.toNodeList();

            return View(detail);

        }

        [HttpPost]
        public ActionResult Create(SubCategory entry)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var context = new FormsBuilderModel())
                    {
                        context.SubCategories.Add(entry);
                        context.SaveChanges();

                    }
                }
                catch (Exception E)
                {
                    ModelState.AddModelError("Category", "Houston have a problem : " + E.Message);
                    return View();
                }

            }
            return RedirectToAction("Show");
        }


    }
}

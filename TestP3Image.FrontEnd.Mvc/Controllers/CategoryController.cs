using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestP3Image.FrontEnd.Mvc.Models;

namespace TestP3Image.FrontEnd.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Category/

        public ActionResult Index()
        {
            IList<NodeItem> list ;
            using (var context = new FormsBuilderModel() )
            {
                list = context.Categories.Include("SubCategories.Fields").toNodeList();
                
            }

            return View(list);
        }


        //public ActionResult Create()
        //{
        //    return View();
        
        //}


    
    }
    
   
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestP3Image.FrontEnd.Mvc.Models;

namespace TestP3Image.FrontEnd.Mvc.Controllers
{
    public class FormsController : Controller
    {
        //
        // GET: /AdminForms/

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category entry)
        {
            
            return View();
        }



    }
}

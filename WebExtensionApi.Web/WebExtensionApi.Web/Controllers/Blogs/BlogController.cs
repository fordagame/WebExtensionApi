using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebExtensionApi.BlogCore.BusinessLayer;
using WebExtensionApi.BlogCore.Helpers;
using WebExtensionApi.Web.Controllers.Base;

namespace WebExtensionApi.Web.Controllers.Blogs
{
    public class BlogController : BaseController
    {
        //
        // GET: /Blog/

        public ActionResult Index()
        {
            var model = base.LoadModel<BlogBL>();
            return View(model.GetAllBlogs());
        }

        public ActionResult Extension()
        {
            return View();
        }

        public JsonResult GetBlogs()
        {
            var model = base.LoadModel<BlogBL>();
            return Json(JsonHelper.GetJson(model.GetAllBlogs()), JsonRequestBehavior.AllowGet);
        }

    }
}

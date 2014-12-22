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
            var model = base.LoadModel<WebExtensionApiBL>();
            return View(model.GetSavedJson());
        }

        public JsonResult GetBlogs()
        {
            var model = base.LoadModel<BlogBL>();
            return Json(JsonHelper.GetJson(model.GetAllBlogs()), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)] 
        public void SaveBlog(string serializedBlog)
        {
            var model = base.LoadModel<WebExtensionApiBL>();
            model.SaveJson(serializedBlog);
        }

    }
}

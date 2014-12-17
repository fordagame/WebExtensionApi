using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebExtensionApi.BlogCore.BusinessLayer;
using WebExtensionApi.BlogCore.DAL;
using WebExtensionApi.BlogCore.Helpers;
using WebMatrix.WebData;

namespace WebExtensionApi.Web.Controllers.Base
{
    public class BaseController : Controller
    {
        public bool IsLogged
        {
            get
            {
                return WebSecurity.CurrentUserName != "";
            }
        }

        private BlogEntities defaultContext;
        private BlogEntities DefaultContext
        {
            get
            {
                if (defaultContext == null)
                {
                    defaultContext = new BlogEntities();
                }
                return defaultContext;
            }
        }

        public T LoadModel<T>(BlogEntities Context = null) where T : IBusinessLayer
        {
            if (Context == null)
            {
                return ModelHelper.LoadModel<T>(DefaultContext);
            }
            else
            {
                return ModelHelper.LoadModel<T>(Context);
            }
        }



        protected T BuildUp<T>(T obj, BlogEntities Context = null) where T : IBusinessLayer
        {
            if (Context == null)
            {
                return ModelHelper.BuildUp<T>(obj, DefaultContext);
            }
            else
            {
                return ModelHelper.BuildUp<T>(obj, Context);
            }
        }
    }
}
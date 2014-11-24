using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebExtensionApi.Core.BusinessLayer;
using WebExtensionApi.Core.DAL;
using WebExtensionApi.Core.Helpers;
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

        private WebExtensionApiEntities defaultContext;
        private WebExtensionApiEntities DefaultContext
        {
            get
            {
                if (defaultContext == null)
                {
                    defaultContext = new WebExtensionApiEntities();
                }
                return defaultContext;
            }
        }

        public T LoadModel<T>(WebExtensionApiEntities Context = null) where T : IBusinessLayer
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



        protected T BuildUp<T>(T obj, WebExtensionApiEntities Context = null) where T : IBusinessLayer
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
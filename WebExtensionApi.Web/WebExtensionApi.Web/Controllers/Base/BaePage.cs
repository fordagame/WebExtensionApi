using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebExtensionApi.Web.Controllers.Base
{
    public abstract class BasePage<T> : WebViewPage<T>
    {
        private static string cssVer = null;
        public static string CssVersion
        {
            get
            {
                if (cssVer == null)
                    cssVer = System.Web.Configuration.WebConfigurationManager.AppSettings["CssVersion"].ToString();

                return cssVer;
            }
        }


        private static string jsVer = null;
        public static string JsVersion
        {
            get
            {
                if (jsVer == null)
                    jsVer = System.Web.Configuration.WebConfigurationManager.AppSettings["JsVersion"].ToString();

                return jsVer;
            }
        }

    }
}
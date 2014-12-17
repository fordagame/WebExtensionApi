using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebExtensionApi.BlogCore.BusinessLayer;
using WebExtensionApi.BlogCore.DAL;
using WebExtensionApi.BlogCore.Helpers;
using WebExtensionApi.BlogCore.Proxy;

namespace WebExtensionApi.BlogServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BlogServices" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BlogServices.svc or BlogServices.svc.cs at the Solution Explorer and start debugging.
    public class BlogServices : IBlogServices
    {
        public string GetBlogs()
        {
            BlogBL model = ModelHelper.LoadModel<BlogBL>(new BlogEntities());
            return JsonHelper.GetJson<List<BlogProxy>>(model.GetAllBlogs());
        }
    }
}

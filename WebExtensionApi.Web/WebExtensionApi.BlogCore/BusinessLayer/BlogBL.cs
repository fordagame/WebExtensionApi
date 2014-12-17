using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExtensionApi.BlogCore.Proxy;
using WebExtensionApi.BlogCore.Repository;

namespace WebExtensionApi.BlogCore.BusinessLayer
{
    public class BlogBL : IBusinessLayer
    {
        #region Repositories
        [Dependency]
        public BlogRepo BlogRep { get; set; }
        #endregion

        public void Init()
        {

        }

        public List<BlogProxy> GetAllBlogs()
        {
            return BlogRep.GetAllBlogs().OrderByDescending(item => item.ID).ToList();
        }
    }
}

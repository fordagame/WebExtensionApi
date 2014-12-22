using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExtensionApi.BlogCore.DAL;
using WebExtensionApi.BlogCore.Proxy;
using WebExtensionApi.BlogCore.Repository;

namespace WebExtensionApi.BlogCore.BusinessLayer
{
    public class WebExtensionApiBL : IBusinessLayer
    {
        #region Repositories
        [Dependency]
        public WebExtensionApiRepo WEARepo { get; set; }
        #endregion

        public void Init()
        {

        }

        public WEAObject GetSavedJson()
        {
            return WEARepo.GetSavedJson() ?? new WEAObject();
        }

        public void SaveJson(string serializedObject)
        {
            var weaobj = WEARepo.GetSavedJson();
            weaobj.JSON = serializedObject;
            if (weaobj == null)
            {
                WEAObject newObj = new WEAObject() { JSON = serializedObject };
                WEARepo.Add(newObj);
            }
            WEARepo.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExtensionApi.Core.DAL
{
    public class DataContextInstance
    {
        private static WebExtensionApiEntities _TouristCatalogModelEntityContext;
        public static WebExtensionApiEntities TouristCatalogModelEntityContext
        {
            get
            {
                if (_TouristCatalogModelEntityContext == null)
                {
                    _TouristCatalogModelEntityContext = new WebExtensionApiEntities();
                }
                return _TouristCatalogModelEntityContext;

            }
        }

        private DataContextInstance()
        {
        }
    }
}

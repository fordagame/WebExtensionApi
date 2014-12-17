using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExtensionApi.Core.DAL
{
    public class DataContextInstance
    {
        private static WebExtensionApiEntities _WebExtensionApiModelEntityContext;
        public static WebExtensionApiEntities WebExtensionApiModelEntityContext
        {
            get
            {
                if (_WebExtensionApiModelEntityContext == null)
                {
                    _WebExtensionApiModelEntityContext = new WebExtensionApiEntities();
                }
                return _WebExtensionApiModelEntityContext;

            }
        }

        private DataContextInstance()
        {
        }
    }
}

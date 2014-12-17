using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExtensionApi.BlogCore.DAL
{
    public class DataContextInstance
    {
        private static BlogEntities _BlogModelEntityContext;
        public static BlogEntities BlogModelEntityContext
        {
            get
            {
                if (_BlogModelEntityContext == null)
                {
                    _BlogModelEntityContext = new BlogEntities();
                }
                return _BlogModelEntityContext;

            }
        }

        private DataContextInstance()
        {
        }
    }
}

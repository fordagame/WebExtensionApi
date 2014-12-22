using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExtensionApi.BlogCore.DAL;

namespace WebExtensionApi.BlogCore.Repository
{
    public class WebExtensionApiRepo : BaseRepo<WEAObject>
    {  
        [InjectionConstructor]
        public WebExtensionApiRepo(BlogEntities context)
            : base(context)
        {
        }

        public WEAObject GetSavedJson()
        {
            return (from c in Context.WEAObjects
                    select c).FirstOrDefault();
        }
    }
}

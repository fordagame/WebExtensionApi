using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExtensionApi.Core.DAL;
using WebExtensionApi.Core.Proxy;

namespace WebExtensionApi.Core.Repository
{
    public class TestRepo : BaseRepo<TestProxy>
    {
        [InjectionConstructor]
        public TestRepo(WebExtensionApiEntities context)
            : base(context)
        {
        }
    }
}

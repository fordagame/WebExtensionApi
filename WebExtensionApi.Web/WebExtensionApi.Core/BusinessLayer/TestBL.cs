using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExtensionApi.Core.Repository;

namespace WebExtensionApi.Core.BusinessLayer
{
    public class TestBL : IBusinessLayer
    {
        #region Repositories
        [Dependency]
        public TestRepo TestRep { get; set; }
        #endregion

        public void Init()
        {

        }
    }
}

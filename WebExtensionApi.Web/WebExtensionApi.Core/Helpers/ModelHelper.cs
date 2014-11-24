using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebExtensionApi.Core.BusinessLayer;
using WebExtensionApi.Core.DAL;

namespace WebExtensionApi.Core.Helpers
{
    public class ModelHelper
    {
        public static T LoadModel<T>(WebExtensionApiEntities Context = null) where T : IBusinessLayer
        {
            if (Context == null)
            {
                Context = DataContextInstance.TouristCatalogModelEntityContext;
            }
            T result = Container.Resolve<T>(new ParameterOverride("context", Context));
            result.Init();

            return result;
        }

        public static T BuildUp<T>(T obj, WebExtensionApiEntities Context = null)
        {
            if (Context == null)
            {
                Context = DataContextInstance.TouristCatalogModelEntityContext;
            }
            return Container.BuildUp<T>(obj, new ParameterOverride("context", Context));
        }

        private static IUnityContainer container;
        private static IUnityContainer Container
        {
            get
            {
                if (container == null)
                {
                    InitContainer();
                }
                return container;
            }
        }

        private static void InitContainer()
        {
            container = new UnityContainer();
            List<Type> types = Assembly.Load("TouristRouteCatalog.Core").GetTypes()
                .Where(t => t.Namespace != null && (t.Namespace.StartsWith("TouristRouteCatalog.Core.Model"))).ToList();
            foreach (Type type in types)
            {
                container.RegisterType(type);
            }
        }
    }
}

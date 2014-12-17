using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebExtensionApi.BlogCore.BusinessLayer;
using WebExtensionApi.BlogCore.DAL;

namespace WebExtensionApi.BlogCore.Helpers
{
    public class ModelHelper
    {
        public static T LoadModel<T>(BlogEntities Context = null) where T : IBusinessLayer
        {
            if (Context == null)
            {
                Context = DataContextInstance.BlogModelEntityContext;
            }
            T result = Container.Resolve<T>(new ParameterOverride("context", Context));
            result.Init();

            return result;
        }

        public static T BuildUp<T>(T obj, BlogEntities Context = null)
        {
            if (Context == null)
            {
                Context = DataContextInstance.BlogModelEntityContext;
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
            List<Type> types = Assembly.Load("WebExtensionApi.BlogCore").GetTypes()
                .Where(t => t.Namespace != null && (t.Namespace.StartsWith("WebExtensionApi.BlogCore.Model"))).ToList();
            foreach (Type type in types)
            {
                container.RegisterType(type);
            }
        }
    }
}

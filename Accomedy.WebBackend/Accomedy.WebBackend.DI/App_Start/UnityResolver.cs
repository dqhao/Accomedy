using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using Accomedy.WebBackend.Business;
using Accomedy.WebBackend.Data;
using Accomedy.WebBackend.Service.FlexibleSearch;
using Unity;
using Unity.Lifetime;

namespace Accomedy.WebBackend.DI.App_Start
{
    public class UnityResolver //: IDependencyResolver
    {
        //protected IUnityContainer container;

        //public UnityResolver(IUnityContainer container)
        //{
        //    if (container == null)
        //    {
        //        throw new ArgumentNullException("container");
        //    }
        //    this.container = container;

        //    container.RegisterType<IFlexibleSearchService, FlexibleSearchService>(new HierarchicalLifetimeManager());
        //    container.RegisterType<IPostRepository, PostRepository>(new HierarchicalLifetimeManager());
        //    container.RegisterType<IPostManager, PostManager>(new HierarchicalLifetimeManager());
        //}

        //public object GetService(Type serviceType)
        //{
        //    try
        //    {
        //        return container.Resolve(serviceType);
        //    }
        //    catch (ResolutionFailedException)
        //    {
        //        return null;
        //    }
        //}

        //public IEnumerable<object> GetServices(Type serviceType)
        //{
        //    try
        //    {
        //        return container.ResolveAll(serviceType);
        //    }
        //    catch (ResolutionFailedException)
        //    {
        //        return new List<object>();
        //    }
        //}

        //public IDependencyScope BeginScope()
        //{
        //    var child = container.CreateChildContainer();
        //    return new UnityResolver(child);
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //}

        //protected virtual void Dispose(bool disposing)
        //{
        //    container.Dispose();
        //}

    }
}

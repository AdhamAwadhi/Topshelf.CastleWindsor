using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf.ServiceConfigurators;

namespace Topshelf.CastleWindsor
{
    public static class ServiceConfiguratorExtensions
    {
        #region Public Methods and Operators

        public static ServiceConfigurator<T> ConstructUsingWindsorContainer<T>(this ServiceConfigurator<T> configurator) where T : class
        {
            configurator.ConstructUsing(serviceFactory => WindsorHostBuilderConfigurator.Container.Resolve<T>());
            return configurator;
        }

        #endregion
    }
}

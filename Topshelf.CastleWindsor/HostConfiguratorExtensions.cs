using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf.HostConfigurators;

namespace Topshelf.CastleWindsor
{
    public static class HostConfiguratorExtensions
    {
        #region Public Methods and Operators

        public static HostConfigurator UseWindsorContainer(this HostConfigurator configurator, IWindsorContainer container)
        {
            configurator.AddConfigurator(new WindsorHostBuilderConfigurator(container));
            return configurator;
        }

        #endregion
    }
}

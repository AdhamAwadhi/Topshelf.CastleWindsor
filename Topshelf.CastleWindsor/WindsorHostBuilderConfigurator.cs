using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf.Builders;
using Topshelf.Configurators;
using Topshelf.HostConfigurators;

namespace Topshelf.CastleWindsor
{
    public class WindsorHostBuilderConfigurator : HostBuilderConfigurator
    {
        #region Static Fields

        private static IWindsorContainer _container;

        #endregion

        #region Constructors and Destructors

        public WindsorHostBuilderConfigurator(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            WindsorHostBuilderConfigurator._container = container;
        }

        #endregion

        #region Public Properties

        public static IWindsorContainer Container
        {
            get
            {
                return _container;
            }
        }

        #endregion

        #region Public Methods and Operators

        public HostBuilder Configure(HostBuilder builder)
        {
            return builder;
        }

        public IEnumerable<ValidateResult> Validate()
        {
            yield break;
        }

        #endregion
    }
}

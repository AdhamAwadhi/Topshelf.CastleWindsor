using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topshelf.CastleWindsor.Sample
{
    class Program
    {
        static void Main(string[] args)
        {            
            // Create your container
            var container = new WindsorContainer();

            // Register components
            container.Register(
                Component.For<ISampleDependency>().ImplementedBy<SampleDependency>(),
                Component. For<SampleService>()
                );
            
            HostFactory.Run(c =>
            {
                // Pass it to Topshelf
                c.UseWindsorContainer(container);

                c.Service<SampleService>(s =>
                {
                    // Let Topshelf use it
                    s.ConstructUsingWindsorContainer();
                    s.WhenStarted((service, control) => service.Start());
                    s.WhenStopped((service, control) => service.Stop());
                });
            });
        }
    }

    public class SampleService
    {
        private readonly ISampleDependency _sample;

        public SampleService(ISampleDependency sample)
        {
            _sample = sample;
        }

        public bool Start()
        {
            Console.WriteLine("Sample Service Started.");
            Console.WriteLine("Sample Dependency: {0}", _sample);
            return _sample != null;
        }

        public bool Stop()
        {
            return _sample != null;
        }
    }

    public interface ISampleDependency
    {
    }

    public class SampleDependency : ISampleDependency
    {
    }
}

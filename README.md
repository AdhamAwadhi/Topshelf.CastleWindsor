# Topshelf.CastleWindsor

Topshelf.CastleWindsor provides extensions to construct your service class from your Castle Windsor IoC container.

I got idea from this repo (https://github.com/alexandrnikitin/Topshelf.Autofac)


Install
-------
It's available via [nuget package](https://www.nuget.org/packages/Topshelf.CastleWindsor)  
PM> `Install-Package Topshelf.CastleWindsor`

Example Usage
-------------
```csharp
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
```

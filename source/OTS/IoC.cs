using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Cells;
using Aspose.Cells.Rendering;
using Castle.Core.Internal;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using OTS;

namespace OTS
{
    public static class IoC
    {
        private static WindsorContainer _container;

        static IoC()
        {
            new Aspose.Words.License().SetLicense(typeof(IoC).Assembly.GetManifestResourceStream("OTS.x.lic"));
            new Aspose.Cells.License().SetLicense(typeof(IoC).Assembly.GetManifestResourceStream("OTS.x.lic"));
            _container = new WindsorContainer();

            _container.Register(Component.For<Excel>().LifestyleSingleton());
            _container.Register(Component.For<Word>().LifestyleSingleton());
            
            _container.Register(Classes.FromAssemblyNamed("OTS")
                .Where(type => type.Is<IReportElement>())
                .WithService.AllInterfaces()
                .WithServiceSelf()
                .LifestyleTransient());
        }

        public static IEnumerable<IReportElement> GetElements()
        {
           return _container.ResolveAll<IReportElement>();
        }

        public static T Get<T>()
        {
            return _container.Resolve<T>();
        }
    }
}

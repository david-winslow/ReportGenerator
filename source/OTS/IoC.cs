using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
using Component = Castle.MicroKernel.Registration.Component;
using License = Aspose.Words.License;

namespace OTS
{
  

    public class Config
    {
        public string WordReportFile { get; set; }
        public string WordTemplateFile { get; set; }
        public string ExcelInputFile { get; set; }
        public string WordSectionsPath { get; set; }
        public string WordExtension { get; set; }
    }

    public class BootStrapper
    {
        private static void SetLicenses()
        {
            new Aspose.Words.License().SetLicense(typeof(IoC).Assembly.GetManifestResourceStream("OTS.x.lic"));
            new Aspose.Cells.License().SetLicense(typeof(IoC).Assembly.GetManifestResourceStream("OTS.x.lic"));
        }

        public void Initialize(Config config,params ComponentRegistration[] components)
        {
            SetLicenses();
            WindsorContainer container = new WindsorContainer();
            container.Register(Component.For<Excel>()
                .LifestyleSingleton()
                .DependsOn(Dependency.OnValue("inputFile", config.ExcelInputFile)));

            container.Register(Component.For<Word>()
                    .LifestyleSingleton()
                    .DependsOn(Dependency.OnValue("templateFile", config.WordTemplateFile))
                    .DependsOn(Dependency.OnValue("reportFile", config.WordReportFile)));

            container.Register(Component.For<SectionFileLocator>()
                .LifestyleSingleton()
                .DependsOn(Dependency.OnValue("wordSectionsPath", config.WordSectionsPath)));


            container.Register(Classes.FromAssemblyNamed("OTS")
                .Where(type => type.Is<IReportElement>())
                .WithService.AllInterfaces()
                .WithServiceSelf()
                .LifestyleTransient());
            IoC._container = container;
        }
    }

    public static class IoC
    {

        internal static WindsorContainer _container;

      

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

using Castle.Core.Internal;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace OTS
{
    public class BootStrapper
    {
        private static void SetLicenses()
        {
            new Aspose.Words.License().SetLicense(typeof(IoC).Assembly.GetManifestResourceStream("OTS.Properties.x.lic"));
            new Aspose.Cells.License().SetLicense(typeof(IoC).Assembly.GetManifestResourceStream("OTS.Properties.x.lic"));
        }

        public void Initialize(Config config,params ComponentRegistration<object>[] components)
        {
            SetLicenses();
            
            WindsorContainer container = new WindsorContainer();
            components.ForEach(x => container.Register(x));
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

            //Section elements
            container.Register(Component.For<IReportElement>().ImplementedBy<LetterHead>().LifestyleTransient());
            container.Register(Component.For<IReportElement>().ImplementedBy<AssessmentInformation>().LifestyleTransient());
            container.Register(Component.For<IReportElement>().ImplementedBy<DocumentationReceived>().LifestyleTransient());
            container.Register(Component.For<IReportElement>().ImplementedBy<MedicalInformation>().LifestyleTransient());
            container.Register(Component.For<IReportElement>().ImplementedBy<Background>().LifestyleTransient());
            
            // other elements
            container.Register(Component.For<IReportElement>().ImplementedBy<CleanUp>().LifestyleTransient());
            
            
            IoC._container = container;
        }
    }
}
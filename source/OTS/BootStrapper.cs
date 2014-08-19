using System;
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
            container.Register(Component.For<IReportElement>().ImplementedBy<LetterHead>().LifestyleTransient().Forward<LetterHead>());
            container.Register(Component.For<IReportElement>().ImplementedBy<AssessmentInformation>().LifestyleTransient().Forward<AssessmentInformation>());
            container.Register(Component.For<IReportElement>().ImplementedBy<MethodsUsed>().LifestyleTransient().Forward<MethodsUsed>());
            container.Register(Component.For<IReportElement>().ImplementedBy<DocumentationReceived>().LifestyleTransient().Forward<DocumentationReceived>());
            container.Register(Component.For<IReportElement>().ImplementedBy<MedicalInformation>().LifestyleTransient().Forward<MedicalInformation>());
            container.Register(Component.For<IReportElement>().ImplementedBy<Background>().LifestyleTransient().Forward<Background>());
            container.Register(Component.For<IReportElement>().ImplementedBy<MainComplaints>().LifestyleTransient().Forward<MainComplaints>());
            container.Register(Component.For<IReportElement>().ImplementedBy<GeneralObservations>().LifestyleTransient().Forward<GeneralObservations>());
            container.Register(Component.For<IReportElement>().ImplementedBy<CooperationEffort>().LifestyleTransient().Forward<CooperationEffort>());
            container.Register(Component.For<IReportElement>().ImplementedBy<ConsistencyOfPerformance>().LifestyleTransient().Forward<ConsistencyOfPerformance>());
            container.Register(Component.For<IReportElement>().ImplementedBy<PainReport>().LifestyleTransient().Forward<PainReport>());
            container.Register(Component.For<Safety>().ImplementedBy<Safety>().LifestyleTransient().Forward<Safety>());

            container.Register(Component.For<IReportElement>().ImplementedBy<PhysicalResults>().LifestyleTransient().Forward<PhysicalResults>());
            container.Register(Component.For<IReportElement>().ImplementedBy<CognitivePhychoSocialResult>().LifestyleTransient().Forward<CognitivePhychoSocialResult>());
            container.Register(Component.For<IReportElement>().ImplementedBy<Thurstone>().LifestyleTransient().Forward<Thurstone>());
            container.Register(Component.For<IReportElement>().ImplementedBy<RiverMeadTest>().LifestyleTransient().Forward<RiverMeadTest>());
            container.Register(Component.For<IReportElement>().ImplementedBy<Cam>().LifestyleTransient().Forward<Cam>());
            container.Register(Component.For<IReportElement>().ImplementedBy<BNCE>().LifestyleTransient().Forward<BNCE>());
            container.Register(Component.For<IReportElement>().ImplementedBy<PsychoSocialResult>().LifestyleTransient().Forward<PsychoSocialResult>());
            container.Register(Component.For<IReportElement>().ImplementedBy<SignatureSection>().LifestyleTransient().Forward<SignatureSection>());            
            
            // other elements
            container.Register(Component.For<IReportElement>().ImplementedBy<CleanUp>().LifestyleTransient().Forward<CleanUp>());
           IoC._container = container;
        }
    }

    public abstract class TextSection : Section
    {
        public override Func<Excel, object> ReportData
        {
            get { return excel => new object(); }
        }
    }

    public class SignatureSection:TextSection
    {
        protected override string SectionName
        {
            get { return "Signature";}
        }
    }

    public class PsychoSocialResult:Section
    {
        private class List
        {
            public string Aspect { get; set; }
            public string Comment { get; set; }
        }

        protected override string SectionName
        {
            get { return "PsychoSocialResult"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e => new { List = e.Get<List>("A2", "B10"), Counter.I }; }
        }
    }

    public class BNCE: Section
    {
        protected override string SectionName
        {
            get { return "BNCE"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e => new { Counter.I }; }
        }
    }
   public class Cam: Section
    {
        private class List
        {
            public string Aspect { get; set; }
            public string Type { get; set; }
            public string Score { get; set; }
            public string Comment { get; set; }
        }

        protected override string SectionName
        {
            get { return "Cam"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e => new { List = e.Get<List>("A2", "D4"), Counter.I }; }
        }
    }

    public class RiverMeadTest :Section
    {
        private class List
        {
            public string Aspect { get; set; }
            public string Type { get; set; }
            public string RawScore { get; set; }
            public string ScaledScore { get; set; }
            public string Rank { get; set; }
            public string Comment { get; set; }
        }

        protected override string SectionName
        {
            get { return "Rivermead"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e => new { List = e.Get<List>("A1", "F8"), Counter.I }; }
        }
    }

    public class Thurstone:Section
    {
        private class List
        {
            public string Test { get; set; }
            public string Time { get; set; }
            public string TimeNorm { get; set; }
            public string Errors { get; set; }
            public string Comment { get; set; }
        }

        protected override string SectionName
        {
            get { return "Thurstone"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e => new {  List = e.Get<List>("A2", "E20"), Counter.I }; }
        }
    }

    public class CognitivePhychoSocialResult:Section
    {
        private class List
        {
            public string Aspect { get; set; }
            public string Comment { get; set; }
        }
        protected override string SectionName
        {
            get { return "Cognitive phychosocial results"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e => new { Cognitive = e.Get<List>("A2", "B20"), Psychosocial = e.Get<List>("D2", "E20"), Counter.I }; }
        }
    } 
    
    public class PhysicalResults:BulletList
    {
        protected override string SectionName
        {
            get { return "Physical results"; }
        }  
    }
}
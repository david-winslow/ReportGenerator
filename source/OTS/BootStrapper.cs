using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Aspose.Cells;
using Aspose.Words.Drawing;
using Castle.Core.Internal;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Remotion.Logging;

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
            container.Register(Component.For<Config>().ImplementedBy<Config>().LifestyleTransient().Forward<Config>());

            //Section elements
            container.Register(Component.For<IReportElement>().ImplementedBy<LetterHead>().LifestyleTransient().Forward<LetterHead>());
            container.Register(Component.For<IReportElement>().ImplementedBy<AssessmentInformation>().LifestyleTransient().Forward<AssessmentInformation>()); 
            container.Register(Component.For<IReportElement>().ImplementedBy<PurposeOfReport>().LifestyleTransient().Forward<PurposeOfReport>());
            container.Register(Component.For<IReportElement>().ImplementedBy<MethodsUsed>().LifestyleTransient().Forward<MethodsUsed>());
            container.Register(Component.For<IReportElement>().ImplementedBy<DocumentationReceived>().LifestyleTransient().Forward<DocumentationReceived>());
            container.Register(Component.For<IReportElement>().ImplementedBy<MedicalInformation>().LifestyleTransient().Forward<MedicalInformation>());
            container.Register(Component.For<IReportElement>().ImplementedBy<Background>().LifestyleTransient().Forward<Background>());
            container.Register(Component.For<IReportElement>().ImplementedBy<OccupationalHistory>().LifestyleTransient().Forward<OccupationalHistory>());

            container.Register(Component.For<IReportElement>().ImplementedBy<MainComplaints>().LifestyleTransient().Forward<MainComplaints>());
            container.Register(Component.For<IReportElement>().ImplementedBy<GeneralObservations>().LifestyleTransient().Forward<GeneralObservations>());
            container.Register(Component.For<IReportElement>().ImplementedBy<CooperationEffort>().LifestyleTransient().Forward<CooperationEffort>());
            container.Register(Component.For<IReportElement>().ImplementedBy<ConsistencyOfPerformance>().LifestyleTransient().Forward<ConsistencyOfPerformance>());
            container.Register(Component.For<IReportElement>().ImplementedBy<PainReport>().LifestyleTransient().Forward<PainReport>());
            container.Register(Component.For<IReportElement>().ImplementedBy<Safety>().LifestyleTransient().Forward<Safety>());

            container.Register(Component.For<IReportElement>().ImplementedBy<AssessmentResults>().LifestyleTransient().Forward<AssessmentResults>());
            container.Register(Component.For<IReportElement>().ImplementedBy<Musculoskeletal>().LifestyleTransient().Forward<Musculoskeletal>());
            container.Register(Component.For<IReportElement>().ImplementedBy<WorkWell>().LifestyleTransient().Forward<WorkWell>());
            container.Register(Component.For<IReportElement>().ImplementedBy<HandFunction>().LifestyleTransient().Forward<HandFunction>());
            container.Register(Component.For<IReportElement>().ImplementedBy<GripPinchStrengthTest>().LifestyleTransient().Forward<GripPinchStrengthTest>());
            container.Register(Component.For<IReportElement>().ImplementedBy<RapidExchangeGrip>().LifestyleTransient().Forward<RapidExchangeGrip>());
            container.Register(Component.For<IReportElement>().ImplementedBy<ADL>().LifestyleTransient().Forward<ADL>());
            container.Register(Component.For<IReportElement>().ImplementedBy<AbiltiesLimitations>().LifestyleTransient().Forward<AbiltiesLimitations>());
            container.Register(Component.For<IReportElement>().ImplementedBy<JobAnalysis>().LifestyleTransient().Forward<JobAnalysis>());

            container.Register(Component.For<IReportElement>().ImplementedBy<CognitivePhychoSocialResult>().LifestyleTransient().Forward<CognitivePhychoSocialResult>());
            container.Register(Component.For<IReportElement>().ImplementedBy<Thurstone>().LifestyleTransient().Forward<Thurstone>());
            container.Register(Component.For<IReportElement>().ImplementedBy<RiverMeadTest>().LifestyleTransient().Forward<RiverMeadTest>());
            container.Register(Component.For<IReportElement>().ImplementedBy<Cam>().LifestyleTransient().Forward<Cam>());
            container.Register(Component.For<IReportElement>().ImplementedBy<BNCE>().LifestyleTransient().Forward<BNCE>());
            container.Register(Component.For<IReportElement>().ImplementedBy<PsychoSocialResult>().LifestyleTransient().Forward<PsychoSocialResult>());
            container.Register(Component.For<IReportElement>().ImplementedBy<Prognosis>().LifestyleTransient().Forward<Prognosis>());            
            container.Register(Component.For<IReportElement>().ImplementedBy<Conclusion>().LifestyleTransient().Forward<Conclusion>());
            container.Register(Component.For<IReportElement>().ImplementedBy<Recommendations>().LifestyleTransient().Forward<Recommendations>());

            container.Register(Component.For<IReportElement>().ImplementedBy<SignatureSection>().LifestyleTransient().Forward<SignatureSection>());
            
            // other elements
            container.Register(Component.For<IReportElement>().ImplementedBy<CleanUp>().LifestyleTransient().Forward<CleanUp>());
           IoC._container = container;
        }
    }

    public class WorkWell:Section
    {
        private class L
        {
            public string Position { get; set; }
            public string Low { get; set; }
            public string Heavy { get; set; }
            public string Max { get; set; }
            public string Limitations { get; set; }

        }
        private class P
        {
            public string Posture { get; set; }
            public string U { get; set; }
            public string S { get; set; }
            public string SL { get; set; }
            public string SNL { get; set; }
            public string Comments { get; set; }

        }

        protected override string SectionName
        {
            get { return "WorkWell"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e => new {L = e.Get<L>("A4", "E13").Where(x => !x.Limitations.IsNullOrEmpty()), Counter.I, P = e.Get<P>("H4", "M13").Where(x => !x.Comments.IsNullOrEmpty())}; }
        }
    }


    public class Prognosis:Section
    {
        protected override string SectionName
        {
            get { return "Prognosis"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e => new { Counter.I }; }
        }
    }

    public class Conclusion : Section
    {
        protected override string SectionName
        {
            get { return "Conclusion"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e => new {Counter.I}; }
        }
    }

    public class Recommendations : Section
    {
        protected override string SectionName
        {
            get { return "Recommendations"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e => new { Counter.I }; }
        }
    }

    public class JobAnalysis:Section
    {
        private class Item
        {
           public string Type { get; set; }
           public string Demand { get; set; }
           public string Ability { get; set; }
           public string Match { get; set; }

        }

        protected override string SectionName
        {
            get { return "JobAnalysis"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e => new {L = e.Get<Item>("A2", "D30"), Counter.I}; }
        }
    }

    public class AbiltiesLimitations:Section
    {
        public class Item :Selectable
        {
            public string Text { get; set; }
            
        }

        protected override string SectionName
        {
            get { return "AbiltiesLimitations"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e => new {A = e.GetSelected<Item>("A2", "B20"), L = e.GetSelected<Item>("C2", "D20"),Counter.I, II = Counter.I}; }
        }
    }


    public class ADL:Section
    {
        private class Item :Selectable
        {
            public string Activity { get; set; }
            public string Present { get; set; }

        }

        protected override string SectionName
        {
            get { return "ADL"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e =>
            {
                List<Item> items = e.GetSelected<Item>("A1", "C70");
                items.ForEach(i => i.Present= i.Present.Replace("[[Client]]",RandomClientNames(e.Cell("ClientSurname").StringValue,e.Cell("ClientTitle").StringValue,e.Cell("ClientGender").StringValue.ToLower())));
                return new {List = items, Counter.I};
            }; }
        }
        static Random Random = new Random();
        private string RandomClientNames(string lastName, string title, string gender)
        {
            var l = new List<string>
            {
                string.Format("{0}. {1}", title, lastName),
                (gender == "male" ? "He" : "She"),
                "The Client"
            };
            return l[Random.Next(0, l.Count)];
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
            get { return e => new { List = e.Get<List>("A2", "D4"), Counter.I}; }
        }
    }

    public class AssessmentResults : Section
    {
        protected override string SectionName
        {
            get { return "AssessmentResults"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e => new { Counter.I }; }
        }
    }

    public class HandFunction :Section
    {
        protected override string SectionName
        {
            get { return "HandFunction"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e => new { Counter.I, Counter.Ar }; }
        }
    }

    public class RapidExchangeGrip:Section
    {
        private readonly Config _config;

        public RapidExchangeGrip(Config config)
        {
            _config = config;
        }
        protected override string SectionName
        {
            get { return "Rapid exchange grip strength"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e => new { Counter.I, Counter.Ar,Counter.Hf }; }
        }

        public override void Execute()
        {
            base.Execute();
            Word.InsertImage(Excel.GetGraph("Chart 3"),"DH");
            Word.InsertImage(Excel.GetGraph("Chart 4"),"NDH");
        }
    }

    public class Musculoskeletal : Section
   {
       private class List
       {
           public string Ability { get; set; }
           public string Text { get; set; }
          
       }


       protected override string SectionName
       {
           get { return "Musculoskeletal"; }
       }

       public override Func<Excel, object> ReportData
       {
           get { return e => new { List = e.Get<List>("A1", "B20"), Counter.I, Counter.Ar  }; }
       }
   }


    public class GripPinchStrengthTest : Section
    {
        private class L
        {
            public string Grip { get; set; }
            public string Hand { get; set; }
            public string Force { get; set; }
            public string Mean { get; set; }
            public string SD { get; set; }
            public string CD { get; set; }
            public string Result { get; set; }
        }

        protected override string SectionName
        {
            get { return "grip pinch strength"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e => new {L = e.Get<L>("A2", "G10"), Counter.I, Counter.Ar, Counter.Hf}; }
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
            public string TestName { get; set; }
        }

        protected override string SectionName
        {
            get { return "Rivermead"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e => new { List =GetData(e) }; }
        }

        private IEnumerable<List> GetData(Excel excel)
        {
            int age = excel.Cell("age").IntValue;
            List<List> data = new List<List>(excel.Get<List>("A1","D15").Where(l => !l.RawScore.IsNullOrEmpty()));
            
            data.ForEach(d =>
            {
                d.ScaledScore = RiverMeadRepository.GetScaledScore(d.TestName, age, d.RawScore);
                d.Rank = RiverMeadRepository.GetRank(d.ScaledScore);
                d.Comment = RiverMeadRepository.GetComment(d.Rank);
            });
            return data;
        }

   
    }

    public class Thurstone:Section
    {
        private class L
        {
            public int TimeMinutes { get; set; }
            public int TimeSeconds { get; set; }
            public int NormMinutes { get; set; }
            public int NormSeconds { get; set; }

            public string Test { get; set; }
            public string Time { get; set; }
            public string TimeNorm { get; set; }
            public int Errors { get; set; }
            public string Comment { get; set; }
        }

        protected override string SectionName
        {
            get { return "Thurstone"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e =>
            {
                var list = new List<L>(e.Get<L>("A2", "I6"));
                foreach (var item in list)
                {
                    item.Time = GetFormattedTime(item.TimeMinutes,item.TimeSeconds);
                    item.TimeNorm = GetFormattedTime(item.NormMinutes,item.NormSeconds);
                    item.Comment = GetComment(new TimeSpan(0, 0, item.TimeMinutes, item.TimeSeconds),item.Errors);
                }
                list.Add(new L() { Test = "Total", Time = GetTotalTime(list), Errors = list.Sum(x => x.Errors), TimeNorm = GetNormTotalTime(list)});
                return new {  List = list, Counter.I };
            }; }
        }

        private string GetTotalTime(List<L> list)
        {
            TimeSpan result = new TimeSpan();
            list.ForEach(t =>  result =result.Add(new TimeSpan(0,0,t.TimeMinutes,t.TimeSeconds)));
            return GetFormattedTime(result.Minutes, result.Seconds);
        }

        private string GetNormTotalTime(List<L> list)
        {
            TimeSpan result = new TimeSpan();
            list.ForEach(t => result =result.Add(new TimeSpan(0, 0, t.NormMinutes, t.NormSeconds)));
            return GetFormattedTime(result.Minutes, result.Seconds);
        }

        private string GetComment(TimeSpan time,int errorCount)
        {
            return string.Format("Speed: {0} \n accuracy: {1}",(time.TotalSeconds < 120) ? "Fast" : "Below average",(errorCount == 0) ? "Adequate" : (errorCount > 3) ? "Below average" :"Average");
            
        }

        private string GetFormattedTime(double min,double sec)
        {
           return string.Format("{0} {1}", (min > 0) ? string.Format("{0} minutes", min) : string.Empty,
                        (sec > 0) ? string.Format("{0} seconds", sec) : string.Empty);
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
    
   
}
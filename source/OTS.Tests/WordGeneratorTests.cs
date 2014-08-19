using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core;
using Castle.Core.Internal;
using Castle.MicroKernel.Registration;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using Should;

namespace OTS.Tests
{
    public class WordGeneratorTests
    {
        Config config;

        public void SetupTestFileService()
        {            
            SetupBootStrapper().Initialize(config, Component.For(typeof(IFileService)).ImplementedBy(typeof(TestFileService)));
        }

        public void SetupGoogleFileService()
        {
            SetupBootStrapper().Initialize(config, Component
                .For(typeof(IFileService))
                .ImplementedBy(typeof(GoogleFileService))
                .DependsOn(Dependency.OnValue("localPath", @"c:\googledrive"))
                .DependsOn(Dependency.OnValue("pendingFilePattern", "_final")));
        }

        private BootStrapper SetupBootStrapper()
        {
            KillProcess("Excel");
            KillProcess("winword");

            var bootStrapper = new BootStrapper();
            config = new Config()
            {
                WordTemplateFile = @"c:\googledrive\templates\template.docx",
                WordReportFile = @"c:\googledrive\templates\report.docx",
                ExcelInputFile = "input.xlsx",
                WordSectionsPath = @"c:\googledrive\templates\Sections"
            };
            return bootStrapper;
        }

        [Test]
        public void ShouldExecuteAllReportElements()
        {
            SetupTestFileService();
            File.Delete(config.WordReportFile);
            ReportGenerator.Process();
            Process.Start(config.WordReportFile);
         }        

        [Test]
        public void test()
        {
            SetupTestFileService();
            IoC.Get<MethodsUsed>().Execute();
            IoC.Get<CleanUp>().Execute();
            Process.Start(config.WordReportFile);
        }

        [Test]
        public void ShouldPullIdFromLocalGoogleSpreadsheet()
        {
            using (FileStream fs = new FileStream("TestSpreadSheet_final.gsheet", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string jsonString = sr.ReadToEnd();
                    var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<LocalGSheet>(jsonString);
                    string id = obj.resource_id.Split(new[] {":"}, StringSplitOptions.RemoveEmptyEntries)[1];
                    id.ShouldEqual("1d5BwM0Iir9JlnpglFSJTtC319ZyANp8DTAdzn3JxEAU");
                }
            }
        }

        [Test]
        public void ShouldProcessWithGoogleFileService()
        {
            SetupGoogleFileService();
            File.Delete(config.WordReportFile);
            ReportGenerator.Process();
            Process.Start(config.WordReportFile);
        }

        private static void KillProcess(string name)
        {
            foreach (Process p in Process.GetProcessesByName(name))
            {
                if (!p.HasExited)
                {
                    p.Kill();
                }
            }
        }
    }

    public class TestFileService : IFileService
    {
        public bool HasFileToProcess()
        {
            return true;
        }

        public void ProcessFile()
        {
            
        }
    }

    public class LocalGSheet
    {
        [JsonProperty("url")]
        public string url { get; set; }
        [JsonProperty("resource_id")]
        public string resource_id { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
        public class Tests
        {
            [Test]
            public void Setup()
            {



            }


            [Test]
            [TestCase("N", 36, "8", "12-19")]
            [TestCase("B", 36, "0", "2")]
            public void ShouldReturnCorrectScaledScore(string testName, int age, string score, string scaledScore)
            {
                RiverMeadRepository.GetScaledScore(testName, age, score).ShouldEqual(scaledScore);
            }

            [Test]
            public void ShouldReturnCorrectComment()
            {
                RiverMeadRepository.GetComment("5").ShouldEqual("Below average");
                RiverMeadRepository.GetComment("0,38").ShouldEqual("Below average");
                RiverMeadRepository.GetComment("99,6").ShouldEqual("Above average");
            }




        }


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
                .DependsOn(Dependency.OnValue("localPath", config.GoogleDrivePath))
                .DependsOn(Dependency.OnValue("pendingFilePattern", config.PendingFilePattern))
                .DependsOn(Dependency.OnValue("excelInputFile", config.ExcelInputFile)));
        }

        private BootStrapper SetupBootStrapper()
        {
            KillProcess("Excel");
            KillProcess("winword");

            var bootStrapper = new BootStrapper();
            config = new Config()
            {
                GoogleDrivePath = @"c:\googledrive\",
                WordTemplateFile = @"c:\googledrive\templates\template.docx",
                WordReportFile = @"c:\googledrive\templates\report.docx",
                ExcelInputFile = "input.xlsx",
                WordSectionsPath = @"c:\googledrive\templates\Sections"
            };
            return bootStrapper;
        }

        [Test]
        public void ClearAllInputFields()
        {
            SetupTestFileService();
            var excel = IoC.Get<Excel>();
            excel.ClearInputFields();
            Thread.Sleep(1000);
            Process.Start("clean_input.xlsx");
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
            IoC.Get<OccupationalHistory>().Execute();
            IoC.Get<CleanUp>().Execute();
            Process.Start(config.WordReportFile);
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
}
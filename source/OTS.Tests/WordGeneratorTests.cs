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
using NUnit.Framework;
using Should;

namespace OTS.Tests
{
    public class WordGeneratorTests
    {
        


        Config config;
        [Test]
        public void ShouldExecuteAllReportElements()
        {
            
            File.Delete(config.WordReportFile);
            ReportGenerator.Process();
            Process.Start(config.WordReportFile);
         }

        [TestFixtureSetUp]
        public void Setup()
        {
            KillProcess("Excel");
            KillProcess("winword");

            var bootStrapper = new BootStrapper();
            config = new Config()
            {
                WordTemplateFile = @"c:\googledrive\templates\template.docx",
                WordReportFile = @"c:\googledrive\templates\report.docx",
                ExcelInputFile = "input.xlsx",
                WordSectionsPath = @"c:\googledrive\templates\Sections",
                
            };
            bootStrapper.Initialize(config, Component.For(typeof(IFileService)).ImplementedBy(typeof(TestFileService)));
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


        [Test]
        public void test()
        {
            IoC.Get<MethodsUsed>().Execute();
            IoC.Get<CleanUp>().Execute();
            Process.Start(config.WordReportFile);
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

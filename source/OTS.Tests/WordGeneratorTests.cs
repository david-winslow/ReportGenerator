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


        [Test]
        public void test()
        {
            IoC.Get<Background>().Execute();
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

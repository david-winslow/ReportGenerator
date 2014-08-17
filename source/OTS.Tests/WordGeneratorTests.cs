using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                WordTemplateFile = @"c:\googledrive\testing\templates\template.docx",
                WordReportFile = @"c:\googledrive\testing\templates\report.docx",
                ExcelInputFile = "input.xlsx",
                WordSectionsPath = @"c:\googledrive\testing\templates\Sections",
            };
            bootStrapper.Initialize(config);
        }


        [Test]
        public void test()
        {
            IoC.Get<Background>().Execute();
            Process.Start(config.WordReportFile);
        }

    }

    
}

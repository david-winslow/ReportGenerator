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
        private string _fileName = @"c:\googledrive\testing\templates\report.docx";


        [Test]
        public void ShouldExecuteAllReportElements()
        {
           
            File.Delete(_fileName);
            ReportGenerator.Process();
            
            Process.Start(_fileName);
         }


        [Test]
        public void test()
        {
            IoC.Get<Background>().Execute();
            Process.Start(_fileName);
        }

    }


}

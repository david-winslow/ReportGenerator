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
      

        [Test]
        public void ShouldExecuteAllReportElements()
        {
            var path = @"c:\googledrive\testing\templates\report.docx";
            File.Delete(path);
            ReportGenerator.Process();
            Process.Start(path);
         }
    }


}

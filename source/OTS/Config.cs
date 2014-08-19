using System.ComponentModel;

namespace OTS
{
    public class Config
    {
        public Config()
        {
            PendingFilePattern = "_final";
        }

        public string WordReportFile { get; set; }
        public string WordTemplateFile { get; set; }
        public string ExcelInputFile { get; set; }
        public string WordSectionsPath { get; set; }
        public string WordExtension { get; set; }
        public string GoogleDrivePath { get; set; }        
        public string PendingFilePattern { get; set; }
    }
}
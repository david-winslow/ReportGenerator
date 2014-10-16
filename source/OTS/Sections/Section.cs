using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OTS
{
    public class SectionFileLocator
    {
        private readonly string _wordSectionsPath;
        private const string _wordExtention = ".docx";

        public SectionFileLocator(string wordSectionsPath)
        {
            _wordSectionsPath = wordSectionsPath;
        }

        public string GetSectionPath(string sectionname, string templateName, string therapist)
        {


            string bookmark_Template_Therapist_Path = Path.Combine(_wordSectionsPath, String.Format("{0}_{1}_{2}{3}", sectionname, templateName, therapist, _wordExtention));
            string bookmark_Therapist_Path = Path.Combine(_wordSectionsPath, String.Format("{0}_{1}{2}", sectionname, therapist, _wordExtention));
            string bookmark_Template_Path = Path.Combine(_wordSectionsPath, String.Format("{0}_{1}{2}", sectionname, templateName, _wordExtention));
            string bookmark_Path = Path.Combine(_wordSectionsPath, sectionname + _wordExtention);

            var bookList = new List<string>() { bookmark_Template_Therapist_Path, bookmark_Therapist_Path, bookmark_Template_Path, bookmark_Path };
            return bookList.Where(File.Exists).First();
        }
    }

    public abstract class Section :IReportElement
    {
        private readonly SectionFileLocator _sectionFileLocator;
        private readonly string _wordSectionsPath;
        protected abstract string SectionName { get; }

        public Section() : this(IoC.Get<SectionFileLocator>())
        {
        }

        public Section(SectionFileLocator sectionFileLocator)
        {
            _sectionFileLocator = sectionFileLocator;
        }

        public virtual void Execute()
        {
            Excel.DefaultWorkSheetName = SectionName;
            Word.InsertSection(_sectionFileLocator.GetSectionPath(SectionName, Excel.Cell("Configuration", "B8").StringValue, Excel.Cell("Configuration", "B2").StringValue));
            if(ReportData != null)
            Word.Replace(ReportData(Excel));
        }


      


        public Word Word { get; set; }
        public Excel Excel { get; set; }
        public abstract Func<Excel,object> ReportData { get;}

        


       
    }
}
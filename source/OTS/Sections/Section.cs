using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OTS
{
    public abstract class Section :IReportElement
    {
        protected abstract string SectionName { get; }
    

        public virtual void Execute()
        {
            Excel.DefaultWorkSheetIndex = OrderIndex;
            Excel.DefaultWorkSheetName = SectionName;
            Word.InsertSection(GetSectionPath(SectionName, "", ""));
            Word.Replace(ReportData(Excel));
        }


      

        public abstract int OrderIndex { get;}

        public Word Word { get; set; }
        public Excel Excel { get; set; }
        public abstract Func<Excel,object> ReportData { get;}

       


        public static string SECTION_PATH = Path.Combine(@"c:\googledrive\testing\templates\", "Sections");
        public static string GetSectionPath(string sectionname, string templateName, string therapist)
        {

            string ext = ".docx";

            string bookmark_Template_Therapist_Path = Path.Combine(SECTION_PATH, String.Format("{0}_{1}_{2}{3}", sectionname, templateName, therapist, ext));
            string bookmark_Therapist_Path = Path.Combine(SECTION_PATH, String.Format("{0}_{1}{2}", sectionname, therapist, ext));
            string bookmark_Template_Path = Path.Combine(SECTION_PATH, String.Format("{0}_{1}{2}", sectionname, templateName, ext));
            string bookmark_Path = Path.Combine(SECTION_PATH, sectionname + ext);

            var bookList = new List<string>() { bookmark_Template_Therapist_Path, bookmark_Therapist_Path, bookmark_Template_Path, bookmark_Path };
            return bookList.Where(File.Exists).First();
        }
    }
}
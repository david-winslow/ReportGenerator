using Aspose.Words;

namespace OTS
{
    public class Word
    {
        public static string WORDTEMPLATEPATH = @"c:\googledrive\testing\templates\template.docx";
        public static string WORDREPORTPATH = @"c:\googledrive\testing\templates\report.docx";
        private Document _document;

        public Word()
        {
            _document = new Document(WORDTEMPLATEPATH);
            Save();
        }

        public void Replace<T>(T reportData)

        {
            using (var templateDocument = NGS.Templater.Configuration.Factory.Open(WORDREPORTPATH))
            {
                templateDocument.Process(reportData);
            }
            _document = new Document(WORDREPORTPATH);
            Save();
        }


        private static string text;
        public bool ContainsValue(string value)
        {
            text = text ?? _document.ToString(SaveFormat.Text);
            return text.Contains(value);
        }

        public void InsertSection(string sectionPath)
        {
            var section = new Document(sectionPath);
            _document.LastSection.AppendContent(section.FirstSection);
            Save();
        }


        public void RemoveTemplaterLicenseSection()
        {
            _document.Sections[0].Remove();
            Save();
        }

        private void Save()
        {
            _document.Save(WORDREPORTPATH);
        }
    }
}
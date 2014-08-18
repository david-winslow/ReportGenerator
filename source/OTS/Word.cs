using System;
using Aspose.Words;

namespace OTS
{
    public class Word
    {
        private readonly string _reportFile;
        private Document _document;

        public Word(string templateFile,string reportFile)
        {
            _reportFile = reportFile;
            _document = new Document(templateFile);
            Save();
        }

        public void Replace<T>(T reportData)

        {
            using (var templateDocument = NGS.Templater.Configuration.Factory.Open(_reportFile))
            {
                templateDocument.Process(reportData);
            }
            _document = new Document(_reportFile);
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
            _document.Save(_reportFile);
        }
        public void UpdateWordDocument(Action<Document> applyAction )
        {
            applyAction(_document);
            Save();
        }
    }
}
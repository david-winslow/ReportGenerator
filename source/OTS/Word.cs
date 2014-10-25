using System;
using System.IO;
using System.Runtime.InteropServices;
using Aspose.Cells;
using Aspose.Words;
using Aspose.Words.Fonts;
using SaveFormat = Aspose.Words.SaveFormat;

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

        public void InsertImage(MemoryStream stream, string bookmark)
        {
            var documentBuilder = new DocumentBuilder(_document);
            documentBuilder.MoveToBookmark(bookmark);
            documentBuilder.InsertImage(stream);
            Save();
        }

        public void SetTemplatePathForAllSections()
        {
            string[] files = Directory.GetFiles(@"C:\googledrive\templates\Sections","*.docx");
            foreach (var file in files)
            {
                try
                {



                    var document = new Document(file);
                    document.AttachedTemplate = @"C:\googledrive\templates\Sections\SectionTemplate.dotx";
                    document.AutomaticallyUpdateSyles = true;
                    document.Save(file);
                    Console.WriteLine(file);
                }
                catch (Exception exc)
                {

                    Console.WriteLine(string.Format("error: {0}", file));
                    continue;
                }
            }
        }

     
    }
}
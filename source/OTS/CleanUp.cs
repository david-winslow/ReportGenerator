using System.Drawing;
using Aspose.Words;
using Aspose.Words.Tables;
using Castle.Core.Internal;
using Style = Aspose.Cells.Style;

namespace OTS
{
    public class CleanUp : IReportElement
    {
        private readonly Word _word;

        public CleanUp(Word word)
        {
            _word = word;
        }

        public void Execute()
        {
            _word.RemoveTemplaterLicenseSection();

            //ensure table headers repeat on each page
            _word.UpdateWordDocument(doc => doc.GetChildNodes(NodeType.Table, true)
                .ToArray()
                .ConvertAll(n => n as Table)
                .ForEach(t =>
                {
                    t.StyleIdentifier =StyleIdentifier.MediumShading1Accent3;
                    t.FirstRow.RowFormat.HeadingFormat = true;
                    foreach (Cell cell in t.GetChildNodes(NodeType.Cell, true))
                    {
                        
                        cell.EnsureMinimum();
                        foreach (Paragraph para in cell.Paragraphs)
                            if (!(cell.ParentRow.IsLastRow && para.IsEndOfCell))
                                para.ParagraphFormat.KeepWithNext = true;
                                
                    }
                }));



            _word.UpdateWordDocument(doc =>
            {
                NodeCollection paragraphs = doc.GetChildNodes(NodeType.Paragraph, true);
                foreach (Paragraph paragraph in paragraphs)
                {
                    
                    paragraph.ParagraphFormat.Style.Font.Name = "Century Gothic";
                    if (paragraph.IsListItem)
                    {
                        // If paragraph is an item of bulleted list, we should specify NumberStyle Arabic.
                        if (paragraph.ListFormat.ListLevel.NumberStyle == NumberStyle.Bullet)
                        {
                            paragraph.ListFormat.ApplyBulletDefault();
                            paragraph.ParagraphFormat.Style.Font.Size = 12;
                            paragraph.ParagraphFormat.Style.Font.Italic = true;

                        }
                    }
                }
            });
        }

        public int OrderIndex {
            get { return 100; }
        }
    }
}
using Aspose.Words;
using Aspose.Words.Tables;
using Castle.Core.Internal;

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
                   .ForEach(t => t.PreferredWidth = PreferredWidth.FromPercent(100)));

            _word.UpdateWordDocument(doc =>doc.GetChildNodes(NodeType.Table, true)
                   .ToArray()
                   .ConvertAll(n => n as Table)
                   .ForEach(t => t.FirstRow.RowFormat.HeadingFormat = true));
         
        }

        public int OrderIndex {
            get { return 100; }
        }
    }
}
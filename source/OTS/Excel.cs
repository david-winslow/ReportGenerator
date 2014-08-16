using Aspose.Cells;

namespace OTS
{
    public class Excel
    {
        public static string EXCELPATH = "input.ods";
        private static Workbook _workbook;
        public int DefaultWorkSheetIndex = 0;
        public Excel()
        {
            _workbook = new Workbook(EXCELPATH);
        }


        

        public string this[string name]
        {
            get { return Cell(DefaultWorkSheetIndex, name).StringValue; }
        }

        public Cell Cell(int workSheetIndex, string name)
        {
            return _workbook.Worksheets[workSheetIndex].Cells[name];
        }
    }
}
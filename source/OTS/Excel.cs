using System.Collections.Generic;
using System.Linq;
using Aspose.Cells;
using LinqToExcel;
using LinqToExcel.Query;
using Cell = Aspose.Cells.Cell;

namespace OTS
{
    public class Excel
    {
        private readonly string _inputFile;
        private static Workbook _workbook;
        public int DefaultWorkSheetIndex = 0;
        private ExcelQueryFactory _linq2Excel;
        public string DefaultWorkSheetName;
        public Excel(string inputFile)
        {
            _inputFile = inputFile;
            _workbook = new Workbook(inputFile);
            _linq2Excel = new ExcelQueryFactory(inputFile);
            _linq2Excel.StrictMapping = StrictMappingType.None;
        }

        public IEnumerable<T> Get<T>(string start, string end) 
        {
            return from p in _linq2Excel.WorksheetRange<T>(start, end, DefaultWorkSheetName)
                    select p;
        }

        public string this[string name]
        {
            get { return Cell(DefaultWorkSheetName, name).StringValue; }
        }

        public Cell Cell(string workSheetName, string name)
        {
            return _workbook.Worksheets[workSheetName].Cells[name];
        }
    }

 
}
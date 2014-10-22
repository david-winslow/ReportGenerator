using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using Aspose.Words;
using Castle.Core.Internal;
using Castle.MicroKernel.ModelBuilder.Descriptors;
using LinqToExcel;
using LinqToExcel.Query;
using Microsoft.SqlServer.Server;
using Cell = Aspose.Cells.Cell;
using SaveFormat = Aspose.Cells.SaveFormat;
using Shape = Aspose.Words.Drawing.Shape;

namespace OTS
{
    public class Excel
    {
        private readonly string _inputFile;
        private static Workbook _workbook;
        private ExcelQueryFactory _linq2Excel;
        public string DefaultWorkSheetName;
        public Excel(string inputFile)
        {
            _inputFile = inputFile;
            _workbook = new Workbook(inputFile);
            _linq2Excel = new ExcelQueryFactory(inputFile);
            _linq2Excel.StrictMapping = StrictMappingType.None;
        }

        public List<T> Get<T>(string start, string end) 
        {
            var result = from p in _linq2Excel.WorksheetRange<T>(start, end, DefaultWorkSheetName)
                    select p;
            return result.ToList();
        }

        public List<T> Get<T>(string namedRange)
        {
            var result = from p in _linq2Excel.NamedRange<T>(namedRange)
                         select p;
            return result.ToList();
        }

        public List<T> GetSelected<T>(string start, string end) where T:ISelectable
        {
            var result = from p in _linq2Excel.WorksheetRange<T>(start, end, DefaultWorkSheetName)
                         where !p.Selected.IsNullOrEmpty()
                         select p;
            return result.ToList();
        }
        public List<T> GetSelected<T>(string namedRange) where T : ISelectable
        {
            var result = from p in _linq2Excel.NamedRange<T>(namedRange)
                         where !p.Selected.IsNullOrEmpty()
                         select p;
            return result.ToList();
        }


        public string this[string name]
        {
            get { return Cell(name).StringValue; }
        }

        public Cell Cell(string workSheetName, string name)
        {
            return _workbook.Worksheets[workSheetName].Cells[name];
        }
        public Cell Cell(string name)
        {
            return _workbook.Worksheets.GetRangeByName(name)[0, 0];
        }
        public IEnumerable<SelectedValue> SelectedValuesList(string startRange, string endRange)
        {
            return from v in _linq2Excel.WorksheetRange<SelectedValue>(startRange, endRange,DefaultWorkSheetName)
            where !string.IsNullOrEmpty(v.Selected)
            select v;
        }

        public MemoryStream GetGraph(string name)
        {
            MemoryStream stream = new MemoryStream();
            _workbook.Worksheets[DefaultWorkSheetName].Charts[name].ToImage(stream,ImageFormat.Png);
            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }

        public void ClearInputFields()
        {
            WorksheetCollection worksheets = _workbook.Worksheets;
            foreach (var worksheet in worksheets)
            {
                Cells cells = worksheet.Cells;
                foreach (Cell cell in cells)
                {
                    if (cell.SharedStyleIndex == 70)
                    cell.Value = string.Empty;
                    
                }
            }
            _workbook.Save(File.Create("clean_input.xlsx"),SaveFormat.Auto);
        }
    }
    public class Selectable:ISelectable
    {
        public string Selected { get; set; }
    }

    public interface ISelectable
    {
        string Selected { get; set; }
    }
}
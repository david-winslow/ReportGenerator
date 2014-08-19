using System.Linq;
using Castle.Core.Internal;

namespace OTS
{
    public static class ReportGenerator
    {
        public static void Process()
        {
            
            var fileService = IoC.Get<IFileService>();
            if (fileService.HasFileToProcess())
            {
                fileService.ProcessFile();
                var result = from element in IoC.GetAll<IReportElement>()
                    select element;
                result.ToList().ForEach(e => e.Execute());
            }
        }
    }

   
}
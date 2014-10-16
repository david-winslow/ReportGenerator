using System;
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
                result.ToList().ForEach(e => GetValue(e));
            }
        }

        private static void GetValue(IReportElement e)
        {
            try
            {
                e.Execute();
            }
            catch (Exception)
            {
                
                throw new Exception(e.ToString());
            }
            
        }
    }
}
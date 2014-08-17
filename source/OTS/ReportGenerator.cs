using System.Linq;
using Castle.Core.Internal;

namespace OTS
{
    public static class ReportGenerator
    {
        public static void Process()
        {
            

            var result = from element in IoC.GetElements()
                orderby element.OrderIndex ascending
                select element;
            result.ToList().ForEach(e => e.Execute());
        }
    }
}
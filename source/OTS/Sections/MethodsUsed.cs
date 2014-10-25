using System;

namespace OTS
{
    public class MethodsUsed : Section
    {
        protected override string SectionName
        {
            get { return "Methods used"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return excel => new { L = Excel.GetSelected("methods_used"), Counter.I }; }
        }
    }
}
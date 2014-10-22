using System;

namespace OTS
{
    public class SelectedValue :Selectable
    {
        public string Text { get; set; }
        
    }

    public class MethodsUsed : Section
    {
        protected override string SectionName
        {
            get { return "Methods used"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return excel => new { L = Excel.GetSelected<SelectedValue>("methods_used"), Counter.I }; }
        }
    }
}
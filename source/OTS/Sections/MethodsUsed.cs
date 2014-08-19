using System;

namespace OTS
{
    public class SelectedValue
    {
        public string Bullet { get; set; }
        public string Selected { get; set; }
    }

    public class MethodsUsed : Section
    {
        protected override string SectionName
        {
            get { return "Methods used"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return excel => new {List = Excel.SelectedValuesList("I2", "J31")}; }
        }
    }
}
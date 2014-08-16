using System;

namespace OTS
{
    public class MethodsUsed : Section
    {
        protected override string SectionName
        {
            get { return "Methods used"; }
        }

        public override int OrderIndex
        {
            get { return 3; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e => new { List = e.Get<List>("A1", "A5"),Counter.I }; }
        }
    }
}
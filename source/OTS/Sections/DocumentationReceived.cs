using System;
using System.Linq;
using Castle.Core.Internal;

namespace OTS
{
    public class DocumentationReceived : Section
    {
        private class Doc
    {
        public string Document { get; set; }
        public string Designation { get; set; }
        public string Date { get; set; }

         
    }
    
        protected override string SectionName
        {
            get { return "Documentation Received"; }
        }

    

        public override Func<Excel, object> ReportData
        {
            get { return e => new { Doc = e.Get<Doc>("docs_received").Where(d => !d.Document.IsNullOrEmpty()), Counter.I }; }
        }
    }
}
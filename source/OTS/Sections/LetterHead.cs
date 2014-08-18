using System;
using System.Runtime.Remoting.Messaging;
using Aspose.Cells;

namespace OTS
{
    public class LetterHead: Section
    {
        public override Func<Excel,object> ReportData {
            get
            { return
                (e) =>
                    new
                    {
                        FirstName = e["B2"],
                        LastName = e["B3"],
                        Cell = e["B4"],
                        Email = e["B5"]
                    };
            }
        }
        
        protected override string SectionName
        {
            get { return "LetterHead"; }
        }

       
    }
}
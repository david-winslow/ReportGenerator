using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using Castle.Core.Internal;
using Remotion.Data.Linq.Clauses;

namespace OTS
{
    


    public class AssessmentInformation : Section
    {
        private class LL
        {
            public string Relationship { get; set; }
            public string Name { get; set; }
        }

        public override Func<Excel, object> ReportData
        {
            get
            {
                return
                    e =>
                        new
                        {
                            ClientName = string.Format("{0} {1}", e["Client_FirstName"],e["Client_Surname"]),
                            IDNumber = e.Cell("IdNumber").DoubleValue,
                            Age = GetAge(e.Cell("age").DoubleValue),
                            Address = e["Client_Address"],
                            ContactNumber = e["Client_ContactNumber"],
                            AssessmentDate = e.Cell("assessmentDate").DateTimeValue.ToString("dd MMMM yyyy"),
                            Location = e["assessmentLocation"],
                            Language = e["AssessmentLanguage"],
                            ReportDate = DateTime.Now.ToString("dd MMMM yyyy"),
                            Duration = BuildDuration(),
                            RefCompany = e["refCompany"],
                            RefAssessor = e["refAssessor"],
                            OurRef = e["ourRef"],
                            YourRef = e["yourRef"],
                            Title = e["Client_Title"],
                            L = e.Get<LL>("People_Present").Where(p => !p.Name.IsNullOrEmpty()),
                            Counter.I
                        };
            }
        }

        private string BuildDuration()
        {
            int minutes = Excel.Cell("Duration_Minutes").IntValue;
            int hours = Excel.Cell("duration_hours").IntValue;

            return (minutes == 0) ? string.Format("{0} hours", hours) :
            string.Format("{0} hours and {1} minutes", hours, minutes);
        }

       

        private int GetAge(double doubleValue)
        {
            string year = "19" + doubleValue.ToString().Substring(0, 2);
            return DateTime.Now.Year - int.Parse(year);
        }


        protected override string SectionName
        {
            get { return "Assessment Information"; }
        }

       
    }
}
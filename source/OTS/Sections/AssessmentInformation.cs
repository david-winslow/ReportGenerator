using System;
using System.Net.Sockets;
using System.Text;
using Remotion.Data.Linq.Clauses;

namespace OTS
{
    public class AssessmentInformation : Section
    {
        public override Func<Excel, object> ReportData
        {
            get
            {
                return
                    e =>
                        new
                        {
                            ClientName = e["B2"],
                            IDNumber = e.Cell(SectionName,"B3").DoubleValue,
                            Age = GetAge(e.Cell(SectionName, "B3").DoubleValue),
                            Address = e["B5"],
                            ContactNumber = e["B6"],
                            AssessmentDate = e.Cell(SectionName, "B7").DateTimeValue.ToString("dd MMMM yyyy"),
                            Location = "554 Louis Botha Ave, Gresswold, Johannesburg",
                            Language = e["B9"],
                            ReportDate = DateTime.Now.ToString("dd MMMM yyyy"),
                            Duration = BuildDuration(),
                            RefCompany = e["B13"],
                            RefAssessor = e["B14"],
                            OurRef = e["B15"],
                            YourRef = e["B16"],
                            Title = e["B17"],
                            PeoplePresent = BuildPeoplePresent(),Counter.I
                        };
            }
        }

        private string BuildDuration()
        {
            int minutes = Excel.Cell(SectionName, "B12").IntValue;
            int hours = Excel.Cell(SectionName, "B11").IntValue;

            return (minutes == 0) ? string.Format("{0} hours", hours) :
            string.Format("{0} hours and {1} minutes", hours, minutes);
        }

        private string BuildPeoplePresent()
        {
            StringBuilder sb = new StringBuilder();
            string therapist = string.Format("{0} {1} (Occupational Therapist) ", Excel.Cell("Configuration", "B2").StringValue,Excel.Cell("Configuration", "B3").StringValue);
            string client = string.Format("{0} (Client) ", Excel.Cell(SectionName, "B2").StringValue);
            sb.AppendLine(therapist);
            sb.AppendLine(client);
            return sb.ToString();


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
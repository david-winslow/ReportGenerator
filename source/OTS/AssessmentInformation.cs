using System;
using System.Text;

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
                            IDNumber = e.Cell(OrderIndex,"B3").DoubleValue,
                            Age = GetAge(e.Cell(OrderIndex, "B3").DoubleValue),
                            Address = e["B5"],
                            ContactNumber = e["B6"],
                            AssessmentDate = e.Cell(OrderIndex, "B7").DateTimeValue.ToString("dd MMMM yyyy"),
                            Location = "554 Louis Botha Ave, Gresswold, Johannesburg",
                            Language = e["B9"],
                            ReportDate = DateTime.Now.ToString("dd MMMM yyyy"),
                            Duration = string.Format("{0}.{1} Hours", e["B11"], e["B12"]),
                            RefCompany = e["B13"],
                            RefAssessor = e["B14"],
                            OurRef = e["B15"],
                            YourRef = e["B16"],
                            Title = e["B17"],
                            PeoplePresent = BuildPeoplePresent()
                        };
            }
        }

        private string BuildPeoplePresent()
        {
            StringBuilder sb = new StringBuilder();
            string therapist = string.Format("{0} {1} (Occupational Therapist) ", Excel.Cell(0, "B2").StringValue,Excel.Cell(0, "B3").StringValue);
            string client = string.Format("{0} (Client) ", Excel.Cell(1, "B2").StringValue);
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
            get { return "AssessmentInformation"; }
        }

        public override int OrderIndex
        {
            get { return 1; }
        }
    }
}
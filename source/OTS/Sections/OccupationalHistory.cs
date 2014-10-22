using System;
using System.Linq;
using Castle.Core.Internal;

namespace OTS
{
    public class OccupationalHistory:Section
    {
        private class Occ
        {
            public string Period { get; set; }
            public string Employer { get; set; }
            public string Experience { get; set; }
        }

        protected override string SectionName
        {
            get { return "Occupational History"; }
        }

        public override Func<Excel, object> ReportData
        {
            get
            {
                return e => new
                {
                    Occ = e.Get<Occ>("occupationalHistory").Where(o => !o.Experience.IsNullOrEmpty()),
                    JD = e.Get<Bullet>("JobDescription").Where(j => !j.Description.IsNullOrEmpty()),
                    Diff = e.Get<Bullet>("Difficulties").Where(j => !j.Description.IsNullOrEmpty()),
                    currentOccupation = e["currentOcc"],
                    currentEmployer = e["currentEmployer"],
                    lastWorked = e["currentAccomplishment"],
                    classification = e["classification"],
                    classificationDescription = e["classificationDescription"],
                    Counter.I,
                    ClientName = string.Format("{0}. {1}", e["client_Title"], e["client_Surname"])
                };
            }
        }

        class Bullet
        {
            public string Description { get; set; }
        }
    }
}
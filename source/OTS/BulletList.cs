using System;

namespace OTS
{
    public abstract class BulletList : Section
    {
        private class List
        {
            public string Bullet { get; set; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e => new { List = e.Get<List>("A2", "A10"), Counter.I }; }
        }
    }

    public class Safety : BulletList
    {
        protected override string SectionName
        {
            get { return "Safety"; }
        }
    }

    public class PainReport : BulletList
    {
        protected override string SectionName
        {
            get { return "Pain report"; }
        }

    }

    public class GeneralObservations : BulletList
    {
        protected override string SectionName
        {
            get { return "General observations"; }
        }
    }

    public class CooperationEffort : BulletList
    {
        protected override string SectionName
        {
            get { return "Cooperation effort"; }
        }
    }

    public class ConsistencyOfPerformance : BulletList
    {
        protected override string SectionName
        {
            get { return "Consistency performance"; }
        }


    }
}
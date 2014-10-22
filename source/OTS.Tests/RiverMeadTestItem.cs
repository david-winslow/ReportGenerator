using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Should;

namespace OTS.Tests
{
    public class RiverMeadTestItem
    {
        public IEnumerable<RiverMeadTestResult> Results;
        public int From;
        public int To;
        public readonly string TestName;

        public RiverMeadTestItem(int from, int to, string testName,params RiverMeadTestResult[] results)
        {
            From = from;
            To = to;
            TestName = testName;
            Results = results;
        }
    }

    public class RiverMeadTestResult
    {
        public string ScaledScore;
        public string Score;
    }

   

  

}
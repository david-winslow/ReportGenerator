using System;
using System.Collections.Generic;
using System.Linq;

namespace OTS
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

    

    public static class RiverMeadRepository
    {
        static List<RiverMeadTestItem> list = new List<RiverMeadTestItem>(); 
        static RiverMeadRepository()
        {
            N();
            B();
            A();
            PR();
            SI();
        }



        private static void SI()
        {
            string testName = "SI";
            var B16_24 = new RiverMeadTestItem(16, 24, testName,
                new RiverMeadTestResult() {Score = "0", ScaledScore = "1"},
                new RiverMeadTestResult() {Score = "0.5", ScaledScore = "1"},
                new RiverMeadTestResult() {Score = "1", ScaledScore = "3"},
                new RiverMeadTestResult() {Score = "1.5", ScaledScore = "4"},
                new RiverMeadTestResult() {Score = "2", ScaledScore = "4"},
                new RiverMeadTestResult() {Score = "2.5", ScaledScore = "5"},
                new RiverMeadTestResult() {Score = "3", ScaledScore = "5"},
                new RiverMeadTestResult() {Score = "3.5", ScaledScore = "6"},
                new RiverMeadTestResult() {Score = "4", ScaledScore = "6"},
                new RiverMeadTestResult() {Score = "4.5", ScaledScore = "6"},
                new RiverMeadTestResult() {Score = "5", ScaledScore = "7"},
                new RiverMeadTestResult() {Score = "5.5", ScaledScore = "7"},
                new RiverMeadTestResult() {Score = "6", ScaledScore = "7"},
                new RiverMeadTestResult() {Score = "6.5", ScaledScore = "8"},
                new RiverMeadTestResult() {Score = "7", ScaledScore = "8"},
                new RiverMeadTestResult() {Score = "7.5", ScaledScore = "8"},
                new RiverMeadTestResult() {Score = "8", ScaledScore = "9"},
                new RiverMeadTestResult() {Score = "8.5", ScaledScore = "9"},
                new RiverMeadTestResult() {Score = "9", ScaledScore = "10"},
                new RiverMeadTestResult() {Score = "9.5", ScaledScore = "10"},
                new RiverMeadTestResult() {Score = "10", ScaledScore = "11"},
                new RiverMeadTestResult() {Score = "10.5", ScaledScore = "11"},
                new RiverMeadTestResult() {Score = "11", ScaledScore = "11"},
                new RiverMeadTestResult() {Score = "11.5", ScaledScore = "12"},
                new RiverMeadTestResult() {Score = "12", ScaledScore = "12"},
                new RiverMeadTestResult() {Score = "12.5", ScaledScore = "12"},
                new RiverMeadTestResult() {Score = "13", ScaledScore = "13"},
                new RiverMeadTestResult() {Score = "13.5", ScaledScore = "13"},
                new RiverMeadTestResult() {Score = "14", ScaledScore = "13"},
                new RiverMeadTestResult() {Score = "14.5", ScaledScore = "14"},
                new RiverMeadTestResult() {Score = "15", ScaledScore = "14"},
                new RiverMeadTestResult() {Score = "15.5", ScaledScore = "15"},
                new RiverMeadTestResult() {Score = "16", ScaledScore = "15"},
                new RiverMeadTestResult() {Score = "16.5", ScaledScore = "15"},
                new RiverMeadTestResult() {Score = "17", ScaledScore = "16"},
                new RiverMeadTestResult() {Score = "17.5", ScaledScore = "17"},
                new RiverMeadTestResult() {Score = "18", ScaledScore = "17"},
                new RiverMeadTestResult() {Score = "18.5", ScaledScore = "17"},
                new RiverMeadTestResult() {Score = "19", ScaledScore = "18"},
                new RiverMeadTestResult() {Score = "19.5", ScaledScore = "19"},
                new RiverMeadTestResult() {Score = "20", ScaledScore = "19"},
                new RiverMeadTestResult() {Score = "20.5", ScaledScore = "19"},
                new RiverMeadTestResult() {Score = "21", ScaledScore = "19"});
                




            var B25_34 = new RiverMeadTestItem(25, 34, testName,
                new RiverMeadTestResult() { Score = "0", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "0.5", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "1", ScaledScore = "3" },
                new RiverMeadTestResult() { Score = "1.5", ScaledScore = "3" },
                new RiverMeadTestResult() { Score = "2", ScaledScore = "3" },
                new RiverMeadTestResult() { Score = "2.5", ScaledScore = "4" },
                new RiverMeadTestResult() { Score = "3", ScaledScore = "4" },
                new RiverMeadTestResult() { Score = "3.5", ScaledScore = "5" },
                new RiverMeadTestResult() { Score = "4", ScaledScore = "6" },
                new RiverMeadTestResult() { Score = "4.5", ScaledScore = "6" },
                new RiverMeadTestResult() { Score = "5", ScaledScore = "6" },
                new RiverMeadTestResult() { Score = "5.5", ScaledScore = "7" },
                new RiverMeadTestResult() { Score = "6", ScaledScore = "7" },
                new RiverMeadTestResult() { Score = "6.5", ScaledScore = "7" },
                new RiverMeadTestResult() { Score = "7", ScaledScore = "8" },
                new RiverMeadTestResult() { Score = "7.5", ScaledScore = "8" },
                new RiverMeadTestResult() { Score = "8", ScaledScore = "9" },
                new RiverMeadTestResult() { Score = "8.5", ScaledScore = "9" },
                new RiverMeadTestResult() { Score = "9", ScaledScore = "10" },
                new RiverMeadTestResult() { Score = "9.5", ScaledScore = "10" },
                new RiverMeadTestResult() { Score = "10", ScaledScore = "11" },
                new RiverMeadTestResult() { Score = "10.5", ScaledScore = "11" },
                new RiverMeadTestResult() { Score = "11", ScaledScore = "12" },
                new RiverMeadTestResult() { Score = "11.5", ScaledScore = "12" },
                new RiverMeadTestResult() { Score = "12", ScaledScore = "12" },
                new RiverMeadTestResult() { Score = "12.5", ScaledScore = "13" },
                new RiverMeadTestResult() { Score = "13", ScaledScore = "13" },
                new RiverMeadTestResult() { Score = "13.5", ScaledScore = "13" },
                new RiverMeadTestResult() { Score = "14", ScaledScore = "13" },
                new RiverMeadTestResult() { Score = "14.5", ScaledScore = "14" },
                new RiverMeadTestResult() { Score = "15", ScaledScore = "14" },
                new RiverMeadTestResult() { Score = "15.5", ScaledScore = "15" },
                new RiverMeadTestResult() { Score = "16", ScaledScore = "15" },
                new RiverMeadTestResult() { Score = "16.5", ScaledScore = "15" },
                new RiverMeadTestResult() { Score = "17", ScaledScore = "16" },
                new RiverMeadTestResult() { Score = "17.5", ScaledScore = "17" },
                new RiverMeadTestResult() { Score = "18", ScaledScore = "17" },
                new RiverMeadTestResult() { Score = "18.5", ScaledScore = "17" },
                new RiverMeadTestResult() { Score = "19", ScaledScore = "18" },
                new RiverMeadTestResult() { Score = "19.5", ScaledScore = "19" },
                new RiverMeadTestResult() { Score = "20", ScaledScore = "19" },
                new RiverMeadTestResult() { Score = "20.5", ScaledScore = "19" },
                new RiverMeadTestResult() { Score = "21", ScaledScore = "19" });



            var B35_44 = new RiverMeadTestItem(35, 44, testName,
              new RiverMeadTestResult() { Score = "0", ScaledScore = "1" },
                new RiverMeadTestResult() { Score = "0.5", ScaledScore = "2" },
                new RiverMeadTestResult() { Score = "1", ScaledScore = "3" },
                new RiverMeadTestResult() { Score = "1.5", ScaledScore = "3" },
                new RiverMeadTestResult() { Score = "2", ScaledScore = "3" },
                new RiverMeadTestResult() { Score = "2.5", ScaledScore = "4" },
                new RiverMeadTestResult() { Score = "3", ScaledScore = "4" },
                new RiverMeadTestResult() { Score = "3.5", ScaledScore = "5" },
                new RiverMeadTestResult() { Score = "4", ScaledScore = "5" },
                new RiverMeadTestResult() { Score = "4.5", ScaledScore = "6" },
                new RiverMeadTestResult() { Score = "5", ScaledScore = "6" },
                new RiverMeadTestResult() { Score = "5.5", ScaledScore = "7" },
                new RiverMeadTestResult() { Score = "6", ScaledScore = "7" },
                new RiverMeadTestResult() { Score = "6.5", ScaledScore = "7" },
                new RiverMeadTestResult() { Score = "7", ScaledScore = "8" },
                new RiverMeadTestResult() { Score = "7.5", ScaledScore = "8" },
                new RiverMeadTestResult() { Score = "8", ScaledScore = "9" },
                new RiverMeadTestResult() { Score = "8.5", ScaledScore = "9" },
                new RiverMeadTestResult() { Score = "9", ScaledScore = "10" },
                new RiverMeadTestResult() { Score = "9.5", ScaledScore = "10" },
                new RiverMeadTestResult() { Score = "10", ScaledScore = "11" },
                new RiverMeadTestResult() { Score = "10.5", ScaledScore = "11" },
                new RiverMeadTestResult() { Score = "11", ScaledScore = "11" },
                new RiverMeadTestResult() { Score = "11.5", ScaledScore = "12" },
                new RiverMeadTestResult() { Score = "12", ScaledScore = "12" },
                new RiverMeadTestResult() { Score = "12.5", ScaledScore = "13" },
                new RiverMeadTestResult() { Score = "13", ScaledScore = "13" },
                new RiverMeadTestResult() { Score = "13.5", ScaledScore = "13" },
                new RiverMeadTestResult() { Score = "14", ScaledScore = "13" },
                new RiverMeadTestResult() { Score = "14.5", ScaledScore = "14" },
                new RiverMeadTestResult() { Score = "15", ScaledScore = "15" },
                new RiverMeadTestResult() { Score = "15.5", ScaledScore = "15" },
                new RiverMeadTestResult() { Score = "16", ScaledScore = "15" },
                new RiverMeadTestResult() { Score = "16.5", ScaledScore = "15" },
                new RiverMeadTestResult() { Score = "17", ScaledScore = "16" },
                new RiverMeadTestResult() { Score = "17.5", ScaledScore = "17" },
                new RiverMeadTestResult() { Score = "18", ScaledScore = "17" },
                new RiverMeadTestResult() { Score = "18.5", ScaledScore = "17" },
                new RiverMeadTestResult() { Score = "19", ScaledScore = "18" },
                new RiverMeadTestResult() { Score = "19.5", ScaledScore = "19" },
                new RiverMeadTestResult() { Score = "20", ScaledScore = "19" },
                new RiverMeadTestResult() { Score = "20.5", ScaledScore = "19" },
                new RiverMeadTestResult() { Score = "21", ScaledScore = "19" });

            var B45_54 = new RiverMeadTestItem(45, 54, testName,
               new RiverMeadTestResult() { Score = "0", ScaledScore = "1" },
                new RiverMeadTestResult() { Score = "0.5", ScaledScore = "1" },
                new RiverMeadTestResult() { Score = "1", ScaledScore = "2-3" },
                new RiverMeadTestResult() { Score = "1.5", ScaledScore = "2-3" },
                new RiverMeadTestResult() { Score = "2", ScaledScore = "4" },
                new RiverMeadTestResult() { Score = "2.5", ScaledScore = "4" },
                new RiverMeadTestResult() { Score = "3", ScaledScore = "5" },
                new RiverMeadTestResult() { Score = "3.5", ScaledScore = "5" },
                new RiverMeadTestResult() { Score = "4", ScaledScore = "6" },
                new RiverMeadTestResult() { Score = "4.5", ScaledScore = "6" },
                new RiverMeadTestResult() { Score = "5", ScaledScore = "6" },
                new RiverMeadTestResult() { Score = "5.5", ScaledScore = "7" },
                new RiverMeadTestResult() { Score = "6", ScaledScore = "7" },
                new RiverMeadTestResult() { Score = "6.5", ScaledScore = "8" },
                new RiverMeadTestResult() { Score = "7", ScaledScore = "8" },
                new RiverMeadTestResult() { Score = "7.5", ScaledScore = "8" },
                new RiverMeadTestResult() { Score = "8", ScaledScore = "9" },
                new RiverMeadTestResult() { Score = "8.5", ScaledScore = "9" },
                new RiverMeadTestResult() { Score = "9", ScaledScore = "10" },
                new RiverMeadTestResult() { Score = "9.5", ScaledScore = "10" },
                new RiverMeadTestResult() { Score = "10", ScaledScore = "11" },
                new RiverMeadTestResult() { Score = "10.5", ScaledScore = "11" },
                new RiverMeadTestResult() { Score = "11", ScaledScore = "11" },
                new RiverMeadTestResult() { Score = "11.5", ScaledScore = "12" },
                new RiverMeadTestResult() { Score = "12", ScaledScore = "12" },
                new RiverMeadTestResult() { Score = "12.5", ScaledScore = "13" },
                new RiverMeadTestResult() { Score = "13", ScaledScore = "13" },
                new RiverMeadTestResult() { Score = "13.5", ScaledScore = "13" },
                new RiverMeadTestResult() { Score = "14", ScaledScore = "13" },
                new RiverMeadTestResult() { Score = "14.5", ScaledScore = "14" },
                new RiverMeadTestResult() { Score = "15", ScaledScore = "14" },
                new RiverMeadTestResult() { Score = "15.5", ScaledScore = "15" },
                new RiverMeadTestResult() { Score = "16", ScaledScore = "15" },
                new RiverMeadTestResult() { Score = "16.5", ScaledScore = "15" },
                new RiverMeadTestResult() { Score = "17", ScaledScore = "16" },
                new RiverMeadTestResult() { Score = "17.5", ScaledScore = "16" },
                new RiverMeadTestResult() { Score = "18", ScaledScore = "17" },
                new RiverMeadTestResult() { Score = "18.5", ScaledScore = "17" },
                new RiverMeadTestResult() { Score = "19", ScaledScore = "18" },
                new RiverMeadTestResult() { Score = "19.5", ScaledScore = "19" },
                new RiverMeadTestResult() { Score = "20", ScaledScore = "19" },
                new RiverMeadTestResult() { Score = "20.5", ScaledScore = "19" },
                new RiverMeadTestResult() { Score = "21", ScaledScore = "19" });


            var B55_64 = new RiverMeadTestItem(55, 64, testName,
                new RiverMeadTestResult() { Score = "0", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "0.5", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "1", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "1.5", ScaledScore = "3" },
                new RiverMeadTestResult() { Score = "2", ScaledScore = "4" },
                new RiverMeadTestResult() { Score = "2.5", ScaledScore = "5" },
                new RiverMeadTestResult() { Score = "3", ScaledScore = "6" },
                new RiverMeadTestResult() { Score = "3.5", ScaledScore = "6" },
                new RiverMeadTestResult() { Score = "4", ScaledScore = "7" },
                new RiverMeadTestResult() { Score = "4.5", ScaledScore = "7" },
                new RiverMeadTestResult() { Score = "5", ScaledScore = "7" },
                new RiverMeadTestResult() { Score = "5.5", ScaledScore = "8" },
                new RiverMeadTestResult() { Score = "6", ScaledScore = "8" },
                new RiverMeadTestResult() { Score = "6.5", ScaledScore = "9" },
                new RiverMeadTestResult() { Score = "7", ScaledScore = "9" },
                new RiverMeadTestResult() { Score = "7.5", ScaledScore = "9" },
                new RiverMeadTestResult() { Score = "8", ScaledScore = "10" },
                new RiverMeadTestResult() { Score = "8.5", ScaledScore = "10" },
                new RiverMeadTestResult() { Score = "9", ScaledScore = "10" },
                new RiverMeadTestResult() { Score = "9.5", ScaledScore = "11" },
                new RiverMeadTestResult() { Score = "10", ScaledScore = "11" },
                new RiverMeadTestResult() { Score = "10.5", ScaledScore = "11" },
                new RiverMeadTestResult() { Score = "11", ScaledScore = "12" },
                new RiverMeadTestResult() { Score = "11.5", ScaledScore = "12" },
                new RiverMeadTestResult() { Score = "12", ScaledScore = "12" },
                new RiverMeadTestResult() { Score = "12.5", ScaledScore = "13" },
                new RiverMeadTestResult() { Score = "13", ScaledScore = "13" },
                new RiverMeadTestResult() { Score = "13.5", ScaledScore = "13" },
                new RiverMeadTestResult() { Score = "14", ScaledScore = "14" },
                new RiverMeadTestResult() { Score = "14.5", ScaledScore = "14" },
                new RiverMeadTestResult() { Score = "15", ScaledScore = "15" },
                new RiverMeadTestResult() { Score = "15.5", ScaledScore = "15" },
                new RiverMeadTestResult() { Score = "16", ScaledScore = "15" },
                new RiverMeadTestResult() { Score = "16.5", ScaledScore = "16" },
                new RiverMeadTestResult() { Score = "17", ScaledScore = "17" },
                new RiverMeadTestResult() { Score = "17.5", ScaledScore = "17" },
                new RiverMeadTestResult() { Score = "18", ScaledScore = "18" },
                new RiverMeadTestResult() { Score = "18.5", ScaledScore = "18" },
                new RiverMeadTestResult() { Score = "19", ScaledScore = "19" },
                new RiverMeadTestResult() { Score = "19.5", ScaledScore = "19" },
                new RiverMeadTestResult() { Score = "20", ScaledScore = "19" },
                new RiverMeadTestResult() { Score = "20.5", ScaledScore = "19" },
                new RiverMeadTestResult() { Score = "21", ScaledScore = "19" });


            var N65_74 = new RiverMeadTestItem(65, 74, testName,
             new RiverMeadTestResult() { Score = "0", ScaledScore = "1" },
                new RiverMeadTestResult() { Score = "0.5", ScaledScore = "1" },
                new RiverMeadTestResult() { Score = "1", ScaledScore = "2-3" },
                new RiverMeadTestResult() { Score = "1.5", ScaledScore = "4" },
                new RiverMeadTestResult() { Score = "2", ScaledScore = "5" },
                new RiverMeadTestResult() { Score = "2.5", ScaledScore = "6" },
                new RiverMeadTestResult() { Score = "3", ScaledScore = "6" },
                new RiverMeadTestResult() { Score = "3.5", ScaledScore = "7" },
                new RiverMeadTestResult() { Score = "4", ScaledScore = "7" },
                new RiverMeadTestResult() { Score = "4.5", ScaledScore = "8" },
                new RiverMeadTestResult() { Score = "5", ScaledScore = "8" },
                new RiverMeadTestResult() { Score = "5.5", ScaledScore = "9" },
                new RiverMeadTestResult() { Score = "6", ScaledScore = "9" },
                new RiverMeadTestResult() { Score = "6.5", ScaledScore = "10" },
                new RiverMeadTestResult() { Score = "7", ScaledScore = "10" },
                new RiverMeadTestResult() { Score = "7.5", ScaledScore = "10" },
                new RiverMeadTestResult() { Score = "8", ScaledScore = "11" },
                new RiverMeadTestResult() { Score = "8.5", ScaledScore = "11" },
                new RiverMeadTestResult() { Score = "9", ScaledScore = "12" },
                new RiverMeadTestResult() { Score = "9.5", ScaledScore = "12" },
                new RiverMeadTestResult() { Score = "10", ScaledScore = "12" },
                new RiverMeadTestResult() { Score = "10.5", ScaledScore = "13" },
                new RiverMeadTestResult() { Score = "11", ScaledScore = "13" },
                new RiverMeadTestResult() { Score = "11.5", ScaledScore = "13" },
                new RiverMeadTestResult() { Score = "12", ScaledScore = "14" },
                new RiverMeadTestResult() { Score = "12.5", ScaledScore = "14" },
                new RiverMeadTestResult() { Score = "13", ScaledScore = "14" },
                new RiverMeadTestResult() { Score = "13.5", ScaledScore = "15" },
                new RiverMeadTestResult() { Score = "14", ScaledScore = "15" },
                new RiverMeadTestResult() { Score = "14.5", ScaledScore = "15" },
                new RiverMeadTestResult() { Score = "15", ScaledScore = "16" },
                new RiverMeadTestResult() { Score = "15.5", ScaledScore = "16" },
                new RiverMeadTestResult() { Score = "16", ScaledScore = "17" },
                new RiverMeadTestResult() { Score = "16.5", ScaledScore = "18" },
                new RiverMeadTestResult() { Score = "17", ScaledScore = "19" },
                new RiverMeadTestResult() { Score = "17.5", ScaledScore = "19" },
                new RiverMeadTestResult() { Score = "18", ScaledScore = "19" },
                new RiverMeadTestResult() { Score = "18.5", ScaledScore = "19" },
                new RiverMeadTestResult() { Score = "19", ScaledScore = "19" },
                new RiverMeadTestResult() { Score = "19.5", ScaledScore = "19" },
                new RiverMeadTestResult() { Score = "20", ScaledScore = "19" },
                new RiverMeadTestResult() { Score = "20.5", ScaledScore = "19" },
                new RiverMeadTestResult() { Score = "21", ScaledScore = "19" });


            list.Add(B16_24);
            list.Add(B25_34);
            list.Add(B35_44);
            list.Add(B55_64);
            list.Add(N65_74);
        } 
        private static void PR()
        {
            string testName = "PR";
            var B16_24 = new RiverMeadTestItem(16, 24, testName,
                new RiverMeadTestResult() {Score = "0", ScaledScore = "1"},
                new RiverMeadTestResult() {Score = "1", ScaledScore = "1"},
                new RiverMeadTestResult() {Score = "2", ScaledScore = "1"},
                new RiverMeadTestResult() {Score = "3", ScaledScore = "1"},
                new RiverMeadTestResult() {Score = "4", ScaledScore = "1"},
                new RiverMeadTestResult() {Score = "5", ScaledScore = "1"},
                new RiverMeadTestResult() {Score = "6", ScaledScore = "1"},
                new RiverMeadTestResult() {Score = "7", ScaledScore = "1"},
                new RiverMeadTestResult() {Score = "8", ScaledScore = "1"},
                new RiverMeadTestResult() {Score = "9", ScaledScore = "1"},
                new RiverMeadTestResult() {Score = "10", ScaledScore = "1"},
                new RiverMeadTestResult() {Score = "11", ScaledScore = "2-3"},
                new RiverMeadTestResult() {Score = "12", ScaledScore = "4"},
                new RiverMeadTestResult() {Score = "13", ScaledScore = "5-6"},
                new RiverMeadTestResult() {Score = "14", ScaledScore = "7-10"},
                new RiverMeadTestResult() {Score = "15", ScaledScore = "11-19"});
                


            var B25_34 = new RiverMeadTestItem(25, 34, testName,
                new RiverMeadTestResult() { Score = "0", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "1", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "2", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "3", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "4", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "5", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "6", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "7", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "8", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "9", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "10", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "11", ScaledScore = "3" },
                new RiverMeadTestResult() { Score = "12", ScaledScore = "4" },
                new RiverMeadTestResult() { Score = "13", ScaledScore = "5-6" },
                new RiverMeadTestResult() { Score = "14", ScaledScore = "7-10" },
                new RiverMeadTestResult() { Score = "15", ScaledScore = "11-19" });



            var B35_44 = new RiverMeadTestItem(35, 44, testName,
                 new RiverMeadTestResult() { Score = "0", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "1", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "2", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "3", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "4", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "5", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "6", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "7", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "8", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "9", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "10", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "11", ScaledScore = "3" },
                new RiverMeadTestResult() { Score = "12", ScaledScore = "4" },
                new RiverMeadTestResult() { Score = "13", ScaledScore = "5-6" },
                new RiverMeadTestResult() { Score = "14", ScaledScore = "7-10" },
                new RiverMeadTestResult() { Score = "15", ScaledScore = "11-19" });

            var B45_54 = new RiverMeadTestItem(45, 54, testName,
                  new RiverMeadTestResult() { Score = "0", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "1", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "2", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "3", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "4", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "5", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "6", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "7", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "8", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "9", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "10", ScaledScore = "1-2" },
                new RiverMeadTestResult() { Score = "11", ScaledScore = "3" },
                new RiverMeadTestResult() { Score = "12", ScaledScore = "4" },
                new RiverMeadTestResult() { Score = "13", ScaledScore = "5-6" },
                new RiverMeadTestResult() { Score = "14", ScaledScore = "7-10" },
                new RiverMeadTestResult() { Score = "15", ScaledScore = "11-19" });


            var B55_64 = new RiverMeadTestItem(55, 64, testName,
                new RiverMeadTestResult() { Score = "0", ScaledScore = "1" },
                new RiverMeadTestResult() { Score = "1", ScaledScore = "1" },
                new RiverMeadTestResult() { Score = "2", ScaledScore = "1" },
                new RiverMeadTestResult() { Score = "3", ScaledScore = "1" },
                new RiverMeadTestResult() { Score = "4", ScaledScore = "1" },
                new RiverMeadTestResult() { Score = "5", ScaledScore = "1" },
                new RiverMeadTestResult() { Score = "6", ScaledScore = "1" },
                new RiverMeadTestResult() { Score = "7", ScaledScore = "1" },
                new RiverMeadTestResult() { Score = "8", ScaledScore = "1" },
                new RiverMeadTestResult() { Score = "9", ScaledScore = "2" },
                new RiverMeadTestResult() { Score = "10", ScaledScore = "3" },
                new RiverMeadTestResult() { Score = "11", ScaledScore = "4" },
                new RiverMeadTestResult() { Score = "12", ScaledScore = "5" },
                new RiverMeadTestResult() { Score = "13", ScaledScore = "6" },
                new RiverMeadTestResult() { Score = "14", ScaledScore = "7-10" },
                new RiverMeadTestResult() { Score = "15", ScaledScore = "11-19" });


            var N65_74 = new RiverMeadTestItem(65, 74, testName,
                  new RiverMeadTestResult() { Score = "0", ScaledScore = "1" },
                new RiverMeadTestResult() { Score = "1", ScaledScore = "1" },
                new RiverMeadTestResult() { Score = "2", ScaledScore = "1" },
                new RiverMeadTestResult() { Score = "3", ScaledScore = "1" },
                new RiverMeadTestResult() { Score = "4", ScaledScore = "1" },
                new RiverMeadTestResult() { Score = "5", ScaledScore = "1" },
                new RiverMeadTestResult() { Score = "6", ScaledScore = "1" },
                new RiverMeadTestResult() { Score = "7", ScaledScore = "1" },
                new RiverMeadTestResult() { Score = "8", ScaledScore = "1" },
                new RiverMeadTestResult() { Score = "9", ScaledScore = "2" },
                new RiverMeadTestResult() { Score = "10", ScaledScore = "3" },
                new RiverMeadTestResult() { Score = "11", ScaledScore = "4" },
                new RiverMeadTestResult() { Score = "12", ScaledScore = "5" },
                new RiverMeadTestResult() { Score = "13", ScaledScore = "6-7" },
                new RiverMeadTestResult() { Score = "14", ScaledScore = "8-10" },
                new RiverMeadTestResult() { Score = "15", ScaledScore = "11-19" });


            list.Add(B16_24);
            list.Add(B25_34);
            list.Add(B35_44);
            list.Add(B55_64);
            list.Add(N65_74);
        } 
        
        
        private static void A()
        {
            var B16_24 = new RiverMeadTestItem(16, 24, "A",
                new RiverMeadTestResult() {Score = "0", ScaledScore = "4"},
                new RiverMeadTestResult() {Score = "1", ScaledScore = "5-6"},
                new RiverMeadTestResult() {Score = "2", ScaledScore = "7"},
                new RiverMeadTestResult() {Score = "3", ScaledScore = "8-10"},
                new RiverMeadTestResult() {Score = "4", ScaledScore = "11-19"});


            var B25_34 = new RiverMeadTestItem(25, 34, "A",
                new RiverMeadTestResult() {Score = "0", ScaledScore = "3-4"},
                new RiverMeadTestResult() {Score = "1", ScaledScore = "5-6"},
                new RiverMeadTestResult() {Score = "2", ScaledScore = "7"},
                new RiverMeadTestResult() {Score = "3", ScaledScore = "8-10"},
                new RiverMeadTestResult() {Score = "4", ScaledScore = "11-19"});



            var B35_44 = new RiverMeadTestItem(35, 44, "A",
                new RiverMeadTestResult() {Score = "0", ScaledScore = "3-4"},
                new RiverMeadTestResult() {Score = "1", ScaledScore = "5-6"},
                new RiverMeadTestResult() {Score = "2", ScaledScore = "7"},
                new RiverMeadTestResult() {Score = "3", ScaledScore = "8-10"},
                new RiverMeadTestResult() {Score = "4", ScaledScore = "11-19"});


            var B45_54 = new RiverMeadTestItem(45, 54, "A",
                new RiverMeadTestResult() {Score = "0", ScaledScore = "3-4"},
                new RiverMeadTestResult() {Score = "1", ScaledScore = "5-6"},
                new RiverMeadTestResult() {Score = "2", ScaledScore = "7-8"},
                new RiverMeadTestResult() {Score = "3", ScaledScore = "9-11"},
                new RiverMeadTestResult() {Score = "4", ScaledScore = "12-19"});

            var B55_64 = new RiverMeadTestItem(55, 64, "A",
                new RiverMeadTestResult() {Score = "0", ScaledScore = "4-5"},
                new RiverMeadTestResult() {Score = "1", ScaledScore = "6-7"},
                new RiverMeadTestResult() {Score = "2", ScaledScore = "8-9"},
                new RiverMeadTestResult() {Score = "3", ScaledScore = "10-11"},
                new RiverMeadTestResult() {Score = "4", ScaledScore = "12-19"});

            var N65_74 = new RiverMeadTestItem(65, 74, "A",
                new RiverMeadTestResult() {Score = "0", ScaledScore = "5-6"},
                new RiverMeadTestResult() {Score = "1", ScaledScore = "7-8"},
                new RiverMeadTestResult() {Score = "2", ScaledScore = "9"},
                new RiverMeadTestResult() {Score = "3", ScaledScore = "10-12"},
                new RiverMeadTestResult() {Score = "4", ScaledScore = "13-19"});


            list.Add(B16_24);
            list.Add(B25_34);
            list.Add(B35_44);
            list.Add(B55_64);
            list.Add(N65_74);
        }
        private static void B()
        {
            var B16_24 = new RiverMeadTestItem(16, 24, "B",
                new RiverMeadTestResult() {Score = "0", ScaledScore = "1"},
                new RiverMeadTestResult() {Score = "1", ScaledScore = "1"},
                new RiverMeadTestResult() {Score = "2", ScaledScore = "1"},
                new RiverMeadTestResult() {Score = "3", ScaledScore = "2-4"},
                new RiverMeadTestResult() {Score = "4", ScaledScore = "5-6"},
                new RiverMeadTestResult() {Score = "5", ScaledScore = "5-6"},
                new RiverMeadTestResult() {Score = "6", ScaledScore = "7"},
                new RiverMeadTestResult() {Score = "7", ScaledScore = "8-10"},
                new RiverMeadTestResult() {Score = "8", ScaledScore = "11-19"});

            var B25_34 = new RiverMeadTestItem(25, 34, "B",
                new RiverMeadTestResult() {Score = "0", ScaledScore = "1-4"},
                new RiverMeadTestResult() {Score = "1", ScaledScore = "1-4"},
                new RiverMeadTestResult() {Score = "2", ScaledScore = "1-4"},
                new RiverMeadTestResult() {Score = "3", ScaledScore = "1-4"},
                new RiverMeadTestResult() {Score = "4", ScaledScore = "5"},
                new RiverMeadTestResult() {Score = "5", ScaledScore = "6-7"},
                new RiverMeadTestResult() {Score = "6", ScaledScore = "8"},
                new RiverMeadTestResult() {Score = "7", ScaledScore = "9-10"},
                new RiverMeadTestResult() {Score = "8", ScaledScore = "11-19"});


            var B35_44 = new RiverMeadTestItem(35, 44, "B",
                new RiverMeadTestResult() {Score = "0", ScaledScore = "2"},
                new RiverMeadTestResult() {Score = "1", ScaledScore = "2"},
                new RiverMeadTestResult() {Score = "2", ScaledScore = "3-5"},
                new RiverMeadTestResult() {Score = "3", ScaledScore = "3-5"},
                new RiverMeadTestResult() {Score = "4", ScaledScore = "6"},
                new RiverMeadTestResult() {Score = "5", ScaledScore = "7"},
                new RiverMeadTestResult() {Score = "6", ScaledScore = "8"},
                new RiverMeadTestResult() {Score = "7", ScaledScore = "9-11"},
                new RiverMeadTestResult() {Score = "8", ScaledScore = "12-19"});


            var B45_54 = new RiverMeadTestItem(45, 54, "B",
                new RiverMeadTestResult() {Score = "0", ScaledScore = "2"},
                new RiverMeadTestResult() {Score = "1", ScaledScore = "2"},
                new RiverMeadTestResult() {Score = "2", ScaledScore = "3-5"},
                new RiverMeadTestResult() {Score = "3", ScaledScore = "3-5"},
                new RiverMeadTestResult() {Score = "4", ScaledScore = "6"},
                new RiverMeadTestResult() {Score = "5", ScaledScore = "7"},
                new RiverMeadTestResult() {Score = "6", ScaledScore = "8-9"},
                new RiverMeadTestResult() {Score = "7", ScaledScore = "10-11"},
                new RiverMeadTestResult() {Score = "8", ScaledScore = "12-19"});

            var B55_64 = new RiverMeadTestItem(55, 64, "B",
                new RiverMeadTestResult() {Score = "0", ScaledScore = "2"},
                new RiverMeadTestResult() {Score = "1", ScaledScore = "2"},
                new RiverMeadTestResult() {Score = "2", ScaledScore = "3-5"},
                new RiverMeadTestResult() {Score = "3", ScaledScore = "3-5"},
                new RiverMeadTestResult() {Score = "4", ScaledScore = "6-8"},
                new RiverMeadTestResult() {Score = "5", ScaledScore = "6-8"},
                new RiverMeadTestResult() {Score = "6", ScaledScore = "9"},
                new RiverMeadTestResult() {Score = "7", ScaledScore = "10-11"},
                new RiverMeadTestResult() {Score = "8", ScaledScore = "12-19"});

            var N65_74 = new RiverMeadTestItem(65, 74, "B",
                new RiverMeadTestResult() {Score = "0", ScaledScore = "2"},
                new RiverMeadTestResult() {Score = "1", ScaledScore = "2"},
                new RiverMeadTestResult() {Score = "2", ScaledScore = "3-4"},
                new RiverMeadTestResult() {Score = "3", ScaledScore = "3-5"},
                new RiverMeadTestResult() {Score = "4", ScaledScore = "6-8"},
                new RiverMeadTestResult() {Score = "5", ScaledScore = "6-8"},
                new RiverMeadTestResult() {Score = "6", ScaledScore = "9-10"},
                new RiverMeadTestResult() {Score = "7", ScaledScore = "11-12"},
                new RiverMeadTestResult() {Score = "8", ScaledScore = "13-19"});


            list.Add(B16_24);
            list.Add(B25_34);
            list.Add(B35_44);
            list.Add(B55_64);
            list.Add(N65_74);
        }  
        
        private static void N()
        {
            var N16_24 = new RiverMeadTestItem(16, 24, "N",
                new RiverMeadTestResult() {Score = "0", ScaledScore = "3"},
                new RiverMeadTestResult() {Score = "1", ScaledScore = "4"},
                new RiverMeadTestResult() {Score = "2", ScaledScore = "5"},
                new RiverMeadTestResult() {Score = "3", ScaledScore = "6"},
                new RiverMeadTestResult() {Score = "4", ScaledScore = "7"},
                new RiverMeadTestResult() {Score = "5", ScaledScore = "8"},
                new RiverMeadTestResult() {Score = "6", ScaledScore = "9"},
                new RiverMeadTestResult() {Score = "7", ScaledScore = "10-11"},
                new RiverMeadTestResult() {Score = "8", ScaledScore = "12-19"});

            var N25_34 = new RiverMeadTestItem(25, 34, "N",
                new RiverMeadTestResult() {Score = "0", ScaledScore = "2-3"},
                new RiverMeadTestResult() {Score = "1", ScaledScore = "4"},
                new RiverMeadTestResult() {Score = "2", ScaledScore = "5-6"},
                new RiverMeadTestResult() {Score = "3", ScaledScore = "5-6"},
                new RiverMeadTestResult() {Score = "4", ScaledScore = "7"},
                new RiverMeadTestResult() {Score = "5", ScaledScore = "8"},
                new RiverMeadTestResult() {Score = "6", ScaledScore = "9"},
                new RiverMeadTestResult() {Score = "7", ScaledScore = "10-11"},
                new RiverMeadTestResult() {Score = "8", ScaledScore = "12-19"});


            var N35_44 = new RiverMeadTestItem(35, 44, "N",
                new RiverMeadTestResult() {Score = "0", ScaledScore = "3"},
                new RiverMeadTestResult() {Score = "1", ScaledScore = "4"},
                new RiverMeadTestResult() {Score = "2", ScaledScore = "5"},
                new RiverMeadTestResult() {Score = "3", ScaledScore = "6"},
                new RiverMeadTestResult() {Score = "4", ScaledScore = "7"},
                new RiverMeadTestResult() {Score = "5", ScaledScore = "8"},
                new RiverMeadTestResult() {Score = "6", ScaledScore = "9"},
                new RiverMeadTestResult() {Score = "7", ScaledScore = "10-11"},
                new RiverMeadTestResult() {Score = "8", ScaledScore = "12-19"});


            var N45_54 = new RiverMeadTestItem(45, 54, "N",
                new RiverMeadTestResult() {Score = "0", ScaledScore = "3"},
                new RiverMeadTestResult() {Score = "1", ScaledScore = "4"},
                new RiverMeadTestResult() {Score = "2", ScaledScore = "5"},
                new RiverMeadTestResult() {Score = "3", ScaledScore = "6"},
                new RiverMeadTestResult() {Score = "4", ScaledScore = "7"},
                new RiverMeadTestResult() {Score = "5", ScaledScore = "8"},
                new RiverMeadTestResult() {Score = "6", ScaledScore = "9"},
                new RiverMeadTestResult() {Score = "7", ScaledScore = "10-11"},
                new RiverMeadTestResult() {Score = "8", ScaledScore = "12-19"});

            var N55_64 = new RiverMeadTestItem(55, 64, "N",
                new RiverMeadTestResult() {Score = "0", ScaledScore = "3"},
                new RiverMeadTestResult() {Score = "1", ScaledScore = "4-5"},
                new RiverMeadTestResult() {Score = "2", ScaledScore = "6"},
                new RiverMeadTestResult() {Score = "3", ScaledScore = "7"},
                new RiverMeadTestResult() {Score = "4", ScaledScore = "7"},
                new RiverMeadTestResult() {Score = "5", ScaledScore = "8"},
                new RiverMeadTestResult() {Score = "6", ScaledScore = "9"},
                new RiverMeadTestResult() {Score = "7", ScaledScore = "10-11"},
                new RiverMeadTestResult() {Score = "8", ScaledScore = "12-19"});

            var N65_74 = new RiverMeadTestItem(65, 74, "N",
                new RiverMeadTestResult() {Score = "0", ScaledScore = "4"},
                new RiverMeadTestResult() {Score = "1", ScaledScore = "5-6"},
                new RiverMeadTestResult() {Score = "2", ScaledScore = "7"},
                new RiverMeadTestResult() {Score = "3", ScaledScore = "7"},
                new RiverMeadTestResult() {Score = "4", ScaledScore = "8"},
                new RiverMeadTestResult() {Score = "5", ScaledScore = "9"},
                new RiverMeadTestResult() {Score = "6", ScaledScore = "10-11"},
                new RiverMeadTestResult() {Score = "7", ScaledScore = "10-11"},
                new RiverMeadTestResult() {Score = "8", ScaledScore = "12-19"});


            list.Add(N16_24);
            list.Add(N25_34);
            list.Add(N35_44);
            list.Add(N55_64);
            list.Add(N65_74);
        }


        public static string GetScaledScore(string testName, int age, string score)
        {
           return list.First(l => l.From <= age && l.To >= age && testName == l.TestName).Results.First(r => r.Score == score).ScaledScore;
        }

        public static string GetRank(string scaledScore)
        {
            return (scaledScore.Contains('-')
                ? String.Format("{0}-{1}", LookUpRank(scaledScore.Split('-')[0]), LookUpRank(scaledScore.Split('-')[1]))
                : LookUpRank(scaledScore.Split('-')[0]));


        }

        public static string GetComment(string rank)
        {
            double percentile = Convert.ToDouble(rank.Split('-').Last());
            if (percentile < 30) return "Below average";
            if (percentile < 50) return "Average";
            return "Above average";
        }

        private static string LookUpRank(string s)
        {
          
            switch (s)
            {
                case "1":
                    return "0,13";
                case "2":
                    return "0,38";
                case "3":
                    return "0,98";
                case "4":
                    return "2,3";
                case "5":
                    return "5";
                case "6":
                    return "9";
                case "7":
                    return "16";
                case "8":
                    return "25";
                case "9":
                    return "37";
                case "10":
                    return "50";
                case "11":
                    return "63";
                case "12":
                    return "75";
                case "13":
                    return "84";
                case "14":
                    return "91";
                case "15":
                    return "95";
                case "16":
                    return "97,7";
                case "17":
                    return "99,0";
                case "18":
                    return "99,6";
                case "19":
                    return "99,9";
                default:
                    return String.Empty;
            }
            
        }
    }

}
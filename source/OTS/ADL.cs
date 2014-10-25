using System;
using System.Collections.Generic;

namespace OTS
{
    public class ClientNamePlaceHolder:IPlaceHolder
    {
        private readonly Excel _excel;

        public ClientNamePlaceHolder(Excel excel)
        {
            _excel = excel;
             _surname = excel.Cell("Client_Surname").StringValue;
             _title = excel.Cell("Client_Title").StringValue;
             _gender = excel.Cell("Client_Gender").StringValue;
             _list = new List<string>
            {
                string.Format("{0}. {1}", _title, _surname),
                (_gender == "male" ? "He" : "She"),
                "The client"
            };

            
        }

        static Random Randomizer = new Random();
        private string _surname;
        private string _title;
        private string _gender;
        private List<string> _list;

        public string TagName {
            get { return "[[Client]]"; }
        }

        public string Replace(string input)
        {
            return (input.Contains(TagName)) ? input.Replace(TagName, _list[Randomizer.Next(0, _list.Count)]) : input;
        }
    }

    public class ADL:Section
    {
        private class Item :Selectable
        {
            public string Activity { get; set; }
            public string Present { get; set; }

        }

        protected override string SectionName
        {
            get { return "ADL"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e =>
            {
                List<Item> items = e.GetSelected<Item>("A1","C60");
                return new {List = items, Counter.I};
            }; }
        }
       
    }
}
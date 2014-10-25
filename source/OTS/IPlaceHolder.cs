using System.Collections.Generic;
using Aspose.Words.Lists;
using Castle.Core.Internal;

namespace OTS
{
    public interface IPlaceHolder
    {
        string TagName { get; }
        string Replace(string input);
    }

    public static class PlaceHolders
    {
        private static IEnumerable<IPlaceHolder> _placeHolders;

        static PlaceHolders()
        {
            _placeHolders = IoC.GetAll<IPlaceHolder>();
        }

        public static string Replace(string input)
        {
            string result = input;
            _placeHolders.ForEach(p => result = p.Replace(result));
            return result;
        }

        public static List<SelectedValue> Replace(IEnumerable<SelectedValue> input)
        {
            List<SelectedValue> result = new List<SelectedValue>();
            input.ForEach(s => result.Add(new SelectedValue(){Text = Replace(s.Text), Selected = s.Selected}));
            return result;
        }


    }
}
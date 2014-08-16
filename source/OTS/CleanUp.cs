namespace OTS
{
    public class CleanUp : IReportElement
    {
        private readonly Word _word;

        public CleanUp(Word word)
        {
            _word = word;
        }

        public void Execute()
        {
            _word.RemoveTemplaterLicenseSection();

        }

        public int OrderIndex {
            get { return 100; }
        }
    }
}
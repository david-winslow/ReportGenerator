namespace OTS
{
    public static class Counter
    {
        private static int _i;
        private static int _assessmentResultCounter;
        private static int _hf;

        public static int I {
            get { return ++_i; }
        }
        public static int Ar
        {
            get { return ++_assessmentResultCounter; }
        }

        public static int Hf
        {
            get { return ++_hf; }
            
        }
    }
}
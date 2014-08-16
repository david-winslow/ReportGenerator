namespace OTS
{
    public interface IReportElement
    {
        void Execute();
        int OrderIndex { get; }
    }
}
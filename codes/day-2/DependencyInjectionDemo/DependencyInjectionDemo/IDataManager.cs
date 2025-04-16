namespace DependencyInjectionDemo
{
    public interface IDataManager
    {
        string? GetData();

        [Obsolete("this property is legacy...do not use this")]
        int FetchChoice { set; get; }
    }
}
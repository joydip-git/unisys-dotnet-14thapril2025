namespace Unisys.DotNet.PmsApp.ModelsCore
{
    //enum data type can be one of the following (by default -> int)
    //byte, sbyte, short, ushort, int, unit, long and ulong
    
    //public enum SortChoice : long
    public enum SortChoice
    {
        SortById,//=1000000,
        SortByName,//=200000,
        SortByPrice,//2
        SortByMake,//3
        SortByYear//4
    }
}

//using PayRollApp.Utility;
using PayRollApp.Models;
using PayRollApp.Utility;

//static import (importing a static class) => only possible with static class
using static PayRollApp.Utility.UiUtility;
//using static PayRollApp.Utility.XUtility;

namespace PayRollApp
{
    internal class Program
    {
        static void Main()
        {
            //int recordCount = UiUtility.GetRecordCount();
            //Employee[] employees = UiUtility.CreateStorage(recordCount);
            //UiUtility.SaveRecord(employees);
            //UiUtility.PrintRecords(employees);

            int recordCount = GetRecordCount();
            Employee[] employees = CreateStorage(recordCount);
            SaveRecord(employees);
            PrintRecords(employees);
        }
    }
}

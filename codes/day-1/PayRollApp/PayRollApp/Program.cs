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

            //int recordCount = GetRecordCount();
            //Employee[] employees = CreateStorage(recordCount);
            //SaveRecord(employees);
            //PrintRecords(employees);

            //Type typeEmployee = typeof(Employee);
            //Employee employee = new Employee();
            //employee.CalculateSalary();
            // employee.GetType();

            //here w.r.t. static member class name acts as the reference to the type class object storing that class's information
            //Console.WriteLine($"Company={Employee.Company}");
        }
    }
}

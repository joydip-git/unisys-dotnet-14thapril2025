using PayRollApp.Models;
//static importing Console class
using static System.Console;

namespace PayRollApp.Utility
{
    public static class UiUtility
    {
        public static int GetRecordCount()
        {
            Write("How many records? ");
            return int.Parse(ReadLine());
        }

        public static Employee[] CreateStorage(int size)
        {
            Employee[] employees = new Employee[size];
            return employees;
        }

        public static void SaveRecord(Employee[] employees)
        {
            for (int i = 0; i < employees.Length; i++)
            {
                Employee employee = CreateEmployee();
                employees[i] = employee;
            }
        }

        public static Employee CreateEmployee()
        {
            Write("enter name: ");
            string name = ReadLine();

            Write("enter id: ");
            int id = int.Parse(ReadLine());

            Write("enter Basic: ");
            decimal basic = decimal.Parse(ReadLine());

            Write("enter Da: ");
            decimal da = decimal.Parse(ReadLine());

            Write("enter Hra: ");
            decimal hra = decimal.Parse(ReadLine());

            Employee employee = new Employee(id, name, basic, da, hra);
            employee.CalculateSalary();
            return employee;
        }

        public static void PrintRecords(Employee[] employees)
        {
            foreach (Employee item in employees)
            {
                WriteLine($"Total salary of {item.Name} is {item.TotalPay}");
            }
        }
    }
}

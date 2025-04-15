using System.Reflection;

namespace PayRollApp
{
    internal class Program
    {
        static void Main()
        {
            //dynamic loading of an assembly
            Assembly loadedAssembly = Assembly.LoadFrom(@"D:\training\unisys-dotnet-14thapril2025\codes\day-2\PayRollApp\PayRollApp.Models\bin\Debug\net9.0\PayRollApp.Models.dll");

            if (loadedAssembly != null)
            {
                Console.WriteLine($"Full Name: {loadedAssembly.FullName}");

                //this line will force to create type class objects for every type in the assembly
                Type[] allTypes = loadedAssembly.GetTypes();
                string? fullName = "";
                foreach (Type singleType in allTypes)
                {
                    Console.WriteLine($"Name: {singleType.FullName}");
                    fullName = singleType.FullName;
                    Console.WriteLine($"Is Class: {singleType.IsClass}");
                    Console.WriteLine($"Is abstract Class: {singleType.IsAbstract}");
                    Console.WriteLine($"Is interface: {singleType.IsInterface}");
                    Console.WriteLine($"Is Value Type: {singleType.IsValueType}");
                    Console.WriteLine("\n");
                }

                if (fullName != null)
                {
                    Type? employeeTypeInfo = loadedAssembly.GetType(fullName);
                    Console.WriteLine($"Type Name: {employeeTypeInfo?.Name}");
                    if (employeeTypeInfo != null)
                    {
                        //employeeTypeInfo.GetConstructors();
                        object? empObj = Activator.CreateInstance(employeeTypeInfo);

                        PropertyInfo? namePropertyInfo = employeeTypeInfo.GetProperty("Name");
                        if (namePropertyInfo != null)
                        {
                            namePropertyInfo.SetValue(empObj, "Anil");
                        }

                        PropertyInfo? basicPropertyInfo = employeeTypeInfo.GetProperty("BasicPay");
                        if (basicPropertyInfo != null)
                        {
                            basicPropertyInfo.SetValue(empObj, 100M);
                        }
                        PropertyInfo? daPropertyInfo = employeeTypeInfo.GetProperty("DaPay");
                        if (daPropertyInfo != null)
                        {
                            daPropertyInfo.SetValue(empObj, 100M);
                        }

                        PropertyInfo? hraPropertyInfo = employeeTypeInfo.GetProperty("HraPay");
                        if (hraPropertyInfo != null)
                        {
                            hraPropertyInfo.SetValue(empObj, 100M);
                        }

                        MethodInfo? methodInfo = employeeTypeInfo.GetMethod("CalculateSalary");
                        if (methodInfo != null)
                        {
                            Console.WriteLine($"Name={methodInfo.Name}");
                            Console.WriteLine($"Return Type: {methodInfo.ReturnType}");

                            ParameterInfo[] allParams = methodInfo.GetParameters();
                            if (allParams.Length == 0)
                            {
                                Console.WriteLine($"No parameters");
                                methodInfo.Invoke(empObj, null);
                            }
                            else
                            {
                                //methodInfo.Invoke(empObj, []);
                                foreach (ParameterInfo p in allParams)
                                {
                                    Console.WriteLine($"Name: {p.Name}");
                                    Console.WriteLine($"Type: {p.ParameterType}");
                                    Console.WriteLine($"Pos: {p.Position}");
                                }
                            }
                        }                      

                        PropertyInfo? propertyInfo = employeeTypeInfo.GetProperty("TotalPay");
                        if (propertyInfo != null)
                        {
                            object? data = propertyInfo.GetValue(empObj);
                            Console.WriteLine($"Total Pay: {data}");
                        }
                    }
                }
            }
            else
                Console.WriteLine("could not load");
        }
    }
}

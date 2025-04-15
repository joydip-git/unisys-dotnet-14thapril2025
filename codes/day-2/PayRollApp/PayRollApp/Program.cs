using System.Reflection;

namespace PayRollApp
{
    internal class Program
    {
        static void Main()
        {
            //UseReflection();
            //B.StaticMethod();
            B obj1 = new B();
            B obj2 = new B("anil", "blr", "1000", "someData");
            //obj2.Call();
        }
        static void UseReflection()
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
                        FieldInfo[] allFields = employeeTypeInfo.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
                        Console.WriteLine("\nall fields\n");
                        foreach (FieldInfo item in allFields)
                        {
                            Console.WriteLine($"name: {item.Name}");
                            Console.WriteLine($"type: {item.FieldType}");
                        }
                        Console.WriteLine("\n");

                        ConstructorInfo? paramCtor = employeeTypeInfo.GetConstructor([typeof(int), typeof(string), typeof(decimal), typeof(decimal), typeof(decimal)]);

                        object? empObj = null;
                        if (paramCtor != null)
                        {
                            empObj = paramCtor.Invoke([1, "Anil", 100M, 100M, 100M]);
                        }
                        //object? empObj = Activator.CreateInstance(employeeTypeInfo);
                        /*
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
                        */
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

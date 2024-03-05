using System.Reflection;

namespace ReflectionDemo.UI
{
    class A
    {
        public static string SMethod()
        {
            return "i am static";
        }
        public string SayHello(string message)
        {
            return $"Hello {message}";
        }
    }
    internal class Program
    {
        static void ExploreMetadata()
        {

            //class metadata
            Type type = typeof(A);
            Console.WriteLine(type.FullName);


            //method metadata
            Console.WriteLine("\n\nmethod info\n");
            MethodInfo? methodInfo = type.GetMethod("SayHello");
            MethodInfo? methodInfoS = type.GetMethod("SMethod");
            Console.WriteLine(methodInfoS?.IsStatic);
            //methodInfo?.IsStatic;
            Console.WriteLine(methodInfoS?.Invoke(null, null));

            //parameter metadata
            Console.WriteLine(methodInfo?.Name);
            Console.WriteLine(methodInfo?.ReturnType);
            Console.WriteLine("\n\nparameter info\n");
            ParameterInfo[]? parameters = methodInfo?.GetParameters();
            if (parameters != null && parameters.Length > 0)
            {
                foreach (var parameter in parameters)
                {
                    Console.WriteLine(parameter.Name);
                    Console.WriteLine(parameter.ParameterType);
                }
            }

            //creating object of the class based in metadata of the class dynamically (creating object on the fly)
            object? obj = Activator.CreateInstance(type);
            Console.WriteLine(obj?.GetType().Name);

            //dynamic invocation of method using method's metadata
            object? value = methodInfo?.Invoke(obj, new object[] { "Joydip " });
            Console.WriteLine(value);

            //A obj = new A();
            //Type objType = obj.GetType();
            //Console.WriteLine(objType.IsValueType);
        }
        static void Main()
        {
            try
            {
                //loading assembly dynamically
                Assembly assembly = Assembly.LoadFrom(@"D:/training/dotnetcore-siemens-1stmarch2024/codes/day-3/ReflectionDemo.LibraryApp/bin/Debug/net8.0/ReflectionDemo.LibraryApp.dll");

                var allTypes = assembly.GetTypes();
                foreach (var type in allTypes)
                {
                    Console.WriteLine($"Name: {type.Name}");
                    Console.WriteLine($"Is Class?: {type.IsClass}");
                    Console.WriteLine($"Is Interface?: {type.IsInterface}");
                    Console.WriteLine($"Is Value type?: {type.IsValueType}");
                }

                Type? calcTypeInfo = assembly.GetType("ReflectionDemo.LibraryApp.Calculation");
                if (calcTypeInfo != null)
                {
                    object? calcObj = Activator.CreateInstance(calcTypeInfo);
                    var methods = calcTypeInfo.GetMethods();

                    foreach (var method in methods)
                    {
                        Console.WriteLine($"Name:{method.Name}");
                    }

                    var addMethodInfo = calcTypeInfo.GetMethod("Add");
                    var res = addMethodInfo?.Invoke(calcObj, new object[] {12, 13 });
                    Console.WriteLine(res);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

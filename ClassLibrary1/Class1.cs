namespace ClassLibrary1;
using System;
using System.Threading.Tasks;
public class Class1
{
    static async Task Main(string[] args)
        {
        Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");
        await (1000);
        Console.Clear();
        await (5000);
        Console.WriteLine("Goodbye World!");
        }
}

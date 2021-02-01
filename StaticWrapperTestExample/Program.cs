using System;
using StaticWrapperTestExample.Interfaces;
using StaticWrapperTestExample.Wrappers;

namespace StaticWrapperTestExample
{
    internal static class Program
    {
        private static void Main()
        {
            IEnumerationFieldSeparatorValidator validator = new EnumerationFieldSeparatorValidator(new CharImpl());
            Console.Write("Enter separator string: ");
            var input = Console.ReadLine();
            var result = validator.Validate(input!);
            Console.WriteLine($"Validated result: {result}");
            Console.ReadKey();
        }
    }
}
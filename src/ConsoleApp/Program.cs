using Salazar.Measurements;
using System;

namespace ConsoleApp
{
    class Pro
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Value:");
            var value = double.Parse(Console.ReadLine());

            Console.WriteLine("Measurement (empty for default):");

            var measurement = Enum.Parse<Measurements>(Console.ReadLine() ?? Measurements.Default.ToString());

            var measure = new Measure(value, measurement);

            Console.WriteLine($"Milli: {measure.Milli}");
            Console.WriteLine($"Centi: {measure.Centi}");
            Console.WriteLine($"Deci: {measure.Deci}");

            Console.WriteLine($"Default: {measure.Default}");

            Console.WriteLine($"Deca: {measure.Deca}");
            Console.WriteLine($"Hecto: {measure.Hecto}");
            Console.WriteLine($"Kilo: {measure.Kilo}");


            Console.WriteLine("Press any key to close...");
            Console.ReadLine();
        }
    }
}
using Calendersystem;
using System;

namespace Infrastructure.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double julianDate = 2460449.78; // Beispiel für ein julianisches Datum
            var result = ConvertDateTime.FromJulianDateToGregorianCalender(julianDate);

            Console.WriteLine($"Datum: {result.ToShortDateString()}, Zeit: {result.ToShortTimeString()}");
            Console.ReadKey();
        }
    }
}
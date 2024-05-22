namespace CalculatePortalDays
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Bitte geben Sie das Jahr an, von welchem Sie die Portaltage anzeigen lassen wollen:");
            string year = Console.ReadLine() ?? "0";
            var portalDays = PortalDaysCalculator.GetPortalDays(Convert.ToInt32(year));

            foreach (var portalDay in portalDays)
                Console.WriteLine($"Datum: {portalDay.Item1.ToShortDateString()}, Kin-Nummer: {portalDay.Item2}");

            Console.ReadKey();
        }
    }
}
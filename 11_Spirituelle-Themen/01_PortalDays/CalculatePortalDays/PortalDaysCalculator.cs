using System.Globalization;

namespace CalculatePortalDays
{
    internal static class PortalDaysCalculator
    {

        /// <summary>
        /// Dient zur Kin-Berechnung für den Tzolkin-Kalender.
        /// </summary>
        private static Dictionary<int, int> _jahresZahlenKinBerechnung = new Dictionary<int, int>()
        {
            { 1910, 62 },
            { 1962, 62 },
            { 2014, 62 },
            { 1936, 192 },
            { 1988, 192 },
            { 2040, 192 },
            { 1911, 167 },
            { 1963, 167 },
            { 2015, 167 },
            { 1937, 37 },
            { 1989, 37 },
            { 2041, 37 },
            { 1912, 12 },
            { 1964, 12 },
            { 2016, 12 },
            { 1938, 142 },
            { 1990, 142 },
            { 2042, 142 },
            { 1913, 117 },
            { 1965, 117 },
            { 2017, 117 },
            { 1939, 247 },
            { 1991, 247 },
            { 2043, 247 },
            { 1914, 222 },
            { 1966, 222 },
            { 2018, 222 },
            { 1940, 92 },
            { 1992, 92 },
            { 2044, 92 },
            { 1915, 67 },
            { 1967, 67 },
            { 2019, 67 },
            { 1941, 197 },
            { 1993, 197 },
            { 2045, 197 },
            { 1916, 172 },
            { 1968, 172 },
            { 2020, 172 },
            { 1942, 42 },
            { 1994, 42 },
            { 2046, 42 },
            { 1917, 17 },
            { 1969, 17 },
            { 2021, 17 },
            { 1943, 147 },
            { 1995, 147 },
            { 2047, 147 },
            { 1918, 122 },
            { 1970, 122 },
            { 2022, 122 },
            { 1944, 252 },
            { 1996, 252 },
            { 2048, 252 },
            { 1919, 227 },
            { 1971, 227 },
            { 2023, 227 },
            { 1945, 97 },
            { 1997, 97 },
            { 2049, 97 },
            { 1920, 72 },
            { 1972, 72 },
            { 2024, 72 },
            { 1946, 202 },
            { 1998, 202 },
            { 2050, 202 },
            { 1921, 177 },
            { 1973, 177 },
            { 2025, 177 },
            { 1947, 47 },
            { 1999, 47 },
            { 2051, 47 },
            { 1922, 152 },
            { 1974, 152 },
            { 2026, 152 },
            { 1948, 257 },
            { 2000, 257 },
            { 2052, 257 },
            { 1923, 127 },
            { 1975, 127 },
            { 2027, 127 },
            { 1949, 7 },
            { 2001, 7 },
            { 2053, 7 },
            { 1924, 232 },
            { 1976, 232 },
            { 2028, 232 },
            { 1950, 102 },
            { 2002, 102 },
            { 2054, 102 },
            { 1925, 77 },
            { 1977, 77 },
            { 2029, 77 },
            { 1951, 207 },
            { 2003, 207 },
            { 2055, 207 },
            { 1926, 182 },
            { 1978, 182 },
            { 2030, 182 },
            { 1952, 52 },
            { 2004, 52 },
            { 2056, 52 },
            { 1927, 157 },
            { 1979, 157 },
            { 2031, 157 },
            { 1953, 2 },
            { 2005, 2 },
            { 2057, 2 },
            { 1928, 132 },
            { 1980, 132 },
            { 2032, 132 },
            { 1954, 107 },
            { 2006, 107 },
            { 2058, 107 },
            { 1929, 237 },
            { 1981, 237 },
            { 2033, 237 },
            { 1955, 212 },
            { 2007, 212 },
            { 2059, 212 },
            { 1930, 82 },
            { 1982, 82 },
            { 2034, 82 },
            { 1956, 57 },
            { 2008, 57 },
            { 2060, 57 },
            { 1931, 187 },
            { 1983, 187 },
            { 2035, 187 },
            { 1957, 162 },
            { 2009, 162 },
            { 2061, 162 },
            { 1932, 32 },
            { 1984, 32 },
            { 2036, 32 },
            { 1958, 7 },
            { 2010, 7 },
            { 2062, 7 },
            { 1933, 112 },
            { 1985, 112 },
            { 2037, 112 },
            { 1959, 217 },
            { 2011, 217 },
            { 2063, 217 },
            { 1934, 87 },
            { 1986, 87 },
            { 2038, 87 },
            { 1960, 197 },
            { 2012, 197 },
            { 2064, 197 },
            { 1935, 257 },
            { 1987, 257 },
            { 2039, 257 },
            { 1961, 112 },
            { 2013, 112 },
            { 2065, 112 }
        };

        /// <summary>
        /// Monate werden für den Mayakalender aufsummiert
        /// </summary>
        public static readonly int[] DaysToMonthSumUpMayaCalender = { 0, 31, 59, 90, 120, 151, 181, 212, 243, 13, 44, 74 };

        public static IList<long> PortlDaysByTzolkinKinNumber = new List<long>() { 1, 20, 22, 39, 43, 50, 51, 58, 64, 69, 72, 77, 85, 88, 93, 96, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 146, 147, 148, 149, 150, 151, 152, 153, 154, 155, 165, 168, 173, 176, 184, 189, 192, 197, 203, 210, 211, 218, 222, 239, 241, 260 };

        /// <summary>
        /// Gibt alle Portaltage im Jahr <paramref name="year"/> zurück.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static IList<Tuple<DateTime, long>> GetPortalDays(int year)
        {
            var portalDays = new List<Tuple<DateTime, long>>();
            var startDateTime = new DateTime(year, 1, 1);

            while (startDateTime.Year <= year)
            {
                if (IsPortalDay(startDateTime))
                {
                    var kinNumber = GetTzolkinKinNumber(startDateTime);
                    var portalDay = new Tuple<DateTime, long>(startDateTime, kinNumber);
                    portalDays.Add(portalDay);
                }

                // Nächster Tag
                startDateTime = startDateTime.AddDays(1);
            }

            return portalDays;
        }

        /// <summary>
        /// Handelt es sich beim Datum <paramref name="gregorianCalender"/>, um einen Portaltag.
        /// </summary>
        /// <param name="gregorianCalender"></param>
        /// <returns></returns>
        public static bool IsPortalDay(DateTime gregorianCalender)
        {
            return IsPortalDay(gregorianCalender.Year, gregorianCalender.Month, gregorianCalender.Day);
        }

        public static bool IsPortalDay(int year, int month, int day)
        {
            var tzolkinNumber = GetTzolkinKinNumber(year, month, day);

            return PortlDaysByTzolkinKinNumber.Any(x => x == tzolkinNumber);
        }

        /// <summary>
        /// Berechnet die Kin-Nummer zwischen 1-260 für den Tzolkin-Kalenders, 
        /// angegeben wird der gregorianische Kalender <paramref name="gregorianCalender"/>.
        /// </summary>
        /// <remarks>
        /// https://canamay-te.de/site/wp-content/uploads/KIN-Berechnung_Tabelle-und-Jahresenergien.pdf
        /// </remarks>
        /// <param name="gregorianCalender"></param>
        /// <returns></returns>
        public static long GetTzolkinKinNumber(DateTime gregorianCalender)
        {
            return GetTzolkinKinNumber(gregorianCalender.Year, gregorianCalender.Month, gregorianCalender.Day);
        }


        /// <summary>
        /// Berechnet die Kin-Nummer zwischen 1-260 für den Tzolkin-Kalender, 
        /// angegeben wird der gregorianische Kalender.
        /// </summary>
        /// <param name="year">Gibt das Jahr an.</param>
        /// <param name="month">Gibt den Monat an.</param>
        /// <param name="day">Gibt den Tag an.</param>
        /// <returns></returns>
        public static long GetTzolkinKinNumber(int year, int month, int day)
        {
            var jahreszahl = GetTzolkinYearNumber(year);
            var monatszahl = GetTzolkinMonthNumber(month);

            // Bei einem Schaltjahr mit dem 29. Februar, wird der Tag um 1 reduziert, der 29. Februar bekommt die Kin-Nummer vom 28. Februar
            // eigentlich zusätzlich die Kin-Nummer vom 1. März.
            var calculatedDay = IsLeapYear(year) && month == 2 && day == 29 ? day - 1 : day;

            var kins = jahreszahl + monatszahl + calculatedDay;

            while (kins > 260)
                kins -= 260;

            return kins;
        }

        /// <summary>
        /// Holt sich die Tagesnummer (Anzahl der Tage im Jahr)
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public static int GetTzolkinMonthNumber(int month)
        {
            if (month < 1)
                throw new ArgumentOutOfRangeException(nameof(month), "Monat darf nicht kleiner als 1 sein.");

            if (month > 12)
                throw new ArgumentOutOfRangeException(nameof(month), "Monat darf nicht größer als 12 sein.");

            return DaysToMonthSumUpMayaCalender[month - 1];
        }

        /// <summary>
        /// Ermittlt die Jahresnummer mithilfe der Jahreszahlen-Matrix.
        /// </summary>
        /// <remarks>
        /// Damit lässt sicch die Gesamt-Kin des Tzolkin-Kalenders berechnen, um anschließend die Portaltage zu ermitteln
        /// </remarks>
        /// <param name="year"></param>
        /// <returns></returns>
        public static int GetTzolkinYearNumber(int year)
        {
            int baseYearMin = 1910;
            int baseYearMax = 2065;
            var yearSteps = 52;

            if (year >= baseYearMin && year < baseYearMax)
            {
                // Standardfall
                return _jahresZahlenKinBerechnung[year];
            }
            else if (year < baseYearMin)
            {
                var yearModified = year + yearSteps;

                while (yearModified < baseYearMin)
                {
                    yearModified += yearSteps;
                }

                return _jahresZahlenKinBerechnung[yearModified];
            }
            else
            {
                var yearModified = year - yearSteps;

                while (yearModified > baseYearMax)
                {
                    yearModified -= yearSteps;
                }

                return _jahresZahlenKinBerechnung[yearModified];
            }
        }

        /// <summary>
        /// Berechnet, ob das angegebene Jahr <paramref name="year"/> ein Schaltjahr ist.
        /// </summary>
        /// <remarks>
        /// Berechnung erfolgt:
        /// Wäre ein Jahr 365,25 Tage lang, würden wir genau alle vier Jahre ein Schaltjahr benötigen.
        /// Da ein Jahr mit 365,242 Tagen jedoch etwas kürzer ist, werden ab und zu Schaltjahre ausgelassen.
        /// Zusatzregel 1: Jahreszahlen, die glatt durch 100 teilbar sind, werden nicht als Schaltjahr gezählt, wie 1900 und 2100.
        /// Zusatzregel 2: Ist das Jahr jedoch glatt durch 400 teilbar, zählt es doch als Schaltjahr, wie 1600 und 2000.
        /// </remarks>
        /// <param name="year"></param>
        /// <returns></returns>
        public static bool IsLeapYear(int year)
        {
            return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
        }
    }
}

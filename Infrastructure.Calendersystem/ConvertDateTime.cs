using System;

namespace Infrastructure.Calendersystem
{
    /// <summary>
    /// Repräsentiert die Konvertierung der einzelnen Kalendersysteme.
    /// 
    /// Im Folgdenden sind noch Referenzen zu den Kalendersystemen aufgeführt:
    /// Wikipedia: Julianisches Datum<seealso cref="https://de.wikipedia.org/wiki/Julianisches_Datum"/>
    /// Online-Kalenderrechner: <seealso cref="https://calendarhome.com/calculate/convert-a-date"/>
    /// Das Jahr 0: <seealso cref="https://de.wikipedia.org/wiki/Jahr_null"/>
    /// </summary>
    public static class ConvertDateTime
    {
        /// <summary>
        /// Berechnung des Wochentags über den julianischen Tag.
        /// </summary>
        /// <param name="julianDate"></param>
        /// <remarks>
        /// Zum junlianischen Datum wird noch 1.5 addiert, um den korrekten Wochentag zu berechnen, da der Wochentag am Montag, den 01.01.4713 v. Chr. um 12:00 Mittags UT beginnt.
        /// Die 0.5 beziet sich auf die Tageshälfte, da der Tag um 12:00 Mittags UT beginnt.
        /// </remarks>
        /// <returns></returns>
        public static DayOfWeek FromJulianDateToDayOfWeek(double julianDate)
        {
            Math.DivRem((int)(julianDate + 1.5), 7, out int julianDateDayOfWeek);

            return (DayOfWeek)julianDateDayOfWeek;
        }


        /// <summary>
        /// Gibt die Uhrzeit aus einem julianischem Datum zurück.
        /// </summary>
        /// <param name="julianDate"></param>
        /// <returns></returns>
        public static TimeSpan FromJulianDateToTimeSpan(JulianDate julianDate)
        {
            return FromJulianDateToTimeSpan(julianDate.JulianDateValue);
        }

        /// <summary>
        /// Gibt die Uhrzeit aus einem julianischem Datum zurück.
        /// </summary>
        /// <param name="julianDate"></param>
        /// <remarks>
        /// Um die Uhrzeit zu extrahieren, wird der ganzzahlige Wert des julianischen Datums abgezogen, der die Tage repräsentiert.
        /// Die Kommastellen des julianischen Datums repräsentieren die Uhrzeit.
        /// </remarks>
        /// <returns></returns>
        public static TimeSpan FromJulianDateToTimeSpan(double julianDate)
        {
            // Uhrzeit berechnen
            int julianDateGanzzahl = (int)julianDate;

            // Holt sich die Uhrzeit aus dem julianischen Datum.
            double fractionOfDay = julianDate - julianDateGanzzahl;

            // Holt sich den absoluten Wert (keine negativen Werte)
            if (fractionOfDay < 0)
                fractionOfDay = -fractionOfDay;

            double totalSeconds = fractionOfDay * 86400.0;
            var hours = (int)(totalSeconds / 3600.0);
            var minutes = (int)((totalSeconds - hours * 3600.0) / 60.0);
            var seconds = totalSeconds - hours * 3600.0 - minutes * 60.0;

            return new TimeSpan(hours, minutes, (int)Math.Round(seconds, 0));
        }

        /// <summary>
        /// Berechnet das julianische Datum aus dem gregorianischen Datum mit Zeitangabe.
        /// </summary>
        /// <param name="calenderDate"></param>
        /// <remarks>
        /// Hinweise:
        /// - Die Berechnung des julianischen Datums erfolgt am 01.01.4713 v. Chr um 12:00 Mittags UT und wurde von Joseph Justus Scaliger eingeführt.
        /// - Das Jahr 0 wird bei der Berechnung des julianischen Datums berücksichtigt.
        /// - Die Berechnung des julianischen Datums erfolgt unter Berücksichtigung der Schaltjahre.
        /// - Die Berechnung des julianischen Datums erfolgt unter Berücksichtigung der Zeit.
        /// </remarks>
        /// <returns>Rückgabewert ist das julianische Datum.</returns>
        public static JulianDate FromGregorianCalenderToJulianDate(DateTime calenderDate)
        {
            return FromGregorianCalenderToJulianDate(calenderDate.Year, calenderDate.Month, calenderDate.Day, calenderDate.Hour, calenderDate.Minute, calenderDate.Second);
        }

        /// <summary>
        /// Berechnet das julianische Datum aus dem gregorianischen Datum mit Zeitangabe.
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <remarks>
        /// Hinweise:
        /// - Die Berechnung des julianischen Datums erfolgt am 01.01.4713 v. Chr um 12:00 Mittags UT und wurde von Joseph Justus Scaliger eingeführt.
        /// - Das Jahr 0 wird bei der Berechnung des julianischen Datums berücksichtigt.
        /// - Die Berechnung des julianischen Datums erfolgt unter Berücksichtigung der Schaltjahre.
        /// - Die Berechnung des julianischen Datums erfolgt unter Berücksichtigung der Zeit.
        /// </remarks>
        /// <returns>Rückgabewert ist das julianische Datum.</returns>
        public static JulianDate FromGregorianCalenderToJulianDate(int year, int month, int day)
        {
            return FromGregorianCalenderToJulianDate(year, month, day, 0, 0, 0);
        }

        /// <summary>
        /// Berechnet das julianische Datum aus dem gregorianischen Datum mit Zeitangabe.
        /// </summary>
        /// <param name="year">Jahr</param>
        /// <param name="month">Monat</param>
        /// <param name="day">Tag</param>
        /// <param name="hour">Stunde</param>
        /// <param name="minute">Minute</param>
        /// <param name="second">Sekunde</param>
        /// <remarks>
        /// Hinweise:
        /// - Die Berechnung des julianischen Datums erfolgt am 01.01.4713 v. Chr um 12:00 Mittags UT und wurde von Joseph Justus Scaliger eingeführt.
        /// - Das Jahr 0 wird bei der Berechnung des julianischen Datums berücksichtigt.
        /// - Die Berechnung des julianischen Datums erfolgt unter Berücksichtigung der Schaltjahre.
        /// - Die Berechnung des julianischen Datums erfolgt unter Berücksichtigung der Zeit.
        /// </remarks>
        /// <returns></returns>
        public static JulianDate FromGregorianCalenderToJulianDate(int year, int month, int day, int hour, int minute, int second)
        {
            double julianDate = ToJulianDate(year, month, day, hour, minute, second);

            return new JulianDate(julianDate);
        }

        /// <summary>
        /// Berechnet das julianische Datum aus dem gregorianischem Datum mit der Zeit.
        /// </summary>
        /// <param name="year">Jahr</param>
        /// <param name="month">Monat</param>
        /// <param name="day">Tag</param>
        /// <param name="hour">Stunde</param>
        /// <param name="minute">Minute</param>
        /// <param name="second">Sekunde</param>
        /// <remarks>
        /// Hinweise:
        /// - Die Berechnung des julianischen Datums erfolgt am 01.01.4713 v. Chr um 12:00 Mittags UT und wurde von Joseph Justus Scaliger eingeführt.
        /// - Das Jahr 0 wird bei der Berechnung des julianischen Datums berücksichtigt.
        /// - Die Berechnung des julianischen Datums erfolgt unter Berücksichtigung der Schaltjahre.
        /// - Die Berechnung des julianischen Datums erfolgt unter Berücksichtigung der Zeit.
        /// </remarks>
        /// <returns></returns>
        public static double ToJulianDate(int year, int month, int day, int hour, int minute, int second)
        {
            var millisecond = 0;

            // Schritt 1: Monat-Korrektur, falls Monat Januar oder Februar
            if (month < 3)
            {
                year -= 1;
                month += 12;
            }

            // Schritt 2: Berechnung des Jahrhunderts und der Schaltjahrkorrektur
            double century = Math.Floor(year / 100.0);
            double leapYearCorrection = 2 - century + Math.Floor(century / 4.0);

            // Schritt 3: Berechnung des Tagesbruchs aus Stunden, Minuten, Sekunden und Millisekunden
            double dayFraction = (double)hour / 24 + (double)minute / (24 * 60) + (double)second / (24 * 60 * 60) + (double)millisecond / (24 * 60 * 60 * 1000);

            // Schritt 4: Berechnung der Hauptkomponenten des Julianischen Datums
            double julianYearDays = Math.Floor(365.25 * (year + 4716));
            double julianMonthDays = Math.Floor(30.6001 * (month + 1));

            // Schritt 5: Kombination aller Komponenten zum Julianischen Datum
            double julianDay = julianYearDays + julianMonthDays + day + leapYearCorrection - 1524.5 + dayFraction;

            return julianDay;
        }

        /// <summary>
        /// Berechnet das gregorianische Datum unter Berücksichtigung der Zeit aus dem julianischem Datum <paramref name="julianDate"/>. 
        /// </summary>
        /// <param name="julianDate">Gibt das julianische Datum an.</param>
        /// <returns>Gibt das gregorianische Datum zurück.</returns>
        public static DateTime FromJulianDateToGregorianCalender(JulianDate julianDate)
        {
            return FromJulianDateToGregorianCalender(julianDate.JulianDateValue);
        }

        /// <summary>
        /// Berechnet das gregorianische Datum unter Berücksichtigung der Zeit aus dem julianischem Datum <paramref name="julianDate"/>.
        /// </summary>
        /// <param name="julianDate">Gibt das julianische Datum an.</param>
        /// <returns>Gibt das gregorianische Datum zurück.</returns>
        public static DateTime FromJulianDateToGregorianCalender(double julianDate)
        {
            var resultTuple = FromJulianDateToGregorianCalenderTuple(julianDate);

            return new DateTime(resultTuple.Item1, resultTuple.Item2, resultTuple.Item3, resultTuple.Item4, resultTuple.Item5, resultTuple.Item6);
        }

        /// <summary>
        /// Berechnet das gregorianische Datum unter Berücksichtigung der Zeit aus dem julianischem Datum <paramref name="julianDate"/>.
        /// </summary>
        /// <param name="julianDate">Gibt das julianische Datum an.</param>
        /// <returns>Gibt das gregorianische Datum zurück.</returns>
        private static Tuple<int, int, int, int, int, int> FromJulianDateToGregorianCalenderTuple(double julianDate)
        {
            // JD ist das julianische Datum, verschoben um eine halbe Tageslänge, da der julianische Tag um 12:00 Uhr beginnt.
            double shiftedJulianDate = julianDate + 0.5;
            double integerPartOfJulianDate = Math.Floor(shiftedJulianDate);
            double fractionalPartOfJulianDate = shiftedJulianDate - integerPartOfJulianDate;
            double adjustedJulianDate;

            if (integerPartOfJulianDate < 0)
            {
                adjustedJulianDate = integerPartOfJulianDate + 1 + 1524;
            }
            else
            {
                double century = Math.Floor((integerPartOfJulianDate - 1867216.25) / 36524.25);
                adjustedJulianDate = integerPartOfJulianDate + 1 + century - Math.Floor(century / 4);
            }

            double tempDate = adjustedJulianDate + 1524;
            double yearComponent = Math.Floor((tempDate - 122.1) / 365.25);
            double yearDays = Math.Floor(365.25 * yearComponent);
            double monthComponent = Math.Floor((tempDate - yearDays) / 30.6001);
            double dayFraction = tempDate - yearDays - Math.Floor(30.6001 * monthComponent) + fractionalPartOfJulianDate;
            int day = (int)Math.Floor(dayFraction);
            int month = monthComponent < 14 ? (int)(monthComponent - 1) : (int)(monthComponent - 13);
            int year = monthComponent < 14 ? (int)(yearComponent - 4716) : (int)(yearComponent - 4715);

            // Berechnung der Uhrzeit aus dem julianischen Datum
            var timeFromJulianDate = FromJulianDateToTimeSpan(shiftedJulianDate);

            return new Tuple<int, int, int, int, int, int>(year, month, day, timeFromJulianDate.Hours, timeFromJulianDate.Minutes, timeFromJulianDate.Seconds);
        }

    }
}

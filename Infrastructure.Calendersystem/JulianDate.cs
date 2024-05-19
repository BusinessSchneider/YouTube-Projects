using System;

namespace Infrastructure.Calendersystem
{
    /// Das Julianische Datum gibt an, wie viele Tage seit dem 1. Januar 4713 v. Chr. um 12h UT vergangen sind.
    /// 
    /// Es stellt eine fortlaufende Tageszählung dar, welche in der Astronomie oft verwendet wird.
    /// Es hat gegenüber im Alltag verwendeten Kalendern den Vorteil, dass Zeitdifferenzen sehr leicht berechnet werden können, 
    /// ohne sich um Besonderheiten wie ungleich lange Monate und Schaltjahre kümmern zu müssen.
    public struct JulianDate : IComparable, IComparable<JulianDate>
    {
        /// <summary>
        /// Die Angabe erfolgt in Tagen
        /// </summary>
        public double JulianDateValue { get; private set; } = 0;

        public DayOfWeek GetWeekDay() => ConvertDateTime.FromJulianDateToDayOfWeek(JulianDateValue);

        /// <summary>
        /// Repräsentiert den Beginn des julianischen Datums, manchmal wird auch ein anderer Zeitpunkt verwendet.
        /// 
        /// Epoche des julianischen Datums.
        /// </summary>
        public DateTime Epoche => new DateTime(-4713, 1, 1, 12, 0, 0);

        /// <summary>
        /// Angegeben wird das julianische Datum.
        /// </summary>
        /// <param name="epocheType"></param>
        /// <param name="julianDate"></param>
        public JulianDate(string julianDate)
        {
            JulianDateValue = Convert.ToDouble(julianDate);
        }

        /// <summary>
        /// Angegeben wird das julianische Datum.
        /// </summary>
        /// <param name="epocheType"></param>
        /// <param name="julianDate"></param>
        public JulianDate(long julianDate)
        {
            JulianDateValue = julianDate;
        }

        /// <summary>
        /// Angegeben wird das julianische Datum.
        /// </summary>
        /// <param name="julianDate"></param>
        public JulianDate(double julianDate)
        {
            JulianDateValue = julianDate;
        }

        public int CompareTo(object obj)
        {
            if (obj is JulianDate)
                return CompareTo((JulianDate)obj);

            throw new ArgumentException("Object is not a JulianDate");
        }

        public int CompareTo(JulianDate other)
        {
            var compare = JulianDateValue.CompareTo(other.JulianDateValue);

            if (compare != 0)
                return compare;

            return 0;
        }

        public override bool Equals(object obj)
        {
            if (obj is JulianDate)
            {
                return Equals((JulianDate)obj);
            }
            return false;
        }

        public bool Equals(JulianDate other)
        {
            return JulianDateValue == other.JulianDateValue;
        }


        public override int GetHashCode()
        {
            return JulianDateValue.GetHashCode();
        }



        /// <summary>
        /// Wandelt den julianischen Wert in String um.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JulianDateValue.ToString();
        }

        /// <summary>
        /// Wandelt das Datum <paramref name="julianDate"/> in ein julianisches Datum um. 
        /// </summary>
        /// <param name="julianDate">Julianisches Datum als Integer-Wert</param>
        public static implicit operator JulianDate(int julianDate)
        {
            return new JulianDate(julianDate);
        }

        /// <summary>
        /// Wandelt das Datum <paramref name="julianDate"/> in ein julianisches Datum um. 
        /// </summary>
        /// <param name="julianDate">Julianisches Datum als Double-Wert</param>
        public static implicit operator JulianDate(double julianDate)
        {
            return new JulianDate(julianDate);
        }

        /// <summary>
        /// Wandelt das Datum <paramref name="julianDate"/> in ein julianisches Datum um. 
        /// </summary>
        /// <param name="julianDate">Julianisches Datum als Long-Wert</param>
        public static implicit operator JulianDate(long julianDate)
        {
            return new JulianDate(julianDate);
        }

        /// <summary>
        /// Wandelt das Datum <paramref name="gregorianCalender"/> in ein julianisches Datum um. 
        /// </summary>
        /// <param name="gregorianCalender">Gregorianischer Kalender</param>
        public static implicit operator JulianDate(DateTime gregorianCalender)
        {
            return ConvertDateTime.FromGregorianCalenderToJulianDate(gregorianCalender);
        }

        /// <summary>
        /// Vergleicht zwei Instanzen von <see cref="JulianDate"/> und gibt an, ob eine Instanz gleich der anderen ist.
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static bool operator ==(JulianDate t1, JulianDate t2) => t1.CompareTo(t2) == 0;

        /// <summary>
        /// Vergleicht zwei Instanzen von <see cref="JulianDate"/> und gibt an, ob eine Instanz ungleich der anderen ist.
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static bool operator !=(JulianDate t1, JulianDate t2) => t1.CompareTo(t2) != 0;

        /// <summary>
        /// Vergleicht zwei Instanzen von <see cref="JulianDate"/> und gibt an, ob eine Instanz kleiner als die andere ist.
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static bool operator <(JulianDate t1, JulianDate t2) => t1.CompareTo(t2) < 0;

        /// <summary>
        /// Vergleicht zwei Instanzen von <see cref="JulianDate"/> und gibt an, ob eine Instanz kleiner oder gleich der anderen ist.
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static bool operator <=(JulianDate t1, JulianDate t2) => t1.CompareTo(t2) <= 0;

        /// <summary>
        /// Vergleicht zwei Instanzen von <see cref="JulianDate"/> und gibt an, ob eine Instanz größer als die andere ist.
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static bool operator >(JulianDate t1, JulianDate t2) => t1.CompareTo(t2) > 0;

        /// <summary>
        /// Vergleicht zwei Instanzen von <see cref="JulianDate"/> und gibt an, ob eine Instanz kleiner als die andere ist.
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static bool operator >=(JulianDate t1, JulianDate t2) => t1.CompareTo(t2) >= 0;

        /// <summary>
        /// Versucht, den Wert des angegebenen <see cref="string"/> in ein <see cref="JulianDate"/> umzuwandeln.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryParse(string s, out JulianDate result)
        {
            if (s == null)
            {
                result = default;

                return false;
            }

            try
            {
                if (double.TryParse(s, out double julianDateNumeric))
                {
                    result = new JulianDate(julianDateNumeric);

                    return true;
                }
                else
                {
                    result = default;

                    return false;
                }
            }
            catch
            {
                result = default;

                return false;
            }
        }
    }
}

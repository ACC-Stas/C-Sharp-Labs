using System;
using System.Text.RegularExpressions;

namespace Lab_7 {
    class Fraction : IFormattable, IComparable<Fraction>, ICloneable, IConvertible {
        private long numerator;
        public long Numerator {
            get {
                return numerator;
            }
            set {
                numerator = value;
                if(denominator != 0 && numerator != 0) {
                    long gcd = GCD(Math.Abs(denominator), numerator);
                    denominator /= gcd;
                    numerator /= gcd;
                }
            }
        }
        private long denominator;
        public long Denominator {
            get {
                return denominator;
            }
            set {
                if(denominator == 0) {
                    throw new ArgumentException("Denominator can't be zero\n");
                }
                denominator = value;
                if (numerator != 0) {
                    long gcd = GCD(Math.Abs(denominator), numerator);
                    denominator /= gcd;
                    numerator /= gcd;
                }
            }
        }
        public Fraction(long numerator, long denominator) {
            this.numerator = numerator;
            this.denominator = denominator;
            Numerator = this.numerator;
            Denominator = this.denominator;
        }
        public Fraction(long numerator) {
            denominator = 1;
            Numerator = numerator;
            Denominator = 1;
        }
        public Fraction(double fraction) {
            Fraction f = Parse(fraction.ToString());
            denominator = f.denominator;
            Numerator = f.Numerator;
            Denominator = f.Denominator;
        }
        /// <summary>
        /// Greatest common divisor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static long GCD(long a, long b) {
            if (a > b) {
                (a, b) = (b, a);
            }
            while (b != 0) {
                a %= b;
                (a, b) = (b, a);
            }
            return a;
        }
        public override string ToString() {
            return ToString("F");
        }
        public string ToString(string format) {
            return ToString(format, null);
        }
        public string ToString(string format, IFormatProvider provider) {
            if (string.IsNullOrEmpty(format)) {
                format = "F";
            }
            if (format == "IF") {
                if (Math.Abs(numerator) > denominator && denominator != 1) {
                    long integral = numerator / denominator;
                    return $"{integral}({Math.Abs(numerator) % denominator}/{denominator})";
                }
                else {
                    format = "I";
                }
            }
            if (format == "I") {
                if (Math.Abs(numerator) > denominator) {
                    long integral = numerator / denominator;
                    return integral.ToString();
                }
                else {
                    format = "F";
                }
            }
            if (format == "F") {
                return $"{numerator}/{denominator}";
            }
            else if (format == "D") {
                return GetDoubleValue().ToString();
            }
            else if (new Regex(@"D\d*").IsMatch(format)) {
                return GetDoubleValue().ToString("F" + format.Substring(1));
            }
            else {
                throw new FormatException($"The \"{format}\" format is not supported.");
            }
        }
        double GetDoubleValue() {
            return (double)numerator / denominator;
        }
        public static Fraction Parse(string s) {
            if (TryParse(s, out Fraction fraction)) {
                return fraction;
            }
            else {
                throw new FormatException("Input string was not in a correct format.");
            }
        }
        public static bool TryParse(string s, out Fraction fraction) {
            fraction = null;
            Regex pattern1 = new Regex(@"^(-?\d+)/(\d+)$");
            Regex pattern2 = new Regex(@"^(-?\d+)$");
            Regex pattern3 = new Regex(@"^(-?\d+)\((\d+)/(\d+)\)$"); ;
            Regex pattern4 = new Regex(@"^(-?\d+)[,|\.](\d+)$");
            if (pattern1.IsMatch(s)) {
                Match match = pattern1.Match(s);
                fraction = new Fraction(long.Parse(match.Groups[1].Value),
                                        long.Parse(match.Groups[2].Value));
                return true;
            }
            if (pattern2.IsMatch(s)) {
                Match match = pattern2.Match(s);
                fraction = new Fraction(long.Parse(match.Groups[1].Value));
                return true;
            }
            if (pattern3.IsMatch(s)) {
                Match match = pattern3.Match(s);
                long integral = long.Parse(match.Groups[1].Value);
                int sign = integral > 0 ? 1 : -1;
                long numerator = long.Parse(match.Groups[2].Value);
                long denominator = long.Parse(match.Groups[3].Value);
                fraction = new Fraction((Math.Abs(integral) * denominator + numerator) * sign,
                                        denominator);
                return true;
            }
            if (pattern4.IsMatch(s)) {
                Match match = pattern4.Match(s);
                long integral = long.Parse(match.Groups[1].Value);
                int sign = integral > 0 ? 1 : -1;
                string floating = match.Groups[2].Value;
                long denominator = BinPow(10, floating.Length);
                fraction = new Fraction((Math.Abs(integral) * denominator + long.Parse(floating))
                                        * sign,
                                        denominator);
                return true;
            }
            return false;
        }
        private static long BinPow(long a, long n) {
            if (n == 0)
                return 1;
            if (n % 2 == 1)
                return a * BinPow(a, n - 1);

            long b = BinPow(a, n / 2);
            return b * b;
        }
        public int CompareTo(Fraction fraction) {
                long lcm = denominator * fraction.Denominator /
                           GCD(Math.Abs(denominator), fraction.Denominator);

                long n1 = numerator * (lcm / denominator);
                long n2 = fraction.Numerator * (lcm / fraction.Denominator);
                if (n1 > n2)
                    return 1;
                else if (n1 < n2)
                    return -1;
                return 0;
            }
        public object Clone() {
            return new Fraction(numerator, denominator);
        }
        public override bool Equals(object obj) {
            return obj is Fraction fraction &&
                   CompareTo(fraction) == 0;
        }
        public override int GetHashCode() {
            int hashCode = -671859081;
            hashCode = hashCode * -1521134295 + numerator.GetHashCode();
            hashCode = hashCode * -1521134295 + denominator.GetHashCode();
            return hashCode;
        }
        public static explicit operator int(Fraction f) {
            return f.ToInt32(null);
        }
        public static explicit operator long(Fraction f) {
            return f.ToInt64(null);
        }
        public static explicit operator float(Fraction f) {
            return f.ToSingle(null);
        }
        public static explicit operator double(Fraction f) {
            return f.ToDouble(null);
        }
        public static explicit operator decimal(Fraction f) {
            return f.ToDecimal(null);
        }
        public TypeCode GetTypeCode() {
            return TypeCode.Object;
        }
        public bool ToBoolean(IFormatProvider provider) {
            return Numerator != 0;
        }
        public char ToChar(IFormatProvider provider) {
            return Convert.ToChar(GetDoubleValue(), provider);
        }
        public sbyte ToSByte(IFormatProvider provider) {
            return Convert.ToSByte(GetDoubleValue(), provider);
        }
        public byte ToByte(IFormatProvider provider) {
            return Convert.ToByte(GetDoubleValue(), provider);
        }
        public short ToInt16(IFormatProvider provider) {
            return Convert.ToInt16(GetDoubleValue(), provider);
        }
        public ushort ToUInt16(IFormatProvider provider) {
            return Convert.ToUInt16(GetDoubleValue(), provider);
        }
        public int ToInt32(IFormatProvider provider) {
            return Convert.ToInt32(GetDoubleValue(), provider);
        }
        public uint ToUInt32(IFormatProvider provider) {
            return Convert.ToUInt32(GetDoubleValue(), provider);
        }
        public long ToInt64(IFormatProvider provider) {
            return Convert.ToInt64(GetDoubleValue(), provider);
        }
        public ulong ToUInt64(IFormatProvider provider) {
            return Convert.ToUInt64(GetDoubleValue(), provider);
        }
        public float ToSingle(IFormatProvider provider) {
            return Convert.ToSingle(GetDoubleValue(), provider);
        }
        public double ToDouble(IFormatProvider provider) {
            return GetDoubleValue();
        }
        public decimal ToDecimal(IFormatProvider provider) {
            return Convert.ToDecimal(GetDoubleValue(), provider);
        }
        public DateTime ToDateTime(IFormatProvider provider) {
            return Convert.ToDateTime(GetDoubleValue(), provider);
        }
        public string ToString(IFormatProvider provider) {
            return ToString("F", provider);
        }
        public object ToType(Type conversionType, IFormatProvider provider) {
            return Convert.ChangeType(GetDoubleValue(), conversionType);
        }
        public static bool operator >(Fraction a, Fraction b) {
            return a.CompareTo(b) == 1;
        }
        public static bool operator <(Fraction a, Fraction b) {
            return a.CompareTo(b) == -1;
        }
        public static bool operator >=(Fraction a, Fraction b) {
            return a.CompareTo(b) != -1;
        }
        public static bool operator <=(Fraction a, Fraction b) {
            return a.CompareTo(b) != 1;
        }
        public static bool operator ==(Fraction a, Fraction b) {
            return a.CompareTo(b) == 0;
        }
        public static bool operator !=(Fraction a, Fraction b) {
            return a.CompareTo(b) != 0;
        }
        public static Fraction operator +(Fraction a, Fraction b) {
            long lcm = a.Denominator * b.Denominator /
                      GCD(Math.Abs(a.Denominator), Math.Abs(b.Denominator));

            long n1 = a.Numerator * (lcm / a.Denominator);
            long n2 = b.Numerator * (lcm / b.Denominator);
            return new Fraction(n1 + n2, lcm);
        }
        public static Fraction operator -(Fraction a) {
            return a * -1;
        }
        public static Fraction operator -(Fraction a, Fraction b) {
            return a + (-b);
        }
        public static Fraction operator *(Fraction a, Fraction b) {
            return new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }
        public static Fraction operator *(Fraction a, long b) {
            return new Fraction(a.Numerator * b, a.Denominator);
        }
        public static Fraction operator /(Fraction a, Fraction b) {
            return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }
    }
}

// SPDX-License-Identifier: MPL-2.0
namespace Emik.Numerics.Fractions;
#pragma warning disable CS1591, SA1600
/// <summary>Represents a fractional value.</summary>
[StructLayout(LayoutKind.Sequential)]
public readonly struct Fraction :
    IConvertible,
    IComparable,
    IComparable<Fraction>,
    IEquatable<Fraction>,
    IEqualityComparer<Fraction>,
    IFormattable
{
    readonly long _numerator;

    [ValueRange(1, long.MaxValue)]
    readonly long _denominator;

    /// <summary>Initializes a new instance of the <see cref="Fraction"/> struct.</summary>
    /// <param name="numerator">The numerator of this value.</param>
    /// <param name="denominator">The denominator of this value. Cannot be zero.</param>
    /// <exception cref="DivideByZeroException">The parameter <paramref name="denominator"/> is 0.</exception>
    public Fraction(long numerator, long denominator = 1)
    {
        if (denominator is 0)
            throw new DivideByZeroException();

        Simplify(ref numerator, ref denominator);
        _numerator = numerator;
        _denominator = denominator;
    }

    /// <summary>Gets the value representing the maximum possible value.</summary>
    public static Fraction MaxValue
    {
        [Pure] get => long.MaxValue;
    }

    /// <summary>Gets the value representing the minimum possible value.</summary>
    public static Fraction MinValue
    {
        [Pure] get => long.MinValue;
    }

    /// <summary>Gets the value representing negative one.</summary>
    public static Fraction NegativeOne
    {
        [Pure] get => -1;
    }

    /// <summary>Gets the value representing one.</summary>
    public static Fraction One
    {
        [Pure] get => 1;
    }

    /// <summary>Gets the value representing zero.</summary>
    public static Fraction Zero
    {
        [Pure] get => 0;
    }

    /// <summary>Gets the radix of this type.</summary>
    public static int Radix
    {
        [Pure, ValueRange(2)] get => 2;
    }

    /// <summary>Gets the denominator.</summary>
    public long Denominator
    {
        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
        [Pure, ValueRange(1, long.MaxValue)] get => _denominator is 0 ? 1 : _denominator;
    }

    /// <summary>Gets the numerator.</summary>
    // ReSharper disable once ConvertToAutoProperty
#pragma warning disable RCS1085
    public long Numerator
    {
        [Pure] get => _numerator;
    }
#pragma warning restore RCS1085

    [Pure]
    public static bool operator ==(Fraction left, Fraction right) =>
        left.Numerator == right.Numerator && left.Denominator == right.Denominator;

    [Pure]
    public static bool operator !=(Fraction left, Fraction right) => !(left == right);

    // While division is slower, check first to make overflows less likely.
    [Pure]
    public static bool operator <(Fraction left, Fraction right) =>
        left.Numerator / left.Denominator < right.Numerator / right.Denominator ||
        left.Numerator * right.Denominator < right.Numerator * left.Denominator;

    [Pure]
    public static bool operator >(Fraction left, Fraction right) => right < left;

    [Pure]
    public static bool operator <=(Fraction left, Fraction right) => left == right || left < right;

    [Pure]
    public static bool operator >=(Fraction left, Fraction right) => right <= left;

    [Pure]
    public static Fraction operator +(Fraction value) => value;

    [Pure]
    public static Fraction operator -(Fraction value) => new(-value.Numerator, value.Denominator);

    [Pure]
    public static Fraction operator !(Fraction value) => new(value.Denominator, value.Numerator);

    [Pure]
    public static Fraction operator ++(Fraction value) => value + 1;

    [Pure]
    public static Fraction operator --(Fraction value) => value - 1;

    [Pure]
    public static Fraction operator +(Fraction left, Fraction right) =>
        new(
            left.Numerator * right.Denominator + right.Numerator * left.Denominator,
            left.Denominator * right.Denominator
        );

    [Pure]
    public static Fraction operator -(Fraction left, Fraction right) => left + -right;

    [Pure]
    public static Fraction operator *(Fraction left, Fraction right) =>
        new(left.Numerator * right.Numerator, left.Denominator * right.Denominator);

    [Pure]
    public static Fraction operator /(Fraction left, Fraction right) => left * !right;

    [Pure]
    public static Fraction operator %(Fraction left, Fraction right) =>
        right.Denominator is 1
            ? new(left.Numerator % right.Numerator, left.Denominator)
            : new(
                left.Numerator * right.Denominator % (right.Numerator * left.Denominator),
                left.Denominator * right.Denominator
            );

    [Pure]
    public static Fraction operator <<(Fraction value, int shiftAmount) => value * (1L << shiftAmount);

    [Pure]
    public static Fraction operator >> (Fraction value, int shiftAmount) => value / (1L << shiftAmount);

    [Pure]
    public static Fraction operator >>> (Fraction value, int shiftAmount) =>
        new(value.Numerator >>> shiftAmount, value.Denominator);

    [Pure]
    public static Fraction operator &(Fraction left, Fraction right) =>
        new(left.Numerator & right.Numerator, left.Denominator & right.Denominator);

    [Pure]
    public static Fraction operator |(Fraction left, Fraction right) =>
        new(left.Numerator | right.Numerator, left.Denominator | right.Denominator);

    [Pure]
    public static Fraction operator ^(Fraction left, Fraction right) =>
        new(left.Numerator ^ right.Numerator, left.Denominator ^ right.Denominator);

    [Pure]
    public static implicit operator Fraction(bool value) => value ? 1 : 0;

    [Pure]
    public static implicit operator Fraction(byte value) => new(value);

    [Pure]
    public static implicit operator Fraction(char value) => new(value);

    [Pure]
    public static implicit operator Fraction(int value) => new(value);

    [Pure]
    public static implicit operator Fraction(long value) => new(value);

    [Pure]
    public static implicit operator Fraction(short value) => new(value);

    [CLSCompliant(false), Pure]
    public static implicit operator Fraction(sbyte value) => new(value);

    [CLSCompliant(false), Pure]
    public static implicit operator Fraction(ushort value) => new(value);

    [CLSCompliant(false), Pure]
    public static implicit operator Fraction(uint value) => new(value);

    [CLSCompliant(false), Pure]
    public static explicit operator Fraction(ulong value) => new(unchecked((long)value));

    [CLSCompliant(false), Pure]
    public static explicit operator bool(Fraction value) => value.Numerator >= 0;

    [Pure]
    public static explicit operator byte(Fraction value) => unchecked((byte)(value.Numerator / value.Denominator));

    [Pure]
    public static explicit operator char(Fraction value) =>
        unchecked((char)(ushort)(value.Numerator / value.Denominator));

    [Pure]
    public static explicit operator int(Fraction value) => unchecked((int)(value.Numerator / value.Denominator));

    [Pure]
    public static explicit operator long(Fraction value) => value.Numerator / value.Denominator;

    [Pure]
    public static explicit operator short(Fraction value) => unchecked((short)(value.Numerator / value.Denominator));

    [CLSCompliant(false), Pure]
    public static explicit operator sbyte(Fraction value) => unchecked((sbyte)(value.Numerator / value.Denominator));

    [CLSCompliant(false), Pure]
    public static explicit operator ushort(Fraction value) => unchecked((ushort)(value.Numerator / value.Denominator));

    [CLSCompliant(false), Pure]
    public static explicit operator uint(Fraction value) => unchecked((uint)(value.Numerator / value.Denominator));

    [CLSCompliant(false), Pure]
    public static explicit operator ulong(Fraction value) => unchecked((ulong)(value.Numerator / value.Denominator));

    [Pure]
    public static explicit operator float(Fraction value) => (float)value.Numerator / value.Denominator;

    [Pure]
    public static explicit operator double(Fraction value) => (double)value.Numerator / value.Denominator;

    [Pure]
    public static explicit operator decimal(Fraction value) => (decimal)value.Numerator / value.Denominator;

    [Pure]
    public static explicit operator string(Fraction value) => value.ToString(CultureInfo.InvariantCulture);

    /// <summary>Determines whether the value is even.</summary>
    /// <param name="value">The value to check.</param>
    /// <returns><see langword="true"/> if even, <see langword="false"/>.</returns>
    [Pure]
    public static bool IsEvenInteger(Fraction value) => value.Numerator % 2 is 0;

    /// <summary>Determines whether the value is negative.</summary>
    /// <param name="value">The value to check.</param>
    /// <returns><see langword="true"/> if negative, <see langword="false"/>.</returns>
    [Pure]
    public static bool IsNegative(Fraction value) => !(bool)value;

    /// <summary>Determines whether the value is odd.</summary>
    /// <param name="value">The value to check.</param>
    /// <returns><see langword="true"/> if odd, <see langword="false"/>.</returns>
    [Pure]
    public static bool IsOddInteger(Fraction value) => value.Numerator % 2 is 1;

    /// <summary>Determines whether the value is positive.</summary>
    /// <param name="value">The value to check.</param>
    /// <returns><see langword="true"/> if positive, <see langword="false"/>.</returns>
    [Pure]
    public static bool IsPositive(Fraction value) => (bool)value;

    /// <summary>Determines whether the value is a power of two.</summary>
    /// <param name="value">The value to check.</param>
    /// <returns><see langword="true"/> if a power of two; otherwise, <see langword="false"/>.</returns>
    [Pure]
    public static bool IsPow2(Fraction value) => (value.Numerator & value.Numerator - 1) is 0;

    /// <summary>Determines whether the value is zero.</summary>
    /// <param name="value">The value to check.</param>
    /// <returns><see langword="true"/> if zero; otherwise, <see langword="false"/>.</returns>
    [Pure]
    public static bool IsZero(Fraction value) => value.Numerator is 0;

    /// <inheritdoc cref="long.TryParse(string, NumberStyles, IFormatProvider, out long)"/>
    [Pure]
    public static bool TryParse(string? s, IFormatProvider? provider, out Fraction result) =>
        TryParse(s, NumberStyles.Integer, provider, out result);

    /// <inheritdoc cref="long.TryParse(string, NumberStyles, IFormatProvider, out long)"/>
    [Pure]
    public static bool TryParse(string? s, NumberStyles style, IFormatProvider? provider, out Fraction result)
    {
        result = default;

        if (s is null)
            return false;

        var slash = -1;

        for (var i = 0; i < s.Length; i++)
            if (s[i] is '/' && slash is var temp && ((slash = i) == s.Length - 1 || temp is not -1))
                return false;

        // ReSharper disable ReplaceSubstringWithRangeIndexer
#pragma warning disable CA1846, IDE0057
        if (slash is not -1)
            return long.TryParse(s.Substring(0, slash), style, provider, out var num1) &&
                long.TryParse(s.Substring(slash + 1, s.Length - (slash + 1)), style, provider, out var num2) &&
                num2 is not 0 &&
                (result = new(num1, num2)) is var _;
#pragma warning restore CA1846, IDE0057

        var ret = long.TryParse(s, style, provider, out var num);

        if (ret)
            result = num;

        return ret;
    }

    /// <inheritdoc cref="Math.Abs(int)"/>
    [Pure]
    public static Fraction Abs(Fraction value) => IsPositive(value) ? value : -value;

    /// <inheritdoc cref="Math.Max(int, int)"/>
    [Pure]
    public static Fraction Min(Fraction x, Fraction y) => x < y ? x : y;

    /// <inheritdoc cref="Math.Max(int, int)"/>
    [Pure]
    public static Fraction Max(Fraction x, Fraction y) => x > y ? x : y;

    /// <inheritdoc cref="long.Parse(string, IFormatProvider)"/>
    [Pure]
    public static Fraction Parse(string s, IFormatProvider? provider) => Parse(s, NumberStyles.Integer, provider);

    /// <inheritdoc cref="long.Parse(string, NumberStyles, IFormatProvider)"/>
    [Pure]
    public static Fraction Parse(string s, NumberStyles style, IFormatProvider? provider) =>
        TryParse(s, style, provider, out var result) ? result : throw new FormatException();

    /// <inheritdoc/>
    [Pure]
    public override bool Equals([NotNullWhen(true)] object? obj) => obj is Fraction f && Equals(f);

    /// <summary>Deconstructs the instance with its components.</summary>
    /// <param name="numerator">The numerator of this value.</param>
    /// <param name="denominator">The denominator of this value. Will not be zero.</param>
    public void Deconstruct(out long numerator, out long denominator)
    {
        numerator = Numerator;
        denominator = Denominator;
    }

    /// <inheritdoc/>
    [Pure]
    public bool Equals(Fraction other) => this == other;

    /// <inheritdoc/>
    [Pure]
    public bool Equals(Fraction x, Fraction y) => x == y;

    /// <inheritdoc/>
    [Pure]
    public int GetHashCode(Fraction obj) => obj.GetHashCode();

    /// <inheritdoc/>
    [Pure]
    public int CompareTo([NotNull] object? obj) =>
        obj is Fraction f ? CompareTo(f) : throw new ArgumentException("Value is not a fraction.", nameof(obj));

    /// <inheritdoc/>
    [Pure]
    public int CompareTo(Fraction other) =>
        Denominator.CompareTo(other.Denominator) is var comparison && comparison is 0
            ? Numerator.CompareTo(other.Numerator)
            : comparison;

    /// <inheritdoc />
    [Pure]
    public override int GetHashCode() => unchecked((int)(~Numerator ^ Denominator));

    /// <inheritdoc />
    [Pure]
    public override string ToString() => Denominator is 1 ? $"{Numerator}" : $"{Numerator}/{Denominator}";

    /// <inheritdoc />
    [Pure]
    public string ToString(string? format, IFormatProvider? formatProvider) => ToString();

    /// <inheritdoc/>
    [Pure]
    public bool ToBoolean(IFormatProvider? provider) => (bool)this;

    /// <inheritdoc/>
    [Pure]
    public byte ToByte(IFormatProvider? provider) => (byte)this;

    /// <inheritdoc/>
    [Pure]
    public char ToChar(IFormatProvider? provider) => (char)this;

    /// <inheritdoc/>
    [Pure]
    public decimal ToDecimal(IFormatProvider? provider) => (decimal)this;

    /// <inheritdoc/>
    [Pure]
    public double ToDouble(IFormatProvider? provider) => (double)this;

    /// <inheritdoc/>
    [Pure]
    public short ToInt16(IFormatProvider? provider) => (short)this;

    /// <inheritdoc/>
    [Pure]
    public int ToInt32(IFormatProvider? provider) => (int)this;

    /// <inheritdoc/>
    [Pure]
    public long ToInt64(IFormatProvider? provider) => (long)this;

    /// <inheritdoc/>
    [CLSCompliant(false), Pure]
    public sbyte ToSByte(IFormatProvider? provider) => (sbyte)this;

    /// <inheritdoc/>
    [Pure]
    public float ToSingle(IFormatProvider? provider) => (float)this;

    /// <inheritdoc/>
    [Pure]
    public string ToString(IFormatProvider? provider) => (string)this;

    /// <inheritdoc/>
    [Pure]
    public object ToType(Type conversionType, IFormatProvider? provider) =>
        ((IConvertible)ToDouble(provider)).ToType(conversionType, provider);

    /// <inheritdoc/>
    [CLSCompliant(false), Pure]
    public ushort ToUInt16(IFormatProvider? provider) => (ushort)this;

    /// <inheritdoc/>
    [CLSCompliant(false), Pure]
    public uint ToUInt32(IFormatProvider? provider) => (uint)this;

    /// <inheritdoc/>
    [CLSCompliant(false), Pure]
    public ulong ToUInt64(IFormatProvider? provider) => (ulong)this;

    /// <inheritdoc/>
    [Pure]
    public DateTime ToDateTime(IFormatProvider? provider) => ((IConvertible)(long)this).ToDateTime(provider);

    /// <inheritdoc/>
    [Pure]
    public TypeCode GetTypeCode() => TypeCode.Object;

    /// <summary>Simplifies the numbers before being passed to the fraction.</summary>
    /// <param name="numerator">The numerator to simplify.</param>
    /// <param name="denominator">The denominator to simplify.</param>
    static void Simplify(ref long numerator, ref long denominator)
    {
        if (numerator is 0)
        {
            denominator = 1;
            return;
        }

        var gcd = GreatestCommonDenominator(numerator, denominator);
        numerator /= gcd;
        denominator /= gcd;

        if (denominator >= 0)
            return;

        numerator *= -1;
        denominator *= -1;
    }

    /// <summary>Gets the greatest common denominator between two numbers.</summary>
    /// <param name="left">The left-hand side.</param>
    /// <param name="right">The right-hand side.</param>
    /// <returns>
    /// The greatest common denominator of the parameters <paramref name="left"/> and <paramref name="right"/>.
    /// </returns>
    [NonNegativeValue, Pure]
    static long GreatestCommonDenominator(long left, long right)
    {
        left = Math.Abs(left);
        right = Math.Abs(right);

        do
        {
            if (left < right)
            {
                // ReSharper disable once SwapViaDeconstruction
#pragma warning disable IDE0180
                var tmp = left;
                left = right;
                right = tmp;
#pragma warning restore IDE0180
            }

            left %= right;
        } while (left is not 0);

        return right;
    }
}

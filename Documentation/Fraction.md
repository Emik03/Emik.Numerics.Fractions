### [Emik.Numerics.Fractions](Emik.Numerics.Fractions.md 'Emik.Numerics.Fractions')

## Fraction Struct

Represents a fractional value.

```csharp
public readonly struct Fraction :
System.IConvertible,
System.IComparable,
System.IComparable<Emik.Numerics.Fractions.Fraction>,
System.IEquatable<Emik.Numerics.Fractions.Fraction>,
System.Collections.Generic.IEqualityComparer<Emik.Numerics.Fractions.Fraction>,
System.IFormattable
```

Implements [System.IConvertible](https://docs.microsoft.com/en-us/dotnet/api/System.IConvertible 'System.IConvertible'), [System.IComparable](https://docs.microsoft.com/en-us/dotnet/api/System.IComparable 'System.IComparable'), [System.IComparable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IComparable-1 'System.IComparable`1')[Fraction](Fraction.md 'Emik.Numerics.Fractions.Fraction')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IComparable-1 'System.IComparable`1'), [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[Fraction](Fraction.md 'Emik.Numerics.Fractions.Fraction')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1'), [System.Collections.Generic.IEqualityComparer&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1')[Fraction](Fraction.md 'Emik.Numerics.Fractions.Fraction')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1'), [System.IFormattable](https://docs.microsoft.com/en-us/dotnet/api/System.IFormattable 'System.IFormattable')

| Constructors | |
| :--- | :--- |
| [Fraction(long, long)](Fraction..ctor(long,long).md 'Emik.Numerics.Fractions.Fraction.Fraction(long, long)') | Initializes a new instance of the [Fraction](Fraction.md 'Emik.Numerics.Fractions.Fraction') struct. |

| Properties | |
| :--- | :--- |
| [Denominator](Fraction.Denominator.md 'Emik.Numerics.Fractions.Fraction.Denominator') | Gets the denominator. |
| [Inv](Fraction.Inv.md 'Emik.Numerics.Fractions.Fraction.Inv') | Gets the inverted value. |
| [IsEven](Fraction.IsEven.md 'Emik.Numerics.Fractions.Fraction.IsEven') | Gets a value indicating whether the value is even. |
| [IsMaxValue](Fraction.IsMaxValue.md 'Emik.Numerics.Fractions.Fraction.IsMaxValue') | Gets a value indicating whether the value is the maximum possible value. |
| [IsMinValue](Fraction.IsMinValue.md 'Emik.Numerics.Fractions.Fraction.IsMinValue') | Gets a value indicating whether the value is the minimum possible value. |
| [IsNegative](Fraction.IsNegative.md 'Emik.Numerics.Fractions.Fraction.IsNegative') | Gets a value indicating whether the value is negative. |
| [IsNegativeOne](Fraction.IsNegativeOne.md 'Emik.Numerics.Fractions.Fraction.IsNegativeOne') | Gets a value indicating whether the value is negative one. |
| [IsOdd](Fraction.IsOdd.md 'Emik.Numerics.Fractions.Fraction.IsOdd') | Gets a value indicating whether the value is odd. |
| [IsOne](Fraction.IsOne.md 'Emik.Numerics.Fractions.Fraction.IsOne') | Gets a value indicating whether the value is one. |
| [IsPositive](Fraction.IsPositive.md 'Emik.Numerics.Fractions.Fraction.IsPositive') | Gets a value indicating whether the value is positive. |
| [IsPow2](Fraction.IsPow2.md 'Emik.Numerics.Fractions.Fraction.IsPow2') | Gets a value indicating whether the value is a power of two. |
| [IsZero](Fraction.IsZero.md 'Emik.Numerics.Fractions.Fraction.IsZero') | Gets a value indicating whether the value is zero. |
| [MaxValue](Fraction.MaxValue.md 'Emik.Numerics.Fractions.Fraction.MaxValue') | Gets the value representing the maximum possible value. |
| [MinValue](Fraction.MinValue.md 'Emik.Numerics.Fractions.Fraction.MinValue') | Gets the value representing the minimum possible value. |
| [NegativeOne](Fraction.NegativeOne.md 'Emik.Numerics.Fractions.Fraction.NegativeOne') | Gets the value representing negative one. |
| [Numerator](Fraction.Numerator.md 'Emik.Numerics.Fractions.Fraction.Numerator') | Gets the numerator. |
| [One](Fraction.One.md 'Emik.Numerics.Fractions.Fraction.One') | Gets the value representing one. |
| [Zero](Fraction.Zero.md 'Emik.Numerics.Fractions.Fraction.Zero') | Gets the value representing zero. |

| Methods | |
| :--- | :--- |
| [Deconstruct(long, long)](Fraction.Deconstruct(long&,long&).md 'Emik.Numerics.Fractions.Fraction.Deconstruct(long, long)') | Deconstructs the instance with its components. |

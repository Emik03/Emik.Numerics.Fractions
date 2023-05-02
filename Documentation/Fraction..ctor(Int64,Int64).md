### [Emik.Numerics.Fractions](Emik.Numerics.Fractions.md 'Emik.Numerics.Fractions').[Fraction](Fraction.md 'Emik.Numerics.Fractions.Fraction')

## Fraction(long, long) Constructor

Initializes a new instance of the [Fraction](Fraction.md 'Emik.Numerics.Fractions.Fraction') struct.

```csharp
public Fraction(long numerator, long denominator=1L);
```
#### Parameters

<a name='Emik.Numerics.Fractions.Fraction.Fraction(long,long).numerator'></a>

`numerator` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

The numerator of this value.

<a name='Emik.Numerics.Fractions.Fraction.Fraction(long,long).denominator'></a>

`denominator` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

The denominator of this value. Cannot be zero.

#### Exceptions

[System.DivideByZeroException](https://docs.microsoft.com/en-us/dotnet/api/System.DivideByZeroException 'System.DivideByZeroException')  
The parameter [denominator](Fraction..ctor(Int64,Int64).md#Emik.Numerics.Fractions.Fraction.Fraction(long,long).denominator 'Emik.Numerics.Fractions.Fraction.Fraction(long, long).denominator') is 0.
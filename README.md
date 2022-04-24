# JOGUnit
A library that makes working with units and quantities a piece of cake.

## Usage

### Creating quantities
```csharp
var weight = Mass.FromKilograms(80);
var duration = Time.FromMinutes(15);
var distance = Length.FromMicrometers(1E-06);
```

### Conversion
```csharp
var distance = Length.FromKilometers(1);
Console.WriteLine(distance.Kilometers);  // 1
Console.WriteLine(distance.Meters);      // 1000
Console.WriteLine(distance.Yards);       // 1093.61
Console.WriteLine(distance.Inches);      // 39370.08
```

### Arithmetic & Equality
```csharp
var a = Time.FromMinutes(1);
var b = Time.FromSeconds(30);
var c = a - b;
Assert.AreEqual(30, c.Seconds);   // TRUE
Assert.AreEqual(0.5, c.Minutes);  // TRUE
```

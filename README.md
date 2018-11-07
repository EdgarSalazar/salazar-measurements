## About

This lib can be used to convert between values on the same measurement unit, like distance, weight, etc.

Works with convertions between values from/to these units: Milli, Centi, Deci, Default, Deca, Hecto and Kilo. All these values are available on the `Measurements` enum.

[Available on Nuget](https://www.nuget.org/packages/Salazar.Measurements)

## Usage
```c#
using Salazar.Measurements;

decimal grams = 1000;

var measure = new Measure(grams);

var milliGrams = measure.Milli; // Will be 1000000.
var centiGrams = measure.Centi; // Will be 100000.
var deciGrams = measure.Deci; // Will be 10000.

var default = measure.Default;  // Will be 1000.

var decaGrams = measure.Deca;  // Will be 100.
var hectoGrams = measure.Hecto;  // Will be 10.
var kiloGrams = measure.Kilo;  // Will be 1.
```
    
You can also input different units into the `Measure` constructor, using the `Measurements` enum. Default value is `Measurements.Default`.

Let's say you have 10 Kilograms, and want to get the ammount of Milligrams. All you have to do is start the `Measure` with 10 and the Kilo enum value:

    decimal kilos = 10;
    
    var measure = new Measure(kilos, Measurements.Kilo);
    
    var milliGrams = measure.Milli; // Will be 10000000.
    
Actually, the lib will only convert between values in the same unit, like distance to distance (meter is default), weight to weight (grams is default), etc.

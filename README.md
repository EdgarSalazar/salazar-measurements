# About

This lib can be used to convert between units. All the available units are on the `Measurements` enum.

# Usage

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
    
You can also input different values into the `Measure` constructor, definint it's unit using the `Measurements` enum.

Let's say you have 10 Kilograms, and want to get the ammount of Milligrams. All you have to do is start the `Measure` with 10 and the Kilo enum value:

    decimal kilos = 10;
    
    var measure = new Measure(kilos, Measurements.Kilo);
    
    var milliGrams = measure.Milli; // Will be 1000000.
    
The `Measure` class should work conversions between the same unit, like distance (meter), weight (grams), etc.


1. The electronic color code (http://en.wikipedia.org/wiki/Electronic_color_code) is used to indicate the values or ratings of electronic components, very commonly for resistors. Write a class that implements the following interface. Feel free to include any supporting types as necessary.

 

public interface IOhmValueCalculator

{

   /// <summary>

   /// Calculates the Ohm value of a resistor based on the band colors.

   /// </summary>

   /// <param name="bandAColor">The color of the first figure of component value band.</param>

   /// <param name="bandBColor">The color of the second significant figure band.</param>

   /// <param name="bandCColor">The color of the decimal multiplier band.</param>

   /// <param name="bandDColor">The color of the tolerance value band.</param>

   int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor);

}

 

2. Using your favorite unit test framework, write the unit tests you feel are necessary to adequately test the code you wrote as your answer to question one.

 

3. Create a .NET MVC or Reactjs web interface that will allow someone to use the calculator you created in step one.

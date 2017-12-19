using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalcuateResistance.Helpers
{
    public class Resistor : IOhmValueCalculator
    {
        public List<ColorCoding> colors = new List<ColorCoding>();
        public Resistor()
        {
            

            // Add parts to the list.
            colors.Add(new ColorCoding() { name = "Pink", figure= null, multiplier = 0.001, percent = null });
            colors.Add(new ColorCoding() { name = "Silver", figure = null, multiplier = 0.01, percent = "10" });
            colors.Add(new ColorCoding() { name = "Gold", figure = null, multiplier = 0.1, percent = "5" });
            colors.Add(new ColorCoding() { name = "Black", figure = "0", multiplier = 1, percent = null });
            colors.Add(new ColorCoding() { name = "Brown", figure = "1", multiplier = 10, percent = "1" });
            colors.Add(new ColorCoding() { name = "Red", figure = "2", multiplier = 100, percent = "2" });
            colors.Add(new ColorCoding() { name = "Orange", figure = "3", multiplier = 1000, percent = null });
            colors.Add(new ColorCoding() { name = "Yellow", figure = "4", multiplier = 10000, percent = "5" });
            colors.Add(new ColorCoding() { name = "Green", figure = "5", multiplier = 100000, percent = "0.5" });
            colors.Add(new ColorCoding() { name = "Blue", figure = "6", multiplier = 1000000, percent = "0.25" });
            colors.Add(new ColorCoding() { name = "Violet", figure = "7", multiplier = 10000000, percent = "0.1" });
            colors.Add(new ColorCoding() { name = "Gray", figure = "8", multiplier = 100000000, percent = "0.05" });
            colors.Add(new ColorCoding() { name = "White", figure = "9", multiplier = 1000000000, percent = null });
        }
        int IOhmValueCalculator.CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            string resistance="0";
            int result;
            int low=0;
            int high=0;
            var A = colors.FirstOrDefault(coding => coding.name == bandAColor);
            var B = colors.FirstOrDefault(coding => coding.name == bandBColor);
            var C = colors.FirstOrDefault(coding => coding.name == bandCColor);
            var D = colors.FirstOrDefault(coding => coding.name == bandDColor);
            if (A.figure != null) resistance = A.figure;
            if (B.figure != null) resistance = resistance + B.figure;
            result = (int)(Int32.Parse(resistance) * C.multiplier);
            if (D.percent != null)
            {
                low = result - (result * (Int32.Parse(D.percent))/100);
                high = result + (result * (Int32.Parse(D.percent))/100);
            }
            return high;
        }
    }
}

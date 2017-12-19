using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalcuateResistance.Helpers
{
    public interface IOhmValueCalculator
    {
        int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor);
    }
}

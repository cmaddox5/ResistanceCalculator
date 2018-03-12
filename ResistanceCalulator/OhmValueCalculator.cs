using System;
using System.Collections.Generic;
using System.Linq;

namespace ResistanceCalculator
{
    public class OhmValueCalculator : IOhmValueCalculator
    {
        private readonly BandColor _bandColor = new BandColor();
        public List<BandColor> BandColors { get; set; }

        public OhmValueCalculator()
        {
            BandColors = _bandColor.GetBandColors();
        }

        /// <summary> 
        /// Calculates the Ohm value of a resistor based on the band colors. 
        /// </summary> 
        /// <param name="bandAColor">The color of the first figure of component value band.</param> 
        /// <param name="bandBColor">The color of the second significant figure band.</param> 
        /// <param name="bandCColor">The color of the decimal multiplier band.</param> 
        /// <param name="bandDColor">The color of the tolerance value band.</param> 
        public int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            int result;

            //Match the colors with their corresponding BandColor
            BandColor bandA = BandColors.Single(bca => bandAColor.ToUpper().Equals(bca.Color));
            BandColor bandB = BandColors.Single(bcb => bandBColor.ToUpper().Equals(bcb.Color));

            //Combine first two SigFigures digits into one int
            result = Convert.ToInt32($"{bandA.SigFigures}{bandB.SigFigures}");

            return result;
        }

        /// <summary> 
        /// Formats the Ohm Value as a string to allow for numbers larger than int.MaxValue to be displayed
        /// </summary>
        /// <param name="sigFigs">The sigFigs formatted as first two digits SigFigs, third digit Multiplier.</param> 
        /// <param name="multiplier">The multiplier digit.</param> 
        /// <param name="tolerance">The tolerance.</param> 
        public string GetOhmValueString(int sigFigs, int multiplier, double tolerance)
        {
            string result;

            //Format SigFigs x 10^Multiplier to allow for numbers larger than int.MaxValue to be displayed
            result = $"{sigFigs * Math.Pow(10, multiplier)} ohms ± {tolerance}%";

            return result;
        }

        /// <summary> 
        /// Gets the multiplier for the third band color
        /// </summary>
        /// <param name="bandColor">The third band color used to calculate the multiplier.</param> 
        public int GetMultiplierValue(string bandColor)
        {
            int result;

            //Match color with its corresponding BandColor
            BandColor multiplierBand = BandColors.Single(bc => bandColor.ToUpper().Equals(bc.Color));
            result = multiplierBand.Multiplier;

            return result;
        }

        /// <summary> 
        /// Gets the tolerance for the fourth band color
        /// </summary>
        /// <param name="bandColor">The fourth band color used to calculate the tolerance.</param> 
        public double GetToleranceValue(string bandColor)
        {
            double result;

            //Match color with its corresponding BandColor
            BandColor toleranceBand = BandColors.Single(bc => bandColor.ToUpper().Equals(bc.Color));
            result = toleranceBand.Tolerance;

            return result;
        }
    }
}

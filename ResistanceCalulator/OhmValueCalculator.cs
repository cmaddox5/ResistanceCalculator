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
            BandColor bandC = BandColors.Single(bcc => bandCColor.ToUpper().Equals(bcc.Color));

            //Combine first two SigFigures and multiplier digit
            result = Convert.ToInt32($"{bandA.SigFigures}{bandB.SigFigures}{bandC.Multiplier}");

            return result;
        }

        /// <summary> 
        /// Formats the Ohm Value as a string to allow for Scientific Notation formatting for large numbers
        /// </summary>
        /// <param name="ohmValue">The ohmValue formatted as first two digits SigFigs, third digit Multiplier.</param> 
        /// <param name="bandD">The fourth band color used to calculate the tolerance.</param> 
        public string GetOhmValueString(int ohmValue, string bandD)
        {
            string result;
            string ohmValueString = ohmValue.ToString();
            //parse out ohmValue into SigFigs and Multiplier digit
            int sigFigs = Convert.ToInt32($"{ohmValueString[0]}{ohmValueString[1]}");
            int multiplier = Convert.ToInt32(ohmValueString[2].ToString());
            double tolerance = GetToleranceValue(bandD);

            //Format SigFigs x 10^Multiplier to allow for Scientific Notation format for numbers larger than int.MaxValue
            result = $"{sigFigs * Math.Pow(10, multiplier)} ohms ± {tolerance}%";

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

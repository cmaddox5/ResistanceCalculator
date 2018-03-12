using System.Collections.Generic;

namespace ResistanceCalculator
{
    public class BandColor
    {
        public string Color { get; set; }
        public int SigFigures { get; set; }
        public int Multiplier { get; set; }
        public double Tolerance { get; set; }

        public BandColor()
        {

        }

        public BandColor(string color, int sigFigures, int multiplier, double tolerance)
        {
            Color = color;
            SigFigures = sigFigures;
            Multiplier = multiplier;
            Tolerance = tolerance;
        }

        public List<BandColor> GetBandColors()
        {
            List<BandColor> result = new List<BandColor>
            {
                new BandColor("NONE", -99, -99, 20),
                new BandColor("PINK", -99, -3, 0),
                new BandColor("SILVER", -99, -2, 10),
                new BandColor("GOLD", -99, -1, 5),
                new BandColor("BLACK", 0, 0, 0),
                new BandColor("BROWN", 1, 1, 1),
                new BandColor("RED", 2, 2, 2),
                new BandColor("ORANGE", 3, 3, 0),
                new BandColor("YELLOW", 4, 4, 5),
                new BandColor("GREEN", 5, 5, 0.5),
                new BandColor("BLUE", 6, 6, 0.25),
                new BandColor("VIOLET", 7, 7, 0.1),
                new BandColor("GRAY", 8, 8, 0.05),
                new BandColor("WHITE", 9, 9, 0)
            };

            return result;
        }
    }
}

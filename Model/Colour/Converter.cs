using System;
using System.Drawing;

namespace Model.Colour
{
    /// <summary>
    /// Описывает конвертацию цвета
    /// </summary>
    public class Converter
    {
        /// <summary>
        /// Конвертация из argb в hex
        /// </summary>
        /// <param name="argb"></param>
        /// <returns></returns>
        public static string ToHEX(ColorArgb argb)
        {
            //Старый способ преобразования цвета из argb в hex
             string hex = "#";

            string convert = Convert.ToString(argb.A, 16);
            hex += (convert.Length != 2) ? ("0" + convert) : (convert);

            convert = Convert.ToString(argb.R, 16);
            hex += (convert.Length != 2) ? ("0" + convert) : (convert);

            convert = Convert.ToString(argb.G, 16);
            hex += (convert.Length != 2) ? ("0" + convert) : (convert);

            convert = Convert.ToString(argb.B, 16);
            hex += (convert.Length != 2) ? ("0" + convert) : (convert);
            
            //return ColorTranslator.ToHtml(argb);
            return hex;
        }
        /// <summary>
        /// Конвертация цвета из hex в argb
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static ColorArgb ToColorARGB(string hex)
        {
            Color colorHex= ColorTranslator.FromHtml(hex);
            //      colorHex= ColorTranslator.FromHtml(hex);
            return new ColorArgb
                {
                    A=colorHex.A,
                    B =colorHex.B,
                    G =colorHex.G,
                    R =colorHex.R
                };

        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pl_autocad_2015.ViewModel.ParametersValidationRule
{ 
    /// <summary>
    /// Класс для проверки введенных параметров выбора цвета
    /// </summary>
    public class ColorPickerRule : ValidationRule
    {
        /// <summary>
        /// В принципе можно не реализовывать эти свойства, а сразу проверять 
        /// является значение типом byte или нет, так как для наших целей мы ограничили уже значение типом
        /// когда преобразуем значение в byte
        /// </summary>

        private byte _min=byte.MinValue;
        private byte _max=byte.MaxValue;

        /// <summary>
        /// Минимальное значение
        /// </summary>
        public byte Min { get { return _min; } set { _min = value; } }
        /// <summary>
        /// Максимальное значение
        /// </summary>
        public byte Max { get { return _max; } set { _max = value; } }

        /// <summary>
        /// Проверяем параметры, в случае ошибки выводим текст иначе возращаем допустимый экзмепляр
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            byte parametr;
            try
            {
                parametr = byte.Parse(value as string);
                return ValidationResult.ValidResult;
            }
            catch
            {
                return new ValidationResult(false,"Недопустимые символы или значение");
            }       
        }
    }
}

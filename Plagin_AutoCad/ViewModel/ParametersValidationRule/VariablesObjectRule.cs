using System;
using System.Globalization;
using System.Windows.Controls;

namespace Plagin_AutoCad.ViewModel.ParametersValidationRule
{

    /// <summary>
    /// Класс для проверки введенных параметров выбора цвета
    /// </summary>
    public class VariablesObjectRule: ValidationRule
    {
        
        private double _min = double.MinValue;
        private double _max = double.MaxValue;
        private int _e = 14;

        /// <summary>
        /// Минимальное значение
        /// </summary>
        public double Min { get { return _min; } set { _min = value; } }
        /// <summary>
        /// Максимальное значение
        /// </summary>
        public double Max { get { return _max; } set { _max = value; } }

        /// <summary>
        /// Эпсила количество знаков после запятой
        /// </summary>
        public int E { get { return _e; } set { _e = value; } }

        /// <summary>
        /// Проверяем параметры, в случае ошибки выводим текст иначе возращаем допустимый экзмепляр
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double parametr;
            try
            {
                parametr = Convert.ToDouble(value as string);
                if ((parametr>Min)&&(parametr<Max))
                {
                    if (E < eps(value as string)) 
                    {
                        return new ValidationResult(false, "Диапозон точности привышен");
                    }
                    return ValidationResult.ValidResult;
                }
                return new ValidationResult(false, "Недопустипое значение");
            }
            catch
            {
                return new ValidationResult(false, "Недопустипое значение");
            }
        }

        private int eps(string value)
        {
            int result=0;
            if (value.IndexOf('.') > 0)
            {
                if (value.IndexOf('E') > 0)
                {
                    result = value.IndexOf('E') - value.IndexOf('.') -1;
                }
                else
                {
                    result = value.Length - value.IndexOf('.') -1;
                }
            }
            if (value.IndexOf("E-") > 0)
            {
                int index1 = value.IndexOf("E-") + 2;
                string k = value.Substring(index1, value.Length - index1);
                result += Convert.ToInt32(k);
            }
            if (value.IndexOf("E+") > 0)
            {
                int index1 = value.IndexOf("E+") + 2;
                string k = value.Substring(index1, value.Length - index1);
                result -= Convert.ToInt32(k);
            }
            
            return result;
        }

    }
}

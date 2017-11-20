using System.Windows.Input;
using Model.Colour;

namespace Plagin_AutoCad.ViewModel
{
    public class ColorPickerViewModel:ViewModelBase
    {
        #region variables
        private ColorArgb _colorArgb;
        private string _colorHex;
        private string _selectedColor;
        #endregion

        public ColorPickerViewModel()
        {
            ClickCommandSelectedColor = new Command(arg =>
            {
                SelectedColor = ColorHex;
            });

            ClickCommandNotSelectedColor = new Command(arg =>
            {
                SelectedColor = null;
            });
        }

        /// <summary>
        /// Получение цвета в argb формате
        /// </summary>
        public ColorArgb ColorArgb
        {
            get
            {
                if (_colorArgb != null)
                {
                    ColorHex = Converter.ToHEX(_colorArgb);
                }                
                return _colorArgb;
            }
            set
            {
                _colorArgb = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Получение цвета в hex формате
        /// </summary>
        public string ColorHex
        {
            get
            {
                return _colorHex;
            }
            set
            {
                
                if ((value != _colorHex)&&(value!=null))
                {
                    _colorHex = value;
                    ColorArgb = Converter.ToColorARGB(value);
                }
                OnPropertyChanged(); 
            }
        }

        public string SelectedColor
        {
            get { return _selectedColor; }
            set { _selectedColor = value; OnPropertyChanged(); }
        }

        public ICommand ClickCommandSelectedColor { get; set; }
        public ICommand ClickCommandNotSelectedColor { get; set; }

    }
}
 
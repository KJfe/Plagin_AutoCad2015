using System.ComponentModel;
using System.Windows.Input;

namespace Plagin_AutoCad.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
        #region variables
        private ShowLayersViewModel _showLayers;
        private ColorPickerViewModel _colorPicker;
        private string _visibleColorPicker;
        #endregion

        public MainViewModel()
        {
            ColorPicker = new ColorPickerViewModel();
            ShowLayers = new ShowLayersViewModel();

            VisibleColorPicker = "Collapsed";
            //string selectLayer=null;
            ClickCommandVisibleInColorPickerUC =new Command(arg =>
            {

                ShowLayers.PropertyChanged += OnShowLayersPropertyChanged;
                ColorPicker.PropertyChanged += OnColorPickerPropertyChanged;
                VisibleColorPicker = "Visible";
                ColorPicker.ColorHex = ShowLayers.SelectedLayer.ColorLayer;

                //VisibleColorPicker = (VisibleColorPicker == "Collapsed") ? "Visible" : "Collapsed";
                
                //для обработки если выбрана другая строка
                /* 
                if (VisibleColorPicker == "Collapsed")
                {
                    VisibleColorPicker = "Visible";
                    ColorPicker.ColorHex = ShowLayers.SelectedLayer.ColorLayer;
                    selectLayer = ShowLayers.SelectedLayer.NameLayer;
                }
                else if (selectLayer != ShowLayers.SelectedLayer.NameLayer)
                {
                    ColorPicker.ColorHex = ShowLayers.SelectedLayer.ColorLayer;
                    selectLayer = ShowLayers.SelectedLayer.NameLayer;
                }
                else
                {
                    VisibleColorPicker = "Collapsed";
                    selectLayer = null;
                }*/
            });
        }

        /// <summary>
        /// Обработчик события на изменение свойств в ShowLayers 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnShowLayersPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ShowLayersViewModel.SelectedLayer))
            {
                ColorPicker.ColorHex = ShowLayers.SelectedLayer.ColorLayer;
            }
        }
        /// <summary>
        /// Обработчик события на изменение свойств в ColorPicker 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnColorPickerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ColorPickerViewModel.SelectedColor))
            {
                if (ColorPicker.SelectedColor != null)
                {
                    ShowLayers.SelectedLayer.ColorLayer = ColorPicker.SelectedColor;
                }
                ShowLayers.PropertyChanged -= OnShowLayersPropertyChanged;
                ColorPicker.PropertyChanged -= OnColorPickerPropertyChanged;
                VisibleColorPicker = "Collapsed";
            }
        }
        /// <summary>
        /// Инииализаия передачи экзмепляра класса ViewModel'и отображения параметров слоя
        /// </summary>
        public ShowLayersViewModel ShowLayers
        {
            get { return _showLayers; }
            set { _showLayers = value;  OnPropertyChanged();}
        }
        /// <summary>
        /// Инииализаия передачи экзмепляра класса ViewModel'и выбора цвета
        /// </summary>
        public ColorPickerViewModel ColorPicker
        {
            get { return _colorPicker; }
            set { _colorPicker = value; OnPropertyChanged(); }
        }
        /// <summary>
        /// Инициализация видимости слоя
        /// </summary>
        public string VisibleColorPicker
        {
            get { return _visibleColorPicker; }
            set { _visibleColorPicker = value; OnPropertyChanged(); }
        }
        /// <summary>
        /// Инициализаия нажатия кнопки для изменения цвета слоя
        /// </summary>
        public ICommand ClickCommandVisibleInColorPickerUC { get; set; }
    }
}

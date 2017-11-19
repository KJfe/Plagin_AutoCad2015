using System.Windows.Input;

namespace Plagin_AutoCad.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
        
        private ShowLayersViewModel _showLayers;
        private ColorPickerViewModel _colorPicker;
        private string _visibleColorPicker;
        
        public MainViewModel()
        {
            ColorPicker = new ColorPickerViewModel();
            ShowLayers = new ShowLayersViewModel();
           
            VisibleColorPicker = "Collapsed";

            ClickCommandVisibleInColorPickerUC=new Command(arg =>
            {
                VisibleColorPicker = (VisibleColorPicker == "Collapsed") ? "Visible" : "Collapsed";
                //ShowLayers.SelectedLayer;
            });
        }
        
        public ShowLayersViewModel ShowLayers
        {
            get { return _showLayers; }
            set { _showLayers = value;  OnPropertyChanged();}
        }

        public ColorPickerViewModel ColorPicker
        {
            get { return _colorPicker; }
            set { _colorPicker = value; OnPropertyChanged(); }
        }

        public string VisibleColorPicker
        {
            get { return _visibleColorPicker; }
            set { _visibleColorPicker = value; OnPropertyChanged(); }
        }

        public ICommand ClickCommandVisibleInColorPickerUC { get; set; }
    }
}

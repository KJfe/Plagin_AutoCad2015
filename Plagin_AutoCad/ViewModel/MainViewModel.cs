using System.ComponentModel;
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
            string selectLayer=null;
            ClickCommandVisibleInColorPickerUC =new Command(arg =>
            {
                /*
                //VisibleColorPicker = (VisibleColorPicker == "Collapsed") ? "Visible" : "Collapsed";
                VisibleColorPicker = (selectLayer != ShowLayers.SelectedLayer.NameLayer) ? "Visible" : "Collapsed";
                selectLayer = ShowLayers.SelectedLayer.ColorLayer;

                ColorPicker.ColorHex = ShowLayers.SelectedLayer.ColorLayer;
                if (VisibleColorPicker == "Collapsed")
                {
                    selectLayer = null;
                }*/

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
                }
                

            });

            ClickCommandСhange = new Command(arg =>
            {

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


        public ICommand ClickCommandСhange { get; set; }

    }
}

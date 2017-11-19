using System.Collections.ObjectModel;
using System.Windows.Input;
using Model.Layer;

namespace Plagin_AutoCad.ViewModel
{
    public class ShowLayersViewModel:ViewModelBase
    {
        #region variables

        private ObservableCollection<Layer> _layersCollection;
        private Layer _selectedLayer;
        private bool _isEnabledColorPicker;
        private string _visibilityColorPicker;

        #endregion

        public ShowLayersViewModel()
        {
            //экзмепляр объекта свойств слоев 
            LayerProperties layerProperties = new LayerProperties();
            //получаем коллекицю слоев
            _layersCollection = layerProperties.ReadLayer();

            //Обработчик нажатия кнопки на добавления нового слоя
            ClickCommandAddLayer = new Command(arg => { _layersCollection.Add(layerProperties.AddLayer()); });
            //Обработчик нажатия кнопки на удаление выбранного слоя
            ClickCommandDeleterLayer = new Command(arg =>
            {
                if (_selectedLayer.DeleteLayer(SelectedLayer.NameLayer))
                {
                    _layersCollection.Remove(_selectedLayer);
                } //иначе exeption 
            });
        }

        /// <summary>
        /// Свойство коллекции экзмепляров слоев
        /// </summary>
        public ObservableCollection<Layer> LayersCollection
        {
            get { return _layersCollection; }
            set { _layersCollection = value; }
        }

        /// <summary>
        /// Свойство выбранного экземпляра
        /// </summary>
        public Layer SelectedLayer
        {
            get { return _selectedLayer; }
            set { _selectedLayer = value; OnPropertyChanged(); }
        }
        
        /// <summary>
        /// Свойсто добавления слоя
        /// </summary>
        public ICommand ClickCommandAddLayer { get; set; }
        /// <summary>
        /// Свойство удаления слоя
        /// </summary>
        public ICommand ClickCommandDeleterLayer { get; set; }
    }
}

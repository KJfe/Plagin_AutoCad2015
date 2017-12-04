using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Autodesk.AutoCAD.DatabaseServices;
using Model.Objects;

namespace Model.Layer
{
    /// <summary>
    /// Класс свойст с параметрами слоя
    /// </summary>
    public class Layer:LayerProperties
    {

        #region PropertyChangedEventHandler
        /// <summary>
        /// Метод проверяющий изменилось ли свойство
        /// </summary>
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        private string _nameLayer;
        /// <summary>
        /// свойство Имени слоя
        /// </summary>
        public string NameLayer
        {
            get { return _nameLayer; }
            set
            {
                if((value!=null)&&(!CheckLayersName(value))&&(_nameLayer!="0"))
                {
                    RenameLayer(_nameLayer, value);
                    //LayerProcedure("Rename",this);
                    _nameLayer = value;
                }
                if (_nameLayer == null)
                {
                    _nameLayer = value;
                }
                // иначае вывести exeption который еще не реализован
            }
        }

        private bool _showLayer;
        /// <summary>
        /// Свойство видимости слоя
        /// </summary>
        public bool ShowLayer
        {
            get { return _showLayer; }
            set
            {
                ChangeLayerVisibility(_nameLayer,value);
                _showLayer = value;
            }
        }

        private string _colorLayer;
        /// <summary>
        /// Свойство цвета слоя
        /// </summary>
        public string ColorLayer
        {
            get { return _colorLayer; }
            set
            {
                ChangeLayerColor(_nameLayer, value);
                _colorLayer = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<IObject> _opjectsCollection;

        public ObservableCollection<IObject> ObjectsCollection
        {
            get { return _opjectsCollection; }
            set { _opjectsCollection = value; OnPropertyChanged(); }
        }

    }
}

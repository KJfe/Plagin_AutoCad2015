using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;

namespace Model.Layer
{
    /// <summary>
    /// Класс свойст с параметрами слоя
    /// </summary>
    public class Layer:LayerProperties
    {
        private ObjectId _objectId;
        public ObjectId ObjectId
        {
            get { return _objectId; }
            set { _objectId = value; }
        }

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
                _colorLayer = value;
            }
        }
        
    }
}

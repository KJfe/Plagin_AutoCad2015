using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Layer
{
    /// <summary>
    /// выбор взаимодействия со слоем
    /// </summary>
    public class ChoiceOfInteractionWithLayer
    {
        /// <summary>
        /// Делегат 
        /// </summary>
        private Dictionary<string, Func<Layer, Layer>> _choice;

        public ChoiceOfInteractionWithLayer()
        {
            _choice = new Dictionary<string, Func<Layer, Layer>>
            {
                {"AddLayer",this.AddLayer },
                {"DeliterLayer",this.DeleteLayer },
                {"Rename", this.RenameLayer},
                {"ChangeLayerVisibility",this.ChangeLayerVisibility },
                {"ChangeLayerColor",this.ChangeLayerColor },
            };
        }
        /// <summary>
        /// Обработка команды
        /// </summary>
        /// <param name="nameOperation"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        public Layer ProcessingCommand(string nameOperation, Layer layer)
        {
            if (!_choice.ContainsKey(nameOperation))
                throw new ArgumentException(string.Format("Operation {0} is invalid", nameOperation), "nameOperation");
            return _choice[nameOperation](layer);
        }

        public Layer RenameLayer(Layer layer)
        {

            return layer;
        }

        public Layer ChangeLayerVisibility(Layer layer)
        {

            return layer;
        }

        public Layer ChangeLayerColor(Layer layer)
        {

            return layer;
        }

        public Layer AddLayer(Layer layer)
        {

            return layer;
        }

        public Layer DeleteLayer(Layer layer)
        {

            return layer;
        }

        
    }
}

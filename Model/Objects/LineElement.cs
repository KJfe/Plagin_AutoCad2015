using System;

namespace Model.Objects
{
    public class LineElement:IObject
    {
        private PointElement _startPosition;
        private PointElement _endPosition;

        public LineElement(PointElement startPosition, PointElement endPosition)
        {
            _startPosition = startPosition;
            _endPosition = endPosition;
        }
        /// <summary>
        /// Реализация отображения наименование типа объекта
        /// </summary>
        public string NameObject { get; set; }

    }
}

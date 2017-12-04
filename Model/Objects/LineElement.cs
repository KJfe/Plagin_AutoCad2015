using System;

namespace Model.Objects
{
    public class LineElement:IObject
    {
        private PointElement _startPosition;
        private PointElement _endPosition;

        public LineElement(PointElement startPosition, PointElement endPosition)
        {
            StartPosition = startPosition;
            EndPosition = endPosition;
        }

        public PointElement StartPosition
        {
            get { return _startPosition; }
            set { _startPosition = value; }
        }

        public PointElement EndPosition
        {
            get { return _endPosition; }
            set { _endPosition = value; }
        }
        /// <summary>
        /// Реализация отображения наименование типа объекта
        /// </summary>
        public string NameObject { get; set; }

    }
}

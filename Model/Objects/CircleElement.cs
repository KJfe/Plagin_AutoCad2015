namespace Model.Objects
{
    public class CircleElement:IObject
    {
        private PointElement _point;
        private double _radius;

        public CircleElement(PointElement center, double radius)
        {
            _point = center;
            _radius = radius;
        }
        /// <summary>
        /// Реализация отображения наименование типа объекта
        /// </summary>
        public string NameObject { get; set; }

        
    }
}

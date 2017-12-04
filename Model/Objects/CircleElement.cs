namespace Model.Objects
{
    public class CircleElement:IObject
    {
        private PointElement _point;
        private double _radius;

        public CircleElement(PointElement center, double radius)
        {
            Point = center;
            Radius = radius;
        }
        /// <summary>
        /// Радиус
        /// </summary>
        public double Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }
        /// <summary>
        /// Координаты точки центра
        /// </summary>
        public PointElement Point
        {
            get { return _point; }
            set { _point = value; }
        }
        /// <summary>
        /// Реализация отображения наименование типа объекта
        /// </summary>
        public string NameObject { get; set; }

        
    }
}

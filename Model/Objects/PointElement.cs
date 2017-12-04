using System;
using Autodesk.AutoCAD.Geometry;

namespace Model.Objects
{
    public class PointElement:IObject
    {
        private Point3d _point3d;
        public PointElement(Point3d point3d)
        {
            Point = point3d;
            X = point3d.X;
            Y = point3d.Y;
            Z = point3d.Z;
        }

        public PointElement(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public Point3d Point
        {
            get { return _point3d; }
            set { _point3d = value; }
        }
        /// <summary>
        /// Реализация отображения наименование типа объекта
        /// </summary>
        public string NameObject { get; set; }

    }
}

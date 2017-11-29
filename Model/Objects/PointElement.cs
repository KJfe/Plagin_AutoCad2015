using System;
using Autodesk.AutoCAD.Geometry;

namespace Model.Objects
{
    public class PointElement:IObject
    {
        private Point3d _point3d;
        public PointElement(Point3d point3d)
        {
            _point3d = point3d;
        }
        /// <summary>
        /// Реализация отображения наименование типа объекта
        /// </summary>
        public string NameObject { get; set; }

    }
}

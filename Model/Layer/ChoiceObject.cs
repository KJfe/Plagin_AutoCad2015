using System;
using System.Collections.Generic;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Model.Objects;

namespace Model.Layer
{
    public class ChoiceObject
    {
        /// <summary>
        /// Делегат 
        /// </summary>
        private Dictionary<string, Func<IObject, Entity, IObject>> _choice;

        public ChoiceObject()
        {
            _choice = new Dictionary<string, Func<IObject, Entity, IObject>>
            {
                {"Circle", this.Circle },
                {"Line", this.Line },
                {"DBPoint", this.DBPoint }
            };
        }

        /// <summary>
        /// Обработка команды
        /// </summary>
        /// <param name="nameOperator"></param>
        /// <param name="obj"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public IObject ProcessingCommand(string nameOperator, Entity entity, IObject obj)
        {
            if (!_choice.ContainsKey(nameOperator))
                throw new ArgumentException(string.Format("Operation {0} is invalid", nameOperator));
            return _choice[nameOperator](obj,entity);
        }
        /// <summary>
        /// Добавление оперции для работы с новой фигурой
        /// </summary>
        /// <param name="nameOperator"></param>
        /// <param name="body"></param>
        public void DefineOperation(string nameOperator, Func<IObject, Entity, IObject> body)
        {
            if (_choice.ContainsKey(nameOperator))
                throw new ArgumentException(string.Format("Operation {0} already exists", nameOperator));
            _choice.Add(nameOperator, body);
        }
        /// <summary>
        /// Реализция параметров для круга
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        private IObject Circle( IObject obj, Entity entity)
        {
            var circle = entity as Circle;
            IObject objCircle=new CircleElement(new PointElement(circle.Center), circle.Radius);
            objCircle = AddParametrs(objCircle, entity);            
            return objCircle;
        }
        /// <summary>
        /// Реализция параметров для линии
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        private IObject Line(IObject obj, Entity entity)
        {
            var line = entity as Line;
            IObject objLine = new LineElement(new PointElement(line.StartPoint), new PointElement(line.EndPoint));
            objLine = AddParametrs(objLine, entity);
            return objLine;
        }
        /// <summary>
        /// Реализция параметров для точки
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        private IObject DBPoint(IObject obj, Entity entity)
        {
            var point = entity as DBPoint;
            IObject objPoint = new PointElement(point.Position);
            objPoint = AddParametrs(objPoint, entity);
            return objPoint;
        }
        /// <summary>
        /// Добавление параметров в объект
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        private IObject AddParametrs(IObject obj, Entity entity)
        {
           // obj.NameLayer = entity.Layer;
            obj.NameObject = entity.GetType().Name;
            return obj;
        }

    }
}

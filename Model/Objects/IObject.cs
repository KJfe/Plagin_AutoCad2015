using System;

namespace Model.Objects
{
    /// <summary>
    /// Интерфес объектов слоя
    /// </summary>
    public interface IObject
    {
        /// <summary>
        /// Отображает наименование типа объекта
        /// </summary>
        string NameObject { get; set; }

    }
}

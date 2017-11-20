using System.Collections.ObjectModel;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Model.Colour;
using autoDSK = Autodesk.AutoCAD.ApplicationServices.Application;
using Color = Autodesk.AutoCAD.Colors.Color;

namespace Model.Layer
{
    public class LayerProperties
    {

        /// <summary>
        /// Генерация наименования слоя 
        /// </summary>
        /// <param name="acLyrTbl"></param>
        /// <returns></returns>
        private string NewLayerName(LayerTable acLyrTbl)
        {
            int index = 1;
            string nameLayer="Слой"+index.ToString();
            
            while (acLyrTbl.Has(nameLayer))
            {
                index++;
                nameLayer = "Слой" + index.ToString();
            }
            return nameLayer;
        }
        /// <summary>
        /// Проверка принадлежности имени к какому либо слою
        /// </summary>
        /// <param name="nameLayer"></param>
        /// <param name="layerTable"></param>
        /// <returns></returns>
        public bool CheckLayersName(string nameLayer, LayerTable layerTable)
        {
            return layerTable.Has(nameLayer);
        }
        /// <summary>
        /// Проверка принадлежности имени к какому либо слою
        /// </summary>
        /// <param name="nameLayer"></param>
        /// <returns></returns>
        public bool CheckLayersName(string nameLayer)
        {
            bool hasLayer;
            Document acDoc = autoDSK.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;

            // блокируем документ
            using (DocumentLock docloc = acDoc.LockDocument())
            {
                // начинаем транзакцию
                using (Transaction tr = acCurDb.TransactionManager.StartTransaction())
                {
                    // открываем таблицу слоев документа
                    LayerTable acLyrTbl = (LayerTable)tr.GetObject(acCurDb.LayerTableId, OpenMode.ForRead);
                    hasLayer = acLyrTbl.Has(nameLayer);
                }
            }
            return hasLayer;
        }

        /// <summary>
        /// Добавить новый слой
        /// </summary>
        /// <returns></returns>
        public Layer AddLayer()
        {
            Layer layer=new Layer();
            Color colorWhite = Color.FromRgb(255, 255, 255);
            //получаем текущий документ и его БД
            Document acDoc = autoDSK.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;

            // блокируем документ
            using (DocumentLock docloc = acDoc.LockDocument())
            {
                // начинаем транзакцию
                using (Transaction tr = acCurDb.TransactionManager.StartTransaction())
                { 
                    // открываем таблицу слоев документа
                    LayerTable acLyrTbl = (LayerTable)tr.GetObject(acCurDb.LayerTableId, OpenMode.ForWrite);

                    // создаем новый слой и задаем ему имя
                    LayerTableRecord acLyrTblRec = new LayerTableRecord();
                    
                    acLyrTblRec.Name = NewLayerName(acLyrTbl);
                    acLyrTblRec.IsOff = false;
                    acLyrTblRec.Color=colorWhite;

                    // заносим созданный слой в таблицу слоев 
                    acLyrTbl.Add(acLyrTblRec);

                    // добавляем созданный слой в документ
                    tr.AddNewlyCreatedDBObject(acLyrTblRec, true);

                    //Передаемзначения 
                    layer.NameLayer = acLyrTblRec.Name;
                    layer.ShowLayer = acLyrTblRec.IsOff;
                    layer.ColorLayer = "#" + acLyrTblRec.Color.ColorValue.Name;

                    // фиксируем транзакцию
                    tr.Commit();
                }
            }
            return layer;
        }
        /// <summary>
        /// Удалить слой
        /// </summary>
        public bool DeleteLayer(string nameLayer)
        {
            bool status = false;
            //Получение тек. документа и БД
            Document acDoc = autoDSK.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;

            // блокируем документ
            using (DocumentLock docloc = acDoc.LockDocument())
            {
                // начинаем транзакцию
                using (Transaction tr = acCurDb.TransactionManager.StartTransaction())
                {
                    // открываем таблицу слоев документа
                    LayerTable acLyrTbl = (LayerTable)tr.GetObject(acCurDb.LayerTableId, OpenMode.ForWrite);
                    if (CheckLayersName(nameLayer))
                    {
                        LayerTableRecord layer = (LayerTableRecord)tr.GetObject(acLyrTbl[nameLayer], OpenMode.ForWrite);
                        layer.Erase();
                        status = true;
                    }// иначе exeption

                    tr.Commit();
                }
            }
            return status;
        }

        /// <summary>
        /// метод изменяющий Имя слоя
        /// </summary>
        /// <param name="oldNameLayer"></param>
        /// <param name="newNameLayer"></param>
        public bool RenameLayer(string oldNameLayer, string newNameLayer)
        {
            bool status = false;
            //Получение тек. документа и БД
            Document acDoc = autoDSK.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;

            // блокируем документ
            using (DocumentLock docloc = acDoc.LockDocument())
            {
                // начинаем транзакцию
                using (Transaction tr = acCurDb.TransactionManager.StartTransaction())
                {
                    // открываем таблицу слоев документа
                    LayerTable acLyrTbl = (LayerTable)tr.GetObject(acCurDb.LayerTableId, OpenMode.ForWrite);
                    if (CheckLayersName(oldNameLayer))
                    {
                        LayerTableRecord layer = (LayerTableRecord)tr.GetObject(acLyrTbl[oldNameLayer], OpenMode.ForWrite);
                        layer.Name = newNameLayer;
                        status = true;
                    }// иначе exeption
                
                    tr.Commit();
                }
            }
            return status;
        }
        /// <summary>
        /// Метод изменения видимости слоя
        /// </summary>
        /// <param name="nameLayer"></param>
        /// <param name="showLayer"></param>
        public bool ChangeLayerVisibility(string nameLayer, bool showLayer)
        {
            bool status = false;
            //Получение тек. документа и БД
            Document acDoc = autoDSK.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;

            // блокируем документ
            using (DocumentLock docloc = acDoc.LockDocument())
            {
                // начинаем транзакцию
                using (Transaction tr = acCurDb.TransactionManager.StartTransaction())
                {
                    // открываем таблицу слоев документа
                    LayerTable acLyrTbl = (LayerTable)tr.GetObject(acCurDb.LayerTableId, OpenMode.ForWrite);
                    if (CheckLayersName(nameLayer))
                    {
                        LayerTableRecord layer = (LayerTableRecord) tr.GetObject(acLyrTbl[nameLayer], OpenMode.ForWrite);
                        layer.IsOff = showLayer;
                        status = true;
                    }
                    tr.Commit();
                }
            }
            return status;
        }
        /// <summary>
        /// Метод изменения цвеат слоя
        /// </summary>
        /// <param name="nameLayer"></param>
        /// <param name="colorLayer"></param>
        public bool ChangeLayerColor(string nameLayer, string colorLayer)
        {
            bool status = false;
            ColorArgb colorArgb = Converter.ToColorARGB(colorLayer);
            // colorArgb = Converter.ToColorARGB(colorLayer);
            Color newColorLayer = Color.FromRgb(colorArgb.R, colorArgb.G, colorArgb.B);

            //Получение тек. документа и БД
            Document acDoc = autoDSK.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;

            // блокируем документ
            using (DocumentLock docloc = acDoc.LockDocument())
            {
                // начинаем транзакцию
                using (Transaction tr = acCurDb.TransactionManager.StartTransaction())
                {
                    // открываем таблицу слоев документа
                    LayerTable acLyrTbl = (LayerTable)tr.GetObject(acCurDb.LayerTableId, OpenMode.ForWrite);

                    if (CheckLayersName(nameLayer))
                    {
                        LayerTableRecord layer = (LayerTableRecord)tr.GetObject(acLyrTbl[nameLayer], OpenMode.ForWrite);
                        layer.Color = newColorLayer;
                        status = true;
                    }
                    tr.Commit();
                }
            }
            return status;
        }

        public Layer LayerProcedure(string procedure, Layer layer)
        {
            //Получение тек. документа и БД
            Document acDoc = autoDSK.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;

            // блокируем документ
            using (DocumentLock docloc = acDoc.LockDocument())
            {
                // начинаем транзакцию
                using (Transaction tr = acCurDb.TransactionManager.StartTransaction())
                {
                    // открываем таблицу слоев документа
                    LayerTable acLyrTbl = (LayerTable)tr.GetObject(acCurDb.LayerTableId, OpenMode.ForRead);

                    ChoiceOfInteractionWithLayer choiceOfInteractionWithLayer = new ChoiceOfInteractionWithLayer();
                    return choiceOfInteractionWithLayer.ProcessingCommand(procedure,layer);

                }
            }
        }

        /// <summary>
        /// тестовый вывод строки в строку состояний
        /// </summary>
        public void Test()
        {
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            acDoc.Editor.WriteMessage("\n Kekkkkkkkkkkkkkekeke \n");
        }

        /// <summary>
        /// Получить список слоев текущего документа
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Layer> ReadLayer()
        {
            ObservableCollection<Layer> collectionLayers = new ObservableCollection<Layer>();

            //Получение тек. документа и БД
            Document acDoc= autoDSK.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;

            // блокируем документ
            using (DocumentLock docloc = acDoc.LockDocument())

            {
                // начинаем транзакцию
                using (Transaction tr = acCurDb.TransactionManager.StartTransaction())
                {
                    // открываем таблицу слоев документа
                    LayerTable acLyrTbl = (LayerTable)tr.GetObject(acCurDb.LayerTableId, OpenMode.ForRead);
                    
                    foreach (ObjectId ent in acLyrTbl)
                    {
                        
                        LayerTableRecord entLayer = (LayerTableRecord)tr.GetObject(ent, OpenMode.ForRead);

                        collectionLayers.Add(new Layer
                        {
                            ObjectId = ent,
                            NameLayer = entLayer.Name,
                            ShowLayer = entLayer.IsOff,
                            ColorLayer = "#" + entLayer.Color.ColorValue.Name
                    });
                    }
                }
            }
            return collectionLayers;
        }


    }
}

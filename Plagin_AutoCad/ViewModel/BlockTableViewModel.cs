using System.Collections.ObjectModel;
using Autodesk.AutoCAD.Geometry;
using Model.Objects;

namespace Plagin_AutoCad.ViewModel
{
    public class BlockTableViewModel:ViewModelBase
    {
        private IObject _selectedObject;
        public ObservableCollection<IObject> _objectsCollection;

        public BlockTableViewModel()
        {
         ObjectsCollection=new ObservableCollection<IObject>();  
            //ObjectsCollection = collection;
            ObjectsCollection.Add(new CircleElement(new PointElement(new Point3d(3,2,5)), 5));

        }

        public ObservableCollection<IObject> ObjectsCollection
        {
            get { return _objectsCollection; }
            set { _objectsCollection = value; OnPropertyChanged(); } 
        }

        public IObject SelectedObject
        {
            get { return _selectedObject; }
            set { _selectedObject = value;OnPropertyChanged(); }
        }
    }
}

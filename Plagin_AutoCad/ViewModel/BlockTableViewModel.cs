using System.Collections.ObjectModel;
using Model.Objects;

namespace Plagin_AutoCad.ViewModel
{
    public class BlockTableViewModel:ViewModelBase
    {
        private ObservableCollection<IObject> _objects;

        public BlockTableViewModel()
        {
            
        }

        public ObservableCollection<IObject> Objects { get { return _objects; } set { _objects = value; OnPropertyChanged();} }
    }
}

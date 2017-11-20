using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Plagin_AutoCad.ViewModel
{
    /// <summary>
    /// Основной класс представления модели для обработки изменений
    /// </summary>
    public class ViewModelBase:INotifyPropertyChanged
    {
        #region PropertyChangedEventHandler
        /// <summary>
        /// Метод проверяющий изменилось ли свойство
        /// </summary>
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

    }
}

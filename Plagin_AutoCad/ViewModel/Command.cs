using System;
using System.Windows.Input;

namespace Plagin_AutoCad.ViewModel
{
    public class Command : ICommand
    {
        /// <summary>
        /// Принимаем параметры
        /// </summary>
        /// <param name="action"></param>
        public Command(Action<object> action)
        {
            ExecuteDelegate = action;
        }
        public Predicate<object> CanExecuteDelegate { get; set; }
        public Action<object> ExecuteDelegate { get; set; }
        /// <summary>
        /// Определяет, может ли команда выполняться
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            if (CanExecuteDelegate != null)
            {
                return CanExecuteDelegate(parameter);
            }

            return true;
        }
        /// <summary>
        /// Событие вызываемое при изменение условий, указывающих, может ли команда выполниться 
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        /// <summary>
        /// Выполняем логику команды
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            if (ExecuteDelegate != null)
            {
                ExecuteDelegate(parameter);
            }
        }
    }

}

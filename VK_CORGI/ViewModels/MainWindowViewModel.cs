using System.Windows;
using System.Windows.Input;
using VK_CORGI.Infrastructure.Commands;
using VK_CORGI.ViewModels.Base;

namespace VK_CORGI.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        /// <summary>
        /// Пример свойства с реализацией INotifyPropertyChanged
        /// </summary>
        private string _Title = "VK_CORGI";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        public ICommand CloseApplicationCommand { get; }


        private bool CanCloseApplicationCommandExecute(object p) => true;
        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        public MainWindowViewModel()
        {
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
        }
    }
}

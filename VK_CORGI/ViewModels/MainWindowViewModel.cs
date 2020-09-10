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
    }
}

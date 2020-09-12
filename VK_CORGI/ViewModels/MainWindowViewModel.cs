using System.Windows;
using System.Windows.Input;
using VK_CORGI.Infrastructure.Commands;
using VK_CORGI.ViewModels.Base;

namespace VK_CORGI.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {


        private ViewModel _SelecteViewModel;

        public ViewModel SelectedViewModel
        {
            get => _SelecteViewModel;
            set => Set(ref _SelecteViewModel, value);
        }

        private string _NavigationVisibility;

        public string NavigationVisibility
        {
            get => _NavigationVisibility;
            set => Set(ref _NavigationVisibility, value);
        }




        #region Команды
        #region Навигация

        public ICommand PageSelectedCommand { get; }

        private bool CanPageSelectedCommandExecute(object p) => true;
        private void OnPageSelectedCommandExecuted(object p)
        {
            if (p.ToString() == "Home")
            {
                SelectedViewModel = new NewsViewModel();
            }
            else if (p.ToString() == "View")
            {
                SelectedViewModel = new MessagesViewModel();
            }
        }

        #endregion

        #region Скрытие меню навигации

        public ICommand NavigationVisibilityCommand { get; }

        private bool CanNavigationVisibilityCommandExecute(object p) => true;
        private void OnNavigationVisibilityCommandExecuted(object p)
        {
            if(p.ToString() == "Hidden" && NavigationVisibility != "Hidden")
            {
                NavigationVisibility = "Hidden";
            }
            else
            {
                NavigationVisibility = "Visible";
            }
        }
        #endregion

        #endregion

        public MainWindowViewModel()
        {
            PageSelectedCommand = new LambdaCommand(OnPageSelectedCommandExecuted, CanPageSelectedCommandExecute);
            NavigationVisibilityCommand = new LambdaCommand(OnNavigationVisibilityCommandExecuted, CanNavigationVisibilityCommandExecute);
        }
    }
}

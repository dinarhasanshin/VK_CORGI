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



        public ICommand PageSelectedCommand { get; }


        private bool CanPageSelectedCommandExecute(object p) => true;
        private void OnPageSelectedCommandExecuted(object p)
        {
            if (p.ToString() == "Home")
            {
                SelectedViewModel = new HomeViewModel();
            }
            else if (p.ToString() == "View")
            {
                SelectedViewModel = new ViewViewModel();
            }
/*            switch (p.ToString())
            {
                case "Home":
                    SelectedViewModel = new HomeViewModel();
                    break;
                case "View":
                    SelectedViewModel = new ViewViewModel();
                    break;
            }*/
        }

        public MainWindowViewModel()
        {
            PageSelectedCommand = new LambdaCommand(OnPageSelectedCommandExecuted, CanPageSelectedCommandExecute);
        }
    }
}

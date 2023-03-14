using Prism.Mvvm;

namespace DDD.WPF.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "DDD";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}

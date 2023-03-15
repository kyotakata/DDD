using DDD.WPF.Views;
using Prism.Ioc;
using System.Windows;

namespace DDD.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
            this.DispatcherUnhandledException
                += App_DispatcherUnhandledException;   // 処理されない例外という意味
        }

        /// <summary>
        /// アプリケーションの例外がキャッチされていない場合にここまで落ちてくる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_DispatcherUnhandledException(
            object sender, 
            System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(
                e.Exception.Message,
                "メッセージ",
                MessageBoxButton.OK, 
                MessageBoxImage.Information);
            e.Handled = true;// これを書いておけばアプリケーションは落ちずに正しく処理されたことを示す
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<WeatherLatestView>();
        }
    }
}

using CompanyEmployee.Desktop.View;
using System.Windows;

namespace CompanyEmployee.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Manager.MainFrame = MainWinFrame;
            if (string.IsNullOrEmpty(Properties.Settings.Default.AccessToken))
                MainWinFrame.Navigate(new AuthorizationPage());
            else
                MainWinFrame.Navigate(new CompanyPage());
        }
    }
}

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
            MainWinFrame.Navigate(new AuthorizationPage());
        }
    }
}

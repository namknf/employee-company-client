using Repository;
using System.Windows.Controls;

namespace CompanyEmployee.Desktop.View
{
    /// <summary>
    /// Interaction logic for CompanyPage.xaml
    /// </summary>
    public partial class CompanyPage : Page
    {
        public CompanyPage()
        {
            InitializeComponent();
        }

        private void GoBackButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AuthorizationPage());
        }

        private async void InitButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var companies = await CompanyRepository.GetCompanies(Properties.Settings.Default.AccessToken);
            CompanyGrid.ItemsSource = companies;
        }
    }
}

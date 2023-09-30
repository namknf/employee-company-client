using CompanyEmployee.Desktop.ViewModel;
using Repository;
using System.Collections.Generic;
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
            CompanyGrid.Visibility = System.Windows.Visibility.Hidden;
        }

        private void GoBackButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Properties.Settings.Default.AccessToken = "";
            Properties.Settings.Default.Save();
            Manager.MainFrame.Navigate(new AuthorizationPage());
        }

        private async void InitButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var companies = await CompanyRepository.GetCompanies(Properties.Settings.Default.AccessToken);
            var newCompanies = new List<CompanyViewModel>();
            foreach (var company in companies)
            {
                newCompanies.Add(new CompanyViewModel()
                {
                    Name = company.Name,
                    FullAddress = company.FullAddress,
                });
            }
            CompanyGrid.ItemsSource = newCompanies;
            CompanyGrid.Visibility = System.Windows.Visibility.Visible;
        }

        private void GoOnEmployeeButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EmployeePage());
        }
    }
}

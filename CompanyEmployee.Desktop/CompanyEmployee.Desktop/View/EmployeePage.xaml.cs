using CompanyEmployee.Desktop.ViewModel;
using Entities.DTO;
using Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CompanyEmployee.Desktop.View
{
    /// <summary>
    /// Interaction logic for EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        public EmployeePage()
        {
            InitializeComponent(); 
            CompanySelector.Visibility = Visibility.Hidden;
            EmployeeGrid.Visibility = Visibility.Hidden;
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.AccessToken = "";
            Properties.Settings.Default.Save();
            Manager.MainFrame.Navigate(new AuthorizationPage());
        }

        private async void InitButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Choose company!", "", MessageBoxButton.OK);
            if (result == MessageBoxResult.OK)
            {
                await InitSelector();
            }
        }

        private async Task InitSelector()
        {
            var companies = await CompanyRepository.GetCompanies(Properties.Settings.Default.AccessToken);
            CompanySelector.ItemsSource = companies;
            CompanySelector.Visibility = Visibility.Visible;
        }

        private async void CompanySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCompany = CompanySelector.SelectedItem as CompanyDto;
            if (selectedCompany != null)
            {
                var companyId = new Guid(selectedCompany.Id.ToString().Trim(new char[] { '{', '}' }));
                var employees = await EmployeeRepository.GetEmployees(Properties.Settings.Default.AccessToken, companyId);
                var newEmployees = new List<EmployeeViewModel>();
                foreach (var employee in employees)
                {
                    newEmployees.Add(new EmployeeViewModel()
                    {
                        Name = employee.Name,
                        Age = employee.Age,
                        Position = employee.Position,
                    });
                }
                EmployeeGrid.ItemsSource = newEmployees;
                EmployeeGrid.Visibility = Visibility.Visible;
            }
        }
    }
}

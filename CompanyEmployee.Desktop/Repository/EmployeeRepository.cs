using Entities.DTO;
using Newtonsoft.Json;
using static Repository.Contract.ApiRoutes;

namespace Repository
{
    public class EmployeeRepository
    {
        public static async Task<List<EmployeeDto>> GetEmployees(string token, Guid companyId)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + token);
                var uri = new Uri(Employee.GetEmployees + $"/{companyId}/employees");
                var result = await client.GetAsync(uri);
                var companyList = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<EmployeeDto>>(await result.Content.ReadAsStringAsync());
            }
        }
    }
}

using Newtonsoft.Json;
using static Repository.Contract.ApiRoutes;

namespace Repository
{
    public class CompanyRepository
    {
        public static async Task<List<Entities.Company>> GetCompanies(string token)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + token);
                var uri = new Uri(Company.GetCompanies + "?country=Russia");
                var result = await client.GetAsync(uri);
                var companyList = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Entities.Company>>(result.Content.ReadAsStringAsync().Result);
            }
        }
    }
}

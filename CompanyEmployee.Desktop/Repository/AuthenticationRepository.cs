using Entities.DTO;
using Entities.Responses;
using Newtonsoft.Json;
using System.Text;
using static Repository.Contract.ApiRoutes;

namespace Repository
{
    public class AuthenticationRepository
    {
        public static async Task<bool> RegistrationAsync(string name, string userName, string lastName, string phoneNumber, string password, string email, ICollection<string> roles)
        {
            var newUser = new UserForRegistrationDto()
            {
                FirstName = name,
                UserName = userName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Password = password,
                Email = email,
                Roles = roles
            };

            var client = new HttpClient();
            var uri = new Uri(Auth.Registration);
            var userJson = JsonConvert.SerializeObject(newUser);
            HttpContent content = new StringContent(userJson, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(uri, content);
            return result.IsSuccessStatusCode;
        }

        public static async Task<AuthResponse> AuthorizeAsync(string password, string username)
        {
            var user = new UserForAuthenticationDto()
            {
                Password = password,
                UserName = username
            };

            using (var client = new HttpClient())
            {
                var uri = new Uri(Auth.Login);
                var userJson = JsonConvert.SerializeObject(user);
                HttpContent content = new StringContent(userJson, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(uri, content);
                return JsonConvert.DeserializeObject<AuthResponse>(await result.Content.ReadAsStringAsync());
            }
        }
    }
}
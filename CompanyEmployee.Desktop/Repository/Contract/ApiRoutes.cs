namespace Repository.Contract
{
    public class ApiRoutes
    {
        private const string ApiRoute = "https://localhost:7080/api";

        public static class Auth
        {
            public static string Login = ApiRoute + "/authentication/login";
            public static string Registration = ApiRoute + "/authentication";
        }

        public static class Company
        {
            public static string GetCompanies = ApiRoute + "/companies";
        }
        public static class Employee
        {
            public static string GetEmployees = ApiRoute + "/companies";
        }
    }
}

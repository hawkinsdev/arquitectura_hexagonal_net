namespace MyApp.Domain.Services {

    public class UserDomainService{

        public static bool IsValidEmail(string email) => email.Contains('@');

        public static bool IsPasswordStrong(string password) => password.Length >= 6;        
    }
}
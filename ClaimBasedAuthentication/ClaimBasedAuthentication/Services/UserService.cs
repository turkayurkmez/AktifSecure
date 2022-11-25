using ClaimBasedAuthentication.Models;

namespace ClaimBasedAuthentication.Services
{
    public class UserService
    {

        private readonly List<User> users;
        public UserService()
        {
            users = new()
            {
                new(){ Id=1, EmailAddress="turkay.urkmez@dinamikzihin.com", Password="123456", Role="Admin", UserName="turkay"},
                new(){ Id=2, EmailAddress="erdem.ozdemir@aktifbank.com.tr", Password="123456", Role="Editor", UserName="erdem"},
                new(){ Id=3, EmailAddress="ece.derici@aktifbank.com.tr", Password="123456", Role="Standart", UserName="ece"},

            };
        }
        public User ValidateUser(string username, string password)
        {
            return users.FirstOrDefault(u => u.UserName == username && u.Password == password);
        }
    }
}

namespace ClaimBasedAuthentication.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; } //Bcrypt ile saklanmalı.
        public string Role { get; set; }
        public string EmailAddress { get; set; }

    }
}

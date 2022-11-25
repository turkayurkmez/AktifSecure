using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace ClaimBasedAuthentication.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adını giriniz")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifenizi boş geçmeyiniz")]
        public string Password { get; set; }
    }
}

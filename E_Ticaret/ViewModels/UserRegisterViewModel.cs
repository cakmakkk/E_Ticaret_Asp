using System.ComponentModel.DataAnnotations;

namespace E_Ticaret.ViewModels
{
	public class UserRegisterViewModel
	{
		[Required(ErrorMessage = "Ad zorunludur")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Soyad zorunludur")]
		public string Surname { get; set; }

		[Required(ErrorMessage = "Email zorunludur")]
		[EmailAddress(ErrorMessage = "Geçerli bir email girin")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Şifre zorunludur")]
		[MinLength(3, ErrorMessage = "En az 3 karakter girin")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		public bool Role { get; set; } = false; // default: kullanıcı
	}

}

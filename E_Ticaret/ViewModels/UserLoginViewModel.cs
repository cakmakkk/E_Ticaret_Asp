using System.ComponentModel.DataAnnotations;

namespace E_Ticaret.ViewModels
{
	public class UserLoginViewModel
	{
		[Required(ErrorMessage = "Email zorunludur")]
		[EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Şifre zorunludur")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		public bool IsAdminLogin { get; set; }
	}
}

using System.ComponentModel.DataAnnotations;

namespace Assignment02.Models.Account
{
	public class ResetPasswordViewModel
	{
		[Required(ErrorMessage = "Password is required")]
		//[MinLength(5, ErrorMessage = "Minimum Password Length is 5")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "Confirm Password is required")]
		[Compare("Password", ErrorMessage = "Confirm Password does not match Password")]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }

		public string Email { get; set; }

		public string Token { get; set; }
	}
}

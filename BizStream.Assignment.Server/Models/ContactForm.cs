using System.ComponentModel.DataAnnotations;

namespace BizStream.Assignment.Server.Models {
	public class ContactForm {
		/// <summary>
		/// (Optional) First name of the contact
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// (Optional) Last name of the contact
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// Contact's email address
		/// </summary>
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		/// <summary>
		/// Message provided by the contact
		/// </summary>
		[Required]
		public string Message { get; set; }
	}
}
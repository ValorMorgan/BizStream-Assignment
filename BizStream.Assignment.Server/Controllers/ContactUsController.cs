using System;
using System.IO;
using System.Threading.Tasks;
using BizStream.Assignment.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BizStream.Assignment.Server.Controllers {
	[Route("api/[controller]")]
	public class ContactUsController : Controller {
		private const string FAILURE_MESSAGE = "Failed to save contact form!";

		[HttpPost]
		public async Task<ActionResult> Submit(
			[FromBody] ContactForm form) {

			Console.WriteLine($"[{DateTime.UtcNow}] Received request...");

			if (form == null || !ModelState.IsValid) {
				return BadRequest();
			}

			try {
				using var fileStream = System.IO.File.Create(
					$"{DateTime.UtcNow:yyyy_MM_dd_hh_mm_ss}_{form.LastName ?? "Unknown"}_{form.FirstName ?? "Unknown"}.txt");

				using var writer = new StreamWriter(fileStream);

				await writer.WriteAsync(
					GetFormString(form));
			} catch (Exception ex) {
				Console.Error.WriteLine($"{FAILURE_MESSAGE}\n{ex}");

				return Problem(
					title: "Internal Failure",
					detail: FAILURE_MESSAGE,
					statusCode: StatusCodes.Status500InternalServerError,
					instance: null,
					type: nameof(ContactForm));
			}

			return Ok();
		}

		private string GetFormString(
			ContactForm form) =>

$@"First Name: {form.FirstName}
Last Name: {form.LastName}
Email: {form.Email}
Message: {form.Message}";
	}
}
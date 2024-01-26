using Microsoft.AspNetCore.Identity;

namespace DatingApp_FullSD.Server.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string? FirstName { get; set; }

		public string? LastName { get; set;}
	}
}

using DatingApp_FullSD.Server.Models;
using DatingApp_FullSD.Shared.Domain;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DatingApp_FullSD.Server.Data
{
	public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
	{
		public ApplicationDbContext(
			DbContextOptions options,
			IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
		{
		}

		public new DbSet<User> Users { get; set; }

		public DbSet<Match> Matches { get; set; }

		public DbSet<Post> Posts { get; set; }
	}
}

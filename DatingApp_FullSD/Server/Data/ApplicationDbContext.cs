using System.Security.Cryptography;
using DatingApp_FullSD.Server.Configurations.Entities;
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

		public DbSet<Profile> Profiles { get; set; }

		public DbSet<Match> Matches { get; set; }

		public DbSet<Post> Posts { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.ApplyConfiguration(new MatchSeedConfiguration());

            builder.ApplyConfiguration(new PostSeedConfiguration());

            builder.ApplyConfiguration(new ProfileSeedConfiguration());

            builder.ApplyConfiguration(new RoleSeedConfiguration());

            builder.ApplyConfiguration(new UserRoleSeedConfiguration());

            builder.ApplyConfiguration(new UserSeedConfiguration());
        }
	}
}

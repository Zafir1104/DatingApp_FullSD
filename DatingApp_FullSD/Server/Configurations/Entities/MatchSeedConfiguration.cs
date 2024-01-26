using DatingApp_FullSD.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatingApp_FullSD.Server.Configurations.Entities
{
    public class MatchSeedConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.HasData(
                new Match
                {
                    MatchID = 1,
                    User1 = 1,
                    User2 = 2
                },
                new Match
                {
                    MatchID = 2,
                    User1 = 1,
                    User2 = 3
                }
                );
        }
    }
}

using System.Text;
using DatingApp_FullSD.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatingApp_FullSD.Server.Configurations.Entities
{
    public class ProfileSeedConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.HasData(
                new Profile
                {
                    Id = 1,
                    UserName = "LeeSirui",
                    Location = "Yishun",
                    Interest = "Hiking, Reading",
                    Picture = "/images/Profiles/ProfilePic1(300x300)",
                    Birthdate = "1990-01-15",
                    Gender = "Male",
                    Occupation = "Doctor"
                },
                new Profile
                {
                    Id = 2,
                    UserName = "Harith",
                    Location = "Bedok",
                    Interest = "Traveling, Photography",
                    Picture = "/images/Profiles/ProfilePic2(300x300)",
                    Birthdate = "1985-08-22",
                    Gender = "Female",
                    Occupation = "Marketing Specialist"
                },
                new Profile
                {
                    Id = 3,
                    UserName = "Gerald",
                    Location = "PasirRis",
                    Interest = "Sports, Music",
                    Picture = "/images/Profiles/ProfilePic3(300x300)",
                    Birthdate = "1992-04-05",
                    Gender = "Male",
                    Occupation = "Teacher"
                }
                );
        }
    }
}

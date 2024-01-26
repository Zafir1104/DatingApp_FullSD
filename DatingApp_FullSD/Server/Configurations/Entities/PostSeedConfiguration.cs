using System.Text;
using DatingApp_FullSD.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatingApp_FullSD.Server.Configurations.Entities
{
    public class PostSeedConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(
                new Post
                {
                    PostID = 1,
                    PostText = "Enjoying a beautiful day!",
                    PostLikes = 10,
                    UserName = "JohnDoe",
                    PostPicture = "/images/Posts/Post1(500x300)",
                    PostComments = "Great picture!"
                },
                new Post
                {
                    PostID = 2,
                    PostText = "Exploring new places!",
                    PostLikes = 15,
                    UserName = "JaneSmith",
                    PostPicture = "/images/Posts/Post2(500x300)",
                    PostComments = "Looks like an amazing adventure!"
                },
                new Post
                {
                    PostID = 3,
                    PostText = "Game day!",
                    PostLikes = 8,
                    UserName = "BobJohnson",
                    PostPicture = "/images/Posts/Post3(500x300)",
                    PostComments = "Go team go!"
                }
                );
        }
    }
}

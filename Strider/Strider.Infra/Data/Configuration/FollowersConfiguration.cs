using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Strider.Infra.Data.Model;
using System;

namespace Strider.Infra.Data.Configuration
{
    public class FollowersConfiguration : IEntityTypeConfiguration<Followers>
    {
        public void Configure(EntityTypeBuilder<Followers> builder)
        {
            builder.ToTable("followers").HasKey(x => x.Id);
            builder.HasOne(v => v.User).WithMany().HasForeignKey(v => v.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(v => v.Follower).WithMany().HasForeignKey(v => v.FollowerId).OnDelete(DeleteBehavior.Cascade); ;
        }
    }
}
